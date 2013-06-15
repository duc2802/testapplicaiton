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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 5;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbTrue);
            this.Controls.Add(this.orderAnswer);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(366, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderAnswer;
        private System.Windows.Forms.CheckBox cbTrue;
        private System.Windows.Forms.TextBox textBox1;

    }
}
