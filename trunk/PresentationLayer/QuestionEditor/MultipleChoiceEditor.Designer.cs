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
            this.lbDislayImage = new System.Windows.Forms.Label();
            this.tbListAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.tbQuestionExplain = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.btMoreAnswer = new System.Windows.Forms.Button();
            this.btAddImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbExplain
            // 
            this.lbExplain.AutoSize = true;
            this.lbExplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExplain.Location = new System.Drawing.Point(12, 186);
            this.lbExplain.Name = "lbExplain";
            this.lbExplain.Size = new System.Drawing.Size(56, 13);
            this.lbExplain.TabIndex = 0;
            this.lbExplain.Text = "Explain: ";
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
            // lbDislayImage
            // 
            this.lbDislayImage.AutoSize = true;
            this.lbDislayImage.Location = new System.Drawing.Point(96, 317);
            this.lbDislayImage.Name = "lbDislayImage";
            this.lbDislayImage.Size = new System.Drawing.Size(143, 13);
            this.lbDislayImage.TabIndex = 3;
            this.lbDislayImage.Text = "This question have no image";
            // 
            // tbListAnswer
            // 
            this.tbListAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbListAnswer.AutoScroll = true;
            this.tbListAnswer.AutoSize = true;
            this.tbListAnswer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbListAnswer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tbListAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.tbListAnswer.Location = new System.Drawing.Point(515, 20);
            this.tbListAnswer.Name = "tbListAnswer";
            this.tbListAnswer.Size = new System.Drawing.Size(405, 2);
            this.tbListAnswer.TabIndex = 4;
            // 
            // tbQuestionExplain
            // 
            this.tbQuestionExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQuestionExplain.Location = new System.Drawing.Point(99, 184);
            this.tbQuestionExplain.Multiline = true;
            this.tbQuestionExplain.Name = "tbQuestionExplain";
            this.tbQuestionExplain.Size = new System.Drawing.Size(399, 106);
            this.tbQuestionExplain.TabIndex = 5;
            this.tbQuestionExplain.TextChanged += new System.EventHandler(this.tbQuestionExplain_TextChanged);
            // 
            // btCreate
            // 
            this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCreate.Location = new System.Drawing.Point(753, 360);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(75, 23);
            this.btCreate.TabIndex = 6;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(834, 360);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 23);
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
            // 
            // btMoreAnswer
            // 
            this.btMoreAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btMoreAnswer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btMoreAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMoreAnswer.Location = new System.Drawing.Point(652, 360);
            this.btMoreAnswer.Name = "btMoreAnswer";
            this.btMoreAnswer.Size = new System.Drawing.Size(95, 23);
            this.btMoreAnswer.TabIndex = 9;
            this.btMoreAnswer.Text = "Add Choice";
            this.btMoreAnswer.UseVisualStyleBackColor = true;
            // 
            // btAddImage
            // 
            this.btAddImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddImage.Location = new System.Drawing.Point(551, 360);
            this.btAddImage.Name = "btAddImage";
            this.btAddImage.Size = new System.Drawing.Size(95, 23);
            this.btAddImage.TabIndex = 11;
            this.btAddImage.Text = "Add Image";
            this.btAddImage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Image:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(99, 317);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(155, 55);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // MultipleChoiceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 395);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAddImage);
            this.Controls.Add(this.btMoreAnswer);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.tbQuestionExplain);
            this.Controls.Add(this.tbListAnswer);
            this.Controls.Add(this.lbDislayImage);
            this.Controls.Add(this.tbQuestionContent);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.lbExplain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultipleChoiceEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MultipleChoiceEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbExplain;
        private System.Windows.Forms.TextBox tbQuestionContent;
        private System.Windows.Forms.OpenFileDialog opFileChoseImage;
        private System.Windows.Forms.Label lbDislayImage;
        private System.Windows.Forms.TableLayoutPanel tbListAnswer;
        private System.Windows.Forms.TextBox tbQuestionExplain;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbQuestion;
        public System.Windows.Forms.Button btCreate;
        public System.Windows.Forms.Button btMoreAnswer;
        public System.Windows.Forms.Button btAddImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox;

    }
}