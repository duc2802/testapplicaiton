namespace PresentationLayer.QuestionEditor
{
    partial class QuestionListPanel
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
            this.questionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionPanel
            // 
            this.questionPanel.AutoScroll = true;
            this.questionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.questionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionPanel.Location = new System.Drawing.Point(0, 0);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(150, 150);
            this.questionPanel.TabIndex = 0;
            // 
            // headingButton
            // 
            this.headingButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.headingButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.headingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.headingButton.Location = new System.Drawing.Point(0, 0);
            this.headingButton.Name = "headingButton";
            this.headingButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.headingButton.Size = new System.Drawing.Size(150, 23);
            this.headingButton.TabIndex = 1;
            this.headingButton.Text = "Test Collection";
            this.headingButton.UseVisualStyleBackColor = false;
            // 
            // QuestionListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.headingButton);
            this.Controls.Add(this.questionPanel);
            this.Name = "QuestionListPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel questionPanel;
        private System.Windows.Forms.Button headingButton;
    }
}
