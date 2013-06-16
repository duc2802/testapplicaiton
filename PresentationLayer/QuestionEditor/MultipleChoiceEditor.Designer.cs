namespace PresentationLayer.QuestionEditor
{
    partial class MultipleChoiceEditor
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
            this.lbExplain = new System.Windows.Forms.Label();
            this.tbQuestionContent = new System.Windows.Forms.TextBox();
            this.opFileChoseImage = new System.Windows.Forms.OpenFileDialog();
            this.lbImportImage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.tbListAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btMoreAnswer = new System.Windows.Forms.Button();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbExplain
            // 
            this.lbExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbExplain.AutoSize = true;
            this.lbExplain.Location = new System.Drawing.Point(12, 331);
            this.lbExplain.Name = "lbExplain";
            this.lbExplain.Size = new System.Drawing.Size(41, 13);
            this.lbExplain.TabIndex = 0;
            this.lbExplain.Text = "Explain";
            this.lbExplain.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbQuestionContent
            // 
            this.tbQuestionContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuestionContent.Location = new System.Drawing.Point(87, 34);
            this.tbQuestionContent.Multiline = true;
            this.tbQuestionContent.Name = "tbQuestionContent";
            this.tbQuestionContent.Size = new System.Drawing.Size(396, 129);
            this.tbQuestionContent.TabIndex = 1;
            this.tbQuestionContent.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // opFileChoseImage
            // 
            this.opFileChoseImage.FileName = "openFileDialog1";
            this.opFileChoseImage.Filter = "(*.bmp, *.jpg)|*.bmp;*.jpg";
            // 
            // lbImportImage
            // 
            this.lbImportImage.AutoSize = true;
            this.lbImportImage.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbImportImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbImportImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbImportImage.Location = new System.Drawing.Point(12, 79);
            this.lbImportImage.Name = "lbImportImage";
            this.lbImportImage.Size = new System.Drawing.Size(70, 15);
            this.lbImportImage.TabIndex = 2;
            this.lbImportImage.Text = "Import Image";
            this.lbImportImage.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.Location = new System.Drawing.Point(12, 197);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(47, 13);
            this.lbAnswer.TabIndex = 0;
            this.lbAnswer.Text = "Answers";
            this.lbAnswer.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbListAnswer
            // 
            this.tbListAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbListAnswer.AutoScroll = true;
            this.tbListAnswer.AutoSize = true;
            this.tbListAnswer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tbListAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tbListAnswer.Location = new System.Drawing.Point(87, 197);
            this.tbListAnswer.Name = "tbListAnswer";
            this.tbListAnswer.Size = new System.Drawing.Size(404, 117);
            this.tbListAnswer.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(87, 331);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(396, 94);
            this.textBox2.TabIndex = 5;
            // 
            // btCreate
            // 
            this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreate.Location = new System.Drawing.Point(411, 438);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(68, 23);
            this.btCreate.TabIndex = 6;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(330, 438);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btMoreAnswer
            // 
            this.btMoreAnswer.Location = new System.Drawing.Point(15, 224);
            this.btMoreAnswer.Name = "btMoreAnswer";
            this.btMoreAnswer.Size = new System.Drawing.Size(49, 23);
            this.btMoreAnswer.TabIndex = 8;
            this.btMoreAnswer.Text = "More..";
            this.btMoreAnswer.UseVisualStyleBackColor = true;
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Location = new System.Drawing.Point(15, 34);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(49, 13);
            this.lbQuestion.TabIndex = 0;
            this.lbQuestion.Text = "Question";
            this.lbQuestion.Click += new System.EventHandler(this.label1_Click);
            // 
            // MultipleChoiceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(506, 473);
            this.Controls.Add(this.btMoreAnswer);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tbListAnswer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbImportImage);
            this.Controls.Add(this.tbQuestionContent);
            this.Controls.Add(this.lbAnswer);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.lbExplain);
            this.Name = "MultipleChoiceEditor";
            this.Load += new System.EventHandler(this.MultipleChoiceEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbExplain;
        private System.Windows.Forms.TextBox tbQuestionContent;
        private System.Windows.Forms.OpenFileDialog opFileChoseImage;
        private System.Windows.Forms.Label lbImportImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAnswer;
        private System.Windows.Forms.TableLayoutPanel tbListAnswer;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btMoreAnswer;
        private System.Windows.Forms.Label lbQuestion;

    }
}