using System;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Linq;

namespace Editor
{
    public class Super : SubSuperBase
    {
        public Super(EquationRow parent, Position position)
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
                Height = rowContainer.Height + Buddy.RefY;
            }
        }

        public override double Top
        {
            get { return base.Top; }
            set
            {
                base.Top = value;
                rowContainer.Top = value;
            }
        }

        public override double RefY
        {
            get
            {
                return Height - FontSize * .6;// *(int)subSuperType;
            }
        }
    }
}
