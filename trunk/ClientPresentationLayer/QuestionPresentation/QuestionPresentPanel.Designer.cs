namespace ClientPresentationLayer.QuestionPresentation
{
    partial class QuestionPresentPanel
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
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.endExamButton = new System.Windows.Forms.Button();
            this.reviewButton = new System.Windows.Forms.Button();
            this.goToQuesNumcomboBox = new System.Windows.Forms.ComboBox();
            this.goToQuesNumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contentQuestionPanel
            // 
            this.contentQuestionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentQuestionPanel.BackColor = System.Drawing.Color.White;
            this.contentQuestionPanel.Location = new System.Drawing.Point(3, 64);
            this.contentQuestionPanel.Name = "contentQuestionPanel";
            this.contentQuestionPanel.Size = new System.Drawing.Size(623, 369);
            this.contentQuestionPanel.TabIndex = 0;
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(2, 439);
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
            this.nextButton.Location = new System.Drawing.Point(83, 439);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // endExamButton
            // 
            this.endExamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endExamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endExamButton.Location = new System.Drawing.Point(551, 439);
            this.endExamButton.Name = "endExamButton";
            this.endExamButton.Size = new System.Drawing.Size(75, 23);
            this.endExamButton.TabIndex = 4;
            this.endExamButton.Text = "End Exam";
            this.endExamButton.UseVisualStyleBackColor = true;
            // 
            // reviewButton
            // 
            this.reviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewButton.Location = new System.Drawing.Point(470, 439);
            this.reviewButton.Name = "reviewButton";
            this.reviewButton.Size = new System.Drawing.Size(75, 23);
            this.reviewButton.TabIndex = 3;
            this.reviewButton.Text = "Review";
            this.reviewButton.UseVisualStyleBackColor = true;
            // 
            // goToQuesNumcomboBox
            // 
            this.goToQuesNumcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goToQuesNumcomboBox.FormattingEnabled = true;
            this.goToQuesNumcomboBox.Location = new System.Drawing.Point(382, 441);
            this.goToQuesNumcomboBox.Name = "goToQuesNumcomboBox";
            this.goToQuesNumcomboBox.Size = new System.Drawing.Size(82, 21);
            this.goToQuesNumcomboBox.TabIndex = 5;
            // 
            // goToQuesNumLabel
            // 
            this.goToQuesNumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goToQuesNumLabel.AutoSize = true;
            this.goToQuesNumLabel.Location = new System.Drawing.Point(274, 444);
            this.goToQuesNumLabel.Name = "goToQuesNumLabel";
            this.goToQuesNumLabel.Size = new System.Drawing.Size(102, 13);
            this.goToQuesNumLabel.TabIndex = 6;
            this.goToQuesNumLabel.Text = "Go To Question No:";
            // 
            // QuestionPresentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goToQuesNumLabel);
            this.Controls.Add(this.goToQuesNumcomboBox);
            this.Controls.Add(this.endExamButton);
            this.Controls.Add(this.reviewButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.contentQuestionPanel);
            this.Name = "QuestionPresentPanel";
            this.Size = new System.Drawing.Size(629, 465);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentQuestionPanel;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button endExamButton;
        private System.Windows.Forms.Button reviewButton;
        private System.Windows.Forms.ComboBox goToQuesNumcomboBox;
        private System.Windows.Forms.Label goToQuesNumLabel;
    }
}
