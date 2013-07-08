using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace Editor
{
    public class DivRegular : DivBase
    {
        double LineSpace { get { return FontSize * .2; } }
        double ExtraWidth { get { return FontSize * .2; } }

        public DivRegular(EquationContainer parent)
            : base(parent)
        {
        }

        public override void DrawEquation(DrawingContext dc)
        {
            base.DrawEquation(dc);
            double y = (Top + topEquation.Height + LineSpace * .7) - LineThickness/2;
            dc.DrawLine(StandardPen, new Point(Left + ExtraWidth * .5, y), new Point(Right - ExtraWidth * .5, y));
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                topEquation.MidX = this.MidX;
                bottomEquation.MidX = this.MidX;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                topEquation.Top = value;
                bottomEquation.Top = topEquation.Bottom + LineSpace;
            }
        }

        protected override void CalculateWidth()
        {
            Width = Math.Max(topEquation.Width, bottomEquation.Width) + ExtraWidth;
        }

        protected override void CalculateHeight()
        {
            Height = topEquation.Height + bottomEquation.Height + LineSpace;
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
                return topEquation.Height + LineSpace * .7;
            }
        }
    }
}
