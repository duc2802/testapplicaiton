using System;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Linq;

namespace Editor
{
    public class Sub : SubSuperBase
    {        
        public Sub(EquationRow parent, Position position)
            : base(parent, position)
        {   
        }              

        protected override void CalculateHeight()
        {
            if (Buddy == null)
            {
                Height = rowContainer.Height;
            }
            else
            {
                Height = rowContainer.Height + Buddy.Height - Buddy.RefY;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                rowContainer.Bottom = Bottom;
            }
        }

        public override double RefY
        {
            get
            {
                return FontSize * .4;
                //return Height * (int)subSuperType;
            }
        }
    }
}
