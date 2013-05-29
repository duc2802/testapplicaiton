namespace PresentationLayer.QuestionEditor
{
    partial class QuestionListItemCustom
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
            this.questionContainer = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numberQuestionLabel = new System.Windows.Forms.Label();
            this.answerChoiseContainer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbListAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.questionContainer.SuspendLayout();
            this.answerChoiseContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionContainer
            // 
            this.questionContainer.BackColor = System.Drawing.Color.White;
            this.questionContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionContainer.Controls.Add(this.textBox1);
            this.questionContainer.Controls.Add(this.numberQuestionLabel);
            this.questionContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.questionContainer.Location = new System.Drawing.Point(0, 0);
            this.questionContainer.Name = "questionContainer";
            this.questionContainer.Size = new System.Drawing.Size(500, 100);
            this.questionContainer.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(439, 76);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Mối quan hệ giữa ruột đối với ngũ cốc tương tự như bao thư đối với :";
            // 
            // numberQuestionLabel
            // 
            this.numberQuestionLabel.AutoSize = true;
            this.numberQuestionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberQuestionLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberQuestionLabel.ForeColor = System.Drawing.Color.Red;
            this.numberQuestionLabel.Location = new System.Drawing.Point(0, 0);
            this.numberQuestionLabel.Name = "numberQuestionLabel";
            this.numberQuestionLabel.Size = new System.Drawing.Size(22, 16);
            this.numberQuestionLabel.TabIndex = 0;
            this.numberQuestionLabel.Text = "15";
            // 
            // answerChoiseContainer
            // 
            this.answerChoiseContainer.AutoSize = true;
            this.answerChoiseContainer.Controls.Add(this.tbListAnswer);
            this.answerChoiseContainer.Controls.Add(this.questionContainer);
            this.answerChoiseContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerChoiseContainer.Location = new System.Drawing.Point(0, 0);
            this.answerChoiseContainer.Name = "answerChoiseContainer";
            this.answerChoiseContainer.Size = new System.Drawing.Size(500, 250);
            this.answerChoiseContainer.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(449, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 250);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbListAnswer
            // 
            this.tbListAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbListAnswer.AutoScroll = true;
            this.tbListAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 439F));
            this.tbListAnswer.Location = new System.Drawing.Point(4, 106);
            this.tbListAnswer.Name = "tbListAnswer";
            this.tbListAnswer.Size = new System.Drawing.Size(439, 131);
            this.tbListAnswer.TabIndex = 1;
            // 
            // QuestionListItemCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.answerChoiseContainer);
            this.Name = "QuestionListItemCustom";
            this.Size = new System.Drawing.Size(500, 250);
            this.questionContainer.ResumeLayout(false);
            this.questionContainer.PerformLayout();
            this.answerChoiseContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel questionContainer;
        private System.Windows.Forms.Panel answerChoiseContainer;
        private System.Windows.Forms.Label numberQuestionLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tbListAnswer;
    }
}
