using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace Editor
{
    class SignSimple : EquationContainer
    {
        protected RowContainer mainEquation;
        protected StaticSign sign;
        protected int hGap = 2;

        public SignSimple(EquationContainer parent, SignCompositeSymbol symbol, bool useUpright)
            : base(parent)
        {
            ActiveChild = mainEquation = new RowContainer(this);
            sign = new StaticSign(this, symbol, useUpright);
            childEquations.AddRange(new EquationBase[] {mainEquation, sign});            
        }
               
        protected override void CalculateWidth()
        {
            Width = sign.Width + mainEquation.Width + hGap;
            sign.Left = Left;
            mainEquation.Left = sign.Right + hGap;
        }

        protected override void CalculateHeight()
        {
            Height = Math.Max(sign.Height, mainEquation.Height);
            sign.MidY = MidY;
            mainEquation.MidY = MidY;
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                sign.MidY = MidY;
                mainEquation.MidY = MidY;
            }
        }
        
        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                sign.Left = value;
                mainEquation.Left = sign.Right + hGap;
            }
        }
    }
}