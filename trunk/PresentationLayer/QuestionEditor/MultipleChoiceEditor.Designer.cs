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
            this.tbListAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.tbQuestionExplain = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.btMoreAnswer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbExplain
            // 
            this.lbExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbExplain.AutoSize = true;
            this.lbExplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExplain.Location = new System.Drawing.Point(12, 186);
            this.lbExplain.Name = "lbExplain";
            this.lbExplain.Size = new System.Drawing.Size(56, 13);
            this.lbExplain.TabIndex = 0;
            this.lbExplain.Text = "Explain: ";
            this.lbExplain.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbQuestionContent
            // 
            this.tbQuestionContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQuestionContent.Location = new System.Drawing.Point(98, 20);
            this.tbQuestionContent.Multiline = true;
            this.tbQuestionContent.Name = "tbQuestionContent";
            this.tbQuestionContent.Size = new System.Drawing.Size(400, 129);
            this.tbQuestionContent.TabIndex = 1;
            this.tbQuestionContent.TextChanged += new System.EventHandler(this.tbQuestionContent_TextChanged);
            // 
            // opFileChoseImage
            // 
            this.opFileChoseImage.FileName = "openFileDialog1";
            this.opFileChoseImage.Filter = "(*.bmp, *.jpg)|*.bmp;*.jpg";
            // 
            // lbImportImage
            // 
            this.lbImportImage.AutoSize = true;
            this.lbImportImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbImportImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbImportImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbImportImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbImportImage.Location = new System.Drawing.Point(113, 301);
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
            // tbListAnswer
            // 
            this.tbListAnswer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbListAnswer.AutoScroll = true;
            this.tbListAnswer.AutoSize = true;
            this.tbListAnswer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tbListAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tbListAnswer.Location = new System.Drawing.Point(515, 20);
            this.tbListAnswer.Name = "tbListAnswer";
            this.tbListAnswer.Size = new System.Drawing.Size(304, 256);
            this.tbListAnswer.TabIndex = 4;
            // 
            // tbQuestionExplain
            // 
            this.tbQuestionExplain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbQuestionExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQuestionExplain.Location = new System.Drawing.Point(99, 184);
            this.tbQuestionExplain.Multiline = true;
            this.tbQuestionExplain.Name = "tbQuestionExplain";
            this.tbQuestionExplain.Size = new System.Drawing.Size(399, 94);
            this.tbQuestionExplain.TabIndex = 5;
            this.tbQuestionExplain.TextChanged += new System.EventHandler(this.tbQuestionExplain_TextChanged);
            // 
            // btCreate
            // 
            this.btCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCreate.Location = new System.Drawing.Point(671, 301);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(68, 23);
            this.btCreate.TabIndex = 6;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(745, 301);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestion.Location = new System.Drawing.Point(12, 22);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(57, 13);
            this.lbQuestion.TabIndex = 0;
            this.lbQuestion.Text = "Question";
            this.lbQuestion.Click += new System.EventHandler(this.label1_Click);
            // 
            // btMoreAnswer
            // 
            this.btMoreAnswer.AccessibleDescription = "";
            this.btMoreAnswer.FlatAppearance.BorderSize = 0;
            this.btMoreAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMoreAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMoreAnswer.Location = new System.Drawing.Point(9, 293);
            this.btMoreAnswer.Name = "btMoreAnswer";
            this.btMoreAnswer.Size = new System.Drawing.Size(92, 23);
            this.btMoreAnswer.TabIndex = 8;
            this.btMoreAnswer.Tag = "";
            this.btMoreAnswer.Text = "Add Choice";
            this.btMoreAnswer.UseVisualStyleBackColor = true;
            this.btMoreAnswer.Click += new System.EventHandler(this.btMoreAnswer_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(577, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add Choice";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(410, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Add Image";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MultipleChoiceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 341);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btMoreAnswer);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.tbQuestionExplain);
            this.Controls.Add(this.tbListAnswer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbImportImage);
            this.Controls.Add(this.tbQuestionContent);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.lbExplain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultipleChoiceEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TableLayoutPanel tbListAnswer;
        private System.Windows.Forms.TextBox tbQuestionExplain;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbQuestion;
        public System.Windows.Forms.Button btCreate;
        public System.Windows.Forms.Button btMoreAnswer;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;

    }
}