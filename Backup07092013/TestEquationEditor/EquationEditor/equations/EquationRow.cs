using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace Editor
{
    public class EquationRow : EquationContainer
    {
        protected EquationContainer deleteable = null;
        static Pen boxPen = new Pen(Brushes.Blue, 1.1) { StartLineCap = PenLineCap.Flat, EndLineCap = PenLineCap.Flat };

        static EquationRow()
        {
            boxPen.DashStyle = DashStyles.Dash;
            boxPen.Freeze();
        }

        public EquationRow(EquationContainer parent)
            : base(parent)
        {
            TextEquation textEq = new TextEquation(this);
            ActiveChild = textEq;
            AddChild(textEq);
            CalculateSize();
        }

        public sealed override void CalculateSize()
        {
            base.CalculateSize();
        }
        
        public override void DrawEquation(DrawingContext dc)
        {
            base.DrawEquation(dc);
            if (deleteable != null)
            {
                Brush brush = new SolidColorBrush(Colors.Gray);
                brush.Opacity = 0.5;
                dc.DrawRectangle(brush, null, new Rect(deleteable.Location, deleteable.Size));
            }
            if (childEquations.Count == 1)
            {
                TextEquation firstEquation = (TextEquation)childEquations.First();
                if (firstEquation.TextLength == 0)
                {
                    dc.DrawRectangle(null, boxPen, Bounds);//new Rect(new Point(Left - 1, Top), new Size(FontSize / 2.5, Height)));
                }
            }
        }

        public override void ExecuteCommand(CommandType commandType, object data)
        {
            deleteable = null;            
            if (ActiveChild.GetType() == typeof(TextEquation))
            {
                EquationBase newEquation = null;
                switch (commandType)
                {
                    case CommandType.DivRegular:
                        newEquation = new DivRegular(this);
                        break;
                    case CommandType.DivSlanted:
                        newEquation = new DivSlanted(this);
                        break;
                    case CommandType.DivHorizontal:
                        newEquation = new DivHorizontal(this);
                        break;
                    case CommandType.SquareRoot:
                        newEquation = new SquareRoot(this);
                        break;
                    case CommandType.nRoot:
                        newEquation = new nRoot(this);
                        break;
                    case CommandType.LeftBracket:
                        newEquation = new LeftBracket(this, (BracketSignType)data);
                        break;
                    case CommandType.RightBracket:
                        newEquation = new RightBracket(this, (BracketSignType)data);
                        break;
                    case CommandType.LeftRightBracket:
                        newEquation = new LeftRightBracket(this, ((BracketSignType[])data)[0], ((BracketSignType[])data)[1]);
                        break;
                    case CommandType.Sub:
                        newEquation = new Sub(this, (Position)data);
                        break;
                    case CommandType.Super:
                        newEquation = new Super(this, (Position)data);
                        break;                    
                    case CommandType.SubAndSuper:
                        newEquation = new SubAndSuper(this, (Position)data);
                        break;
                    case CommandType.SignComposite:
                        newEquation = SignCompositeFactory.CreateEquation(this, (Position)(((object[])data)[0]), (SignCompositeSymbol)(((object[])data)[1]));
                        break;
                }
                if (newEquation != null)
                {
                    EquationBase newText = ActiveChild.Split(this);
                    int caretIndex = ((TextEquation)ActiveChild).TextLength;
                    AddChild(newEquation);
                    AddChild(newText);
                    newEquation.CalculateSize();
                    CalculateSize();
                    ActiveChild = newEquation;
                }
            }
            else if (ActiveChild != null)
            {
                ((EquationContainer)ActiveChild).ExecuteCommand(commandType, data);
                CalculateSize();
            }
        }

        void AddChild(EquationBase newChild)
        {
            int index = 0;
            if (childEquations.Count > 0)
            {
                index = childEquations.IndexOf(ActiveChild) + 1;
            }
            childEquations.Insert(index, newChild);
            newChild.ParentEquation = this;
            ActiveChild = newChild;
        }

        void RemoveChild(EquationBase child)
        {
            childEquations.Remove(child);
            CalculateSize();
        }

        public override void SetCursorOnKeyUpDown(Key key, Point point)
        {
            foreach (EquationBase eb in childEquations)
            {
                if (eb.Right >= point.X)
                {
                    eb.SetCursorOnKeyUpDown(key, point);
                    ActiveChild = eb;
                    break;
                }
            }
        }

        public override bool ConsumeMouseClick(Point mousePoint)
        {
            deleteable = null;
            ActiveChild = null;
            foreach (EquationBase eb in childEquations)
            {
                if (eb.Right >= mousePoint.X && eb.Left <= mousePoint.X)
                {
                    ActiveChild = eb;
                    break;
                }
            }
            if (ActiveChild == null)
            {
                if (mousePoint.X <= MidX)
                    ActiveChild = childEquations.First();
                else
                    ActiveChild = childEquations.Last();
            }
            if (!ActiveChild.ConsumeMouseClick(mousePoint))
            {
                bool moveToStart = true;
                if (childEquations.Count == 1)
                {
                    if (ActiveChild.MidX < mousePoint.X)
                    {
                        moveToStart = false;
                    }
                }
                else if (mousePoint.X < ActiveChild.MidX)
                {
                    if (ActiveChild != childEquations.First())
                    {
                        ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) - 1];
                        moveToStart = false;
                    }
                }
                else if (ActiveChild != childEquations.Last())
                {
                    ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) + 1];
                }
                else
                {
                    moveToStart = false;
                }
                TextEquation equation = ActiveChild as TextEquation;
                if (equation != null)
                {
                    if (moveToStart)
                    {
                        equation.MoveCaretToStart();
                    }
                    else
                    {
                        equation.MoveCaretToEnd();
                    }
                }
            }
            return true;
        }

        public override bool ConsumeKey(Key key)
        {
            bool result = false;
            if (key == Key.Home)
            {
                ActiveChild = childEquations.First();
            }
            else if (key == Key.End)
            {
                ActiveChild = childEquations.Last();
            }
            if (ActiveChild.ConsumeKey(key))
            {
                deleteable = null;
                result = true;
            }
            else if (key == Key.Delete)
            {
                if (ActiveChild.GetType() == typeof(TextEquation) && ActiveChild != childEquations.Last())
                {
                    if (childEquations[childEquations.IndexOf(ActiveChild) + 1] == deleteable)
                    {
                        childEquations.Remove(deleteable);
                        deleteable = null;
                        ((TextEquation)ActiveChild).Merge((TextEquation)childEquations[childEquations.IndexOf(ActiveChild) + 1]);
                        childEquations.Remove(childEquations[childEquations.IndexOf(ActiveChild) + 1]);
                    }
                    else
                    {
                        deleteable = (EquationContainer)childEquations[childEquations.IndexOf(ActiveChild) + 1];
                    }
                    result = true;
                }
            }
            else if (key == Key.Back)
            {
                if (ActiveChild.GetType() == typeof(TextEquation))
                {
                    if (ActiveChild != childEquations.First())
                    {
                        if ((EquationContainer)childEquations[childEquations.IndexOf(ActiveChild) - 1] == deleteable)
                        {
                            TextEquation equationAfter = (TextEquation)ActiveChild;
                            ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) - 2];
                            childEquations.Remove(deleteable);
                            ((TextEquation)ActiveChild).Merge(equationAfter);
                            childEquations.Remove(equationAfter);
                            deleteable = null;
                        }
                        else
                        {
                            deleteable = (EquationContainer)childEquations[childEquations.IndexOf(ActiveChild) - 1];
                        }
                        result = true;
                    }
                }
                else
                {
                    if (deleteable == ActiveChild)
                    {
                        TextEquation equationAfter = (TextEquation)childEquations[childEquations.IndexOf(ActiveChild) + 1];
                        ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) - 1];
                        childEquations.Remove(deleteable);
                        ((TextEquation)ActiveChild).Merge(equationAfter);
                        childEquations.Remove(equationAfter);
                        deleteable = null;
                    }
                    else
                    {
                        deleteable = (EquationContainer)ActiveChild;
                    }
                    result = true;
                }
            }
            if (!result)
            {
                deleteable = null;
                if (key == Key.Right)
                {
                    if (ActiveChild != childEquations.Last())
                    {
                        ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) + 1];
                        result = true;
                    }
                }
                else if (key == Key.Left)
                {
                    if (ActiveChild != childEquations.First())
                    {
                        ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) - 1];
                        result = true;
                    }
                }
            }
            CalculateSize();
            return result;
        }

        public void Merge(EquationRow secondLine)
        {
            ((TextEquation)childEquations.Last()).Merge((TextEquation)secondLine.childEquations.First()); //first and last are always of tyep TextEquation
            for (int i = 1; i < secondLine.childEquations.Count; i++)
            {
                AddChild(secondLine.childEquations[i]);
            }
            CalculateSize();
        }

        void SplitRow(EquationRow newRow)
        {
            int index = childEquations.IndexOf(ActiveChild) + 1;
            EquationBase newChild = ActiveChild.Split(newRow);

            if (newChild != null)
            {
                newRow.RemoveChild(newRow.ActiveChild);
                newRow.AddChild(newChild);
                int i = index;
                for (; i < childEquations.Count; i++)
                {
                    newRow.AddChild(childEquations[i]);
                }
                for (i = childEquations.Count - 1; i >= index; i--)
                {
                    RemoveChild(childEquations[i]);
                }
            }
        }

        public override EquationBase Split(EquationContainer newParent)
        {
            deleteable = null;
            EquationRow newRow = null;
            if (ActiveChild.GetType() == typeof(TextEquation))
            {
                newRow = new EquationRow(newParent);
                SplitRow(newRow);
                newRow.CalculateSize();
            }
            else
            {
                ActiveChild.Split(this);
            }
            CalculateSize();
            return newRow;
        }

        public void Truncate()
        {
            if (ActiveChild.GetType() == typeof(TextEquation))
            {
                deleteable = null;
                ((TextEquation)ActiveChild).Truncate();
                int index = childEquations.IndexOf(ActiveChild) + 1;
                int i = index;
                for (i = childEquations.Count - 1; i >= index; i--)
                {
                    RemoveChild(childEquations[i]);
                }
            }
            CalculateSize();
        }

        protected override void CalculateWidth()
        {
            double left = 0;
            foreach (EquationBase eb in childEquations)
            {
                eb.Left = Left + left;
                left += eb.Width;
            }
            Width = left;
        }

        protected override void CalculateHeight()
        {
            double maxUpperHalf = 0;
            double maxBottomHalf = 0;
            foreach (EquationBase eb in childEquations)
            {
                if (eb.GetType() == typeof(Super) || eb.GetType() == typeof(Sub) || eb.GetType() == typeof(SubAndSuper))
                {
                    SubSuperBase subSuperBase = (SubSuperBase)eb;
                    if (subSuperBase.Position == Position.Right)
                    {
                        subSuperBase.SetBuddy(PreviousNonEmptyChild(subSuperBase));
                    }
                    else
                    {
                        subSuperBase.SetBuddy(NextNonEmptyChild(subSuperBase));
                    }
                }
                double childRefY = eb.RefY;
                double childHeight = eb.Height;
                if (childRefY > maxUpperHalf) 
                { 
                    maxUpperHalf = childRefY; 
                }
                if (childHeight - childRefY > maxBottomHalf) 
                { 
                    maxBottomHalf = childHeight - childRefY; 
                }
            }
            Height = maxUpperHalf + maxBottomHalf;
            AdjustChildrenVertical(maxUpperHalf);
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                double left = 0;
                foreach (EquationBase eb in childEquations)
                {
                    eb.Left = Left + left;
                    left += eb.Width;
                }
            }
        }

        public override double Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                double maxUpperHalf = value / 2;
                foreach (EquationBase eb in childEquations)
                {
                    if (eb.RefY > maxUpperHalf)
                    {
                        maxUpperHalf = eb.RefY;
                    }
                }
            }
        }

        public override double RefY
        {
            get
            {
                return childEquations.First().MidY - Top;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                double maxUpperHalf = 0;
                foreach (EquationBase eb in childEquations)
                {
                    if (eb.RefY > maxUpperHalf) { maxUpperHalf = eb.RefY; }
                }
                AdjustChildrenVertical(maxUpperHalf);
            }
        }

        void AdjustChildrenVertical(double maxUpperHalf)
        {
            foreach (EquationBase eb in childEquations)
            {
                eb.Top = (Top + maxUpperHalf) - eb.RefY;
            }
        }

        public override double Width
        {
            get { return base.Width; }
            set
            {
                if (value > 0)
                {
                    base.Width = value;
                }
                else
                {
                    base.Width = FontSize / 2.5;
                }                
            }
        }        

        public bool IsEmpty
        {
            get
            {
                if (childEquations.Count == 1)
                {
                    if (string.IsNullOrEmpty(((TextEquation)ActiveChild).Text))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        
        public void MoveToStart()
        {
            ActiveChild = childEquations.First();
            ((TextEquation)ActiveChild).MoveCaretToStart();
        }

        public void MoveToEnd()
        {
            ActiveChild = childEquations.Last();
            ((TextEquation)ActiveChild).MoveCaretToEnd();
        }

        public override double GetVerticalCaretLength()
        {
            if (ActiveChild.GetType() == typeof(TextEquation))
            {
                return Height;
            }
            else
            {
                return ActiveChild.GetVerticalCaretLength();
            }
        }

        public override Point GetVerticalCaretLocation()
        {
            if (ActiveChild.GetType() == typeof(TextEquation))
            {
                return new Point(ActiveChild.GetVerticalCaretLocation().X, Top);
            }
            else
            {
                return ActiveChild.GetVerticalCaretLocation();
            }
        }

        public EquationBase PreviousNonEmptyChild(EquationContainer equation)
        {
            int index = childEquations.IndexOf(equation) - 1;
            if (index >= 0)
            {
                if (index >= 1 && ((TextEquation)childEquations[index]).TextLength == 0)
                {
                    index--;
                }
                return childEquations[index];
            }
            else
            {
                return null;
            }
        }

        public EquationBase NextNonEmptyChild(EquationContainer equation)
        {
            int index = childEquations.IndexOf(equation) + 1;
            if (index < childEquations.Count)
            {
                if (index < childEquations.Count -1 && ((TextEquation)childEquations[index]).TextLength == 0)
                {
                    index++;
                }
                return childEquations[index];
            }
            else
            {
                return null;
            }
        }
    }
}
