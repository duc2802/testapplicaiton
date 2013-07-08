using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Input;

namespace Editor
{
    public class nRoot : SquareRoot
    {        
        RowContainer nthRootEquation = null;
        double hGap { get { return FontSize * .5; } }

        public nRoot(EquationContainer parent)
            : base(parent)
        {
            nthRootEquation = new RowContainer(this);
            nthRootEquation.FontFactor = SmallerFontFactor;            
            childEquations.Add(nthRootEquation);
        }

        public override bool ConsumeMouseClick(System.Windows.Point mousePoint)
        {
            if (nthRootEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = nthRootEquation;                
            }
            else if (insideEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = insideEquation;                
            }
            return ActiveChild.ConsumeMouseClick(mousePoint);
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                AdjustVertical();
            }
        }

        private void AdjustVertical()
        {
            insideEquation.Bottom = Bottom - ExtraHeight/2;
            radicalSign.Bottom = Bottom;
            nthRootEquation.Bottom = radicalSign.MidY - ExtraHeight;            
        }

        protected override void CalculateWidth()
        {
            Width = Math.Max(nthRootEquation.Width + hGap, radicalSign.Width) + insideEquation.Width;
            if (nthRootEquation.Width + hGap > radicalSign.Width)
            {
                nthRootEquation.Left = Left;
                radicalSign.Right = nthRootEquation.Right + hGap;
            }
            else
            {
                radicalSign.Left = Left;
                nthRootEquation.Right = radicalSign.Right - hGap;
            }
            insideEquation.Left = radicalSign.Right;
        }

        protected override void CalculateHeight()
        {
            double upperHalf = Math.Max(insideEquation.RefY, nthRootEquation.Height);
            double lowerHalf = insideEquation.RefY;
            Height = upperHalf + lowerHalf + ExtraHeight;            
        }

        public override double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;                
                radicalSign.Height = insideEquation.Height + ExtraHeight;
                AdjustVertical();
            }
        }

        public override double RefY
        {
            get
            {
                return Height - insideEquation.RefY;
            }
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;                
                insideEquation.Left = radicalSign.Right;
                if (nthRootEquation.Width + hGap > radicalSign.Width)
                {
                    nthRootEquation.Left = Left;
                    radicalSign.Right = nthRootEquation.Right + hGap;
                }
                else
                {
                    radicalSign.Left = Left;
                    nthRootEquation.Right = radicalSign.Right - hGap;
                }
                insideEquation.Left = radicalSign.Right;
            }
        }
        public override bool ConsumeKey(Key key)
        {
            if (ActiveChild.ConsumeKey(key))
            {
                CalculateSize();
                return true;
            }
            if (key == Key.Left)
            {
                if (ActiveChild == insideEquation)
                {
                    ActiveChild = nthRootEquation;
                    return true;
                }
            }
            else if (key == Key.Right)
            {
                if (ActiveChild == nthRootEquation)
                {
                    ActiveChild = insideEquation;
                    return true;
                }
            }
            return false;
        }
    }
}
