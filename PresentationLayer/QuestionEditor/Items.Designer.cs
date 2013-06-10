namespace PresentationLayer.QuestionEditor
{
    partial class Items
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
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbIDQuestion = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Location = new System.Drawing.Point(297, 17);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(48, 23);
            this.checkBoxX1.TabIndex = 8;
            this.checkBoxX1.Text = "True";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Location = new System.Drawing.Point(51, 18);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(240, 20);
            this.textBoxX1.TabIndex = 7;
            // 
            // lbIDQuestion
            // 
            this.lbIDQuestion.Location = new System.Drawing.Point(20, 18);
            this.lbIDQuestion.Name = "lbIDQuestion";
            this.lbIDQuestion.Size = new System.Drawing.Size(25, 19);
            this.lbIDQuestion.TabIndex = 6;
            this.lbIDQuestion.Text = "1";
            this.lbIDQuestion.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 51);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.lbIDQuestion);
            this.Name = "Items";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX lbIDQuestion;

    }
}
