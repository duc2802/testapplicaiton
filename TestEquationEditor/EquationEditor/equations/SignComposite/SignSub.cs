using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Input;

namespace Editor
{
    class SignSub : EquationContainer
    {
        RowContainer mainEquation;
        StaticSign sign;
        RowContainer subEquation;
        int bottomDif = 6;
        double maxUpperHalf = 0;
        int hGap = 2;

        public SignSub(EquationContainer parent, SignCompositeSymbol symbol, bool useUpright)
            : base(parent)
        {
            ActiveChild = mainEquation = new RowContainer(this);
            subEquation = new RowContainer(this);
            sign = new StaticSign(this, symbol, useUpright);
            subEquation.FontFactor = SmallerFontFactor;
            childEquations.AddRange(new EquationBase[] { mainEquation, sign, subEquation });
        }
        
        protected override void CalculateWidth()
        {
            Width = sign.Width + subEquation.Width + mainEquation.Width + hGap;
            sign.Left = Left;
            subEquation.Left = sign.Right;
            mainEquation.Left = subEquation.Right + hGap;
        }
        protected override void CalculateHeight()
        {
            maxUpperHalf = Math.Max(mainEquation.RefY, Math.Max(sign.RefY, subEquation.RefY - (sign.RefY - bottomDif)));
            double maxLowerHalf = Math.Max(mainEquation.RefY, sign.RefY + subEquation.RefY - bottomDif);
            Height = maxLowerHalf + maxUpperHalf;
            sign.MidY = MidY;
            mainEquation.MidY = MidY;
            subEquation.MidY = sign.Bottom - bottomDif;
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
                return maxUpperHalf;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                sign.MidY = MidY;
                mainEquation.MidY = MidY;
                subEquation.MidY = sign.Bottom - bottomDif;
            }
        }
        
        public override bool ConsumeMouseClick(System.Windows.Point mousePoint)
        {
            if (subEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = subEquation;
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
                sign.Left = value;
                subEquation.Left = sign.Right;
                mainEquation.Left = subEquation.Right + hGap;
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
                    ActiveChild = subEquation;
                    return true;
                }
            }
            else if (key == Key.Up)
            {
                if (ActiveChild == subEquation)
                {
                    ActiveChild = mainEquation;
                    return true;
                }
            }
            return false;
        }
    }
}