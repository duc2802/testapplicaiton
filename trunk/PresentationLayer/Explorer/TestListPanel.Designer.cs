using System.Drawing;

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
            this.testListBox = new System.Windows.Forms.TableLayoutPanel();
            this.headingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testListBox
            // 
            this.testListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.testListBox.AutoScroll = true;
            this.testListBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.testListBox.Location = new System.Drawing.Point(3, 33);
            this.testListBox.Name = "testListBox";
            this.testListBox.Size = new System.Drawing.Size(175, 381);
            this.testListBox.TabIndex = 0;
            // 
            // headingButton
            // 
            this.headingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.headingButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.headingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.headingButton.Location = new System.Drawing.Point(3, 4);
            this.headingButton.Name = "headingButton";
            this.headingButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.headingButton.Size = new System.Drawing.Size(175, 23);
            this.headingButton.TabIndex = 1;
            this.headingButton.Text = "Test Collection";
            this.headingButton.UseVisualStyleBackColor = false;
            // 
            // TestListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.headingButton);
            this.Controls.Add(this.testListBox);
            this.Name = "TestListPanel";
            this.Size = new System.Drawing.Size(181, 414);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel testListBox;
        private System.Windows.Forms.Button headingButton;
    }
}
