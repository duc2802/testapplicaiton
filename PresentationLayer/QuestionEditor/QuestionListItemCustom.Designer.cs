namespace PresentationLayer.QuestionEditor
{
    partial class QuestionListItemCustom
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
            this.contentQuestionTextBox = new System.Windows.Forms.TextBox();
            this.answerChoiseContainer = new System.Windows.Forms.Panel();
            this.orderNumQuest = new System.Windows.Forms.Label();
            this.answerChoiseContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentQuestionTextBox
            // 
            this.contentQuestionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentQuestionTextBox.BackColor = System.Drawing.Color.White;
            this.contentQuestionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentQuestionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentQuestionTextBox.Location = new System.Drawing.Point(26, 39);
            this.contentQuestionTextBox.Multiline = true;
            this.contentQuestionTextBox.Name = "contentQuestionTextBox";
            this.contentQuestionTextBox.AutoSize = true;
            this.contentQuestionTextBox.ReadOnly = true;
            this.contentQuestionTextBox.Size = new System.Drawing.Size(454, 81);
            this.contentQuestionTextBox.TabIndex = 1;
            // 
            // answerChoiseContainer
            // 
            this.answerChoiseContainer.AutoSize = true;
            this.answerChoiseContainer.Controls.Add(this.orderNumQuest);
            this.answerChoiseContainer.Controls.Add(this.contentQuestionTextBox);
            this.answerChoiseContainer.Location = new System.Drawing.Point(0, 0);
            this.answerChoiseContainer.Name = "answerChoiseContainer";
            this.answerChoiseContainer.Size = new System.Drawing.Size(503, 157);
            this.answerChoiseContainer.TabIndex = 1;
            // 
            // orderNumQuest
            // 
            this.orderNumQuest.AutoSize = true;
            this.orderNumQuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderNumQuest.Location = new System.Drawing.Point(26, 17);
            this.orderNumQuest.Name = "orderNumQuest";
            this.orderNumQuest.Size = new System.Drawing.Size(21, 15);
            this.orderNumQuest.TabIndex = 2;
            this.orderNumQuest.Text = "15";
            // 
            // QuestionListItemCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.answerChoiseContainer);
            this.Name = "QuestionListItemCustom";
            this.Size = new System.Drawing.Size(506, 160);
            this.answerChoiseContainer.ResumeLayout(false);
            this.answerChoiseContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentQuestionTextBox;
        private System.Windows.Forms.Panel answerChoiseContainer;
        private System.Windows.Forms.Label orderNumQuest;

    }
}
