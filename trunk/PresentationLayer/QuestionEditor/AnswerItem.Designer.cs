﻿namespace PresentationLayer.QuestionEditor
{
    partial class AnswerItem
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
            this.lbAnswer = new System.Windows.Forms.Label();
            this.lbResultAnswer = new System.Windows.Forms.Label();
            this.lbContentAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbAnswer.Location = new System.Drawing.Point(12, 11);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(14, 13);
            this.lbAnswer.TabIndex = 0;
            this.lbAnswer.Text = "A";
            // 
            // lbResultAnswer
            // 
            this.lbResultAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResultAnswer.AutoSize = true;
            this.lbResultAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbResultAnswer.Location = new System.Drawing.Point(196, 11);
            this.lbResultAnswer.Name = "lbResultAnswer";
            this.lbResultAnswer.Size = new System.Drawing.Size(29, 13);
            this.lbResultAnswer.TabIndex = 1;
            this.lbResultAnswer.Text = "True";
            // 
            // lbContentAnswer
            // 
            this.lbContentAnswer.AutoSize = true;
            this.lbContentAnswer.Location = new System.Drawing.Point(21, 34);
            this.lbContentAnswer.Name = "lbContentAnswer";
            this.lbContentAnswer.Size = new System.Drawing.Size(99, 13);
            this.lbContentAnswer.TabIndex = 2;
            this.lbContentAnswer.Text = "Nội dung câu trả lời";
            // 
            // AnswerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbContentAnswer);
            this.Controls.Add(this.lbResultAnswer);
            this.Controls.Add(this.lbAnswer);
            this.Name = "AnswerItem";
            this.Size = new System.Drawing.Size(237, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAnswer;
        private System.Windows.Forms.Label lbResultAnswer;
        private System.Windows.Forms.Label lbContentAnswer;
    }
}
