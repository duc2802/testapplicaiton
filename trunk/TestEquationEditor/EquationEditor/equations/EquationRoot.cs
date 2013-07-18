using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using Commons;
using SingleInstanceObject;
using Microsoft.Win32;

namespace Editor
{
    public class EquationRoot : EquationContainer
    {
        Caret vCaret;
        Caret hCaret;

        public EquationRoot(Caret vCaret, Caret hCaret)
            : base(null)
        {
            this.vCaret = vCaret;
            this.hCaret = hCaret;
            ActiveChild = new RowContainer(this, 0.3);
            childEquations.Add(ActiveChild);
            ActiveChild.Location = Location = new Point(15, 15);
            AdjustCarets();
        }

        public override bool ConsumeMouseClick(Point mousePoint)
        {
            ActiveChild.ConsumeMouseClick(mousePoint);
            AdjustCarets();
            return true;
        }
        
        public void HandleUserCommand(CommandDetails commandDetails)
        {
            if (commandDetails.CommandType == CommandType.Text)
            {
                ConsumeText(commandDetails.UnicodeString); //ConsumeText() will call DeSelect() itself. No worries here
            }
            else
            {
                ((EquationContainer)ActiveChild).ExecuteCommand(commandDetails.CommandType, commandDetails.CommandParam);
                CalculateSize();
                AdjustCarets();
            }
        }

        public void AdjustCarets()
        {
            vCaret.Location = ActiveChild.GetVerticalCaretLocation();
            vCaret.CaretLength = ActiveChild.GetVerticalCaretLength();
            EquationContainer innerMost = ((RowContainer)ActiveChild).GetInnerMostEquationContainer();
            hCaret.Location = innerMost.GetHorizontalCaretLocation();
            hCaret.CaretLength = innerMost.GetHorizontalCaretLength();
        }


        public override void ConsumeText(string text)
        {
            ActiveChild.ConsumeText(text);
            CalculateSize();
            AdjustCarets();
        }
        
        public void DrawVisibleRows(DrawingContext dc, double top, double bottom)
        {
            ((RowContainer)ActiveChild).DrawVisibleRows(dc, top, bottom);
        }

        public void SaveImageToFile(string path)
        {
            string extension = Path.GetExtension(path).ToLower();
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                if (extension == ".bmp" || extension == "jpg")
                {
                    dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, Math.Ceiling(Width + Location.X * 2), Math.Ceiling(Width + Location.Y * 2)));
                }
                ActiveChild.DrawEquation(dc);
            }
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)(Math.Ceiling(Width + Location.X * 2)), (int)(Math.Ceiling(Height + Location.Y * 2)), 96, 96, PixelFormats.Default);
            bitmap.Render(dv);
            BitmapEncoder encoder = null;
            switch (extension)
            {
                case ".jpg":
                    encoder = new JpegBitmapEncoder();
                    break;
                case ".gif":
                    encoder = new GifBitmapEncoder();
                    break;
                case ".bmp":
                    encoder = new BmpBitmapEncoder();
                    break;
                case ".png":
                    encoder = new PngBitmapEncoder();
                    break;
                case ".wdp":
                    encoder = new WmpBitmapEncoder();
                    break;
                case ".tif":
                    encoder = new TiffBitmapEncoder();
                    break;
            }
            try
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                using (Stream s = File.Create(path))
                {
                    encoder.Save(s);
                    Singleton<SettingManager>.Instance.EquationName = path;
                    var processes = Process.GetProcessesByName("Editor");
                    foreach (Process proc in processes)
                    {
                        MessageBox.Show("Khong tim thay", "Error");

                        proc.CloseMainWindow();
                     //   proc.Close();
                    }
                 //   closeEditorWindow();
                }
            }
            catch
            {
                MessageBox.Show("File could not be saved. Please make sure the path you entered is correct", "Error");
            }
        }

        public override bool ConsumeKey(Key key)
        {            
            Key[] handledKeys = { Key.Left, Key.Right, Key.Delete, Key.Up, Key.Down, Key.Enter, Key.Escape, Key.Back, Key.Home, Key.End };
            bool result = false;
            if (handledKeys.Contains(key))
            {
                result = true;
                ActiveChild.ConsumeKey(key);
                CalculateSize();
                AdjustCarets();
            }
            return result;
        }

        protected override void CalculateWidth()
        {
            Width = ActiveChild.Width;
        }

        protected override void CalculateHeight()
        {
            Height = ActiveChild.Height;
        }

        public void ZoomOut(int difference)
        {
            FontSize -= difference;
        }

        public void ZoomIn(int difference)
        {
            FontSize += difference;
        }

        public override double FontSize
        {
            get { return base.FontSize; }
            set
            {
                base.FontSize = value;
                AdjustCarets();
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        private void closeEditorWindow()
        {
            // retrieve the handler of the window  
            int iHandle = FindWindow("Editor", "Editor.exe");
            if (iHandle > 0)
            {
                // close the window using API        
                SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
            }
        }
    }
}
