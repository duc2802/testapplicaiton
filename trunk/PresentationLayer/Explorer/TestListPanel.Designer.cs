namespace PresentationLayer.Explorer
{
    partial class TestListPanel
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
            this.testListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // testListBox
            // 
            this.testListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testListBox.FormattingEnabled = true;
            this.testListBox.Location = new System.Drawing.Point(0, 0);
            this.testListBox.Name = "testListBox";
            this.testListBox.Size = new System.Drawing.Size(181, 414);
            this.testListBox.TabIndex = 0;
            // 
            // TestListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testListBox);
            this.Name = "TestListPanel";
            this.Size = new System.Drawing.Size(181, 414);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox testListBox;
    }
}
