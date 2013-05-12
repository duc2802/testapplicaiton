namespace PresentationLayer.Explorer
{
    partial class TestListItemCustom
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextValue = new System.Windows.Forms.Label();
            this.dateTextValue = new System.Windows.Forms.Label();
            this.noteTextValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(14, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(36, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title:";
            // 
            // titleTextValue
            // 
            this.titleTextValue.AutoSize = true;
            this.titleTextValue.Location = new System.Drawing.Point(51, 9);
            this.titleTextValue.Name = "titleTextValue";
            this.titleTextValue.Size = new System.Drawing.Size(90, 13);
            this.titleTextValue.TabIndex = 1;
            this.titleTextValue.Text = "Bai test cho HK 2";
            // 
            // dateTextValue
            // 
            this.dateTextValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTextValue.AutoSize = true;
            this.dateTextValue.Location = new System.Drawing.Point(159, 9);
            this.dateTextValue.Name = "dateTextValue";
            this.dateTextValue.Size = new System.Drawing.Size(65, 13);
            this.dateTextValue.TabIndex = 2;
            this.dateTextValue.Text = "22/05/2013";
            // 
            // noteTextValue
            // 
            this.noteTextValue.AutoSize = true;
            this.noteTextValue.Location = new System.Drawing.Point(17, 26);
            this.noteTextValue.Name = "noteTextValue";
            this.noteTextValue.Size = new System.Drawing.Size(193, 13);
            this.noteTextValue.TabIndex = 3;
            this.noteTextValue.Text = "Comment: So luong cau hoi trong de thi";
            // 
            // ListTestItemCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.noteTextValue);
            this.Controls.Add(this.dateTextValue);
            this.Controls.Add(this.titleTextValue);
            this.Controls.Add(this.titleLabel);
            this.Name = "ListTestItemCustom";
            this.Size = new System.Drawing.Size(237, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label titleTextValue;
        private System.Windows.Forms.Label dateTextValue;
        private System.Windows.Forms.Label noteTextValue;
    }
}
