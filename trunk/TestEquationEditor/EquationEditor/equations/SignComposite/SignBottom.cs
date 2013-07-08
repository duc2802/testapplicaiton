using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Input;

namespace Editor
{
    class SignBottom : EquationContainer
    {
        RowContainer mainEquation;
        RowContainer bottomEquation;
        StaticSign sign;
        int hGap = 1;
        int vGap = 0;

        public SignBottom(EquationContainer parent, SignCompositeSymbol symbol, bool useUpright)
            : base(parent)
        {
            ActiveChild = mainEquation = new RowContainer(this);
            bottomEquation = new RowContainer(this);
            sign = new StaticSign(this, symbol, useUpright);
            bottomEquation.FontFactor = SmallerFontFactor;
            childEquations.AddRange(new EquationBase[] { mainEquation, bottomEquation, sign });
        }

        protected override void CalculateWidth()
        {
            double maxLeft = Math.Max(sign.Width, bottomEquation.Width);
            Width = maxLeft + mainEquation.Width + hGap;
            sign.MidX = Left + maxLeft / 2;
            bottomEquation.MidX = sign.MidX;
            mainEquation.Left = Math.Max(bottomEquation.Right, sign.Right) + hGap;
        }

        protected override void CalculateHeight()
        {
            double upperHalf = Math.Max(mainEquation.RefY, sign.RefY);
            double lowerHalf = Math.Max(sign.RefY - vGap + bottomEquation.Height, mainEquation.RefY);
            Height = upperHalf + lowerHalf;
            AdjustVertical();
        }

        void AdjustVertical()
        {
            if (mainEquation.RefY > sign.RefY - vGap + bottomEquation.Height)
            {
                sign.MidY = MidY;
                mainEquation.MidY = MidY;
                bottomEquation.Top = sign.Bottom + vGap;
            }
            else
            {
                bottomEquation.Bottom = Bottom;
                sign.Bottom = bottomEquation.Top + vGap;
                mainEquation.MidY = sign.MidY;
            }
        }

        public override double Top
        {
            get
            {
                return base.Top;
            }
            set
            {
                base.Top = value;
                AdjustVertical();
            }
        }


        public override bool ConsumeMouseClick(System.Windows.Point mousePoint)
        {
            if (bottomEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = bottomEquation;
            }
            else
            {
                ActiveChild = mainEquation;
            }
            return ActiveChild.ConsumeMouseClick(mousePoint);
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                double maxLeft = Math.Max(sign.Width, bottomEquation.Width);
                sign.MidX = value + maxLeft / 2;
                bottomEquation.MidX = sign.MidX;
                mainEquation.Left = Math.Max(bottomEquation.Right, sign.Right) + hGap;
            }
        }

        public override double Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;                
            }
        }

        public override double RefY
        {
            get
            {
                return Math.Max(sign.RefY, mainEquation.RefY);
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
                if (ActiveChild == mainEquation)
                {
                    ActiveChild = bottomEquation;
                    return true;
                }
            }
            else if (key == Key.Up)
            {
                if (ActiveChild == bottomEquation)
                {
                    ActiveChild = mainEquation;
                    return true;
                }
            }
            return false;
        }
    }
}