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
            this.answerItemCheckBox = new System.Windows.Forms.CheckBox();
            this.lbAnswerContent = new System.Windows.Forms.Label();
            this.btTrueFail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderAnswer
            // 
            this.orderAnswer.AutoSize = true;
            this.orderAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderAnswer.Location = new System.Drawing.Point(52, 9);
            this.orderAnswer.Name = "orderAnswer";
            this.orderAnswer.Size = new System.Drawing.Size(15, 15);
            this.orderAnswer.TabIndex = 4;
            this.orderAnswer.Text = "1";
            // 
            // answerItemCheckBox
            // 
            this.answerItemCheckBox.AutoSize = true;
            this.answerItemCheckBox.Location = new System.Drawing.Point(89, 10);
            this.answerItemCheckBox.Name = "answerItemCheckBox";
            this.answerItemCheckBox.Size = new System.Drawing.Size(15, 14);
            this.answerItemCheckBox.TabIndex = 5;
            this.answerItemCheckBox.UseVisualStyleBackColor = true;
            // 
            // lbAnswerContent
            // 
            this.lbAnswerContent.AutoSize = true;
            this.lbAnswerContent.Location = new System.Drawing.Point(110, 10);
            this.lbAnswerContent.Name = "lbAnswerContent";
            this.lbAnswerContent.Size = new System.Drawing.Size(177, 13);
            this.lbAnswerContent.TabIndex = 6;
            this.lbAnswerContent.Text = "This is Answer Content abcd eghigk";
            // 
            // btTrueFail
            // 
            this.btTrueFail.FlatAppearance.BorderSize = 0;
            this.btTrueFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTrueFail.Image = global::ClientPresentationLayer.Properties.Resources._true;
            this.btTrueFail.Location = new System.Drawing.Point(14, 0);
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
            this.Controls.Add(this.answerItemCheckBox);
            this.Controls.Add(this.orderAnswer);
            this.Name = "AnswerItem";
            this.Size = new System.Drawing.Size(515, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderAnswer;
        private System.Windows.Forms.CheckBox answerItemCheckBox;
        private System.Windows.Forms.Label lbAnswerContent;
        private System.Windows.Forms.Button btTrueFail;
    }
}
