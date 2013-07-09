using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Editor
{
    public abstract class SubSuperBase : EquationContainer
    {
        public Position Position { get; set; }        
        protected RowContainer rowContainer;
        EquationBase buddy = null;
        protected EquationBase Buddy
        {
            get { return buddy ?? ParentEquation.ActiveChild; }
            set { buddy = value; }
        }
        
        public SubSuperBase(EquationRow parent, Position position)
            : base(parent)
        {
            Position = position;
            ActiveChild = rowContainer = new RowContainer(this);
            childEquations.Add(rowContainer);
            rowContainer.FontFactor = SmallerFontFactor;
        }
        
        public void SetBuddy(EquationBase buddy)
        {
            this.Buddy = buddy;
            CalculateHeight();
        }

        protected override void CalculateWidth()
        {
            Width = rowContainer.Width;
        }

        public override double Left
        {
            get { return base.Left; }
            set
            {
                base.Left = value;
                rowContainer.Left = this.Left;
            }
        }
    }
}
