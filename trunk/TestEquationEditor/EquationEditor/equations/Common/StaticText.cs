using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Editor
{
    public class StaticText : EquationBase
    {
        protected string Text { get; set; }        
        protected FontType FontType { get; set; }
        protected double FontSizeFactor = 1;
        protected FontWeight FontWeight = FontWeights.Normal;
        protected double TopOffestFactor = 0;
        protected double LeftMarginFactor = 0;
        protected double RightMarginFactor = 0;

        FormattedText formattedText;

        public StaticText(EquationContainer parent)
            :base(parent)
        {
            IsStatic = true;
        }

        public override void DrawEquation(DrawingContext dc)
        {
            formattedText.DrawTextTopLeftAligned(dc, new Point(Left + LeftMarginFactor * FontSize, Top + TopOffestFactor * Height));
        }

        public override double FontSize
        {
            get
            {
                return base.FontSize;
            }
            set
            {
                base.FontSize = value;
                ReformatSign();            
            }
        }

        protected void ReformatSign()
        {
            formattedText = FontFactory.GetFormattedText(Text, FontType, FontSize * FontSizeFactor, FontWeight);
            Width = formattedText.Width + LeftMarginFactor * FontSize + RightMarginFactor * FontSize; // * WidthFactor;
            Height = formattedText.Baseline;// +formattedText.OverhangAfter;
        }
    }
}
