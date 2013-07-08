using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Editor
{
    public static class FormattedTextHelper
    {
        public static void DrawTextTopLeftAligned (this FormattedText text, DrawingContext dc, Point topLeft)
        {
            double height = text.Height;
            double baseLine = text.Baseline;
            double extent = text.Extent;
            double bottomExtra = -text.OverhangAfter;
            double descent = (height - baseLine) - bottomExtra;
            double topExtra = baseLine - (extent - descent);
            dc.DrawText(text, new Point(topLeft.X - text.OverhangLeading, topLeft.Y - topExtra));
        }

        public static void DrawTextTopRightAligned(this FormattedText text, DrawingContext dc, Point topRight)
        {
            double height = text.Height;
            double baseLine = text.Baseline;
            double extent = text.Extent;
            double bottomExtra = -text.OverhangAfter;
            double descent = (height - baseLine) - bottomExtra;
            double topExtra = baseLine - (extent - descent);
            dc.DrawText(text, new Point(topRight.X - text.GetExactWidth() - text.OverhangLeading, topRight.Y - topExtra));
        }

        public static void DrawTextBottomLeftAligned(this FormattedText text, DrawingContext dc, Point bottomLeft)
        {
            double height = text.Height;
            double baseLine = text.Baseline;
            double extent = text.Extent;
            double bottomExtra = -text.OverhangAfter;
            double descent = (height - baseLine) - bottomExtra;
            double topExtra = baseLine - (extent - descent);
            dc.DrawText(text, new Point(bottomLeft.X - text.OverhangLeading, bottomLeft.Y - topExtra - extent));
        }

        public static void DrawTextBottomRightAligned(this FormattedText text, DrawingContext dc, Point bottomRight)
        {
            double height = text.Height;
            double baseLine = text.Baseline;
            double extent = text.Extent;
            double bottomExtra = -text.OverhangAfter;
            double descent = (height - baseLine) - bottomExtra;
            double topExtra = baseLine - (extent - descent);
            dc.DrawText(text, new Point(bottomRight.X - text.GetExactWidth() - text.OverhangLeading, bottomRight.Y - topExtra - extent));
        }

        public static double GetExactWidth(this FormattedText formattedText)
        {
            double width = formattedText.WidthIncludingTrailingWhitespace;
            if (formattedText.Text.Length > 0 && !char.IsSeparator((formattedText.Text.Substring(0, 1).ToCharArray()[0])))
            {
                width = width - formattedText.OverhangLeading;
                if (!char.IsSeparator(formattedText.Text.Substring(formattedText.Text.Length-1, 1).ToCharArray()[0]))
                {
                    width -= formattedText.OverhangTrailing;
                }
            }
            return width;
        }
    }
}
