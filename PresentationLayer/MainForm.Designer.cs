using System.Windows.Forms;

namespace PresentationLayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.insertTabItem = new DevComponents.DotNetBar.RibbonTabItem();
            this.startButton = new DevComponents.DotNetBar.Office2007StartButton();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer5 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem13 = new DevComponents.DotNetBar.ButtonItem();
            this.btHelp = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite9 = new DevComponents.DotNetBar.DockSite();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer = new DevComponents.DotNetBar.PanelDockContainer();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.explorerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.dockContainerItem = new DevComponents.DotNetBar.DockContainerItem();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.File = new DevComponents.DotNetBar.RibbonBar();
            this.openFileButton = new DevComponents.DotNetBar.ButtonItem();
            this.Exam = new DevComponents.DotNetBar.RibbonBar();
            this.btNewExam = new DevComponents.DotNetBar.ButtonItem();
            this.btExportExam = new DevComponents.DotNetBar.ButtonItem();
            this.Question = new DevComponents.DotNetBar.RibbonBar();
            this.btEditQuestion = new DevComponents.DotNetBar.ButtonItem();
            this.btNewQuestion = new DevComponents.DotNetBar.ButtonItem();
            this.saveTestToXmlFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileForderDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.exportDocsExamButton = new DevComponents.DotNetBar.ButtonItem();
            this.dockSite9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            this.panelDockContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explorerSplitContainer)).BeginInit();
            this.explorerSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.insertTabItem});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(4, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.startButton,
            this.btHelp,
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(662, 133);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 6;
            this.ribbonControl1.Text = "ribbonControl1";
            this.ribbonControl1.TitleText = "<font color=\"#ED1C24\"><b>TEST EASY</b></font>";
            // 
            // insertTabItem
            // 
            this.insertTabItem.Checked = true;
            this.insertTabItem.ImagePaddingHorizontal = 8;
            this.insertTabItem.Name = "insertTabItem";
            this.insertTabItem.Text = "<b>List Test</b>";
            // 
            // startButton
            // 
            this.startButton.AutoExpandOnClick = true;
            this.startButton.CanCustomize = false;
            this.startButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.startButton.Image = global::PresentationLayer.Properties.Resources.Program;
            this.startButton.ImagePaddingHorizontal = 2;
            this.startButton.ImagePaddingVertical = 2;
            this.startButton.Name = "startButton";
            this.startButton.ShowSubItems = false;
            this.startButton.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.startButton.Text = "&File";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(0, 0);
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2,
            this.itemContainer5});
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.itemContainer2.ItemSpacing = 0;
            this.itemContainer2.MinimumSize = new System.Drawing.Size(0, 0);
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3,
            this.itemContainer4});
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.MinimumSize = new System.Drawing.Size(120, 0);
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem7});
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.ImagePaddingHorizontal = 8;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 24;
            this.buttonItem2.Text = "&New";
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.ImagePaddingHorizontal = 8;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.SubItemsExpandWidth = 24;
            this.buttonItem3.Text = "&Open...";
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.ImagePaddingHorizontal = 8;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.SubItemsExpandWidth = 24;
            this.buttonItem4.Text = "&Save...";
            // 
            // buttonItem5
            // 
            this.buttonItem5.BeginGroup = true;
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.ImagePaddingHorizontal = 8;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.SubItemsExpandWidth = 24;
            this.buttonItem5.Text = "S&hare...";
            // 
            // buttonItem7
            // 
            this.buttonItem7.BeginGroup = true;
            this.buttonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem7.ImagePaddingHorizontal = 8;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.SubItemsExpandWidth = 24;
            this.buttonItem7.Text = "&Close";
            // 
            // itemContainer4
            // 
            // 
            // 
            // 
            this.itemContainer4.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer";
            this.itemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer4.MinimumSize = new System.Drawing.Size(180, 0);
            this.itemContainer4.Name = "itemContainer4";
            // 
            // itemContainer5
            // 
            // 
            // 
            // 
            this.itemContainer5.BackgroundStyle.Class = "RibbonFileMenuBottomContainer";
            this.itemContainer5.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.itemContainer5.MinimumSize = new System.Drawing.Size(0, 0);
            this.itemContainer5.Name = "itemContainer5";
            this.itemContainer5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem12,
            this.buttonItem13});
            // 
            // buttonItem12
            // 
            this.buttonItem12.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem12.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem12.ImagePaddingHorizontal = 8;
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.SubItemsExpandWidth = 24;
            this.buttonItem12.Text = "Opt&ions";
            // 
            // buttonItem13
            // 
            this.buttonItem13.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem13.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem13.ImagePaddingHorizontal = 8;
            this.buttonItem13.Name = "buttonItem13";
            this.buttonItem13.SubItemsExpandWidth = 24;
            this.buttonItem13.Text = "E&xit";
            // 
            // btHelp
            // 
            this.btHelp.ImagePaddingHorizontal = 8;
            this.btHelp.Name = "btHelp";
            this.btHelp.Text = "Help";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.DefinitionName = "";
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.FillDockSite = this.dockSite9;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(4, 436);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(662, 0);
            this.dockSite4.TabIndex = 11;
            this.dockSite4.TabStop = false;
            // 
            // dockSite9
            // 
            this.dockSite9.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite9.Controls.Add(this.bar1);
            this.dockSite9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockSite9.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.bar1, 662, 302)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.dockSite9.Location = new System.Drawing.Point(4, 134);
            this.dockSite9.Name = "dockSite9";
            this.dockSite9.Size = new System.Drawing.Size(662, 302);
            this.dockSite9.TabIndex = 16;
            this.dockSite9.TabStop = false;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AlwaysDisplayDockTab = true;
            this.bar1.AlwaysDisplayKeyAccelerators = true;
            this.bar1.CanCustomize = false;
            this.bar1.CanDockBottom = false;
            this.bar1.CanDockDocument = true;
            this.bar1.CanDockLeft = false;
            this.bar1.CanDockRight = false;
            this.bar1.CanDockTop = false;
            this.bar1.CanHide = true;
            this.bar1.CanUndock = false;
            this.bar1.Controls.Add(this.panelDockContainer);
            this.bar1.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.bar1.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dockContainerItem});
            this.bar1.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.SelectedDockTab = 0;
            this.bar1.Size = new System.Drawing.Size(662, 302);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 0;
            this.bar1.TabNavigation = true;
            this.bar1.TabStop = false;
            // 
            // panelDockContainer
            // 
            this.panelDockContainer.Controls.Add(this.mainSplitContainer);
            this.panelDockContainer.Location = new System.Drawing.Point(6, 31);
            this.panelDockContainer.Name = "panelDockContainer";
            this.panelDockContainer.Size = new System.Drawing.Size(650, 265);
            this.panelDockContainer.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelDockContainer.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer.Style.GradientAngle = 90;
            this.panelDockContainer.TabIndex = 0;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.mainSplitContainer.Panel1.Controls.Add(this.explorerSplitContainer);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.mainSplitContainer.Size = new System.Drawing.Size(650, 265);
            this.mainSplitContainer.SplitterDistance = 250;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // explorerSplitContainer
            // 
            this.explorerSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.explorerSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.explorerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.explorerSplitContainer.Name = "explorerSplitContainer";
            // 
            // explorerSplitContainer.Panel1
            // 
            this.explorerSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            // 
            // explorerSplitContainer.Panel2
            // 
            this.explorerSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.explorerSplitContainer.Size = new System.Drawing.Size(250, 265);
            this.explorerSplitContainer.SplitterDistance = 73;
            this.explorerSplitContainer.TabIndex = 0;
            // 
            // dockContainerItem
            // 
            this.dockContainerItem.Control = this.panelDockContainer;
            this.dockContainerItem.Name = "dockContainerItem";
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(4, 1);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 435);
            this.dockSite1.TabIndex = 8;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(666, 1);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 435);
            this.dockSite2.TabIndex = 9;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(4, 436);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(662, 0);
            this.dockSite8.TabIndex = 15;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(4, 1);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 435);
            this.dockSite5.TabIndex = 12;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(666, 1);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 435);
            this.dockSite6.TabIndex = 13;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(4, 1);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(662, 0);
            this.dockSite7.TabIndex = 14;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(4, 1);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(662, 0);
            this.dockSite3.TabIndex = 10;
            this.dockSite3.TabStop = false;
            // 
            // File
            // 
            this.File.AutoOverflowEnabled = true;
            this.File.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.openFileButton});
            this.File.Location = new System.Drawing.Point(7, 58);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(80, 70);
            this.File.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.File.TabIndex = 18;
            this.File.Text = "File";
            // 
            // openFileButton
            // 
            this.openFileButton.Image = global::PresentationLayer.Properties.Resources.test;
            this.openFileButton.ImagePaddingHorizontal = 8;
            this.openFileButton.Name = "btOpenFile";
            this.openFileButton.Text = "ButtonOpenFile";
            // 
            // Exam
            // 
            this.Exam.AutoOverflowEnabled = true;
            this.Exam.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btNewExam,
            this.btExportExam,
            this.exportDocsExamButton});
            this.Exam.Location = new System.Drawing.Point(93, 58);
            this.Exam.Name = "Exam";
            this.Exam.Size = new System.Drawing.Size(175, 70);
            this.Exam.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Exam.TabIndex = 19;
            this.Exam.Text = "Exam";
            // 
            // btNewExam
            // 
            this.btNewExam.Image = global::PresentationLayer.Properties.Resources.AddNew;
            this.btNewExam.ImagePaddingHorizontal = 8;
            this.btNewExam.Name = "btNewExam";
            this.btNewExam.Text = "ButtonNewExam";
            // 
            // btExportExam
            // 
            this.btExportExam.Image = global::PresentationLayer.Properties.Resources.Export;
            this.btExportExam.ImagePaddingHorizontal = 8;
            this.btExportExam.Name = "btExportExam";
            this.btExportExam.Text = "buttonItem1";
            this.btExportExam.Click += new System.EventHandler(this.btExportExam_Click);
            // 
            // Question
            // 
            this.Question.AutoOverflowEnabled = true;
            this.Question.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btEditQuestion,
            this.btNewQuestion});
            this.Question.Location = new System.Drawing.Point(274, 58);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(125, 70);
            this.Question.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Question.TabIndex = 20;
            this.Question.Text = "Question";
            // 
            // btEditQuestion
            // 
            this.btEditQuestion.Image = global::PresentationLayer.Properties.Resources.editquestion;
            this.btEditQuestion.ImagePaddingHorizontal = 8;
            this.btEditQuestion.Name = "btEditQuestion";
            this.btEditQuestion.Text = "ButtonEditQuestion";
            // 
            // btNewQuestion
            // 
            this.btNewQuestion.Image = global::PresentationLayer.Properties.Resources.NewQuestion;
            this.btNewQuestion.ImagePaddingHorizontal = 8;
            this.btNewQuestion.Name = "btNewQuestion";
            this.btNewQuestion.Text = "NewQuestion";
            // 
            // openFolderBrowserDialog
            // 
            this.openFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // exportDocsExamButton
            // 
            this.exportDocsExamButton.Image = global::PresentationLayer.Properties.Resources.docs;
            this.exportDocsExamButton.ImageFixedSize = new System.Drawing.Size(45, 45);
            this.exportDocsExamButton.ImagePaddingHorizontal = 8;
            this.exportDocsExamButton.Name = "btExportDocsExam";
            this.exportDocsExamButton.Text = "buttonItem1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 438);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.Exam);
            this.Controls.Add(this.File);
            this.Controls.Add(this.dockSite9);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.dockSite9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            this.panelDockContainer.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.explorerSplitContainer)).EndInit();
            this.explorerSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonTabItem insertTabItem;
        private DevComponents.DotNetBar.Office2007StartButton startButton;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ItemContainer itemContainer4;
        private DevComponents.DotNetBar.ItemContainer itemContainer5;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private DevComponents.DotNetBar.ButtonItem buttonItem13;
        private DevComponents.DotNetBar.ButtonItem btHelp;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite9;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer explorerSplitContainer;
        private DevComponents.DotNetBar.RibbonBar File;
        private DevComponents.DotNetBar.ButtonItem openFileButton;
        private DevComponents.DotNetBar.RibbonBar Question;
        private DevComponents.DotNetBar.RibbonBar Exam;
        private DevComponents.DotNetBar.ButtonItem btNewExam;
        private DevComponents.DotNetBar.ButtonItem btNewQuestion;
        private DevComponents.DotNetBar.ButtonItem btExportExam;
        private DevComponents.DotNetBar.ButtonItem btEditQuestion;
        private SaveFileDialog saveTestToXmlFileDialog;
        private OpenFileDialog openFileForderDialog;
        private FolderBrowserDialog openFolderBrowserDialog;
        private DevComponents.DotNetBar.ButtonItem exportDocsExamButton;


    }
}