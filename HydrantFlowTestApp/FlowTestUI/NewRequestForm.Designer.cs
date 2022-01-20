namespace FlowTestUI
{
    partial class NewRequestForm
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
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.requestTypeComboBox = new System.Windows.Forms.ComboBox();
            this.requestTitleTextBox = new System.Windows.Forms.TextBox();
            this.customerNoteTextBox = new System.Windows.Forms.TextBox();
            this.addRequestButton = new System.Windows.Forms.Button();
            this.cstomerComboBoxLabel = new System.Windows.Forms.Label();
            this.requestTypeComboBoxLabel = new System.Windows.Forms.Label();
            this.requestTitleTextBoxLabel = new System.Windows.Forms.Label();
            this.customerNoteTextBoxLabel = new System.Windows.Forms.Label();
            this.newRequestFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(294, 58);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(244, 21);
            this.customerComboBox.TabIndex = 0;
            this.customerComboBox.Enter += new System.EventHandler(this.customerComboBox_Enter);
            // 
            // requestTypeComboBox
            // 
            this.requestTypeComboBox.FormattingEnabled = true;
            this.requestTypeComboBox.Location = new System.Drawing.Point(294, 104);
            this.requestTypeComboBox.Name = "requestTypeComboBox";
            this.requestTypeComboBox.Size = new System.Drawing.Size(244, 21);
            this.requestTypeComboBox.TabIndex = 1;
            // 
            // requestTitleTextBox
            // 
            this.requestTitleTextBox.Location = new System.Drawing.Point(294, 150);
            this.requestTitleTextBox.Name = "requestTitleTextBox";
            this.requestTitleTextBox.Size = new System.Drawing.Size(244, 20);
            this.requestTitleTextBox.TabIndex = 2;
            // 
            // customerNoteTextBox
            // 
            this.customerNoteTextBox.AcceptsReturn = true;
            this.customerNoteTextBox.Location = new System.Drawing.Point(294, 195);
            this.customerNoteTextBox.Multiline = true;
            this.customerNoteTextBox.Name = "customerNoteTextBox";
            this.customerNoteTextBox.Size = new System.Drawing.Size(244, 94);
            this.customerNoteTextBox.TabIndex = 3;
            // 
            // addRequestButton
            // 
            this.addRequestButton.Location = new System.Drawing.Point(294, 324);
            this.addRequestButton.Name = "addRequestButton";
            this.addRequestButton.Size = new System.Drawing.Size(75, 23);
            this.addRequestButton.TabIndex = 4;
            this.addRequestButton.Text = "Add";
            this.addRequestButton.UseVisualStyleBackColor = true;
            // 
            // cstomerComboBoxLabel
            // 
            this.cstomerComboBoxLabel.AutoSize = true;
            this.cstomerComboBoxLabel.Location = new System.Drawing.Point(222, 58);
            this.cstomerComboBoxLabel.Name = "cstomerComboBoxLabel";
            this.cstomerComboBoxLabel.Size = new System.Drawing.Size(51, 13);
            this.cstomerComboBoxLabel.TabIndex = 5;
            this.cstomerComboBoxLabel.Text = "Customer";
            this.cstomerComboBoxLabel.Click += new System.EventHandler(this.cstomerComboBoxLabel_Click);
            // 
            // requestTypeComboBoxLabel
            // 
            this.requestTypeComboBoxLabel.AutoSize = true;
            this.requestTypeComboBoxLabel.Location = new System.Drawing.Point(199, 104);
            this.requestTypeComboBoxLabel.Name = "requestTypeComboBoxLabel";
            this.requestTypeComboBoxLabel.Size = new System.Drawing.Size(74, 13);
            this.requestTypeComboBoxLabel.TabIndex = 6;
            this.requestTypeComboBoxLabel.Text = "Request Type";
            // 
            // requestTitleTextBoxLabel
            // 
            this.requestTitleTextBoxLabel.AutoSize = true;
            this.requestTitleTextBoxLabel.Location = new System.Drawing.Point(222, 153);
            this.requestTitleTextBoxLabel.Name = "requestTitleTextBoxLabel";
            this.requestTitleTextBoxLabel.Size = new System.Drawing.Size(27, 13);
            this.requestTitleTextBoxLabel.TabIndex = 7;
            this.requestTitleTextBoxLabel.Text = "Title";
            // 
            // customerNoteTextBoxLabel
            // 
            this.customerNoteTextBoxLabel.AutoSize = true;
            this.customerNoteTextBoxLabel.Location = new System.Drawing.Point(199, 195);
            this.customerNoteTextBoxLabel.Name = "customerNoteTextBoxLabel";
            this.customerNoteTextBoxLabel.Size = new System.Drawing.Size(77, 13);
            this.customerNoteTextBoxLabel.TabIndex = 8;
            this.customerNoteTextBoxLabel.Text = "Customer Note";
            // 
            // newRequestFormLabel
            // 
            this.newRequestFormLabel.AutoSize = true;
            this.newRequestFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRequestFormLabel.Location = new System.Drawing.Point(294, 13);
            this.newRequestFormLabel.Name = "newRequestFormLabel";
            this.newRequestFormLabel.Size = new System.Drawing.Size(164, 24);
            this.newRequestFormLabel.TabIndex = 9;
            this.newRequestFormLabel.Text = "Add New Request";
            // 
            // NewRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newRequestFormLabel);
            this.Controls.Add(this.customerNoteTextBoxLabel);
            this.Controls.Add(this.requestTitleTextBoxLabel);
            this.Controls.Add(this.requestTypeComboBoxLabel);
            this.Controls.Add(this.cstomerComboBoxLabel);
            this.Controls.Add(this.addRequestButton);
            this.Controls.Add(this.customerNoteTextBox);
            this.Controls.Add(this.requestTitleTextBox);
            this.Controls.Add(this.requestTypeComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Name = "NewRequestForm";
            this.Text = "NewRequestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox requestTypeComboBox;
        private System.Windows.Forms.TextBox requestTitleTextBox;
        private System.Windows.Forms.TextBox customerNoteTextBox;
        private System.Windows.Forms.Button addRequestButton;
        private System.Windows.Forms.Label cstomerComboBoxLabel;
        private System.Windows.Forms.Label requestTypeComboBoxLabel;
        private System.Windows.Forms.Label requestTitleTextBoxLabel;
        private System.Windows.Forms.Label customerNoteTextBoxLabel;
        private System.Windows.Forms.Label newRequestFormLabel;
    }
}