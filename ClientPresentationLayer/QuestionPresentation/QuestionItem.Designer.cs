﻿namespace ClientPresentationLayer
{
    partial class QuestionItem
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
            this.tbQuestionContent = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tbListAnswerItem = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbQuestionContent
            // 
            this.tbQuestionContent.BackColor = System.Drawing.Color.White;
            this.tbQuestionContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbQuestionContent.Location = new System.Drawing.Point(12, 13);
            this.tbQuestionContent.Multiline = true;
            this.tbQuestionContent.Name = "tbQuestionContent";
            this.tbQuestionContent.Size = new System.Drawing.Size(394, 128);
            this.tbQuestionContent.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(413, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(87, 83);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tbListAnswerItem
            // 
            this.tbListAnswerItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbListAnswerItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbListAnswerItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 413F));
            this.tbListAnswerItem.Location = new System.Drawing.Point(12, 147);
            this.tbListAnswerItem.Name = "tbListAnswerItem";
            this.tbListAnswerItem.Size = new System.Drawing.Size(394, 96);
            this.tbListAnswerItem.TabIndex = 2;
            // 
            // QuestionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tbListAnswerItem);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.tbQuestionContent);
            this.Name = "QuestionItem";
            this.Size = new System.Drawing.Size(515, 254);
            this.Load += new System.EventHandler(this.QuestionItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQuestionContent;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tbListAnswerItem;
    }
}
