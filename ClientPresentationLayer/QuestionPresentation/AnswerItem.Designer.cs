namespace ClientPresentationLayer.QuestionPresentation
{
    partial class AnswerItem
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
            this.orderAnswer = new System.Windows.Forms.Label();
            this.cbAnswerItem = new System.Windows.Forms.CheckBox();
            this.lbAnswerContent = new System.Windows.Forms.Label();
            this.btTrueFail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderAnswer
            // 
            this.orderAnswer.AutoSize = true;
            this.orderAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderAnswer.Location = new System.Drawing.Point(21, 17);
            this.orderAnswer.Name = "orderAnswer";
            this.orderAnswer.Size = new System.Drawing.Size(15, 15);
            this.orderAnswer.TabIndex = 4;
            this.orderAnswer.Text = "1";
            // 
            // cbAnswerItem
            // 
            this.cbAnswerItem.AutoSize = true;
            this.cbAnswerItem.Location = new System.Drawing.Point(58, 17);
            this.cbAnswerItem.Name = "cbAnswerItem";
            this.cbAnswerItem.Size = new System.Drawing.Size(15, 14);
            this.cbAnswerItem.TabIndex = 5;
            this.cbAnswerItem.UseVisualStyleBackColor = true;
            // 
            // lbAnswerContent
            // 
            this.lbAnswerContent.AutoSize = true;
            this.lbAnswerContent.Location = new System.Drawing.Point(80, 17);
            this.lbAnswerContent.Name = "lbAnswerContent";
            this.lbAnswerContent.Size = new System.Drawing.Size(177, 13);
            this.lbAnswerContent.TabIndex = 6;
            this.lbAnswerContent.Text = "This is Answer Content abcd eghigk";
            // 
            // btTrueFail
            // 
            this.btTrueFail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btTrueFail.FlatAppearance.BorderSize = 0;
            this.btTrueFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTrueFail.Image = global::ClientPresentationLayer.Properties.Resources._true;
            this.btTrueFail.Location = new System.Drawing.Point(480, 12);
            this.btTrueFail.Name = "btTrueFail";
            this.btTrueFail.Size = new System.Drawing.Size(32, 23);
            this.btTrueFail.TabIndex = 7;
            this.btTrueFail.UseVisualStyleBackColor = true;
            // 
            // AnswerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btTrueFail);
            this.Controls.Add(this.lbAnswerContent);
            this.Controls.Add(this.cbAnswerItem);
            this.Controls.Add(this.orderAnswer);
            this.Name = "AnswerItem";
            this.Size = new System.Drawing.Size(515, 48);
            this.Load += new System.EventHandler(this.AnswerItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderAnswer;
        private System.Windows.Forms.CheckBox cbAnswerItem;
        private System.Windows.Forms.Label lbAnswerContent;
        private System.Windows.Forms.Button btTrueFail;
    }
}
