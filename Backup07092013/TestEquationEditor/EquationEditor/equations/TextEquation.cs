using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Globalization;
using System.Xml.Linq;
using System.Windows.Media.Imaging;

namespace Editor
{
    public sealed class TextEquation : EquationBase
    {
        private StringBuilder textData = new StringBuilder("");
        FormattedText formattedText = null;
        int caretIndex = 0;
        static FontType fontType = FontType.STIXGeneral;

        public TextEquation(EquationContainer parent)
            : base(parent)
        {
            Height = FontSize;
        }

        public string Text
        {
            get
            {
                return textData.ToString();
            }
            set
            {
                textData.Clear();
                textData.Append(value);
                caretIndex = 0;
                FormatText();
            }
        }

        public void MoveCaretToStart()
        {
            caretIndex = 0;
        }

        public void MoveCaretToEnd()
        {
            caretIndex = textData.Length;
        }

        public int CaretIndex
        {
            get { return caretIndex; }
            set { caretIndex = value; }
        }

        public int TextLength
        {
            get { return textData.Length; }
        }

        public override double FontSize
        {
            get { return base.FontSize; }
            set
            {
                base.FontSize = value;
                FormatText();
            }
        }

        public override EquationBase Split(EquationContainer newParent)
        {
            TextEquation newText = new TextEquation(newParent);
            newText.textData.Append(textData.ToString(caretIndex, textData.Length - caretIndex));
            textData.Remove(caretIndex, textData.Length - caretIndex);
            caretIndex = textData.Length;
            newText.FontSize = FontSize;
            FormatText();
            newText.FormatText();
            return newText;
        }

        public void Merge(TextEquation secondText)
        {
            caretIndex = textData.Length;
            textData.Append(secondText.textData.ToString());
            FormatText();
        }

        public override void ConsumeText(string text)
        {
            textData.Insert(caretIndex, text);
            caretIndex += text.Length;
            FormatText();
        }

        public override bool ConsumeKey(Key key)
        {
            bool consumed = false;
            switch (key)
            {
                case Key.Home:
                    caretIndex = 0;
                    consumed = true;
                    break;
                case Key.End:
                    caretIndex = textData.Length;
                    consumed = true;
                    break;
                case Key.Delete:
                    if (textData.Length > 0 && caretIndex < textData.Length)
                    {
                        RemoveText(caretIndex);
                        FormatText();
                        consumed = true;
                    }
                    break;
                case Key.Back:
                    if (caretIndex > 0)
                    {
                        RemoveText(caretIndex - 1);
                        caretIndex--;
                        FormatText();
                        consumed = true;
                    }
                    break;
                case Key.Right:
                    if (caretIndex < textData.Length)
                    {
                        caretIndex++;
                        consumed = true;
                    }
                    break;
                case Key.Left:
                    if (caretIndex > 0)
                    {
                        caretIndex--;
                        consumed = true;
                    }
                    break;
            }
            return consumed;
        }

        void FormatText()
        {
            string str = textData.ToString();
            formattedText = FontFactory.GetFormattedText(str, fontType, FontSize);
            CalculateSize();
        }

        public override bool ConsumeMouseClick(Point mousePoint)
        {
            if (Left <= mousePoint.X && Right >= mousePoint.X)
            {
                double left = 0;
                caretIndex = textData.Length;
                for (; caretIndex > 0; caretIndex--)
                {
                    FormattedText textPart = FontFactory.GetFormattedText(textData.ToString(0, caretIndex), fontType, FontSize);
                    left = textPart.WidthIncludingTrailingWhitespace + Left;
                    if (left <= mousePoint.X + 2)
                        break;
                }
                return true;
            }
            return false;
        }

        public override void SetCursorOnKeyUpDown(Key key, Point point)
        {
            double left = 0;
            caretIndex = textData.Length;
            for (; caretIndex > 0; caretIndex--)
            {
                FormattedText textPart = FontFactory.GetFormattedText(textData.ToString(0, caretIndex), fontType, FontSize);
                left = textPart.WidthIncludingTrailingWhitespace + Left;
                if (left <= point.X + 2)
                    break;
            }
        }
        
        public override Point GetVerticalCaretLocation()
        {
            FormattedText textPart = FontFactory.GetFormattedText(textData.ToString(0, caretIndex), fontType, FontSize);
            if (textData.Length > 0 && char.IsLetterOrDigit((textData.ToString(0, 1).ToCharArray()[0])))
            {
                return new Point(this.Left + textPart.WidthIncludingTrailingWhitespace - textPart.OverhangLeading - textPart.OverhangTrailing, this.Top);
            }
            else
            {
                return new Point(this.Left + textPart.WidthIncludingTrailingWhitespace, this.Top);
            }
        }

        public override void DrawEquation(DrawingContext dc)
        {
            base.DrawEquation(dc);
            if (formattedText != null)
            {
                if (textData.Length > 0 && char.IsLetterOrDigit((textData.ToString(0, 1).ToCharArray()[0])))
                {
                    dc.DrawText(formattedText, new Point(Left - formattedText.OverhangLeading, Top - FontSize * .1));
                }
                else
                {
                    dc.DrawText(formattedText, new Point(Left, Top - FontSize * .1));
                }
            }
        }

        protected override void CalculateWidth()
        {
            Width = formattedText.GetExactWidth();
        }

        protected override void CalculateHeight()
        {
            FormattedText text = formattedText;
            if (text == null || text.Extent == 0)
            {
                Height = FontSize;
            }
            else
            {
                Height = text.Height + text.OverhangAfter;
            }            
        }

        public override double RefY
        {
            get
            {               
                if (formattedText == null || formattedText.Extent == 0)
                {
                    return FontSize * .75;
                }
                else
                {
                    return formattedText.Baseline - FontSize * .25;
                }
            }
        }

        void RemoveText(int index, int count = 1)
        {            
            textData.Remove(index, count);
        }

        public void Truncate()
        {
            textData.Length = caretIndex;
            FormatText();
        }
    }
}
