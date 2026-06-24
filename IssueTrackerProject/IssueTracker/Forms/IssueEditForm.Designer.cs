namespace IssueTracker.Forms
{
    partial class IssueEditForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.nudIssueId = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSeverity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbEnvironment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbReporter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDateReported = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAssignee = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudHoursSpent = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLabels = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudIssueId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursSpent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue ID:";
            // 
            // nudIssueId
            // 
            this.nudIssueId.Location = new System.Drawing.Point(90, 23);
            this.nudIssueId.Name = "nudIssueId";
            this.nudIssueId.Size = new System.Drawing.Size(120, 20);
            this.nudIssueId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(90, 62);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(90, 104);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Severity:";
            // 
            // cmbSeverity
            // 
            this.cmbSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeverity.FormattingEnabled = true;
            this.cmbSeverity.Location = new System.Drawing.Point(90, 144);
            this.cmbSeverity.Name = "cmbSeverity";
            this.cmbSeverity.Size = new System.Drawing.Size(121, 21);
            this.cmbSeverity.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(90, 184);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 9;
            // 
            // cmbEnvironment
            // 
            this.cmbEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnvironment.FormattingEnabled = true;
            this.cmbEnvironment.Location = new System.Drawing.Point(90, 230);
            this.cmbEnvironment.Name = "cmbEnvironment";
            this.cmbEnvironment.Size = new System.Drawing.Size(121, 21);
            this.cmbEnvironment.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Environment:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Reporter (QA):";
            // 
            // cmbReporter
            // 
            this.cmbReporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReporter.FormattingEnabled = true;
            this.cmbReporter.Location = new System.Drawing.Point(90, 278);
            this.cmbReporter.Name = "cmbReporter";
            this.cmbReporter.Size = new System.Drawing.Size(121, 21);
            this.cmbReporter.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Date Reported:";
            // 
            // dtpDateReported
            // 
            this.dtpDateReported.Location = new System.Drawing.Point(90, 328);
            this.dtpDateReported.Name = "dtpDateReported";
            this.dtpDateReported.Size = new System.Drawing.Size(200, 20);
            this.dtpDateReported.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Assignee (Dev):";
            // 
            // cmbAssignee
            // 
            this.cmbAssignee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignee.FormattingEnabled = true;
            this.cmbAssignee.Location = new System.Drawing.Point(91, 367);
            this.cmbAssignee.Name = "cmbAssignee";
            this.cmbAssignee.Size = new System.Drawing.Size(121, 21);
            this.cmbAssignee.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Hours Spent:";
            // 
            // nudHoursSpent
            // 
            this.nudHoursSpent.DecimalPlaces = 1;
            this.nudHoursSpent.Location = new System.Drawing.Point(90, 408);
            this.nudHoursSpent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHoursSpent.Name = "nudHoursSpent";
            this.nudHoursSpent.Size = new System.Drawing.Size(120, 20);
            this.nudHoursSpent.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(322, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Labels (comma-separated):";
            // 
            // txtLabels
            // 
            this.txtLabels.Location = new System.Drawing.Point(462, 20);
            this.txtLabels.Name = "txtLabels";
            this.txtLabels.Size = new System.Drawing.Size(100, 20);
            this.txtLabels.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(622, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(622, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // IssueEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLabels);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudHoursSpent);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbAssignee);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpDateReported);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbReporter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEnvironment);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSeverity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudIssueId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nudIssueId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursSpent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudIssueId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSeverity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbEnvironment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbReporter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDateReported;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAssignee;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudHoursSpent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLabels;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}