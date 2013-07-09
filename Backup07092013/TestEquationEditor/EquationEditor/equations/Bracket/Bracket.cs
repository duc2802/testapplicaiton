using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace Editor
{
    public abstract class Bracket : EquationContainer
    {
        protected RowContainer insideEq = null;
        protected BracketSign bracketSign;
        protected double ExtraHeight { get; set; }

        public Bracket(EquationContainer parent)
            : base(parent)
        {
            ExtraHeight = FontSize * 0.2;
            ActiveChild = insideEq = new RowContainer(this);
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                insideEq.MidY = MidY;
                bracketSign.Top = Top + ExtraHeight / 4;
            }
        }

        public override void CalculateSize()
        {
            CalculateHeight();
            CalculateWidth();
        }

        protected override void CalculateWidth()
        {
            Width = insideEq.Width + bracketSign.Width;
        }

        protected override void CalculateHeight()
        {
            ExtraHeight = FontSize * 0.2;
            Height = insideEq.Height + ExtraHeight;
            bracketSign.Height = Height - ExtraHeight / 2;
        }

        public override double RefY
        {
            get
            {
                return insideEq.RefY + ExtraHeight/2;
            }
        }
    }
}
