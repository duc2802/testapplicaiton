namespace ClientPresentationLayer.QuestionPresentation
{
    partial class QuestionExplainPanel
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
            this.contentQuestionPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tbExplain = new System.Windows.Forms.TextBox();
            this.lbExplain = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.btCloseViewExplain = new System.Windows.Forms.Button();
            this.goToQuesNumcomboBox = new System.Windows.Forms.ComboBox();
            this.goToQuesNumLabel = new System.Windows.Forms.Label();
            this.sendFeedBackLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.contentQuestionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentQuestionPanel
            // 
            this.contentQuestionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentQuestionPanel.AutoScroll = true;
            this.contentQuestionPanel.AutoSize = true;
            this.contentQuestionPanel.BackColor = System.Drawing.Color.White;
            this.contentQuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentQuestionPanel.Controls.Add(this.splitContainer);
            this.contentQuestionPanel.Controls.Add(this.splitter1);
            this.contentQuestionPanel.Location = new System.Drawing.Point(17, 59);
            this.contentQuestionPanel.Name = "contentQuestionPanel";
            this.contentQuestionPanel.Size = new System.Drawing.Size(593, 333);
            this.contentQuestionPanel.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbExplain);
            this.splitContainer.Panel2.Controls.Add(this.lbExplain);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(588, 331);
            this.splitContainer.SplitterDistance = 201;
            this.splitContainer.TabIndex = 1;
            // 
            // tbExplain
            // 
            this.tbExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExplain.Location = new System.Drawing.Point(4, 17);
            this.tbExplain.Multiline = true;
            this.tbExplain.Name = "tbExplain";
            this.tbExplain.Size = new System.Drawing.Size(577, 102);
            this.tbExplain.TabIndex = 1;
            this.tbExplain.Text = "This is explain of question";
            // 
            // lbExplain
            // 
            this.lbExplain.AutoSize = true;
            this.lbExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExplain.Location = new System.Drawing.Point(4, 0);
            this.lbExplain.Name = "lbExplain";
            this.lbExplain.Size = new System.Drawing.Size(48, 13);
            this.lbExplain.TabIndex = 0;
            this.lbExplain.Text = "Explain";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 331);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(15, 398);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Location = new System.Drawing.Point(96, 398);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // btCloseViewExplain
            // 
            this.btCloseViewExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCloseViewExplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseViewExplain.Location = new System.Drawing.Point(535, 398);
            this.btCloseViewExplain.Name = "btCloseViewExplain";
            this.btCloseViewExplain.Size = new System.Drawing.Size(75, 23);
            this.btCloseViewExplain.TabIndex = 4;
            this.btCloseViewExplain.Text = "Close";
            this.btCloseViewExplain.UseVisualStyleBackColor = true;
            // 
            // goToQuesNumcomboBox
            // 
            this.goToQuesNumcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goToQuesNumcomboBox.FormattingEnabled = true;
            this.goToQuesNumcomboBox.Location = new System.Drawing.Point(366, 400);
            this.goToQuesNumcomboBox.Name = "goToQuesNumcomboBox";
            this.goToQuesNumcomboBox.Size = new System.Drawing.Size(82, 21);
            this.goToQuesNumcomboBox.TabIndex = 5;
            // 
            // goToQuesNumLabel
            // 
            this.goToQuesNumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goToQuesNumLabel.AutoSize = true;
            this.goToQuesNumLabel.Location = new System.Drawing.Point(258, 403);
            this.goToQuesNumLabel.Name = "goToQuesNumLabel";
            this.goToQuesNumLabel.Size = new System.Drawing.Size(102, 13);
            this.goToQuesNumLabel.TabIndex = 6;
            this.goToQuesNumLabel.Text = "Go To Question No:";
            // 
            // sendFeedBackLabel
            // 
            this.sendFeedBackLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendFeedBackLabel.AutoSize = true;
            this.sendFeedBackLabel.Location = new System.Drawing.Point(524, 431);
            this.sendFeedBackLabel.Name = "sendFeedBackLabel";
            this.sendFeedBackLabel.Size = new System.Drawing.Size(83, 13);
            this.sendFeedBackLabel.TabIndex = 7;
            this.sendFeedBackLabel.Text = "Send Feedback";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Explain";
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestion.Location = new System.Drawing.Point(18, 40);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(85, 13);
            this.lbQuestion.TabIndex = 9;
            this.lbQuestion.Text = "Question XXX";
            // 
            // QuestionExplainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendFeedBackLabel);
            this.Controls.Add(this.goToQuesNumLabel);
            this.Controls.Add(this.goToQuesNumcomboBox);
            this.Controls.Add(this.btCloseViewExplain);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.contentQuestionPanel);
            this.Name = "QuestionExplainPanel";
            this.Size = new System.Drawing.Size(629, 451);
            this.contentQuestionPanel.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentQuestionPanel;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button btCloseViewExplain;
        private System.Windows.Forms.ComboBox goToQuesNumcomboBox;
        private System.Windows.Forms.Label goToQuesNumLabel;
        private System.Windows.Forms.Label sendFeedBackLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.TextBox tbExplain;
        private System.Windows.Forms.Label lbExplain;
    }
}
