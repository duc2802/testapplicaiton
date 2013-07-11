namespace ClientPresentationLayer.QuestionPresentation
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
            this.trueCheckBox = new System.Windows.Forms.CheckBox();
            this.orderAnswerLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btTrueFail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trueCheckBox
            // 
            this.trueCheckBox.AutoSize = true;
            this.trueCheckBox.Location = new System.Drawing.Point(66, 23);
            this.trueCheckBox.Name = "trueCheckBox";
            this.trueCheckBox.Size = new System.Drawing.Size(15, 14);
            this.trueCheckBox.TabIndex = 8;
            this.trueCheckBox.UseVisualStyleBackColor = true;
            this.trueCheckBox.CheckedChanged += new System.EventHandler(this.TrueCheckBoxCheckedChanged);
            // 
            // orderAnswerLabel
            // 
            this.orderAnswerLabel.AutoSize = true;
            this.orderAnswerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderAnswerLabel.Location = new System.Drawing.Point(33, 23);
            this.orderAnswerLabel.Name = "orderAnswerLabel";
            this.orderAnswerLabel.Size = new System.Drawing.Size(15, 15);
            this.orderAnswerLabel.TabIndex = 7;
            this.orderAnswerLabel.Text = "1";
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Location = new System.Drawing.Point(87, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(392, 57);
            this.contentPanel.TabIndex = 11;
            // 
            // btTrueFail
            // 
            this.btTrueFail.FlatAppearance.BorderSize = 0;
            this.btTrueFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTrueFail.Image = global::ClientPresentationLayer.Properties.Resources._true;
            this.btTrueFail.Location = new System.Drawing.Point(-1, 15);
            this.btTrueFail.Name = "btTrueFail";
            this.btTrueFail.Size = new System.Drawing.Size(32, 23);
            this.btTrueFail.TabIndex = 12;
            this.btTrueFail.UseVisualStyleBackColor = true;
            // 
            // HTMLAnswerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btTrueFail);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.trueCheckBox);
            this.Controls.Add(this.orderAnswerLabel);
            this.Name = "HTMLAnswerItem";
            this.Size = new System.Drawing.Size(482, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox trueCheckBox;
        private System.Windows.Forms.Label orderAnswerLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button btTrueFail;
    }
}
