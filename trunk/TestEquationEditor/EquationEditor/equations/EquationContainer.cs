using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace Editor
{
    public abstract class EquationContainer : EquationBase
    {
        protected List<EquationBase> childEquations = new List<EquationBase>();
        EquationBase active;
        public EquationBase ActiveChild 
        {
            get { return active; }
            set { active = value; }
        }

        public EquationContainer(EquationContainer parent) : base(parent) { }

        public virtual void ExecuteCommand(CommandType commandType, object data)
        {
            if (ActiveChild is EquationContainer)
            {
                ((EquationContainer)ActiveChild).ExecuteCommand(commandType, data);
            }
            CalculateSize();
        }        

        public override void DrawEquation(DrawingContext dc)
        {
            base.DrawEquation(dc);
            foreach (EquationBase eb in childEquations)
            {
                eb.DrawEquation(dc);
            }
        }
       
        public override void ConsumeText(string text)
        {
            ActiveChild.ConsumeText(text);
            CalculateSize();
        }

        public override bool ConsumeKey(Key key)
        {
            bool temp = ActiveChild.ConsumeKey(key);
            CalculateSize();
            return temp;
        }

        public override Point GetVerticalCaretLocation()
        {
            return ActiveChild.GetVerticalCaretLocation();
        }

        public override double GetVerticalCaretLength()
        {
            return ActiveChild.GetVerticalCaretLength();
        }

        public virtual EquationContainer GetInnerMostEquationContainer()
        {
            if (ActiveChild is EquationContainer)
            {
                return ((EquationContainer)ActiveChild).GetInnerMostEquationContainer();
            }
            else
            {
                return this;
            }
        }

        public virtual Point GetHorizontalCaretLocation()
        {
            if (ActiveChild is EquationContainer)
            {
                return ((EquationContainer)ActiveChild).GetHorizontalCaretLocation();
            }
            else
            {
                return new Point(this.Left, this.Bottom);
            }
        }

        public double GetHorizontalCaretLength()
        {
            if (ActiveChild is EquationContainer)
            {
                return ((EquationContainer)ActiveChild).GetHorizontalCaretLength();
            }
            else
            {
                return Width;
            }
        }

        public override EquationBase Split(EquationContainer newParent)
        {
            EquationBase result = ActiveChild.Split(this);
            CalculateSize();
            return result;
        }

        public override bool ConsumeMouseClick(Point mousePoint)
        {
            foreach (EquationBase eb in childEquations)
            {
                if (!eb.IsStatic && eb.Bounds.Contains(mousePoint))
                {
                    ActiveChild = eb;
                    return ActiveChild.ConsumeMouseClick(mousePoint);
                }
            }
            return false;
        }

        public override void SetCursorOnKeyUpDown(Key key, Point point)
        {
            if (key == Key.Up)
            {
                for (int i = childEquations.Count - 1; i >= 0; i--)
                {
                    Type type = childEquations[i].GetType();
                    if (type == typeof(RowContainer) || type == typeof(EquationRow))
                    {
                        childEquations[i].SetCursorOnKeyUpDown(key, point);
                        ActiveChild = childEquations[i];
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childEquations.Count; i++)
                {
                    Type type = childEquations[i].GetType();
                    if (type == typeof(RowContainer) || type == typeof(EquationRow))
                    {
                        childEquations[i].SetCursorOnKeyUpDown(key, point);
                        ActiveChild = childEquations[i];
                        break;
                    }
                }
            }
        }  

        public override double FontSize
        {
            get { return base.FontSize; }
            set
            {
                base.FontSize = value;
                foreach (EquationBase eb in childEquations)
                {
                    eb.FontSize = FontSize;
                }
                CalculateSize();
            }
        }
    }
}
