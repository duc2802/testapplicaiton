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
            this.btOpenFile = new DevComponents.DotNetBar.ButtonItem();
            this.Exam = new DevComponents.DotNetBar.RibbonBar();
            this.btNewExam = new DevComponents.DotNetBar.ButtonItem();
            this.btExportExam = new DevComponents.DotNetBar.ButtonItem();
            this.Question = new DevComponents.DotNetBar.RibbonBar();
            this.btNewQuestion = new DevComponents.DotNetBar.ButtonItem();
            this.btEquation = new DevComponents.DotNetBar.ButtonItem();
            this.saveTestToXmlFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileForderDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.ribbonControl1.TitleText = "<font color=\"#ED1C24\"><b>IU-EasyTest</b></font>";
            // 
            // insertTabItem
            // 
            this.insertTabItem.ImagePaddingHorizontal = 8;
            this.insertTabItem.Name = "insertTabItem";
            this.insertTabItem.Text = "<b>Create Exam</b>";
            // 
            // startButton
            // 
            this.startButton.AutoExpandOnClick = true;
            this.startButton.CanCustomize = false;
            this.startButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.startButton.Image = global::PresentationLayer.Properties.Resources.Tatice_Cristal_Intense_Ok;
            this.startButton.ImagePaddingHorizontal = 2;
            this.startButton.ImagePaddingVertical = 2;
            this.startButton.Name = "startButton";
            this.startButton.ShowSubItems = false;
            this.startButton.Text = "&File";
            // 
            // btHelp
            // 
            this.btHelp.ImagePaddingHorizontal = 8;
            this.btHelp.Name = "btHelp";
            this.btHelp.SplitButton = true;
            this.btHelp.Text = "About us";
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
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
            this.btOpenFile});
            this.File.Location = new System.Drawing.Point(7, 58);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(80, 70);
            this.File.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.File.TabIndex = 18;
            this.File.Text = "File";
            // 
            // btOpenFile
            // 
            this.btOpenFile.Image = global::PresentationLayer.Properties.Resources.test;
            this.btOpenFile.ImagePaddingHorizontal = 8;
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Text = "ButtonOpenFile";
            this.btOpenFile.Tooltip = "Exam Folder";
            // 
            // Exam
            // 
            this.Exam.AutoOverflowEnabled = true;
            this.Exam.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btNewExam,
            this.btExportExam});
            this.Exam.Location = new System.Drawing.Point(93, 58);
            this.Exam.Name = "Exam";
            this.Exam.Size = new System.Drawing.Size(131, 70);
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
            this.btNewExam.Tooltip = "Add a new Exam";
            // 
            // btExportExam
            // 
            this.btExportExam.Image = global::PresentationLayer.Properties.Resources.Export;
            this.btExportExam.ImagePaddingHorizontal = 8;
            this.btExportExam.Name = "btExportExam";
            this.btExportExam.Text = "buttonItem1";
            this.btExportExam.Tooltip = "Export a exam";
            this.btExportExam.Click += new System.EventHandler(this.btExportExam_Click);
            // 
            // Question
            // 
            this.Question.AutoOverflowEnabled = true;
            this.Question.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btNewQuestion,
            this.btEquation});
            this.Question.Location = new System.Drawing.Point(230, 59);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(133, 70);
            this.Question.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Question.TabIndex = 20;
            this.Question.Text = "Question";
            // 
            // btNewQuestion
            // 
            this.btNewQuestion.Image = global::PresentationLayer.Properties.Resources.NewQuestion;
            this.btNewQuestion.ImagePaddingHorizontal = 8;
            this.btNewQuestion.Name = "btNewQuestion";
            this.btNewQuestion.Text = "NewQuestion";
            this.btNewQuestion.Tooltip = "Add a question into exam";
            // 
            // btEquation
            // 
            this.btEquation.Image = global::PresentationLayer.Properties.Resources.math;
            this.btEquation.ImagePaddingHorizontal = 8;
            this.btEquation.Name = "btEquation";
            this.btEquation.Text = "buttonItem1";
            this.btEquation.Tooltip = "Create Equation import to Exam";
            // 
            // openFolderBrowserDialog
            // 
            this.openFolderBrowserDialog.ShowNewFolderButton = false;
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
        private SaveFileDialog saveTestToXmlFileDialog;
        private OpenFileDialog openFileForderDialog;
        private FolderBrowserDialog openFolderBrowserDialog;
        private DevComponents.DotNetBar.ButtonItem exportDocsExamButton;
        private DevComponents.DotNetBar.ButtonItem btEquation;
        private DevComponents.DotNetBar.ButtonItem btOpenFile;
    }
}