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
            this.lbNameExam = new System.Windows.Forms.Label();
            this.dateTextValue = new System.Windows.Forms.Label();
            this.lbNumberQuestion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTimeExam = new System.Windows.Forms.Label();
            this.Minute = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(14, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(43, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Name:";
            // 
            // lbNameExam
            // 
            this.lbNameExam.AutoSize = true;
            this.lbNameExam.Location = new System.Drawing.Point(51, 9);
            this.lbNameExam.Name = "lbNameExam";
            this.lbNameExam.Size = new System.Drawing.Size(90, 13);
            this.lbNameExam.TabIndex = 1;
            this.lbNameExam.Text = "Bai test cho HK 2";
            // 
            // dateTextValue
            // 
            this.dateTextValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTextValue.AutoSize = true;
            this.dateTextValue.Location = new System.Drawing.Point(157, 9);
            this.dateTextValue.Name = "dateTextValue";
            this.dateTextValue.Size = new System.Drawing.Size(65, 13);
            this.dateTextValue.TabIndex = 2;
            this.dateTextValue.Text = "22/05/2013";
            // 
            // lbNumberQuestion
            // 
            this.lbNumberQuestion.AutoSize = true;
            this.lbNumberQuestion.Location = new System.Drawing.Point(132, 35);
            this.lbNumberQuestion.Name = "lbNumberQuestion";
            this.lbNumberQuestion.Size = new System.Drawing.Size(13, 13);
            this.lbNumberQuestion.TabIndex = 3;
            this.lbNumberQuestion.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number Question:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time of Exam:";
            // 
            // lbTimeExam
            // 
            this.lbTimeExam.AutoSize = true;
            this.lbTimeExam.Location = new System.Drawing.Point(132, 60);
            this.lbTimeExam.Name = "lbTimeExam";
            this.lbTimeExam.Size = new System.Drawing.Size(19, 13);
            this.lbTimeExam.TabIndex = 3;
            this.lbTimeExam.Text = "30";
            // 
            // Minute
            // 
            this.Minute.AutoSize = true;
            this.Minute.Location = new System.Drawing.Point(170, 60);
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(39, 13);
            this.Minute.TabIndex = 6;
            this.Minute.Text = "Minute";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(225, 50);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(37, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Del";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // TestListItemCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.Minute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTimeExam);
            this.Controls.Add(this.lbNumberQuestion);
            this.Controls.Add(this.dateTextValue);
            this.Controls.Add(this.lbNameExam);
            this.Controls.Add(this.titleLabel);
            this.Name = "TestListItemCustom";
            this.Size = new System.Drawing.Size(265, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lbNameExam;
        private System.Windows.Forms.Label dateTextValue;
        private System.Windows.Forms.Label lbNumberQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTimeExam;
        private System.Windows.Forms.Label Minute;
        private System.Windows.Forms.Button deleteButton;
    }
}
