namespace FlowTestUI
{
    partial class Dashboard
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
            this.requestListView = new System.Windows.Forms.ListView();
            this.openRequestRadioButton = new System.Windows.Forms.RadioButton();
            this.closedRequestsRadioButton = new System.Windows.Forms.RadioButton();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.requestIdTextBox = new System.Windows.Forms.TextBox();
            this.requestOpenDateTextBox = new System.Windows.Forms.TextBox();
            this.requestTitleTextBox = new System.Windows.Forms.TextBox();
            this.requestTypeTextBox = new System.Windows.Forms.TextBox();
            this.requestCustomerTextBox = new System.Windows.Forms.TextBox();
            this.requestCloseDateTextBox = new System.Windows.Forms.TextBox();
            this.flowTestIdTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.requestCustNoteTextBox = new System.Windows.Forms.TextBox();
            this.requestWwNoteTextBox = new System.Windows.Forms.TextBox();
            this.requestStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.flowTestPictureBox = new System.Windows.Forms.PictureBox();
            this.requestCustNoteLabel = new System.Windows.Forms.Label();
            this.requestWwNoteLabel = new System.Windows.Forms.Label();
            this.createFlowTestButton = new System.Windows.Forms.Button();
            this.flowTestDataListView = new System.Windows.Forms.ListView();
            this.hydrantIdTextBox = new System.Windows.Forms.TextBox();
            this.requestGroupBox = new System.Windows.Forms.GroupBox();
            this.newRequestButton = new System.Windows.Forms.Button();
            this.updateRequestButton = new System.Windows.Forms.Button();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.requestTypeComboBox = new System.Windows.Forms.ComboBox();
            this.newRequestTitleTextBox = new System.Windows.Forms.TextBox();
            this.customerNoteTextBox = new System.Windows.Forms.TextBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.requestTypeLabel = new System.Windows.Forms.Label();
            this.requestTitleLabel = new System.Windows.Forms.Label();
            this.customerNoteLabel = new System.Windows.Forms.Label();
            this.addRequestButton = new System.Windows.Forms.Button();
            this.newRequestGroupBox = new System.Windows.Forms.GroupBox();
            this.flowTestDataIdTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.flowTestPictureBox)).BeginInit();
            this.requestGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestListView
            // 
            this.requestListView.HideSelection = false;
            this.requestListView.Location = new System.Drawing.Point(12, 75);
            this.requestListView.Name = "requestListView";
            this.requestListView.Size = new System.Drawing.Size(406, 181);
            this.requestListView.TabIndex = 1;
            this.requestListView.UseCompatibleStateImageBehavior = false;
            this.requestListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.requestListView_MouseClick);
            // 
            // openRequestRadioButton
            // 
            this.openRequestRadioButton.AutoSize = true;
            this.openRequestRadioButton.Location = new System.Drawing.Point(49, 52);
            this.openRequestRadioButton.Name = "openRequestRadioButton";
            this.openRequestRadioButton.Size = new System.Drawing.Size(99, 17);
            this.openRequestRadioButton.TabIndex = 2;
            this.openRequestRadioButton.TabStop = true;
            this.openRequestRadioButton.Text = "Open Requests";
            this.openRequestRadioButton.UseVisualStyleBackColor = true;
            this.openRequestRadioButton.CheckedChanged += new System.EventHandler(this.openRequestRadioButton_CheckedChanged);
            // 
            // closedRequestsRadioButton
            // 
            this.closedRequestsRadioButton.AutoSize = true;
            this.closedRequestsRadioButton.Location = new System.Drawing.Point(171, 52);
            this.closedRequestsRadioButton.Name = "closedRequestsRadioButton";
            this.closedRequestsRadioButton.Size = new System.Drawing.Size(105, 17);
            this.closedRequestsRadioButton.TabIndex = 3;
            this.closedRequestsRadioButton.TabStop = true;
            this.closedRequestsRadioButton.Text = "Closed Requests";
            this.closedRequestsRadioButton.UseVisualStyleBackColor = true;
            // 
            // generateReportButton
            // 
            this.generateReportButton.Location = new System.Drawing.Point(825, 309);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(75, 23);
            this.generateReportButton.TabIndex = 4;
            this.generateReportButton.Text = "Report";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // requestIdTextBox
            // 
            this.requestIdTextBox.Enabled = false;
            this.requestIdTextBox.Location = new System.Drawing.Point(97, 21);
            this.requestIdTextBox.Name = "requestIdTextBox";
            this.requestIdTextBox.Size = new System.Drawing.Size(50, 20);
            this.requestIdTextBox.TabIndex = 5;
            // 
            // requestOpenDateTextBox
            // 
            this.requestOpenDateTextBox.Enabled = false;
            this.requestOpenDateTextBox.Location = new System.Drawing.Point(97, 42);
            this.requestOpenDateTextBox.Name = "requestOpenDateTextBox";
            this.requestOpenDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.requestOpenDateTextBox.TabIndex = 6;
            // 
            // requestTitleTextBox
            // 
            this.requestTitleTextBox.Location = new System.Drawing.Point(97, 68);
            this.requestTitleTextBox.Name = "requestTitleTextBox";
            this.requestTitleTextBox.Size = new System.Drawing.Size(186, 20);
            this.requestTitleTextBox.TabIndex = 7;
            // 
            // requestTypeTextBox
            // 
            this.requestTypeTextBox.Enabled = false;
            this.requestTypeTextBox.Location = new System.Drawing.Point(97, 92);
            this.requestTypeTextBox.Name = "requestTypeTextBox";
            this.requestTypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.requestTypeTextBox.TabIndex = 8;
            // 
            // requestCustomerTextBox
            // 
            this.requestCustomerTextBox.Enabled = false;
            this.requestCustomerTextBox.Location = new System.Drawing.Point(97, 117);
            this.requestCustomerTextBox.Name = "requestCustomerTextBox";
            this.requestCustomerTextBox.Size = new System.Drawing.Size(100, 20);
            this.requestCustomerTextBox.TabIndex = 9;
            // 
            // requestCloseDateTextBox
            // 
            this.requestCloseDateTextBox.Enabled = false;
            this.requestCloseDateTextBox.Location = new System.Drawing.Point(97, 143);
            this.requestCloseDateTextBox.Name = "requestCloseDateTextBox";
            this.requestCloseDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.requestCloseDateTextBox.TabIndex = 10;
            // 
            // flowTestIdTextBox
            // 
            this.flowTestIdTextBox.Enabled = false;
            this.flowTestIdTextBox.Location = new System.Drawing.Point(97, 174);
            this.flowTestIdTextBox.Name = "flowTestIdTextBox";
            this.flowTestIdTextBox.Size = new System.Drawing.Size(50, 20);
            this.flowTestIdTextBox.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "FlowTestID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "RequestID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date Closed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date Open";
            // 
            // requestCustNoteTextBox
            // 
            this.requestCustNoteTextBox.AcceptsReturn = true;
            this.requestCustNoteTextBox.Enabled = false;
            this.requestCustNoteTextBox.Location = new System.Drawing.Point(317, 23);
            this.requestCustNoteTextBox.Multiline = true;
            this.requestCustNoteTextBox.Name = "requestCustNoteTextBox";
            this.requestCustNoteTextBox.Size = new System.Drawing.Size(162, 77);
            this.requestCustNoteTextBox.TabIndex = 40;
            // 
            // requestWwNoteTextBox
            // 
            this.requestWwNoteTextBox.AcceptsReturn = true;
            this.requestWwNoteTextBox.Location = new System.Drawing.Point(317, 121);
            this.requestWwNoteTextBox.Multiline = true;
            this.requestWwNoteTextBox.Name = "requestWwNoteTextBox";
            this.requestWwNoteTextBox.Size = new System.Drawing.Size(162, 78);
            this.requestWwNoteTextBox.TabIndex = 41;
            // 
            // requestStatusCheckBox
            // 
            this.requestStatusCheckBox.AutoSize = true;
            this.requestStatusCheckBox.Location = new System.Drawing.Point(98, 200);
            this.requestStatusCheckBox.Name = "requestStatusCheckBox";
            this.requestStatusCheckBox.Size = new System.Drawing.Size(99, 17);
            this.requestStatusCheckBox.TabIndex = 42;
            this.requestStatusCheckBox.Text = "Request Status";
            this.requestStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // flowTestPictureBox
            // 
            this.flowTestPictureBox.Location = new System.Drawing.Point(756, 387);
            this.flowTestPictureBox.Name = "flowTestPictureBox";
            this.flowTestPictureBox.Size = new System.Drawing.Size(127, 72);
            this.flowTestPictureBox.TabIndex = 43;
            this.flowTestPictureBox.TabStop = false;
            // 
            // requestCustNoteLabel
            // 
            this.requestCustNoteLabel.AutoSize = true;
            this.requestCustNoteLabel.Location = new System.Drawing.Point(314, 7);
            this.requestCustNoteLabel.Name = "requestCustNoteLabel";
            this.requestCustNoteLabel.Size = new System.Drawing.Size(77, 13);
            this.requestCustNoteLabel.TabIndex = 44;
            this.requestCustNoteLabel.Text = "Customer Note";
            // 
            // requestWwNoteLabel
            // 
            this.requestWwNoteLabel.AutoSize = true;
            this.requestWwNoteLabel.Location = new System.Drawing.Point(314, 105);
            this.requestWwNoteLabel.Name = "requestWwNoteLabel";
            this.requestWwNoteLabel.Size = new System.Drawing.Size(90, 13);
            this.requestWwNoteLabel.TabIndex = 45;
            this.requestWwNoteLabel.Text = "Waterworks Note";
            // 
            // createFlowTestButton
            // 
            this.createFlowTestButton.Location = new System.Drawing.Point(163, 174);
            this.createFlowTestButton.Name = "createFlowTestButton";
            this.createFlowTestButton.Size = new System.Drawing.Size(75, 23);
            this.createFlowTestButton.TabIndex = 46;
            this.createFlowTestButton.Text = "Flow Test";
            this.createFlowTestButton.UseVisualStyleBackColor = true;
            this.createFlowTestButton.Click += new System.EventHandler(this.createFlowTestButton_Click);
            // 
            // flowTestDataListView
            // 
            this.flowTestDataListView.HideSelection = false;
            this.flowTestDataListView.Location = new System.Drawing.Point(13, 309);
            this.flowTestDataListView.Name = "flowTestDataListView";
            this.flowTestDataListView.Size = new System.Drawing.Size(588, 97);
            this.flowTestDataListView.TabIndex = 47;
            this.flowTestDataListView.UseCompatibleStateImageBehavior = false;
            // 
            // hydrantIdTextBox
            // 
            this.hydrantIdTextBox.Location = new System.Drawing.Point(662, 311);
            this.hydrantIdTextBox.Name = "hydrantIdTextBox";
            this.hydrantIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.hydrantIdTextBox.TabIndex = 48;
            // 
            // requestGroupBox
            // 
            this.requestGroupBox.Controls.Add(this.newRequestButton);
            this.requestGroupBox.Controls.Add(this.updateRequestButton);
            this.requestGroupBox.Controls.Add(this.createFlowTestButton);
            this.requestGroupBox.Controls.Add(this.requestWwNoteLabel);
            this.requestGroupBox.Controls.Add(this.requestCustNoteLabel);
            this.requestGroupBox.Controls.Add(this.requestStatusCheckBox);
            this.requestGroupBox.Controls.Add(this.requestWwNoteTextBox);
            this.requestGroupBox.Controls.Add(this.requestCustNoteTextBox);
            this.requestGroupBox.Controls.Add(this.label8);
            this.requestGroupBox.Controls.Add(this.label6);
            this.requestGroupBox.Controls.Add(this.label5);
            this.requestGroupBox.Controls.Add(this.label4);
            this.requestGroupBox.Controls.Add(this.label3);
            this.requestGroupBox.Controls.Add(this.label2);
            this.requestGroupBox.Controls.Add(this.label1);
            this.requestGroupBox.Controls.Add(this.flowTestIdTextBox);
            this.requestGroupBox.Controls.Add(this.requestCloseDateTextBox);
            this.requestGroupBox.Controls.Add(this.requestCustomerTextBox);
            this.requestGroupBox.Controls.Add(this.requestTypeTextBox);
            this.requestGroupBox.Controls.Add(this.requestTitleTextBox);
            this.requestGroupBox.Controls.Add(this.requestOpenDateTextBox);
            this.requestGroupBox.Controls.Add(this.requestIdTextBox);
            this.requestGroupBox.Location = new System.Drawing.Point(458, 12);
            this.requestGroupBox.Name = "requestGroupBox";
            this.requestGroupBox.Size = new System.Drawing.Size(498, 254);
            this.requestGroupBox.TabIndex = 49;
            this.requestGroupBox.TabStop = false;
            // 
            // newRequestButton
            // 
            this.newRequestButton.Location = new System.Drawing.Point(351, 206);
            this.newRequestButton.Name = "newRequestButton";
            this.newRequestButton.Size = new System.Drawing.Size(75, 23);
            this.newRequestButton.TabIndex = 48;
            this.newRequestButton.Text = "New Request";
            this.newRequestButton.UseVisualStyleBackColor = true;
            this.newRequestButton.Click += new System.EventHandler(this.newRequestButton_Click);
            // 
            // updateRequestButton
            // 
            this.updateRequestButton.Location = new System.Drawing.Point(228, 200);
            this.updateRequestButton.Name = "updateRequestButton";
            this.updateRequestButton.Size = new System.Drawing.Size(75, 23);
            this.updateRequestButton.TabIndex = 47;
            this.updateRequestButton.Text = "Update";
            this.updateRequestButton.UseVisualStyleBackColor = true;
            this.updateRequestButton.Click += new System.EventHandler(this.updateRequestButton_Click);
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(1062, 51);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(131, 21);
            this.customerComboBox.TabIndex = 50;
            this.customerComboBox.Enter += new System.EventHandler(this.customerComboBox_Enter);
            // 
            // requestTypeComboBox
            // 
            this.requestTypeComboBox.FormattingEnabled = true;
            this.requestTypeComboBox.Location = new System.Drawing.Point(1062, 83);
            this.requestTypeComboBox.Name = "requestTypeComboBox";
            this.requestTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.requestTypeComboBox.TabIndex = 51;
            // 
            // newRequestTitleTextBox
            // 
            this.newRequestTitleTextBox.Location = new System.Drawing.Point(1062, 117);
            this.newRequestTitleTextBox.Name = "newRequestTitleTextBox";
            this.newRequestTitleTextBox.Size = new System.Drawing.Size(140, 20);
            this.newRequestTitleTextBox.TabIndex = 52;
            // 
            // customerNoteTextBox
            // 
            this.customerNoteTextBox.AcceptsReturn = true;
            this.customerNoteTextBox.Location = new System.Drawing.Point(1065, 146);
            this.customerNoteTextBox.Multiline = true;
            this.customerNoteTextBox.Name = "customerNoteTextBox";
            this.customerNoteTextBox.Size = new System.Drawing.Size(146, 100);
            this.customerNoteTextBox.TabIndex = 53;
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(982, 51);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(51, 13);
            this.customerLabel.TabIndex = 54;
            this.customerLabel.Text = "Customer";
            this.customerLabel.Click += new System.EventHandler(this.customerLabel_Click);
            // 
            // requestTypeLabel
            // 
            this.requestTypeLabel.AutoSize = true;
            this.requestTypeLabel.Location = new System.Drawing.Point(982, 86);
            this.requestTypeLabel.Name = "requestTypeLabel";
            this.requestTypeLabel.Size = new System.Drawing.Size(74, 13);
            this.requestTypeLabel.TabIndex = 55;
            this.requestTypeLabel.Text = "Request Type";
            // 
            // requestTitleLabel
            // 
            this.requestTitleLabel.AutoSize = true;
            this.requestTitleLabel.Location = new System.Drawing.Point(967, 103);
            this.requestTitleLabel.Name = "requestTitleLabel";
            this.requestTitleLabel.Size = new System.Drawing.Size(27, 13);
            this.requestTitleLabel.TabIndex = 56;
            this.requestTitleLabel.Text = "Title";
            // 
            // customerNoteLabel
            // 
            this.customerNoteLabel.AutoSize = true;
            this.customerNoteLabel.Location = new System.Drawing.Point(982, 149);
            this.customerNoteLabel.Name = "customerNoteLabel";
            this.customerNoteLabel.Size = new System.Drawing.Size(77, 13);
            this.customerNoteLabel.TabIndex = 57;
            this.customerNoteLabel.Text = "Customer Note";
            // 
            // addRequestButton
            // 
            this.addRequestButton.Location = new System.Drawing.Point(985, 193);
            this.addRequestButton.Name = "addRequestButton";
            this.addRequestButton.Size = new System.Drawing.Size(53, 23);
            this.addRequestButton.TabIndex = 58;
            this.addRequestButton.Text = "Add";
            this.addRequestButton.UseVisualStyleBackColor = true;
            this.addRequestButton.Click += new System.EventHandler(this.addRequestButton_Click);
            // 
            // newRequestGroupBox
            // 
            this.newRequestGroupBox.Location = new System.Drawing.Point(962, 12);
            this.newRequestGroupBox.Name = "newRequestGroupBox";
            this.newRequestGroupBox.Size = new System.Drawing.Size(258, 254);
            this.newRequestGroupBox.TabIndex = 59;
            this.newRequestGroupBox.TabStop = false;
            // 
            // flowTestDataIdTextBox
            // 
            this.flowTestDataIdTextBox.Location = new System.Drawing.Point(1036, 311);
            this.flowTestDataIdTextBox.Name = "flowTestDataIdTextBox";
            this.flowTestDataIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.flowTestDataIdTextBox.TabIndex = 60;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 543);
            this.Controls.Add(this.flowTestDataIdTextBox);
            this.Controls.Add(this.addRequestButton);
            this.Controls.Add(this.customerNoteLabel);
            this.Controls.Add(this.requestTitleLabel);
            this.Controls.Add(this.requestTypeLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.customerNoteTextBox);
            this.Controls.Add(this.newRequestTitleTextBox);
            this.Controls.Add(this.requestTypeComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.requestGroupBox);
            this.Controls.Add(this.hydrantIdTextBox);
            this.Controls.Add(this.flowTestDataListView);
            this.Controls.Add(this.flowTestPictureBox);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.closedRequestsRadioButton);
            this.Controls.Add(this.openRequestRadioButton);
            this.Controls.Add(this.requestListView);
            this.Controls.Add(this.newRequestGroupBox);
            this.Name = "Dashboard";
            this.Text = "Hydrant Flow Testing";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flowTestPictureBox)).EndInit();
            this.requestGroupBox.ResumeLayout(false);
            this.requestGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView requestListView;
        private System.Windows.Forms.RadioButton openRequestRadioButton;
        private System.Windows.Forms.RadioButton closedRequestsRadioButton;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.TextBox requestIdTextBox;
        private System.Windows.Forms.TextBox requestOpenDateTextBox;
        private System.Windows.Forms.TextBox requestTitleTextBox;
        private System.Windows.Forms.TextBox requestTypeTextBox;
        private System.Windows.Forms.TextBox requestCustomerTextBox;
        private System.Windows.Forms.TextBox requestCloseDateTextBox;
        private System.Windows.Forms.TextBox flowTestIdTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox requestCustNoteTextBox;
        private System.Windows.Forms.TextBox requestWwNoteTextBox;
        private System.Windows.Forms.CheckBox requestStatusCheckBox;
        private System.Windows.Forms.PictureBox flowTestPictureBox;
        private System.Windows.Forms.Label requestCustNoteLabel;
        private System.Windows.Forms.Label requestWwNoteLabel;
        private System.Windows.Forms.Button createFlowTestButton;
        private System.Windows.Forms.ListView flowTestDataListView;
        private System.Windows.Forms.TextBox hydrantIdTextBox;
        private System.Windows.Forms.GroupBox requestGroupBox;
        private System.Windows.Forms.Button updateRequestButton;
        private System.Windows.Forms.Button newRequestButton;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox requestTypeComboBox;
        private System.Windows.Forms.TextBox newRequestTitleTextBox;
        private System.Windows.Forms.TextBox customerNoteTextBox;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label requestTypeLabel;
        private System.Windows.Forms.Label requestTitleLabel;
        private System.Windows.Forms.Label customerNoteLabel;
        private System.Windows.Forms.Button addRequestButton;
        private System.Windows.Forms.GroupBox newRequestGroupBox;
        private System.Windows.Forms.TextBox flowTestDataIdTextBox;
    }
}

