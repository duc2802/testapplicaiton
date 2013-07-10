namespace ClientPresentationLayer.QuestionPresentation
{
    partial class HTMLQuestionItem
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
            this.panelQuestionContent = new System.Windows.Forms.Panel();
            this.listAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // panelQuestionContent
            // 
            this.panelQuestionContent.Location = new System.Drawing.Point(14, 12);
            this.panelQuestionContent.Name = "panelQuestionContent";
            this.panelQuestionContent.Size = new System.Drawing.Size(549, 171);
            this.panelQuestionContent.TabIndex = 0;
            // 
            // listAnswer
            // 
            this.listAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listAnswer.AutoScroll = true;
            this.listAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.listAnswer.Location = new System.Drawing.Point(14, 189);
            this.listAnswer.Name = "listAnswer";
            this.listAnswer.Size = new System.Drawing.Size(552, 123);
            this.listAnswer.TabIndex = 1;
            // 
            // HTMLQuestionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listAnswer);
            this.Controls.Add(this.panelQuestionContent);
            this.Name = "HTMLQuestionItem";
            this.Size = new System.Drawing.Size(584, 333);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelQuestionContent;
        private System.Windows.Forms.TableLayoutPanel listAnswer;
    }
}
