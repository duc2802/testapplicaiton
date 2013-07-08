using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace Editor
{
    public abstract class EquationBase
    {   
        static protected double subEquationFraction = 0.65;        
        static protected double lineFactor = 0.06;

        protected double LineThickness { get { return fontSize * lineFactor; } }
        protected double ThinLineThickness { get { return fontSize * lineFactor * 0.7; } }
        protected Pen StandardPen { get { return PenManager.GetPen(LineThickness); } }
        protected Pen ThinPen { get { return PenManager.GetPen(ThinLineThickness); } }

        public bool IsStatic { get; set; }
        protected double SmallerFontFactor = 0.8;
       
        public EquationContainer ParentEquation { get; set; }
        protected static Pen BluePen = new Pen(Brushes.Blue, 1);
        Point location = new Point();
        //Point refPoint = new Point();
        double width;
        double height;
        double fontSize = 20;
        double fontFactor = 1;
     
        public EquationBase(EquationContainer parent)
        {
            this.ParentEquation = parent;
            if (parent != null)
            {
                fontSize = parent.fontSize;
            }
        }

        public virtual bool ConsumeMouseClick(Point mousePoint) { return false; }

        public virtual EquationBase Split(EquationContainer newParent) { return null; }
        public virtual void ConsumeText(string text) { }
        public virtual bool ConsumeKey(Key key) { return false; }
        public virtual Point GetVerticalCaretLocation() { return location; }
        public virtual double GetVerticalCaretLength() { return height; }
        protected virtual void CalculateWidth() { }
        protected virtual void CalculateHeight() { }
        public virtual void SetCursorOnKeyUpDown(Key key, Point point) { }

        public virtual void CalculateSize()
        {
            CalculateWidth();
            CalculateHeight();
        }

        public virtual void DrawEquation(DrawingContext dc) { }

        public virtual double FontFactor
        {
            get { return fontFactor; }
            set
            {
                fontFactor = value;
                FontSize = fontSize; //fontsize needs adjustement!
            }
        }

        public virtual double FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = Math.Min(1000, Math.Max(value * fontFactor, 4));
            }
        }

        public virtual double RefX
        {
            get { return width / 2; }
        }

        public virtual double RefY
        {
            get { return height / 2; }
        }

        public virtual double Width
        {
            get { return width; }
            set
            {
                width = value;
            }
        }

        public virtual double Height
        {
            get { return height; }
            set
            {
                height = value;
            }
        }

        public Point Location
        {
            get { return location; }
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public virtual double Left
        {
            get { return location.X; }
            set { location.X = value; }
        }
        public virtual double Top
        {
            get { return location.Y; }
            set { location.Y = value; }
        }

        public double MidX
        {
            get { return location.X + RefX; }
            set { Left = value - RefX; }
        }

        public double MidY
        {
            get { return location.Y + RefY; }
            set { Top = value - RefY; }
        }

        public virtual double Right
        {
            get { return location.X + width; }
            set { Left = value - width; }
        }

        public virtual double Bottom
        {
            get { return location.Y + height; }
            set { Top = value - height; }
        }

        public Size Size
        {
            get { return new Size(width, height); }
        }

        public Rect Bounds
        {
            get { return new Rect(location, Size); }
        }
    }
}
