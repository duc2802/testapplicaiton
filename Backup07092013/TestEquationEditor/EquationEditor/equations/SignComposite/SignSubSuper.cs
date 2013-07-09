using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Input;

namespace Editor
{
    class SignSubSuper : EquationContainer
    {
        RowContainer mainEquation;
        StaticSign sumSign;
        RowContainer superEquation;
        RowContainer subEquation;
        int bottomDif = 6;
        double maxUpperHalf = 0;
        int hGap = 2;

        public SignSubSuper(EquationContainer parent, SignCompositeSymbol symbol, bool useUpright)
            : base(parent)
        {
            ActiveChild = mainEquation = new RowContainer(this);
            subEquation = new RowContainer(this);
            superEquation = new RowContainer(this);
            sumSign = new StaticSign(this, symbol, useUpright);
            subEquation.FontFactor = SmallerFontFactor;
            superEquation.FontFactor = SmallerFontFactor;
            childEquations.AddRange(new EquationBase[] { mainEquation, sumSign, superEquation, subEquation });
        }
        
        protected override void CalculateWidth()
        {
            Width = sumSign.Width + Math.Max(subEquation.Width, superEquation.Width) + mainEquation.Width + hGap;
            sumSign.Left = Left;
            subEquation.Left = sumSign.Right;
            superEquation.Left = sumSign.Right;
            mainEquation.Left = subEquation.Right + hGap;
        }

        protected override void CalculateHeight()
        {
            maxUpperHalf = Math.Max(mainEquation.RefY, Math.Max(sumSign.RefY, subEquation.RefY - (sumSign.RefY - bottomDif)));
            double maxLowerHalf = Math.Max(mainEquation.RefY, sumSign.RefY + subEquation.RefY - bottomDif);
            Height = maxLowerHalf + maxUpperHalf;
            sumSign.MidY = MidY;
            mainEquation.MidY = MidY;
            subEquation.MidY = sumSign.Bottom - bottomDif;
            superEquation.Bottom = sumSign.Top + FontSize / 5;
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
                sumSign.MidY = MidY;
                mainEquation.MidY = MidY;
                subEquation.MidY = sumSign.Bottom - bottomDif;
                superEquation.Bottom = sumSign.Top + FontSize / 5;
            }
        }
        
        public override bool ConsumeMouseClick(System.Windows.Point mousePoint)
        {
            if (mainEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = mainEquation;
            }
            else if (superEquation.Bounds.Contains(mousePoint))
            {
                ActiveChild = superEquation;
            }
            else 
            {
                ActiveChild = subEquation;
            }
            return ActiveChild.ConsumeMouseClick(mousePoint);
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                sumSign.Left = value;
                subEquation.Left = sumSign.Right;
                superEquation.Left = sumSign.Right;
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
                if (ActiveChild == superEquation)
                {
                    ActiveChild = mainEquation;
                    return true;    
                }
                else if (ActiveChild == mainEquation)
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
                else if (ActiveChild == mainEquation)
                {
                    ActiveChild = superEquation;
                    return true;
                }
            }
            return false;
        }
    }
}