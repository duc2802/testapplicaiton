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
            this.lbItemNumer = new DevComponents.DotNetBar.LabelX();
            this.cbResultItem = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tbItemContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lbItemNumer
            // 
            this.lbItemNumer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbItemNumer.Location = new System.Drawing.Point(22, 14);
            this.lbItemNumer.Name = "lbItemNumer";
            this.lbItemNumer.Size = new System.Drawing.Size(23, 23);
            this.lbItemNumer.TabIndex = 0;
            this.lbItemNumer.Text = "<b>1</b>";
            this.lbItemNumer.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbResultItem
            // 
            this.cbResultItem.Location = new System.Drawing.Point(310, 14);
            this.cbResultItem.Name = "cbResultItem";
            this.cbResultItem.Size = new System.Drawing.Size(53, 23);
            this.cbResultItem.TabIndex = 1;
            this.cbResultItem.Text = "True";
            // 
            // tbItemContent
            // 
            // 
            // 
            // 
            this.tbItemContent.Border.Class = "TextBoxBorder";
            this.tbItemContent.Location = new System.Drawing.Point(65, 14);
            this.tbItemContent.Name = "tbItemContent";
            this.tbItemContent.Size = new System.Drawing.Size(239, 23);
            this.tbItemContent.TabIndex = 2;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbItemContent);
            this.Controls.Add(this.cbResultItem);
            this.Controls.Add(this.lbItemNumer);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(366, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbItemNumer;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbResultItem;
        private DevComponents.DotNetBar.Controls.TextBoxX tbItemContent;
    }
}
