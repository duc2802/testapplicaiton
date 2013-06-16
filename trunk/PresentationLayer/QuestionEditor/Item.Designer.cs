namespace PresentationLayer.QuestionEditor
{
    partial class Item
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
            this.cbTrue = new System.Windows.Forms.CheckBox();
            this.tbAnswerContent = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderAnswer
            // 
            this.orderAnswer.AutoSize = true;
            this.orderAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderAnswer.Location = new System.Drawing.Point(18, 16);
            this.orderAnswer.Name = "orderAnswer";
            this.orderAnswer.Size = new System.Drawing.Size(15, 15);
            this.orderAnswer.TabIndex = 3;
            this.orderAnswer.Text = "1";
            // 
            // cbTrue
            // 
            this.cbTrue.AutoSize = true;
            this.cbTrue.Location = new System.Drawing.Point(315, 16);
            this.cbTrue.Name = "cbTrue";
            this.cbTrue.Size = new System.Drawing.Size(48, 17);
            this.cbTrue.TabIndex = 4;
            this.cbTrue.Text = "True";
            this.cbTrue.UseVisualStyleBackColor = true;
            // 
            // tbAnswerContent
            // 
            this.tbAnswerContent.Location = new System.Drawing.Point(45, 14);
            this.tbAnswerContent.Name = "tbAnswerContent";
            this.tbAnswerContent.Size = new System.Drawing.Size(264, 20);
            this.tbAnswerContent.TabIndex = 5;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Location = new System.Drawing.Point(361, 11);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(21, 23);
            this.btDelete.TabIndex = 6;
            this.btDelete.Text = "X";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.tbAnswerContent);
            this.Controls.Add(this.cbTrue);
            this.Controls.Add(this.orderAnswer);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(385, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderAnswer;
        private System.Windows.Forms.CheckBox cbTrue;
        private System.Windows.Forms.TextBox tbAnswerContent;
        private System.Windows.Forms.Button btDelete;

    }
}
