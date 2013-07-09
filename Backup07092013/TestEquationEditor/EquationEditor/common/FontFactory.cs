using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Globalization;

namespace Editor
{ 
    public class FontFactory
    {
        private FontFactory() { }
        
        public static FormattedText GetFormattedText(string textToFormat, FontType fontType, double fontSize)
        {
            return GetFormattedText(textToFormat, fontType, fontSize, FontStyles.Normal, FontWeights.Normal);
        }

        public static FormattedText GetFormattedText(string textToFormat, FontType fontType, double fontSize, FontWeight fontWeight)
        {
            return GetFormattedText(textToFormat, fontType, fontSize, FontStyles.Normal, fontWeight);
        }
        
        public static FormattedText GetFormattedText(string textToFormat, FontType fontType, double fontSize, FontStyle fontStyle, FontWeight fontWeight)
        {
            return GetFormattedText(textToFormat, fontType, fontSize, fontStyle, fontWeight, Brushes.Black);
        }

        public static FormattedText GetFormattedText(string textToFormat, FontType fontType, double fontSize, Brush brush)
        {
            return GetFormattedText(textToFormat, fontType, fontSize, FontStyles.Normal, FontWeights.Normal, brush);
        }


        public static FormattedText GetFormattedText(string textToFormat, FontType fontType, double fontSize, FontStyle fontStyle, FontWeight fontWeight, Brush brush)
        {
            Typeface typeface = GetTypeface(fontType, fontStyle, fontWeight);
            return new FormattedText(textToFormat, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, typeface, fontSize, brush);
        }

        public static FontFamily GetFontFamily(FontType fontType)
        {
            switch (fontType)
            {
                case FontType.STIXGeneral:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXGeneral");
                case FontType.STIXIntegralsD:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXIntegralsD");
                case FontType.STIXIntegralsSm:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXIntegralsSm");
                case FontType.STIXIntegralsUp:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXIntegralsUp");
                case FontType.STIXIntegralsUpD:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXIntegralsUpD");
                case FontType.STIXIntegralsUpSm:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXIntegralsUpSm");
                case FontType.STIXNonUnicode:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXNonUnicode");
                case FontType.STIXSizeFiveSym:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXSizeFiveSym");
                case FontType.STIXSizeFourSym:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXSizeFourSym");
                case FontType.STIXSizeOneSym:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXSizeOneSym");
                case FontType.STIXSizeThreeSym:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXSizeThreeSym");
                case FontType.STIXSizeTwoSym:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXSizeTwoSym");
                case FontType.STIXVariants:
                    return new FontFamily(new Uri("pack://application:,,,/STIX/"), "./#STIXVariants");
                case FontType.Arial:
                    return new FontFamily("Arial");
                case FontType.Segoe:
                    return new FontFamily("Segoe UI");
            }
            return new FontFamily("Segoe UI");
        }

        public static Typeface GetTypeface(FontType fontType, FontStyle fontStyle, FontWeight fontWeight)
        {
            return new Typeface(GetFontFamily(fontType), fontStyle, fontWeight, FontStretches.Normal);
        }        
    }
}