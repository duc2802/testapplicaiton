namespace PresentationLayer.ExamEditor
{
    partial class NewExam
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNameExam = new System.Windows.Forms.Label();
            this.tbNameExam = new System.Windows.Forms.TextBox();
            this.lbTimeExam = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumberQuestion = new System.Windows.Forms.TextBox();
            this.btCreateExam = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNameExam
            // 
            this.lbNameExam.AutoSize = true;
            this.lbNameExam.Location = new System.Drawing.Point(12, 88);
            this.lbNameExam.Name = "lbNameExam";
            this.lbNameExam.Size = new System.Drawing.Size(64, 13);
            this.lbNameExam.TabIndex = 0;
            this.lbNameExam.Text = "Name Exam";
            // 
            // tbNameExam
            // 
            this.tbNameExam.Location = new System.Drawing.Point(99, 81);
            this.tbNameExam.Multiline = true;
            this.tbNameExam.Name = "tbNameExam";
            this.tbNameExam.Size = new System.Drawing.Size(193, 131);
            this.tbNameExam.TabIndex = 1;
            this.tbNameExam.TextChanged += new System.EventHandler(this.tbNameExam_TextChanged);
            // 
            // lbTimeExam
            // 
            this.lbTimeExam.AutoSize = true;
            this.lbTimeExam.Location = new System.Drawing.Point(12, 52);
            this.lbTimeExam.Name = "lbTimeExam";
            this.lbTimeExam.Size = new System.Drawing.Size(30, 13);
            this.lbTimeExam.TabIndex = 2;
            this.lbTimeExam.Text = "Time";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(99, 49);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(139, 20);
            this.tbTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number Question";
            // 
            // tbNumberQuestion
            // 
            this.tbNumberQuestion.Location = new System.Drawing.Point(99, 16);
            this.tbNumberQuestion.Name = "tbNumberQuestion";
            this.tbNumberQuestion.Size = new System.Drawing.Size(139, 20);
            this.tbNumberQuestion.TabIndex = 6;
            // 
            // btCreateExam
            // 
            this.btCreateExam.Location = new System.Drawing.Point(217, 231);
            this.btCreateExam.Name = "btCreateExam";
            this.btCreateExam.Size = new System.Drawing.Size(75, 23);
            this.btCreateExam.TabIndex = 7;
            this.btCreateExam.Text = "Create";
            this.btCreateExam.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(127, 231);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // NewExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 267);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btCreateExam);
            this.Controls.Add(this.tbNumberQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.lbTimeExam);
            this.Controls.Add(this.tbNameExam);
            this.Controls.Add(this.lbNameExam);
            this.Name = "NewExam";
            this.Text = "NewExam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameExam;
        private System.Windows.Forms.TextBox tbNameExam;
        private System.Windows.Forms.Label lbTimeExam;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumberQuestion;
        private System.Windows.Forms.Button btCreateExam;
        private System.Windows.Forms.Button btCancel;
    }
}