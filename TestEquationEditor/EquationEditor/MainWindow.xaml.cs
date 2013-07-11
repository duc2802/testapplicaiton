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
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Commons;
using SingleInstanceObject;
using ThreadQueueManager;

namespace Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string version = Assembly.GetEntryAssembly().GetName().Version.ToString();

        public MainWindow()
        {
            InitializeComponent();
            mathToolBar.CommandCompleted += (x, y) => { editor.Focus(); };
            SetTitle();
            AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(MainWindow_MouseDown), true);
           // underbarToggle.IsChecked = true;
        }

        public void HandleToolBarCommand(CommandDetails commandDetails)
        {
            editor.HandleUserCommand(commandDetails);
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.DirectlyOver != null)
            {
                if (Mouse.DirectlyOver.GetType() == typeof(EditorToolBarButton))
                {
                    return;
                }
                else if (editor.IsMouseOver)
                {
                    //editor.HandleMouseDown();
                    editor.Focus();
                }
                mathToolBar.HideVisiblePanel();
            }
        }

        private void Window_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!editor.IsFocused)
            {
                editor.Focus();
                editor.ConsumeText(e.Text);
                mathToolBar.HideVisiblePanel();
            }
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        
        void SetTitle()
        {
           Title = "Math Editor Mini v." + version;
        }

        string ShowSaveFileDialog(string extension, string filter)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.DefaultExt = "." + extension;
            sfd.Filter = filter;
            bool? result = sfd.ShowDialog();
            if (result == true)
            {
                return Path.GetExtension(sfd.FileName) == "." + extension ? sfd.FileName : sfd.FileName + "." + extension;
            }
            else
            {
                return null;
            }
        }
        
        private void ExportFilePNG(object sender, RoutedEventArgs e)
        {
            //string imageType = (string)((Control)sender).Tag ?? "png";

            string newName = Guid.NewGuid().ToString()+".png";
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + newName;

            //string fileName = Singleton<SettingManager>.Instance.GetImageFolder() +"\\"+ newName;
            //"C:\Users\ducnm\Desktop\hinh anh";
            // Set file Name for Image 
            /**
             * 
             * add code here
             * 
             * 
             */
            if (!string.IsNullOrEmpty(fileName))
            {
                string ext = Path.GetExtension(fileName);
                editor.ExportImage(fileName);
            }      
        }               

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void underbarToggleCheckChanged(object sender, RoutedEventArgs e)
        {
          //  editor.ShowOverbar(underbarToggle.IsChecked == true);
        }

        private void IncreaseZoomCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            editor.ZoomIn();
        }

        private void DecreaseZoomCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            editor.ZoomOut();
        }

        private void contentsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://mathiversity.com/MathEditor/Documentation");
        }

        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Math Editor Mini version " + version + Environment.NewLine + Environment.NewLine +
                            "\u00A9 2013 Kashif Imran", "About Math Editor Mini");
        }        
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!editor.IsFocused)
            {
                editor.Focus();
                mathToolBar.HideVisiblePanel();
            }
        }
        
        private void supportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://forum.mathiversity.com/");
        }
         
        private void scrollViwer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            editor.InvalidateVisual();
        }

        private void meLinkClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://mathiversity.com/MathEditor");
        }

        private void button1_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            ExportFilePNG(sender,e);
        }
    }
}
