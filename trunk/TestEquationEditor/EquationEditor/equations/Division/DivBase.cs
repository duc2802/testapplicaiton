using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Editor
{
    public abstract class DivBase : EquationContainer
    {
        protected RowContainer topEquation;
        protected RowContainer bottomEquation;

        protected DivBase(EquationContainer parent)
            : base(parent)
        {
            ActiveChild = topEquation = new RowContainer(this);
            bottomEquation = new RowContainer(this);
            childEquations.AddRange(new EquationBase[] { topEquation, bottomEquation});
        }
       
        public override bool ConsumeMouseClick(Point mousePoint)
        {
            if (bottomEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = bottomEquation;
                ActiveChild.ConsumeMouseClick(mousePoint);
                return true;
            }
            else if (topEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = topEquation;
                ActiveChild.ConsumeMouseClick(mousePoint);
                return true;
            } 
            return false;
        }

        public override bool ConsumeKey(Key key)
        {
            if (ActiveChild.ConsumeKey(key))
            {
                CalculateSize();
                return true;
            }
            if (key == Key.Down)
            {
                if (ActiveChild == topEquation)
                {
                    Point point = ActiveChild.GetVerticalCaretLocation();
                    ActiveChild = bottomEquation;
                    point.Y = ActiveChild.Top + 1;
                    ActiveChild.SetCursorOnKeyUpDown(key, point);
                    return true;
                }
            }
            else if (key == Key.Up)
            {
                if (ActiveChild == bottomEquation)
                {
                    Point point = ActiveChild.GetVerticalCaretLocation();
                    ActiveChild = topEquation;
                    point.Y = ActiveChild.Bottom - 1;
                    ActiveChild.SetCursorOnKeyUpDown(key, point);
                    return true;
                }
            }
            return false;
        }
    }
}
