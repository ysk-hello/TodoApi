namespace TodoApiClient
{
    partial class TodoEditForm
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
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.doneCheckBox = new System.Windows.Forms.CheckBox();
            this.isCompleteLabel = new System.Windows.Forms.Label();
            this.idValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(30, 22);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(17, 15);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Id";
            this.idLabel.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(30, 54);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 15);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(224, 116);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(320, 116);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(108, 51);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(287, 23);
            this.nameTextBox.TabIndex = 5;
            // 
            // doneCheckBox
            // 
            this.doneCheckBox.AutoSize = true;
            this.doneCheckBox.Location = new System.Drawing.Point(108, 90);
            this.doneCheckBox.Name = "doneCheckBox";
            this.doneCheckBox.Size = new System.Drawing.Size(54, 19);
            this.doneCheckBox.TabIndex = 6;
            this.doneCheckBox.Text = "Done";
            this.doneCheckBox.UseVisualStyleBackColor = true;
            // 
            // isCompleteLabel
            // 
            this.isCompleteLabel.AutoSize = true;
            this.isCompleteLabel.Location = new System.Drawing.Point(30, 90);
            this.isCompleteLabel.Name = "isCompleteLabel";
            this.isCompleteLabel.Size = new System.Drawing.Size(65, 15);
            this.isCompleteLabel.TabIndex = 2;
            this.isCompleteLabel.Text = "IsComplete";
            // 
            // idValueLabel
            // 
            this.idValueLabel.AutoSize = true;
            this.idValueLabel.Location = new System.Drawing.Point(108, 22);
            this.idValueLabel.Name = "idValueLabel";
            this.idValueLabel.Size = new System.Drawing.Size(22, 15);
            this.idValueLabel.TabIndex = 7;
            this.idValueLabel.Text = "---";
            this.idValueLabel.Visible = false;
            // 
            // TodoEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(436, 156);
            this.Controls.Add(this.idValueLabel);
            this.Controls.Add(this.doneCheckBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.isCompleteLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TodoEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TodoEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label idLabel;
        private Label nameLabel;
        private Button okButton;
        private Button cancelButton;
        private TextBox nameTextBox;
        private CheckBox doneCheckBox;
        private Label isCompleteLabel;
        private Label idValueLabel;
    }
}