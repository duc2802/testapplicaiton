using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;

namespace Editor
{
    public class LeftRightBracket : Bracket
    {
        BracketSign bracketSign2;

        public LeftRightBracket(EquationContainer parent, BracketSignType leftBracketType, BracketSignType rightBracketType)
            : base(parent)
        {
            bracketSign = new BracketSign(this, leftBracketType);
            bracketSign2 = new BracketSign(this, rightBracketType);
            childEquations.AddRange(new EquationBase[] { insideEq, bracketSign, bracketSign2 });
        }     
        
        protected override void CalculateWidth()
        {
            Width = insideEq.Width + bracketSign.Width + bracketSign2.Width;
        }

        protected override void CalculateHeight()
        {
            base.CalculateHeight();
            bracketSign2.Height = bracketSign.Height;
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                bracketSign.Left = value;
                insideEq.Left = bracketSign.Right;
                bracketSign2.Left = insideEq.Right;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                bracketSign2.Top = bracketSign.Top;
            }
        }
    }
}
