using System;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace Editor
{
    public class SubAndSuper : SubSuperBase
    {
        //The inherited RowContainer becomes our subEquation
        RowContainer superEquation;
        RowContainer subEquation;

        public SubAndSuper(EquationRow parent, Position position)
            : base(parent, position)
        {
            ActiveChild = superEquation = new RowContainer(this);
            subEquation = rowContainer;
            childEquations.Add(superEquation);
            superEquation.FontFactor = SmallerFontFactor;            
        }
       
        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                superEquation.Left = this.Left;
            }
        }

        protected override void CalculateWidth()
        {
            Width = Math.Max(superEquation.Width, subEquation.Width);
        }

        protected override void CalculateHeight()
        {
            Height = Buddy.Height + superEquation.Height + subEquation.Height - FontSize * .8;
            superEquation.Top = this.Top;
            subEquation.Bottom = this.Bottom;
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                superEquation.Top = value;
                subEquation.Top = superEquation.Bottom;
            }
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
                if (ActiveChild == superEquation)
                {
                    ActiveChild = subEquation;
                    return true;
                }
            }
            else if (key == Key.Up)
            {
                if (ActiveChild == subEquation)
                {
                    ActiveChild = superEquation;
                    return true;
                }
            }
            return false;
        }
    }
}
