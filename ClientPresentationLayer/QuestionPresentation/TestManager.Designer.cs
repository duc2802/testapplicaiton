namespace ClientPresentationLayer.QuestionPresentation
{
    partial class TestManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.managerTabControl = new System.Windows.Forms.TabControl();
            this.learningModeTabPage = new System.Windows.Forms.TabPage();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numOfExamTextBox = new System.Windows.Forms.TextBox();
            this.totalExamLabel = new System.Windows.Forms.Label();
            this.testlistView = new System.Windows.Forms.ListView();
            this.titleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberQuesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.importButton = new System.Windows.Forms.Button();
            this.startExamButton = new System.Windows.Forms.Button();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.managerTabControl.SuspendLayout();
            this.learningModeTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // managerTabControl
            // 
            this.managerTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.managerTabControl.Controls.Add(this.learningModeTabPage);
            this.managerTabControl.Controls.Add(this.aboutTabPage);
            this.managerTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerTabControl.Location = new System.Drawing.Point(0, 0);
            this.managerTabControl.Multiline = true;
            this.managerTabControl.Name = "managerTabControl";
            this.managerTabControl.SelectedIndex = 0;
            this.managerTabControl.Size = new System.Drawing.Size(611, 505);
            this.managerTabControl.TabIndex = 0;
            // 
            // learningModeTabPage
            // 
            this.learningModeTabPage.BackColor = System.Drawing.Color.White;
            this.learningModeTabPage.Controls.Add(this.deleteButton);
            this.learningModeTabPage.Controls.Add(this.label1);
            this.learningModeTabPage.Controls.Add(this.numOfExamTextBox);
            this.learningModeTabPage.Controls.Add(this.totalExamLabel);
            this.learningModeTabPage.Controls.Add(this.testlistView);
            this.learningModeTabPage.Controls.Add(this.importButton);
            this.learningModeTabPage.Controls.Add(this.startExamButton);
            this.learningModeTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learningModeTabPage.Location = new System.Drawing.Point(4, 25);
            this.learningModeTabPage.Name = "learningModeTabPage";
            this.learningModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.learningModeTabPage.Size = new System.Drawing.Size(603, 476);
            this.learningModeTabPage.TabIndex = 0;
            this.learningModeTabPage.Text = "Learning Mode";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Enabled = false;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(522, 86);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete Exam";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Help >>";
            // 
            // numOfExamTextBox
            // 
            this.numOfExamTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfExamTextBox.Enabled = false;
            this.numOfExamTextBox.Location = new System.Drawing.Point(428, 30);
            this.numOfExamTextBox.Name = "numOfExamTextBox";
            this.numOfExamTextBox.Size = new System.Drawing.Size(88, 20);
            this.numOfExamTextBox.TabIndex = 5;
            this.numOfExamTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalExamLabel
            // 
            this.totalExamLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalExamLabel.AutoSize = true;
            this.totalExamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalExamLabel.Location = new System.Drawing.Point(351, 33);
            this.totalExamLabel.Name = "totalExamLabel";
            this.totalExamLabel.Size = new System.Drawing.Size(74, 13);
            this.totalExamLabel.TabIndex = 4;
            this.totalExamLabel.Text = "Total Exam:";
            // 
            // testlistView
            // 
            this.testlistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testlistView.BackColor = System.Drawing.Color.White;
            this.testlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.numberQuesColumn,
            this.dateColumn});
            this.testlistView.FullRowSelect = true;
            this.testlistView.GridLines = true;
            this.testlistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.testlistView.HideSelection = false;
            this.testlistView.Location = new System.Drawing.Point(20, 57);
            this.testlistView.MultiSelect = false;
            this.testlistView.Name = "testlistView";
            this.testlistView.Size = new System.Drawing.Size(496, 398);
            this.testlistView.TabIndex = 3;
            this.testlistView.UseCompatibleStateImageBehavior = false;
            this.testlistView.View = System.Windows.Forms.View.Details;
            // 
            // titleColumn
            // 
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 300;
            // 
            // numberQuesColumn
            // 
            this.numberQuesColumn.Text = "Questions";
            this.numberQuesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberQuesColumn.Width = 100;
            // 
            // dateColumn
            // 
            this.dateColumn.Text = "Date";
            this.dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateColumn.Width = 100;
            // 
            // importButton
            // 
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Location = new System.Drawing.Point(20, 28);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 2;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // startExamButton
            // 
            this.startExamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startExamButton.Enabled = false;
            this.startExamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startExamButton.Location = new System.Drawing.Point(522, 57);
            this.startExamButton.Name = "startExamButton";
            this.startExamButton.Size = new System.Drawing.Size(75, 23);
            this.startExamButton.TabIndex = 1;
            this.startExamButton.Text = "Start Exam";
            this.startExamButton.UseVisualStyleBackColor = true;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.BackColor = System.Drawing.Color.White;
            this.aboutTabPage.Location = new System.Drawing.Point(4, 25);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTabPage.Size = new System.Drawing.Size(603, 476);
            this.aboutTabPage.TabIndex = 1;
            this.aboutTabPage.Text = "About TestEasy";
            // 
            // TestManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.managerTabControl);
            this.Name = "TestManager";
            this.Size = new System.Drawing.Size(611, 505);
            this.managerTabControl.ResumeLayout(false);
            this.learningModeTabPage.ResumeLayout(false);
            this.learningModeTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl managerTabControl;
        private System.Windows.Forms.TabPage learningModeTabPage;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button startExamButton;
        private System.Windows.Forms.ListView testlistView;
        private System.Windows.Forms.ColumnHeader titleColumn;
        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.TextBox numOfExamTextBox;
        private System.Windows.Forms.Label totalExamLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader numberQuesColumn;
        private System.Windows.Forms.Button deleteButton;
    }
}
