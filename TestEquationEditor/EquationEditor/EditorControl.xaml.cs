using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.IO;

namespace Editor
{
    /// <summary>
    /// Interaction logic for EditorControl.xaml
    /// </summary>
    public partial class EditorControl : UserControl
    {
        System.Threading.Timer timer;
        int blinkPeriod = 500;

        bool showOverbar = true;

        public bool Dirty { get; set; }

        EquationRoot equationRoot;
        Caret vCaret = new Caret(false);
        Caret hCaret = new Caret(true);

        public static double rootFontBaseSize = 22;
        static double rootFontSize = rootFontBaseSize;
        int fontSize = 35;

        public static double RootFontSize 
        {
            get { return rootFontSize; }
        }

        public EditorControl()
        {
            InitializeComponent();
            mainGrid.Children.Add(vCaret);
            mainGrid.Children.Add(hCaret);
            equationRoot = new EquationRoot(vCaret, hCaret);
            equationRoot.FontSize = fontSize;
            timer = new System.Threading.Timer(blinkCaret, null, blinkPeriod, blinkPeriod);
        }

        public void SetFontSizePercentage(int percentage)
        {            
            equationRoot.FontSize = fontSize * percentage / 100;
            rootFontSize = equationRoot.FontSize;
            AdjustView();
        }

        public void ShowOverbar(bool show)
        {
            showOverbar = show;
            if (!show)
            {
                hCaret.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                hCaret.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void blinkCaret(Object state)
        {
            vCaret.ToggleVisibility();
            hCaret.ToggleVisibility();
        }

        public void HandleUserCommand(CommandDetails commandDetails)
        {
            equationRoot.HandleUserCommand(commandDetails);
            AdjustView();
            Dirty = true;
        }

        private void EditorControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (equationRoot.ConsumeMouseClick(Mouse.GetPosition(this)))
            {
                InvalidateVisual();
            }
            this.Focus();
            lastMouseLocation = e.GetPosition(this);
        }

        private void EditorControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void EditorControl_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        Point lastMouseLocation = new Point();

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            ScrollViewer scrollViewer = Parent as ScrollViewer;
            equationRoot.DrawVisibleRows(drawingContext, scrollViewer.VerticalOffset, scrollViewer.ViewportHeight + scrollViewer.VerticalOffset);
        }

        public void EditorControl_TextInput(object sender, TextCompositionEventArgs e)
        {
            ConsumeText(e.Text.Replace('-', '\u2212'));
        }

        public void ConsumeText(string text)
        {
            equationRoot.ConsumeText(text);
            AdjustView();
            Dirty = true;
        }

        private void EditorControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void EditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            bool handled = false;
            if (e.Key == Key.Tab)
            {
                equationRoot.ConsumeText("    ");
                handled = true;
            }
            else if (equationRoot.ConsumeKey(e.Key))
            {
                handled = true;
            }
            if (handled)
            {
                e.Handled = true;
                AdjustView();
                Dirty = true;
            }
        }

        void AdjustView()
        {
            DetermineSize();
            AdjustScrollViewer();
            this.InvalidateVisual();
        }

        void DetermineSize()
        {
            this.MinWidth = equationRoot.Width;
            this.MinHeight = equationRoot.Height + 20;
        }

        void AdjustScrollViewer()
        {
            ScrollViewer scrollViewer = Parent as ScrollViewer;
            if (scrollViewer != null)
            {
                double left = scrollViewer.HorizontalOffset;
                double top = scrollViewer.VerticalOffset;
                double right = scrollViewer.ViewportWidth + scrollViewer.HorizontalOffset;
                double bottom = scrollViewer.ViewportHeight + scrollViewer.VerticalOffset;
                double hOffset = 0;
                double vOffset = 0;
                bool rightDone = false;
                bool bottomDone = false;
                while (vCaret.Left > right - 8)
                {
                    hOffset += 8;
                    right += 8;
                    rightDone = true;
                }
                while (vCaret.VerticalCaretBottom > bottom - 10)
                {
                    vOffset += 10;
                    bottom += 10;
                    bottomDone = true;
                }
                while (vCaret.Left < left + 8 && !rightDone)
                {
                    hOffset -= 8;
                    left -= 8;
                }
                while (vCaret.Top < top + 10 && !bottomDone)
                {
                    vOffset -= 10;
                    top -= 10;
                }
                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + hOffset);
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + vOffset);
            }
        }       

        public void ExportImage(string filePath)
        {
            equationRoot.SaveImageToFile(filePath);
        }

        public void ZoomOut()
        {
            equationRoot.ZoomOut(4);
            rootFontSize = equationRoot.FontSize;
            AdjustView();
        }

        public void ZoomIn()
        {
            equationRoot.ZoomIn(4);
            rootFontSize = equationRoot.FontSize;
            AdjustView();
        }

        private void ZoomOutHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ZoomOut();
        }

        private void ZoomInHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ZoomIn();
        }
    }
}
