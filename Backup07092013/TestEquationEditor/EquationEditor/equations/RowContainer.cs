using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using System.IO;
using System.Windows.Media.Imaging;

namespace Editor
{
    public class RowContainer : EquationContainer
    {
        double lineSpaceFactor;
        double LineSpace
        {
            get { return lineSpaceFactor * FontSize; }
        }
       
        public override void ConsumeText(string text)
        {
            if (((EquationRow)ActiveChild).ActiveChild.GetType() == typeof(TextEquation))
            {
                List<string> lines = new List<string>();
                using (StringReader reader = new StringReader(text))
                {
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        lines.Add(s);
                    }
                }
                if (lines.Count == 1)
                {
                    ActiveChild.ConsumeText(lines[0]);
                }
                else if (lines.Count > 1)
                {
                    List<EquationRow> newEquations = new List<EquationRow>();
                    TextEquation activeText = (TextEquation)((EquationRow)ActiveChild).ActiveChild;                    
                    ActiveChild.ConsumeText(lines[0]);
                    EquationRow splitRow = (EquationRow)ActiveChild.Split(this);
                    if (!splitRow.IsEmpty)
                    {
                        childEquations.Add(splitRow);
                    }
                    int activeIndex = childEquations.IndexOf(ActiveChild);
                    int i = 1;
                    for (; i < lines.Count; i++)
                    {
                        EquationRow row = new EquationRow(this);
                        row.CalculateSize();
                        childEquations.Insert(activeIndex + i, row);
                        newEquations.Add(row);
                    }
                    newEquations.Add(splitRow);
                    ActiveChild = childEquations[activeIndex + lines.Count - 1];
                    ((TextEquation)((EquationRow)ActiveChild).ActiveChild).MoveCaretToEnd();
                }
                CalculateSize();
            }
            else
            {
                base.ConsumeText(text);
            }
        }

        public void DrawVisibleRows(DrawingContext dc, double top, double bottom)
        {           
            foreach (EquationBase eb in childEquations)
            {
                if (eb.Bottom >= top)
                {
                    eb.DrawEquation(dc);                    
                }
                if (eb.Bottom >= bottom)
                {
                    break;
                }
            }
        }       

        public RowContainer(EquationContainer parent, double lineSpaceFactor=0)
            : base(parent)
        {
            EquationRow newLine = new EquationRow(this);
            AddLine(newLine);
            Height = newLine.Height;
            Width = newLine.Width;
            this.lineSpaceFactor = lineSpaceFactor;
        }

        void AddLine(EquationRow newRow)
        {
            int index = 0;
            if (childEquations.Count > 0)
            {
                index = childEquations.IndexOf((EquationRow)ActiveChild) + 1;
            }
            childEquations.Insert(index, newRow);
            ActiveChild = newRow;
            CalculateSize();
        }

        public override EquationBase Split(EquationContainer newParent)
        {
            EquationRow newRow = (EquationRow)ActiveChild.Split(this);
            if (newRow != null)
            {
                EquationRow activeRow = ActiveChild as EquationRow;
                AddLine(newRow);
            }
            CalculateSize();
            return newRow;
        }

        public override bool ConsumeMouseClick(Point mousePoint)
        {
            foreach (EquationBase eb in childEquations)
            {
                Rect rect = new Rect(0, eb.Top, double.MaxValue, eb.Height);
                if (rect.Contains(mousePoint))
                {
                    ActiveChild = eb;
                    return eb.ConsumeMouseClick(mousePoint);
                }
            }
            return false;
        }        

        public override Point GetHorizontalCaretLocation()
        {
            if (ParentEquation is EquationRoot)
            {
                return ActiveChild.Location;
            }
            else
            {
                return ParentEquation.Location;
            }
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                foreach (EquationBase eb in childEquations)
                {
                    eb.Left = value;
                }
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                double nextY = value;
                foreach (EquationBase eb in childEquations)
                {
                    eb.Top = nextY;
                    nextY += eb.Height + LineSpace;
                }
            }
        }
                
        public override bool ConsumeKey(Key key)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                if (key == Key.Home)
                {
                    ActiveChild = childEquations.First();
                    ((EquationRow)ActiveChild).MoveToStart();
                }
                else if (key == Key.End)
                {
                    ActiveChild = childEquations.Last();
                    ((EquationRow)ActiveChild).MoveToEnd();
                }
                return true;
            }
            bool result = false;
            if (ActiveChild.ConsumeKey(key))
            {
                result = true;
            }
            else if (key == Key.Enter)
            {
                Split(this);
                ((EquationRow)ActiveChild).MoveToStart();
                result = true;
            }
            else if (key == Key.Delete)
            {
                if (ActiveChild != childEquations.Last())
                {
                    EquationRow activeRow = ActiveChild as EquationRow;
                    EquationRow rowToRemove = (EquationRow)childEquations[childEquations.IndexOf(activeRow) + 1];
                    activeRow.Merge(rowToRemove);
                    childEquations.RemoveAt(childEquations.IndexOf(activeRow) + 1);
                }
                result = true;
            }
            else if (!result)
            {
                if (key == Key.Up && ActiveChild != childEquations.First())
                {
                    Point point = ActiveChild.GetVerticalCaretLocation();
                    ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) - 1];
                    point.Y = ActiveChild.Bottom-1;
                    ActiveChild.SetCursorOnKeyUpDown(key, point);                    
                    result = true;
                }
                else if (key == Key.Down && ActiveChild != childEquations.Last())
                {
                    Point point = ActiveChild.GetVerticalCaretLocation();
                    ActiveChild = childEquations[childEquations.IndexOf(ActiveChild) + 1];
                    point.Y = ActiveChild.Top + 1;
                    ActiveChild.SetCursorOnKeyUpDown(key, point);
                    result = true;
                }
                else if (key == Key.Left)
                {
                    if (ActiveChild != childEquations.First())
                    {
                        ActiveChild = childEquations[childEquations.IndexOf((EquationRow)ActiveChild) - 1];
                        result = true;
                    }
                }
                else if (key == Key.Right)
                {
                    if (ActiveChild != childEquations.Last())
                    {
                        ActiveChild = childEquations[childEquations.IndexOf((EquationRow)ActiveChild) + 1];
                        result = true;
                    }
                }
                else if (key == Key.Back)
                {
                    if (ActiveChild != childEquations.First())
                    {
                        EquationRow activeRow = ActiveChild as EquationRow;
                        EquationRow previousRow = (EquationRow)childEquations[childEquations.IndexOf(activeRow) - 1];
                        previousRow.Merge(activeRow);
                        childEquations.Remove(activeRow);
                        ActiveChild = previousRow;
                        result = true;
                    }
                }
            }
            CalculateSize();
            return result;
        }

        protected override void CalculateWidth()
        {
            double maxLeftHalf = 0;
            double maxRightHalf = 0;
            foreach (EquationBase eb in childEquations)
            {
                if (eb.RefX > maxLeftHalf)
                {
                    maxLeftHalf = eb.RefX;
                }
                if (eb.Width - eb.RefX > maxRightHalf)
                {
                    maxRightHalf = eb.Width - eb.RefX;
                }
                eb.Left = Left;
            }
            Width = maxLeftHalf + maxRightHalf;
        }

        protected override void CalculateHeight()
        {
            double height = 0;
            foreach (EquationBase eb in childEquations)
            {
                height += eb.Height + LineSpace;
            }
            Height = height;
            double nextY = Top;
            foreach (EquationBase eb in childEquations)
            {
                eb.Top = nextY;
                nextY += eb.Height + LineSpace;
            }
        }

        public override double RefY
        {
            get
            {
                int count = childEquations.Count;
                if (count == 1)
                {
                    return childEquations.First().RefY;
                }
                else if (count % 2 == 0)
                {
                    return childEquations[(count+1)/2].Top - Top - LineSpace/2 + FontSize * .3;
                }
                else
                {
                    return childEquations[count / 2].MidY - Top;
                }
            }
        }       
    }
}
