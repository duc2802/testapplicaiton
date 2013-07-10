namespace ClientPresentationLayer.QuestionPresentation
{
    partial class HTMLQuestionPresentPanel
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
            this.components = new System.ComponentModel.Container();
            this.contentQuestionPanel = new System.Windows.Forms.Panel();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.endExamButton = new System.Windows.Forms.Button();
            this.reviewButton = new System.Windows.Forms.Button();
            this.goToQuesNumcomboBox = new System.Windows.Forms.ComboBox();
            this.goToQuesNumLabel = new System.Windows.Forms.Label();
            this.sendFeedBackLabel = new System.Windows.Forms.Label();
            this.lbQuestionLB = new System.Windows.Forms.Label();
            this.timeTest = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.orderQuestionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNameExam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contentQuestionPanel
            // 
            this.contentQuestionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentQuestionPanel.BackColor = System.Drawing.Color.White;
            this.contentQuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentQuestionPanel.Location = new System.Drawing.Point(17, 64);
            this.contentQuestionPanel.Name = "contentQuestionPanel";
            this.contentQuestionPanel.Size = new System.Drawing.Size(593, 328);
            this.contentQuestionPanel.TabIndex = 0;
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
            // endExamButton
            // 
            this.endExamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endExamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endExamButton.Location = new System.Drawing.Point(535, 398);
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
            this.reviewButton.Location = new System.Drawing.Point(454, 398);
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
            // lbQuestionLB
            // 
            this.lbQuestionLB.AutoSize = true;
            this.lbQuestionLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestionLB.Location = new System.Drawing.Point(14, 38);
            this.lbQuestionLB.Name = "lbQuestionLB";
            this.lbQuestionLB.Size = new System.Drawing.Size(65, 13);
            this.lbQuestionLB.TabIndex = 10;
            this.lbQuestionLB.Text = "Question :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(488, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Time :";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(536, 38);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(52, 13);
            this.lbTime.TabIndex = 12;
            this.lbTime.Text = " 24:25:30";
            // 
            // orderQuestionLabel
            // 
            this.orderQuestionLabel.AutoSize = true;
            this.orderQuestionLabel.Location = new System.Drawing.Point(86, 38);
            this.orderQuestionLabel.Name = "orderQuestionLabel";
            this.orderQuestionLabel.Size = new System.Drawing.Size(13, 13);
            this.orderQuestionLabel.TabIndex = 13;
            this.orderQuestionLabel.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Exam :";
            // 
            // lbNameExam
            // 
            this.lbNameExam.AutoSize = true;
            this.lbNameExam.Location = new System.Drawing.Point(71, 16);
            this.lbNameExam.Name = "lbNameExam";
            this.lbNameExam.Size = new System.Drawing.Size(75, 13);
            this.lbNameExam.TabIndex = 15;
            this.lbNameExam.Text = "Name of exam";
            // 
            // QuestionPresentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbNameExam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderQuestionLabel);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbQuestionLB);
            this.Controls.Add(this.sendFeedBackLabel);
            this.Controls.Add(this.goToQuesNumLabel);
            this.Controls.Add(this.goToQuesNumcomboBox);
            this.Controls.Add(this.endExamButton);
            this.Controls.Add(this.reviewButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.contentQuestionPanel);
            this.Name = "QuestionPresentPanel";
            this.Size = new System.Drawing.Size(629, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel contentQuestionPanel;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button endExamButton;
        private System.Windows.Forms.Button reviewButton;
        private System.Windows.Forms.ComboBox goToQuesNumcomboBox;
        private System.Windows.Forms.Label goToQuesNumLabel;
        private System.Windows.Forms.Label sendFeedBackLabel;
        private System.Windows.Forms.Label lbQuestionLB;
        private System.Windows.Forms.Timer timeTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label orderQuestionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNameExam;
    }
}
