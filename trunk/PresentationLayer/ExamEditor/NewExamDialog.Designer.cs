namespace PresentationLayer.ExamEditor
{
    partial class NewExamDialog
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
            this.nameExamTextBox = new System.Windows.Forms.TextBox();
            this.lbTimeExam = new System.Windows.Forms.Label();
            this.timeTestTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numQuestionTextBox = new System.Windows.Forms.TextBox();
            this.createExamButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNameExam
            // 
            this.lbNameExam.AutoSize = true;
            this.lbNameExam.Location = new System.Drawing.Point(7, 19);
            this.lbNameExam.Name = "lbNameExam";
            this.lbNameExam.Size = new System.Drawing.Size(64, 13);
            this.lbNameExam.TabIndex = 0;
            this.lbNameExam.Text = "Name Exam";
            // 
            // nameExamTextBox
            // 
            this.nameExamTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameExamTextBox.Location = new System.Drawing.Point(105, 12);
            this.nameExamTextBox.Multiline = true;
            this.nameExamTextBox.Name = "nameExamTextBox";
            this.nameExamTextBox.Size = new System.Drawing.Size(366, 35);
            this.nameExamTextBox.TabIndex = 1;
            this.nameExamTextBox.TextChanged += new System.EventHandler(this.NameExamTextBoxChanged);
            // 
            // lbTimeExam
            // 
            this.lbTimeExam.AutoSize = true;
            this.lbTimeExam.Location = new System.Drawing.Point(7, 90);
            this.lbTimeExam.Name = "lbTimeExam";
            this.lbTimeExam.Size = new System.Drawing.Size(30, 13);
            this.lbTimeExam.TabIndex = 2;
            this.lbTimeExam.Text = "Time";
            // 
            // timeTestTextBox
            // 
            this.timeTestTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeTestTextBox.Location = new System.Drawing.Point(105, 84);
            this.timeTestTextBox.Name = "timeTestTextBox";
            this.timeTestTextBox.Size = new System.Drawing.Size(139, 20);
            this.timeTestTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minutes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number Question";
            // 
            // numQuestionTextBox
            // 
            this.numQuestionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numQuestionTextBox.Location = new System.Drawing.Point(105, 54);
            this.numQuestionTextBox.Name = "numQuestionTextBox";
            this.numQuestionTextBox.Size = new System.Drawing.Size(139, 20);
            this.numQuestionTextBox.TabIndex = 2;
            // 
            // createExamButton
            // 
            this.createExamButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createExamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createExamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createExamButton.Location = new System.Drawing.Point(164, 118);
            this.createExamButton.Name = "createExamButton";
            this.createExamButton.Size = new System.Drawing.Size(75, 23);
            this.createExamButton.TabIndex = 4;
            this.createExamButton.Text = "Create";
            this.createExamButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(245, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // NewExamDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 154);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createExamButton);
            this.Controls.Add(this.numQuestionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTestTextBox);
            this.Controls.Add(this.lbTimeExam);
            this.Controls.Add(this.nameExamTextBox);
            this.Controls.Add(this.lbNameExam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewExamDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Exam Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameExam;
        private System.Windows.Forms.TextBox nameExamTextBox;
        private System.Windows.Forms.Label lbTimeExam;
        private System.Windows.Forms.TextBox timeTestTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numQuestionTextBox;
        private System.Windows.Forms.Button createExamButton;
        private System.Windows.Forms.Button cancelButton;
    }
}