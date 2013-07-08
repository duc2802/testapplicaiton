﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Editor
{
    public class RadicalSign : EquationBase
    {
        static double widthFactor = .9;
        public RadicalSign(EquationContainer parent)
            : base(parent)
        {
            Width = FontSize * widthFactor;
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
                Width = value * widthFactor;
            }
        }

        public override void DrawEquation(DrawingContext dc)
        {

            dc.DrawPolyline(new Point(Left, Bottom - Height * .4),
                                   new PointCollection 
                                    {   
                                        new Point(Left + FontSize * .2, Bottom - Height * .5), 
                                        new Point(Left + FontSize * .2, Bottom - Height * .5),
                                        new Point(Left + FontSize * .4, Bottom),
                                        new Point(Left + FontSize * .4, Bottom),
                                        new Point(Right - FontSize * .1, Top + FontSize * .1),
                                        new Point(Right - FontSize * .1, Top + FontSize * .1),
                                        new Point(ParentEquation.Right, Top + FontSize * .1),
                                    },
                                   ThinPen);
        }
    }
}
