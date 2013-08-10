namespace PresentationLayer.QuestionEditor
{
    partial class HTMLQuestionEditor
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
            this.contentQuestionPanel = new System.Windows.Forms.Panel();
            this.explainQuestionPanel = new System.Windows.Forms.Panel();
            this.answerListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.lbExplain = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.moreAnswerButton = new System.Windows.Forms.Button();
            this.insertEquaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contentQuestionPanel
            // 
            this.contentQuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentQuestionPanel.Location = new System.Drawing.Point(75, 12);
            this.contentQuestionPanel.Name = "contentQuestionPanel";
            this.contentQuestionPanel.Size = new System.Drawing.Size(448, 245);
            this.contentQuestionPanel.TabIndex = 0;
            // 
            // explainQuestionPanel
            // 
            this.explainQuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.explainQuestionPanel.Location = new System.Drawing.Point(75, 263);
            this.explainQuestionPanel.Name = "explainQuestionPanel";
            this.explainQuestionPanel.Size = new System.Drawing.Size(448, 258);
            this.explainQuestionPanel.TabIndex = 1;
            // 
            // answerListTableLayoutPanel
            // 
            this.answerListTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerListTableLayoutPanel.AutoSize = true;
            this.answerListTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.answerListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 528F));
            this.answerListTableLayoutPanel.Location = new System.Drawing.Point(529, 12);
            this.answerListTableLayoutPanel.Name = "answerListTableLayoutPanel";
            this.answerListTableLayoutPanel.Size = new System.Drawing.Size(528, 0);
            this.answerListTableLayoutPanel.TabIndex = 10;
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestion.Location = new System.Drawing.Point(12, 12);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(61, 13);
            this.lbQuestion.TabIndex = 11;
            this.lbQuestion.Text = "Question:";
            // 
            // lbExplain
            // 
            this.lbExplain.AutoSize = true;
            this.lbExplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExplain.Location = new System.Drawing.Point(12, 263);
            this.lbExplain.Name = "lbExplain";
            this.lbExplain.Size = new System.Drawing.Size(56, 13);
            this.lbExplain.TabIndex = 12;
            this.lbExplain.Text = "Explain: ";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(909, 498);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(99, 23);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "Cancel";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Location = new System.Drawing.Point(799, 498);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(104, 23);
            this.createButton.TabIndex = 13;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // moreAnswerButton
            // 
            this.moreAnswerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moreAnswerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.moreAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreAnswerButton.Location = new System.Drawing.Point(673, 498);
            this.moreAnswerButton.Name = "moreAnswerButton";
            this.moreAnswerButton.Size = new System.Drawing.Size(120, 23);
            this.moreAnswerButton.TabIndex = 15;
            this.moreAnswerButton.Text = "More Answer ...";
            this.moreAnswerButton.UseVisualStyleBackColor = true;
            // 
            // insertEquaButton
            // 
            this.insertEquaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.insertEquaButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.insertEquaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertEquaButton.Location = new System.Drawing.Point(547, 498);
            this.insertEquaButton.Name = "insertEquaButton";
            this.insertEquaButton.Size = new System.Drawing.Size(120, 23);
            this.insertEquaButton.TabIndex = 16;
            this.insertEquaButton.Text = "Insert Equation";
            this.insertEquaButton.UseVisualStyleBackColor = true;
            this.insertEquaButton.Visible = false;
            // 
            // HTMLQuestionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 528);
            this.Controls.Add(this.insertEquaButton);
            this.Controls.Add(this.moreAnswerButton);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.lbExplain);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.answerListTableLayoutPanel);
            this.Controls.Add(this.explainQuestionPanel);
            this.Controls.Add(this.contentQuestionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HTMLQuestionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentQuestionPanel;
        private System.Windows.Forms.Panel explainQuestionPanel;
        private System.Windows.Forms.TableLayoutPanel answerListTableLayoutPanel;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Label lbExplain;
        private System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.Button createButton;
        public System.Windows.Forms.Button moreAnswerButton;
        public System.Windows.Forms.Button insertEquaButton;
    }
}