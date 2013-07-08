using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Input;

namespace Editor
{
    class SignBottomTop : EquationContainer
    {
        RowContainer mainEquation;
        RowContainer topEquation;
        RowContainer bottomEquation;
        StaticSign sign;
        int hGap = 1;

        public SignBottomTop(EquationContainer parent, SignCompositeSymbol symbol, bool useUpright)
            : base(parent)
        {
            ActiveChild = mainEquation = new RowContainer(this);
            bottomEquation = new RowContainer(this);
            topEquation = new RowContainer(this);
            sign = new StaticSign(this, symbol, useUpright);
            topEquation.FontFactor = SmallerFontFactor;
            bottomEquation.FontFactor = SmallerFontFactor;
            childEquations.AddRange(new EquationBase[] { mainEquation, topEquation, bottomEquation, sign });
        }
                
        protected override void CalculateWidth()
        {
            double maxLeft = Math.Max(sign.Width, Math.Max(bottomEquation.Width, topEquation.Width));
            Width = maxLeft + mainEquation.Width + hGap;
            sign.MidX = Left + maxLeft / 2;
            topEquation.MidX = sign.MidX;
            bottomEquation.MidX = sign.MidX;
            mainEquation.Left = Math.Max(Math.Max(topEquation.Right, bottomEquation.Right), sign.Right) + hGap;
        }

        protected override void CalculateHeight()
        {
            double upperHalf = Math.Max(mainEquation.RefY, sign.RefY) + topEquation.Height;
            double lowerHalf = Math.Max(sign.RefY, mainEquation.RefY) + bottomEquation.Height;
            Height = upperHalf + lowerHalf;
            if (mainEquation.RefY > sign.RefY + topEquation.Height)
            {
                mainEquation.MidY = MidY;
                sign.MidY = MidY;
                topEquation.Bottom = sign.Top;
                bottomEquation.Top = sign.Bottom;
            }
            else
            {
                topEquation.Top = Top;
                sign.Top = topEquation.Bottom;
                bottomEquation.Top = sign.Bottom;
                mainEquation.MidY = sign.MidY;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                double upperHalf = Math.Max(mainEquation.RefY, sign.RefY + topEquation.Height);
                double lowerHalf = Math.Max(sign.RefY + bottomEquation.Height, mainEquation.RefY);
                Height = upperHalf + lowerHalf;
                if (mainEquation.RefY > sign.RefY + topEquation.Height)
                {
                    mainEquation.MidY = MidY;
                    sign.MidY = MidY;
                    topEquation.Bottom = sign.Top;
                    bottomEquation.Top = sign.Bottom;
                }
                else
                {
                    topEquation.Top = Top;
                    sign.Top = topEquation.Bottom;
                    bottomEquation.Top = sign.Bottom;
                    mainEquation.MidY = sign.MidY;
                }
            }
        }


        public override bool ConsumeMouseClick(System.Windows.Point mousePoint)
        {
            if (topEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = topEquation;
            }
            else if (bottomEquation.Bounds.Contains(mousePoint))
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
                double maxLeft = Math.Max(sign.Width, Math.Max(bottomEquation.Width, topEquation.Width));
                sign.MidX = value + maxLeft / 2;
                topEquation.MidX = sign.MidX;
                bottomEquation.MidX = sign.MidX;
                mainEquation.Left = Math.Max(Math.Max(topEquation.Right, bottomEquation.Right), sign.Right) + hGap;
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
                return Math.Max(sign.RefY + topEquation.Height, mainEquation.RefY);
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
                if (ActiveChild == topEquation)
                {
                    ActiveChild = mainEquation;
                    return true;
                }
                else if (ActiveChild == mainEquation)
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
                else if (ActiveChild == mainEquation)
                {
                    ActiveChild = topEquation;
                    return true;
                }
            }
            return false;
        }
    }
}