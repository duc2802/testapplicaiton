namespace PresentationLayer.QuestionEditor
{
    partial class HTMLAnswerItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTMLAnswerItem));
            this.deleteButton = new System.Windows.Forms.Button();
            this.trueCheckBox = new System.Windows.Forms.CheckBox();
            this.orderAnswerLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(458, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(21, 20);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // trueCheckBox
            // 
            this.trueCheckBox.AutoSize = true;
            this.trueCheckBox.Location = new System.Drawing.Point(399, 3);
            this.trueCheckBox.Name = "trueCheckBox";
            this.trueCheckBox.Size = new System.Drawing.Size(60, 17);
            this.trueCheckBox.TabIndex = 8;
            this.trueCheckBox.Text = "Correct";
            this.trueCheckBox.UseVisualStyleBackColor = true;
            this.trueCheckBox.CheckedChanged += new System.EventHandler(this.TrueCheckBoxCheckedChanged);
            // 
            // orderAnswerLabel
            // 
            this.orderAnswerLabel.AutoSize = true;
            this.orderAnswerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderAnswerLabel.Location = new System.Drawing.Point(3, 3);
            this.orderAnswerLabel.Name = "orderAnswerLabel";
            this.orderAnswerLabel.Size = new System.Drawing.Size(15, 15);
            this.orderAnswerLabel.TabIndex = 7;
            this.orderAnswerLabel.Text = "1";
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(24, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(369, 69);
            this.contentPanel.TabIndex = 11;
            // 
            // HTMLAnswerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.trueCheckBox);
            this.Controls.Add(this.orderAnswerLabel);
            this.Name = "HTMLAnswerItem";
            this.Size = new System.Drawing.Size(482, 74);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.CheckBox trueCheckBox;
        private System.Windows.Forms.Label orderAnswerLabel;
        private System.Windows.Forms.Panel contentPanel;
    }
}
