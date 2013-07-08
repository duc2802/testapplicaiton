using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace Editor
{
    public class BracketSign : EquationBase
    {
        public BracketSignType SignType { get; set; }
        FormattedText signText; //used by certain brackets
        FormattedText signText2; //used by certain brackets
        FormattedText midText; //for bigger curly brackets

        double BracketBreakLimit { get { return FontSize * 2.8; } }

        double leftPaddingFactor = .1;
        double rightPaddingFactor = .1;
        double SignLeft { get { return Left + LeftPadding; } }
        double SignRight { get { return Right - RightPadding; } }
        double LeftPadding { get { return FontSize * leftPaddingFactor; } }
        double RightPadding { get { return FontSize * rightPaddingFactor; } }

        public BracketSign(EquationContainer parent, BracketSignType entityType)
            : base(parent)
        {
            this.SignType = entityType;
            IsStatic = true;
        }

        void CreateTextBrackets()
        {
            switch (SignType)
            {
                case BracketSignType.LeftRound:
                case BracketSignType.RightRound:
                    CreateRoundTextBracket();
                    break;
                case BracketSignType.LeftCurly:
                case BracketSignType.RightCurly:
                    CreateCurlyTextBracket();
                    break;
            }
        }

        void CreateRoundTextBracket()
        {
            if (Height < FontSize)
            {
                string singText = SignType == BracketSignType.LeftRound ? "(" : ")";
                FitSignToHeight(FontType.STIXSizeOneSym, singText);
            }
            else if (Height < FontSize * 1.6)
            {
                string singText = SignType == BracketSignType.LeftRound ? "(" : ")";
                FitSignToHeight(FontType.STIXSizeTwoSym, singText);
            }
            else if (Height < FontSize * 2.2)
            {
                string singText = SignType == BracketSignType.LeftRound ? "(" : ")";
                FitSignToHeight(FontType.STIXSizeThreeSym, singText);
            }
            else if (Height < BracketBreakLimit)
            {
                string singText = SignType == BracketSignType.LeftRound ? "(" : ")";
                FitSignToHeight(FontType.STIXSizeFourSym, singText);
            }
            else
            {
                string text1 = SignType == BracketSignType.LeftRound ? "\u239b" : "\u239e";
                string text2 = SignType == BracketSignType.LeftRound ? "\u239d" : "\u23a0";
                signText = FontFactory.GetFormattedText(text1, FontType.STIXSizeOneSym, FontSize * .5);
                signText2 = FontFactory.GetFormattedText(text2, FontType.STIXSizeOneSym, FontSize * .5);
            }
        }

        void CreateCurlyTextBracket()
        {
            if (Height < FontSize)
            {
                string singText = SignType == BracketSignType.LeftCurly ? "{" : "}";
                FitSignToHeight(FontType.STIXSizeOneSym, singText);
            }
            else if (Height < FontSize * 1.6)
            {
                string singText = SignType == BracketSignType.LeftCurly ? "{" : "}";
                FitSignToHeight(FontType.STIXSizeTwoSym, singText);
            }
            else if (Height < FontSize * 2.2)
            {
                string singText = SignType == BracketSignType.LeftCurly ? "{" : "}";
                FitSignToHeight(FontType.STIXSizeThreeSym, singText);
            }
            else if (Height < BracketBreakLimit)
            {
                string singText = SignType == BracketSignType.LeftCurly ? "{" : "}";
                FitSignToHeight(FontType.STIXSizeFourSym, singText);
            }
            else
            {
                string text1 = SignType == BracketSignType.LeftCurly ? "\u23a7" : "\u23ab";
                string midtex = SignType == BracketSignType.LeftCurly ? "\u23a8" : "\u23ac";
                string text2 = SignType == BracketSignType.LeftCurly ? "\u23a9" : "\u23ad";
                signText = FontFactory.GetFormattedText(text1, FontType.STIXSizeOneSym, FontSize * .5);
                midText = FontFactory.GetFormattedText(midtex, FontType.STIXSizeOneSym, FontSize * .5);
                signText2 = FontFactory.GetFormattedText(text2, FontType.STIXSizeOneSym, FontSize * .5);
            }
        }

        private void FitSignToHeight(FontType fontType, string unicodeCharText)
        {
            double factor = .4;
            do
            {
                signText = FontFactory.GetFormattedText(unicodeCharText, fontType, FontSize * factor);
                factor += .05;
            }
            while (Height > signText.Extent);
        }

        public override double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                if (SignType == BracketSignType.LeftRound || SignType == BracketSignType.RightRound ||
                    SignType == BracketSignType.LeftCurly || SignType == BracketSignType.RightCurly
                    )
                {
                    CreateTextBrackets();
                }
                DetermineWidth();
            }
        }

        void DetermineWidth()
        {
            double width = FontSize * .2;
            switch (SignType)
            {
                case BracketSignType.LeftRound:
                case BracketSignType.RightRound:
                    if (Height < BracketBreakLimit)
                    {
                        width = signText.GetExactWidth();
                    }
                    else
                    {
                        width = FontSize * .26;
                    }
                    break;
                case BracketSignType.LeftCurly:
                case BracketSignType.RightCurly:
                    if (Height < BracketBreakLimit)
                    {
                        width = signText.GetExactWidth();
                    }
                    else
                    {
                        width = FontSize * .3;
                    }
                    break;
                case BracketSignType.LeftBar:
                case BracketSignType.RightBar:
                    width = LineThickness;
                    break;
                case BracketSignType.LeftDoubleBar:
                case BracketSignType.RightDoubleBar:
                    width = LineThickness * 2 + FontSize * 0.05;
                    break;
                case BracketSignType.LeftAngle:
                case BracketSignType.RightAngle:
                    width = FontSize * .12 + Height * 0.1;
                    break;
                case BracketSignType.LeftSquareBar:
                case BracketSignType.RightSquareBar:
                    width = LineThickness * 2 + FontSize * 0.15;
                    break;
            }
            Width = width + LeftPadding + RightPadding;
        }

        public override void DrawEquation(DrawingContext dc)
        {   
            switch (SignType)
            {
                case BracketSignType.LeftAngle:
                    PaintLeftAngle(dc);
                    break;
                case BracketSignType.RightAngle:
                    PaintRightAngle(dc);
                    break;
                case BracketSignType.LeftBar:
                case BracketSignType.RightBar:
                    PaintVerticalBar(dc);
                    break;
                case BracketSignType.LeftCeiling:
                    PaintLeftCeiling(dc);
                    break;
                case BracketSignType.RightCeiling:
                    PaintRightCeiling(dc);
                    break;
                case BracketSignType.LeftCurly:
                case BracketSignType.RightCurly:
                    PaintCurly(dc);
                    break;
                case BracketSignType.LeftDoubleBar:
                case BracketSignType.RightDoubleBar:
                    dc.DrawLine(StandardPen, new Point(SignLeft, Top), new Point(SignLeft, Bottom));
                    dc.DrawLine(StandardPen, new Point(SignRight, Top), new Point(SignRight, Bottom));
                    break;
                case BracketSignType.LeftFloor:
                    PaintLeftFloor(dc);
                    break;
                case BracketSignType.RightFloor:
                    PaintRightFloor(dc);
                    break;
                case BracketSignType.LeftRound:
                case BracketSignType.RightRound:
                    PaintRound(dc);
                    break;
                case BracketSignType.LeftSquare:
                    PaintLeftSquare(dc);
                    break;
                case BracketSignType.RightSquare:
                    PaintRightSquare(dc);
                    break;
                case BracketSignType.LeftSquareBar:
                    PaintLeftSquareBar(dc);
                    break;
                case BracketSignType.RightSquareBar:
                    PaintRightSquareBar(dc);
                    break;
            }
        }

        void PaintVerticalBar(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Bottom),                                                            
                                                            new Point(SignLeft, Bottom),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
        }

        void PaintLeftCeiling(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Top + ThinLineThickness),
                                                            new Point(SignLeft + ThinLineThickness, Top + ThinLineThickness),
                                                            new Point(SignLeft + ThinLineThickness, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
        }

        void PaintRightCeiling(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignRight - ThinLineThickness, Bottom),
                                                            new Point(SignRight - ThinLineThickness, Top + ThinLineThickness),
                                                            new Point(SignLeft, Top + ThinLineThickness),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
        }

        void PaintLeftFloor(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignLeft + ThinLineThickness, Top),
                                                            new Point(SignLeft + ThinLineThickness, Bottom - ThinLineThickness),
                                                            new Point(SignRight, Bottom - ThinLineThickness),
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
        }

        void PaintRightFloor(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                            new Point(SignLeft, Bottom - ThinLineThickness),
                                                            new Point(SignRight - ThinLineThickness, Bottom - ThinLineThickness),
                                                            new Point(SignRight - ThinLineThickness, Top),
                                                         };
            dc.FillPolylineGeometry(new Point(SignRight, Top), points);
        }

        void PaintLeftSquareBar(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Top + ThinLineThickness),
                                                            new Point(SignLeft + ThinLineThickness, Top + ThinLineThickness),
                                                            new Point(SignLeft + ThinLineThickness, Bottom - ThinLineThickness),
                                                            new Point(SignRight, Bottom - ThinLineThickness),
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
            dc.DrawLine(ThinPen, new Point(SignLeft + FontSize * .12, Top + ThinLineThickness * .5), new Point(SignLeft + FontSize * .12, Bottom - ThinLineThickness * .5));
        }

        void PaintRightSquareBar(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                            new Point(SignLeft, Bottom - ThinLineThickness),
                                                            new Point(SignRight - ThinLineThickness, Bottom - ThinLineThickness),
                                                            new Point(SignRight - ThinLineThickness, Top + ThinLineThickness),
                                                            new Point(SignLeft, Top + ThinLineThickness),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
            dc.DrawLine(ThinPen, new Point(SignRight - FontSize * .12, Top + ThinLineThickness * .5), new Point(SignRight - FontSize * .12, Bottom - ThinLineThickness * .5));
        }

        void PaintLeftSquare(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Top + ThinLineThickness),
                                                            new Point(SignLeft + LineThickness, Top + ThinLineThickness),
                                                            new Point(SignLeft + LineThickness, Bottom - ThinLineThickness),
                                                            new Point(SignRight, Bottom - ThinLineThickness),
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
        }

        void PaintRightSquare(DrawingContext dc)
        {
            PointCollection points = new PointCollection {  
                                                            new Point(SignRight, Top),
                                                            new Point(SignRight, Bottom),
                                                            new Point(SignLeft, Bottom),
                                                            new Point(SignLeft, Bottom - ThinLineThickness),
                                                            new Point(SignRight - LineThickness, Bottom - ThinLineThickness),
                                                            new Point(SignRight - LineThickness, Top + ThinLineThickness),
                                                            new Point(SignLeft, Top + ThinLineThickness),
                                                         };
            dc.FillPolylineGeometry(new Point(SignLeft, Top), points);
        }

        void PaintRound(DrawingContext dc)
        {
            if (Height < BracketBreakLimit)
            {
                if (SignType == BracketSignType.LeftRound)
                {
                    signText.DrawTextTopLeftAligned(dc, new Point(SignLeft, Top));
                }
                else
                {
                    signText.DrawTextTopRightAligned(dc, new Point(SignRight, Top));
                }
            }
            else
            {
                if (SignType == BracketSignType.LeftRound)
                {
                    signText.DrawTextTopLeftAligned(dc, new Point(SignLeft, Top));
                    signText2.DrawTextBottomLeftAligned(dc, new Point(SignLeft, Bottom));                
                    dc.DrawLine(StandardPen, new Point(SignLeft + LineThickness * .5, Top + signText.Extent * .96), new Point(SignLeft + LineThickness * .5, Bottom - signText2.Extent * .96));
                }
                else
                {
                    signText.DrawTextTopRightAligned(dc, new Point(SignRight, Top));
                    signText2.DrawTextBottomRightAligned(dc, new Point(SignRight, Bottom));
                    dc.DrawLine(StandardPen, new Point(SignRight - LineThickness * .5, Top + signText.Extent * .96), new Point(SignRight - LineThickness * .5, Bottom - signText2.Extent * .96));
                }
            }
        }

        void PaintCurly(DrawingContext dc)
        {
            if (Height < BracketBreakLimit)
            {
                signText.DrawTextTopLeftAligned(dc, new Point(SignLeft, Top));
            }
            else
            {
                if (SignType == BracketSignType.LeftCurly)
                {
                    signText.DrawTextTopLeftAligned(dc, new Point(SignLeft + FontSize * .11, Top));
                    midText.DrawTextTopLeftAligned(dc, new Point(SignLeft, MidY - midText.Extent / 2));
                    signText2.DrawTextBottomLeftAligned(dc, new Point(SignLeft + FontSize * .11, Bottom));
                    dc.DrawLine(StandardPen, new Point(SignLeft + FontSize * .14, Top + signText.Extent * .94), new Point(SignLeft + FontSize * .14, MidY - midText.Extent * .46));
                    dc.DrawLine(StandardPen, new Point(SignLeft + FontSize * .14, MidY + midText.Extent * .46), new Point(SignLeft + FontSize * .14, Bottom - signText2.Extent * .94));
                }
                else
                {
                    signText.DrawTextTopLeftAligned(dc, new Point(SignLeft, Top));
                    midText.DrawTextTopLeftAligned(dc, new Point(SignLeft + FontSize * .11, MidY - midText.Extent * .5));
                    signText2.DrawTextBottomLeftAligned(dc, new Point(SignLeft, Bottom));
                    dc.DrawLine(StandardPen, new Point(SignRight - FontSize * .16, Top + signText.Extent * .94), new Point(SignRight - FontSize * .16, MidY - midText.Extent * .46));
                    dc.DrawLine(StandardPen, new Point(SignRight - FontSize * .16, MidY + midText.Extent * .46), new Point(SignRight - FontSize * .16, Bottom - signText2.Extent * .94));
                }
            }
        }

        void PaintLeftAngle(DrawingContext dc)
        {
            PointCollection points = new PointCollection { new Point(SignLeft, MidY), new Point(SignRight, Bottom) };
            dc.DrawPolyline(new Point(SignRight, Top), points, ThinPen);
        }

        void PaintRightAngle(DrawingContext dc)
        {
            PointCollection points = new PointCollection { new Point(SignRight, MidY), new Point(SignLeft, Bottom) };
            dc.DrawPolyline(new Point(SignLeft, Top), points, ThinPen);
        }
    }
}
