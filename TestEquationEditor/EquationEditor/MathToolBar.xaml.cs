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

namespace Editor
{
    /// <summary>
    /// Interaction logic for MathToolbar.xaml
    /// </summary>
    public partial class MathToolBar : UserControl
    {
        public event EventHandler CommandCompleted = (x, y) => { };
        Dictionary<object, ButtonPanel> buttonPanelMapping = new Dictionary<object, ButtonPanel>();
        ButtonPanel visiblePanel = null;

        public MathToolBar()
        {
            InitializeComponent();
        }

        private void toolBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (visiblePanel != null)
            {
                visiblePanel.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (buttonPanelMapping[sender].Visibility != System.Windows.Visibility.Visible)
            {
                buttonPanelMapping[sender].Visibility = System.Windows.Visibility.Visible;
                visiblePanel = buttonPanelMapping[sender];
            }
        }

        public void HideVisiblePanel()
        {
            if (visiblePanel != null)
            {
                visiblePanel.Visibility = System.Windows.Visibility.Collapsed;
                visiblePanel = null;
            }
        }

        private void toolBarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeActivePanel(sender);
        }


        private void toolBarButton_GotFocus(object sender, RoutedEventArgs e)
        {
            ChangeActivePanel(sender);
        }

        void ChangeActivePanel(object sender)
        {
            if (visiblePanel != null)
            {
                visiblePanel.Visibility = System.Windows.Visibility.Collapsed;
                buttonPanelMapping[sender].Visibility = System.Windows.Visibility.Visible;
                visiblePanel = buttonPanelMapping[sender];
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CreateSymbolsPanel();
            CreateGreekCapitalPanel();
            CreateGreekSmallPanel();
            CreateArrowsPanel();
            CreateBracketsPanel();
            CreateSumsProductsPanel();
            CreateIntegralsPanel();
            CreateSubAndSuperPanel();
            CreateDivAndRootsPanel();
        }

        void CreatePanel(List<CommandDetails> list, Button toolBarButton, int columns, int margin)
        {
            ButtonPanel bp = new ButtonPanel(list, columns, margin);
            bp.ButtonClick += (x, y) => { CommandCompleted(this, EventArgs.Empty); visiblePanel = null; };
            mainToolBarPanel.Children.Add(bp);
            Canvas.SetTop(bp, mainToolBarPanel.Height);
            Vector offset = VisualTreeHelper.GetOffset(toolBarButton);
            Canvas.SetLeft(bp, offset.X + 2);
            bp.Visibility = System.Windows.Visibility.Collapsed;
            buttonPanelMapping.Add(toolBarButton, bp);
        }


        void CreateTextPanel(string[] items, Button toolBarButton, int columns)
        {
            List<CommandDetails> list = new List<CommandDetails>();
            foreach (string s in items)
            {
                list.Add(new CommandDetails { UnicodeString = s, CommandType = CommandType.Text });
            }
            CreatePanel(list, toolBarButton, columns, 0);
        }


        void CreateImagePanel(Uri[] imageUris, CommandType[] commands, object[] paramz, Button toolBarButton, int columns)
        {
            try
            {
                Image[] items = new Image[imageUris.Count()];
                for (int i = 0; i < items.Count(); i++)
                {
                    items[i] = new Image();
                    BitmapImage bmi = new BitmapImage(imageUris[i]);
                    items[i].Source = bmi;
                }
                List<CommandDetails> list = new List<CommandDetails>();
                for (int i = 0; i < items.Count(); i++)
                {
                    list.Add(new CommandDetails { Image = items[i], CommandType = commands[i], CommandParam = paramz[i] });
                }
                CreatePanel(list, toolBarButton, columns, 4);
            }
            catch
            { }
        }



        void CreateSymbolsPanel()
        {
            string[] items = {  "\u00d7", "-", "\u2013", "\u2012", "\u2014", "\u00b7", "\u00f7", "\u00b1", 
                             "\u00bd", "\u00bc", "\u00be", "\u2200", "\u2202", "\u2203", "\u2204", 
                             "\u2205", "\u2208", "\u2209", "\u220B", "\u220C", "\u220F", "\u2210", 
                             "\u2211", "\u2217", "\u221A", "\u221D", "\u221E", "\u2227", "\u2228", 
                             "\u2229", "\u222A", "\u2234", "\u2235", "\u2237", "\u2238", "\u2264", 
                             "\u2265", "\u226e", "\u226f", "\u25B3", "\u25B7", "\u25BD", "\u25c8", 
                             "\u25C9", "\u25CE", "\u25E0", "\u25E1", "\u25EC" };

            CreateTextPanel(items, symbolsButton, 4);
        }

        void CreateGreekCapitalPanel()
        {
            string[] items = { "\u0391", "\u0392", "\u0393", "\u0394", "\u0395", "\u0396", "\u0397", 
                             "\u0398", "\u0399", "\u039A", "\u039B", "\u039C", "\u039D", "\u039E",
                             "\u039F", "\u03A0", "\u03A1", "\u03A3", "\u03A4", "\u03A5", "\u03A6",
                             "\u03A7", "\u03A8", "\u03A9" };

            CreateTextPanel(items, greekCapitalButton, 4);
        }

        void CreateGreekSmallPanel()
        {
            string[] items = { "\u03B1", "\u03B2", "\u03B3", "\u03B4", "\u03B5", "\u03B6", "\u03B7",
                             "\u03B8", "\u03B9", "\u03BA", "\u03BB", "\u03BC", "\u03BD", "\u03BE", 
                             "\u03BF", "\u03C0", "\u03C1", "\u03C2", "\u03C3", "\u03C4", "\u03C5", 
                             "\u03C6", "\u03C7", "\u03C8", "\u03C9" };

            CreateTextPanel(items, greekSmallButton, 4);
        }

        void CreateArrowsPanel()
        {
            string[] items = {
                                 "\u2190", "\u2191", "\u2192", "\u2193", "\u2194", "\u2195", "\u2196", 
                                 "\u2197", "\u2198", "\u2199", "\u219A", "\u219B", "\u219C", "\u219D", 
                                 "\u219E", "\u219F", "\u21A0", "\u21A1", "\u21A2", "\u21A3", "\u21A4", 
                                 "\u21A5", "\u21A6", "\u21A7", "\u21A8", "\u21A9", "\u21AA", "\u21AB", 
                                 "\u21AC", "\u21AD", "\u21AE", "\u21AF", "\u21B0", "\u21B1", "\u21B2",
                                 "\u21B3", "\u21B4", "\u21B5", "\u21B6", "\u21B7", "\u21B8", "\u21B9",
                                 "\u21BA", "\u21BB", "\u21BC", "\u21BD", "\u21BE", "\u21BF", "\u21C0",
                                 "\u21C1", "\u21C2", "\u21C3", "\u21C4", "\u21C5", "\u21C6", "\u21C7",
                                 "\u21C8", "\u21C9", "\u21CA", "\u21CB", "\u21CC", "\u21CD", "\u21CE", 
                                 "\u21CF", "\u21D0", "\u21D1", "\u21D2", "\u21D3", "\u21D4", "\u21D5", 
                                 "\u21D6", "\u21D7", "\u21D8", "\u21D8", "\u21D9", "\u21DA", "\u21DB",
                                 "\u21DC",
                             };

            CreateTextPanel(items, arrowsButton, 6);
        }

        Uri CreateImageUri(string subFolder, string imageFileName)
        {
            return new Uri("pack://application:,,,/images/commands/" + subFolder + "/" + imageFileName);
        }

        void CreateBracketsPanel()
        {
            Uri[] imageUris = { CreateImageUri("brackets", "SingleBar.png"),
                                CreateImageUri("brackets", "DoubleBar.png"),
                                CreateImageUri("brackets", "Floor.png"),
                                CreateImageUri("brackets", "Ceiling.png"),
                                CreateImageUri("brackets", "CurlyBracket.png"),
                                CreateImageUri("brackets", "RightRightSquareBracket.png"),
                                CreateImageUri("brackets", "Parentheses.png"),
                                CreateImageUri("brackets", "SquareBracket.png"),
                                CreateImageUri("brackets", "AngleBar.png"),
                                CreateImageUri("brackets", "BarAngle.png"),
                                CreateImageUri("brackets", "SquareBar.png"),
                                CreateImageUri("brackets", "ParenthesisSquare.png"),
                                CreateImageUri("brackets", "SquareParenthesis.png"),
                                CreateImageUri("brackets", "LeftLeftSquareBracket.png"),
                                CreateImageUri("brackets", "PointingAngles.png"),
                                CreateImageUri("brackets", "RightLeftSquareBracket.png"),
                                CreateImageUri("brackets", "LeftCurlyBracket.png"),
                                CreateImageUri("brackets", "RightCurlyBracket.png"),
                                CreateImageUri("brackets", "LeftDoubleBar.png"),
                                CreateImageUri("brackets", "RightDoubleBar.png"),
                                CreateImageUri("brackets", "LeftParenthesis.png"),
                                CreateImageUri("brackets", "RightParenthesis.png"),
                                CreateImageUri("brackets", "LeftSquareBar.png"),
                                CreateImageUri("brackets", "RightSquareBar.png"),
                                CreateImageUri("brackets", "LeftSquareBracket.png"),
                                CreateImageUri("brackets", "RightSquareBracket.png"),
                                CreateImageUri("brackets", "LeftAngle.png"),
                                CreateImageUri("brackets", "RightAngle.png"),
                                CreateImageUri("brackets", "LeftBar.png"),
                                CreateImageUri("brackets", "RightBar.png"),                             
                               };

            CommandType[] commands = { CommandType.LeftRightBracket, CommandType.LeftRightBracket, CommandType.LeftRightBracket, 
                                       CommandType.LeftRightBracket, CommandType.LeftRightBracket, CommandType.LeftRightBracket,
                                       CommandType.LeftRightBracket, CommandType.LeftRightBracket, CommandType.LeftRightBracket, 
                                       CommandType.LeftRightBracket, CommandType.LeftRightBracket, CommandType.LeftRightBracket,
                                       CommandType.LeftRightBracket, CommandType.LeftRightBracket, CommandType.LeftRightBracket,
                                       CommandType.LeftRightBracket,
                                       CommandType.LeftBracket,      CommandType.RightBracket, 
                                       CommandType.LeftBracket,      CommandType.RightBracket, 
                                       CommandType.LeftBracket,      CommandType.RightBracket, 
                                       CommandType.LeftBracket,      CommandType.RightBracket, 
                                       CommandType.LeftBracket,      CommandType.RightBracket, 
                                       CommandType.LeftBracket,      CommandType.RightBracket, 
                                       CommandType.LeftBracket,      CommandType.RightBracket,                                                          
                                     };
            object[] paramz = { 
                                   new BracketSignType [] {BracketSignType.LeftBar,       BracketSignType.RightBar},
                                   new BracketSignType [] {BracketSignType.LeftDoubleBar, BracketSignType.RightDoubleBar},
                                   new BracketSignType [] {BracketSignType.LeftFloor,     BracketSignType.RightFloor},
                                   new BracketSignType [] {BracketSignType.LeftCeiling,   BracketSignType.RightCeiling},
                                   new BracketSignType [] {BracketSignType.LeftCurly,     BracketSignType.RightCurly},
                                   new BracketSignType [] {BracketSignType.RightSquare,   BracketSignType.RightSquare},
                                   new BracketSignType [] {BracketSignType.LeftRound,     BracketSignType.RightRound},
                                   new BracketSignType [] {BracketSignType.LeftSquare,    BracketSignType.RightSquare},
                                   new BracketSignType [] {BracketSignType.LeftAngle,     BracketSignType.RightBar},
                                   new BracketSignType [] {BracketSignType.LeftBar,       BracketSignType.RightAngle},
                                   new BracketSignType [] {BracketSignType.LeftSquareBar, BracketSignType.RightSquareBar},
                                   new BracketSignType [] {BracketSignType.LeftRound,     BracketSignType.RightSquare},
                                   new BracketSignType [] {BracketSignType.LeftSquare,    BracketSignType.RightRound},
                                   new BracketSignType [] {BracketSignType.LeftSquare,    BracketSignType.LeftSquare},
                                   new BracketSignType [] {BracketSignType.LeftAngle,     BracketSignType.RightAngle},                                   
                                   new BracketSignType [] {BracketSignType.RightSquare,   BracketSignType.LeftSquare},

                                   BracketSignType.LeftCurly,
                                   BracketSignType.RightCurly, 
                                   BracketSignType.LeftDoubleBar,
                                   BracketSignType.RightDoubleBar, 
                                   BracketSignType.LeftRound,
                                   BracketSignType.RightRound, 
                                   BracketSignType.LeftSquareBar,
                                   BracketSignType.RightSquareBar, 
                                   BracketSignType.LeftSquare,
                                   BracketSignType.RightSquare, 
                                   BracketSignType.LeftAngle,
                                   BracketSignType.RightAngle,
                                   BracketSignType.LeftBar,
                                   BracketSignType.RightBar,
                              };

            CreateImagePanel(imageUris, commands, paramz, bracketsButton, 4);
        }

        void CreateSumsProductsPanel()
        {
            Uri[] imageUris = {   
                                  CreateImageUri("sumsProducts", "sum.png"),
                                  CreateImageUri("sumsProducts", "sumSub.png"),
                                  CreateImageUri("sumsProducts", "sumSubSuper.png"),
                                  CreateImageUri("sumsProducts", "sumBottom.png"),
                                  CreateImageUri("sumsProducts", "sumBottomTop.png"),                                  

                                  CreateImageUri("sumsProducts", "product.png"),
                                  CreateImageUri("sumsProducts", "productSub.png"),
                                  CreateImageUri("sumsProducts", "productSubSuper.png"),
                                  CreateImageUri("sumsProducts", "productBottom.png"),
                                  CreateImageUri("sumsProducts", "productBottomTop.png"),

                                  CreateImageUri("sumsProducts", "coProduct.png"),
                                  CreateImageUri("sumsProducts", "coProductSub.png"),
                                  CreateImageUri("sumsProducts", "coProductSubSuper.png"),
                                  CreateImageUri("sumsProducts", "coProductBottom.png"),
                                  CreateImageUri("sumsProducts", "coProductBottomTop.png"),
                                  
                                  CreateImageUri("sumsProducts", "intersection.png"),
                                  CreateImageUri("sumsProducts", "intersectionSub.png"),
                                  CreateImageUri("sumsProducts", "intersectionSubSuper.png"),
                                  CreateImageUri("sumsProducts", "intersectionBottom.png"),
                                  CreateImageUri("sumsProducts", "intersectionBottomTop.png"),
                                  
                                  CreateImageUri("sumsProducts", "union.png"),
                                  CreateImageUri("sumsProducts", "unionSub.png"),
                                  CreateImageUri("sumsProducts", "unionSubSuper.png"),
                                  CreateImageUri("sumsProducts", "unionBottom.png"),
                                  CreateImageUri("sumsProducts", "unionBottomTop.png"),
                              };
            CommandType[] commands = Enumerable.Repeat(CommandType.SignComposite, 25).ToArray();
            object[] paramz = { 
                                  new object [] {Position.None,    SignCompositeSymbol.Sum} ,
                                  new object [] {Position.Sub,       SignCompositeSymbol.Sum} ,
                                  new object [] {Position.SubSuper,  SignCompositeSymbol.Sum} ,
                                  new object [] {Position.Bottom,    SignCompositeSymbol.Sum} ,
                                  new object [] {Position.BottomTop, SignCompositeSymbol.Sum} ,

                                  new object [] {Position.None,    SignCompositeSymbol.Product} ,
                                  new object [] {Position.Sub,       SignCompositeSymbol.Product} ,
                                  new object [] {Position.SubSuper,  SignCompositeSymbol.Product} ,
                                  new object [] {Position.Bottom,    SignCompositeSymbol.Product} ,
                                  new object [] {Position.BottomTop, SignCompositeSymbol.Product} ,

                                  new object [] {Position.None,    SignCompositeSymbol.CoProduct} ,
                                  new object [] {Position.Sub,       SignCompositeSymbol.CoProduct} ,
                                  new object [] {Position.SubSuper,  SignCompositeSymbol.CoProduct} ,
                                  new object [] {Position.Bottom,    SignCompositeSymbol.CoProduct} ,
                                  new object [] {Position.BottomTop, SignCompositeSymbol.CoProduct} ,

                                  new object [] {Position.None,    SignCompositeSymbol.Intersection} ,
                                  new object [] {Position.Sub,       SignCompositeSymbol.Intersection} ,
                                  new object [] {Position.SubSuper,  SignCompositeSymbol.Intersection} ,
                                  new object [] {Position.Bottom,    SignCompositeSymbol.Intersection} ,
                                  new object [] {Position.BottomTop, SignCompositeSymbol.Intersection} ,

                                  new object [] {Position.None,    SignCompositeSymbol.Union} ,
                                  new object [] {Position.Sub,       SignCompositeSymbol.Union} ,
                                  new object [] {Position.SubSuper,  SignCompositeSymbol.Union} ,
                                  new object [] {Position.Bottom,    SignCompositeSymbol.Union} ,
                                  new object [] {Position.BottomTop, SignCompositeSymbol.Union} ,
                              };

            CreateImagePanel(imageUris, commands, paramz, sumsProductsButton, 5);
        }

        void CreateIntegralsPanel()
        {
            Uri[] imageUris = { 
                                  CreateImageUri("integrals", "integral.png"),
                                  CreateImageUri("integrals", "integralSub.png"),
                                  CreateImageUri("integrals", "integralSubSuper.png"),
                                  CreateImageUri("integrals", "integralBottom.png"),
                                  CreateImageUri("integrals", "integralBottomTop.png"),
                                  CreateImageUri("integrals", "integralBottomTop.png"), //this will be left empty using CommandType.None

                                  CreateImageUri("integrals", "dIntegral.png"),
                                  CreateImageUri("integrals", "dIntegralSub.png"),
                                  CreateImageUri("integrals", "dIntegralBottom.png"),                                  
                                  
                                  CreateImageUri("integrals", "tIntegral.png"),
                                  CreateImageUri("integrals", "tIntegralSub.png"),
                                  CreateImageUri("integrals", "tIntegralBottom.png"),                                  
                                  
                                  CreateImageUri("integrals", "contourIntegral.png"),
                                  CreateImageUri("integrals", "contourIntegralSub.png"),
                                  CreateImageUri("integrals", "contourIntegralBottom.png"),
                                  
                                  CreateImageUri("integrals", "surfaceIntegral.png"),
                                  CreateImageUri("integrals", "surfaceIntegralSub.png"),
                                  CreateImageUri("integrals", "surfaceIntegralBottom.png"),
                                  
                                  CreateImageUri("integrals", "volumeIntegral.png"),
                                  CreateImageUri("integrals", "volumeIntegralSub.png"),
                                  CreateImageUri("integrals", "volumeIntegralBottom.png"),
                                  
                                  CreateImageUri("integrals", "clockContourIntegral.png"),
                                  CreateImageUri("integrals", "clockContourIntegralSub.png"),
                                  CreateImageUri("integrals", "clockContourIntegralBottom.png"),
                                  
                                  CreateImageUri("integrals", "anticlockContourIntegral.png"),
                                  CreateImageUri("integrals", "anticlockContourIntegralSub.png"),
                                  CreateImageUri("integrals", "anticlockContourIntegralBottom.png"),
                               };

            CommandType[] commands = Enumerable.Repeat(CommandType.SignComposite, 27).ToArray();
            commands[5] = CommandType.None; //empty cell

            object[] paramz = { 
                                  new object [] {Position.None,    SignCompositeSymbol.Integral} ,
                                  new object [] {Position.Sub,       SignCompositeSymbol.Integral} ,
                                  new object [] {Position.SubSuper,  SignCompositeSymbol.Integral} ,
                                  new object [] {Position.Bottom,    SignCompositeSymbol.Integral} ,
                                  new object [] {Position.BottomTop, SignCompositeSymbol.Integral} ,
                                  
                                  0 /*Empty cell */,

                                  new object [] {Position.None, SignCompositeSymbol.DoubleIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.DoubleIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.DoubleIntegral} ,
                                  
                                  
                                  new object [] {Position.None, SignCompositeSymbol.TripleIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.TripleIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.TripleIntegral} ,

                                  new object [] {Position.None, SignCompositeSymbol.ContourIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.ContourIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.ContourIntegral} ,

                                  new object [] {Position.None, SignCompositeSymbol.SurfaceIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.SurfaceIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.SurfaceIntegral} ,

                                  new object [] {Position.None, SignCompositeSymbol.VolumeIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.VolumeIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.VolumeIntegral} ,

                                  new object [] {Position.None, SignCompositeSymbol.ClockContourIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.ClockContourIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.ClockContourIntegral} ,

                                  new object [] {Position.None, SignCompositeSymbol.AntiClockContourIntegral} ,
                                  new object [] {Position.Sub, SignCompositeSymbol.AntiClockContourIntegral} ,
                                  new object [] {Position.Bottom, SignCompositeSymbol.AntiClockContourIntegral}                                  
                              };

            CreateImagePanel(imageUris, commands, paramz, integralsButton, 3);
        }

        void CreateSubAndSuperPanel()
        {
            Uri[] imageUris = { 
                                  CreateImageUri("subSuper", "Sub.png"),   
                                  CreateImageUri("subSuper", "Super.png"),   
                                  CreateImageUri("subSuper", "SubSuper.png"),   
                                  CreateImageUri("subSuper", "SubLeft.png"),   
                                  CreateImageUri("subSuper", "SuperLeft.png"),   
                                  CreateImageUri("subSuper", "SubSuperLeft.png"),   
                               };
            CommandType[] commands = { CommandType.Sub, CommandType.Super, CommandType.SubAndSuper,
                                       CommandType.Sub, CommandType.Super, CommandType.SubAndSuper};

            object[] paramz = { Position.Right, Position.Right, Position.Right,
                                Position.Left, Position.Left, Position.Left,};

            CreateImagePanel(imageUris, commands, paramz, subAndSuperButton, 3);
        }

        void CreateDivAndRootsPanel()
        {
            Uri[] imageUris = { 
                                  CreateImageUri("divAndRoots", "SqRoot.png"),  
                                  CreateImageUri("divAndRoots", "nRoot.png"),  
                                  CreateImageUri("divAndRoots", "Div.png"),  
                                  CreateImageUri("divAndRoots", "DivSlant.png"),  
                                  CreateImageUri("divAndRoots", "DivHoriz.png"),
                               };
            CommandType[] commands = { CommandType.SquareRoot, CommandType.nRoot, CommandType.DivRegular, CommandType.DivSlanted, CommandType.DivHorizontal };
            object[] paramz = { 0, 0, 0, 0, 0 };
            CreateImagePanel(imageUris, commands, paramz, divAndRootsButton, 2);
        }
    }
}
