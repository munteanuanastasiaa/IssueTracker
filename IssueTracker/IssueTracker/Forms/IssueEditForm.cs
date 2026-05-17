using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;

namespace IssueTracker.Forms
{
    public partial class IssueEditForm : Form
    {
        private Issue editedIssue;
        private bool isEditMode;

        // ===== Constructor 1: create new issue =====
        public IssueEditForm(List<Developer> developers, List<QATester> qaTesters)
        {
            InitializeComponent();
            isEditMode = false;
            editedIssue = null;

            PopulateDropdowns(developers, qaTesters);
            SetFormDefaults();
            WireUpEvents();

            this.Text = "New Issue";
        }

        // ===== Constructor 2: edit existing issue =====
        public IssueEditForm(Issue existing, List<Developer> developers, List<QATester> qaTesters)
        {
            InitializeComponent();
            isEditMode = true;
            editedIssue = existing;

            PopulateDropdowns(developers, qaTesters);
            LoadIssueIntoForm(existing);
            WireUpEvents();

            this.Text = "Edit Issue #" + existing.IssueId;
        }


        private void PopulateDropdowns(List<Developer> developers, List<QATester> qaTesters)
        {
            cmbSeverity.Items.Clear();
            foreach (Severity s in Enum.GetValues(typeof(Severity)))
                cmbSeverity.Items.Add(s);

            cmbStatus.Items.Clear();
            foreach (IssueStatus s in Enum.GetValues(typeof(IssueStatus)))
                cmbStatus.Items.Add(s);

            cmbEnvironment.Items.Clear();
            foreach (IssueEnvironment env in Enum.GetValues(typeof(IssueEnvironment)))
                cmbEnvironment.Items.Add(env);

            cmbReporter.Items.Clear();
            foreach (QATester q in qaTesters)
                cmbReporter.Items.Add(q);

            cmbAssignee.Items.Clear();
            foreach (Developer d in developers)
                cmbAssignee.Items.Add(d);
        }


        private void SetFormDefaults()
        {
            nudIssueId.Value = 0;
            txtTitle.Text = "";
            txtDescription.Text = "";
            cmbSeverity.SelectedItem = Severity.Low;
            cmbStatus.SelectedItem = IssueStatus.Open;
            cmbEnvironment.SelectedItem = IssueEnvironment.Local;
            dtpDateReported.Value = DateTime.Now;
            if (cmbReporter.Items.Count > 0) cmbReporter.SelectedIndex = 0;
            if (cmbAssignee.Items.Count > 0) cmbAssignee.SelectedIndex = 0;
            nudHoursSpent.Value = 0;
            txtLabels.Text = "";
        }


        private void LoadIssueIntoForm(Issue i)
        {
            nudIssueId.Value = i.IssueId;
            nudIssueId.Enabled = false;
            txtTitle.Text = i.Title;
            txtDescription.Text = i.Description;
            cmbSeverity.SelectedItem = i.Severity;
            cmbStatus.SelectedItem = i.Status;
            cmbEnvironment.SelectedItem = i.Environment;
            dtpDateReported.Value = i.DateReported;

            foreach (var item in cmbReporter.Items)
            {
                QATester q = item as QATester;
                if (q != null && q.QATesterId == i.ReporterId)
                {
                    cmbReporter.SelectedItem = q;
                    break;
                }
            }

            foreach (var item in cmbAssignee.Items)
            {
                Developer d = item as Developer;
                if (d != null && d.DeveloperId == i.AssigneeId)
                {
                    cmbAssignee.SelectedItem = d;
                    break;
                }
            }

            nudHoursSpent.Value = (decimal)i.HoursSpent;
            txtLabels.Text = i.Labels != null ? string.Join(",", i.Labels) : "";
        }


        private void WireUpEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            txtTitle.Validating += TxtTitle_Validating;
            nudHoursSpent.Validating += NudHoursSpent_Validating;
        }


        private void TxtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider1.SetError(txtTitle, "Title cannot be empty.");
                e.Cancel = false;
            }
            else
            {
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void NudHoursSpent_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nudHoursSpent.Value < 0)
            {
                errorProvider1.SetError(nudHoursSpent, "Hours cannot be negative.");
                e.Cancel = false;
            }
            else
            {
                errorProvider1.SetError(nudHoursSpent, "");
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation Error");
                txtTitle.Focus();
                return;
            }

            if (cmbReporter.SelectedItem == null)
            {
                MessageBox.Show("Please select a reporter.", "Validation Error");
                return;
            }

            try
            {
                if (editedIssue == null)
                    editedIssue = new Issue();

                editedIssue.IssueId = (int)nudIssueId.Value;
                editedIssue.Title = txtTitle.Text;
                editedIssue.Description = txtDescription.Text;
                editedIssue.Severity = (Severity)cmbSeverity.SelectedItem;
                editedIssue.Status = (IssueStatus)cmbStatus.SelectedItem;
                editedIssue.Environment = (IssueEnvironment)cmbEnvironment.SelectedItem;
                editedIssue.DateReported = dtpDateReported.Value;
                editedIssue.ReporterId = ((QATester)cmbReporter.SelectedItem).QATesterId;
                editedIssue.AssigneeId = cmbAssignee.SelectedItem != null
                    ? ((Developer)cmbAssignee.SelectedItem).DeveloperId
                    : 0;
                editedIssue.HoursSpent = (double)nudHoursSpent.Value;

                if (!string.IsNullOrWhiteSpace(txtLabels.Text))
                {
                    string[] labels = txtLabels.Text.Split(',');
                    for (int idx = 0; idx < labels.Length; idx++)
                        labels[idx] = labels[idx].Trim();
                    editedIssue.Labels = labels;
                }
                else
                {
                    editedIssue.Labels = new string[0];
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving issue: " + ex.Message, "Error");
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        public Issue GetIssue()
        {
            return editedIssue;
        }
    }
}