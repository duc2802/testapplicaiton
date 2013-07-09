using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Editor
{
    public static class PenManager
    {
        static Dictionary<double, Pen> pens = new Dictionary<double, Pen>();       
                    
        public static Pen GetPen(double thickness)
        {
            thickness = Math.Round(thickness, 1);
            if (!pens.ContainsKey(thickness))
            {
                Pen pen = new Pen(Brushes.Black, thickness);
                pen.Freeze();
                pens.Add(thickness, pen);
            }
            return pens[thickness];            
        }       
    }
}
