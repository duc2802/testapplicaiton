using System.Windows.Forms;

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
            this.contentQuestionPanel = new System.Windows.Forms.Panel();
            this.answerChoiseContainer = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.orderNumQuest = new System.Windows.Forms.Label();
            this.answerChoiseContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentQuestionPanel
            // 
            this.contentQuestionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentQuestionPanel.BackColor = System.Drawing.Color.White;
            this.contentQuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentQuestionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentQuestionPanel.Location = new System.Drawing.Point(26, 39);
            //this.contentQuestionPanel.Multiline = true;
            this.contentQuestionPanel.Name = "contentQuestionPanel";
            //this.contentQuestionPanel.ReadOnly = true;
            this.contentQuestionPanel.Size = new System.Drawing.Size(502, 81);
            this.contentQuestionPanel.TabIndex = 1;
            // 
            // answerChoiseContainer
            // 
            this.answerChoiseContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.answerChoiseContainer.AutoSize = true;
            this.answerChoiseContainer.Controls.Add(this.deleteButton);
            this.answerChoiseContainer.Controls.Add(this.editButton);
            this.answerChoiseContainer.Controls.Add(this.orderNumQuest);
            this.answerChoiseContainer.Controls.Add(this.contentQuestionPanel);
            this.answerChoiseContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerChoiseContainer.Location = new System.Drawing.Point(0, 0);
            this.answerChoiseContainer.Name = "answerChoiseContainer";
            this.answerChoiseContainer.Size = new System.Drawing.Size(620, 123);
            this.answerChoiseContainer.TabIndex = 1;
            this.answerChoiseContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.answerChoiseContainer_Paint);
            this.answerChoiseContainer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.answerChoiseContainer_MouseClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(570, 39);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(37, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Del";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Location = new System.Drawing.Point(570, 10);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(37, 23);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // orderNumQuest
            // 
            this.orderNumQuest.AutoSize = true;
            this.orderNumQuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderNumQuest.Location = new System.Drawing.Point(26, 17);
            this.orderNumQuest.Name = "orderNumQuest";
            this.orderNumQuest.Size = new System.Drawing.Size(21, 15);
            this.orderNumQuest.TabIndex = 2;
            this.orderNumQuest.Text = "15";
            // 
            // QuestionListItemCustom
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.answerChoiseContainer);
            this.Name = "QuestionListItemCustom";
            this.Size = new System.Drawing.Size(620, 123);
            this.answerChoiseContainer.ResumeLayout(false);
            this.answerChoiseContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentQuestionPanel;
        private System.Windows.Forms.Panel answerChoiseContainer;
        private System.Windows.Forms.Label orderNumQuest;
        private System.Windows.Forms.Button editButton;
        private Button deleteButton;

    }
}
