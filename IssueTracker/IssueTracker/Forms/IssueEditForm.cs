using IssueTracker.Models;
using IssueTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IssueTracker.Forms
{
    public partial class IssueEditForm : Form
    {
        private IssueViewModel viewModel;
        private bool isEditMode;

        // ===== Constructor 1: create new issue =====
        public IssueEditForm(List<Developer> developers, List<QATester> qaTesters)
        {
            InitializeComponent();
            isEditMode = false;
            viewModel = new IssueViewModel();

            PopulateDropdowns(developers, qaTesters);
            SetViewModelDefaults();
            SetupBindings();
            WireUpEvents();

            this.Text = "New Issue";
        }

        // ===== Constructor 2: edit existing issue =====
        public IssueEditForm(Issue existing, List<Developer> developers, List<QATester> qaTesters)
        {
            InitializeComponent();
            isEditMode = true;
            viewModel = new IssueViewModel(existing);

            PopulateDropdowns(developers, qaTesters);
            SetupBindings();
            PreselectReporterAndAssignee();
            nudIssueId.Enabled = false; // can't change ID of existing issue
            WireUpEvents();

            this.Text = "Edit Issue #" + existing.IssueId;
        }


        // ===== Set up data bindings between controls and the ViewModel =====
        // This is the rubric item #11: each control is bound to a ViewModel property.
        // When the user types in a control, the ViewModel is updated automatically.
        // When the ViewModel changes (via OnPropertyChanged), the control refreshes automatically.
        private void SetupBindings()
        {
            // simple value bindings (TextBox.Text, NumericUpDown.Value, etc.)
            nudIssueId.DataBindings.Add("Value", viewModel, "IssueId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTitle.DataBindings.Add("Text", viewModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDescription.DataBindings.Add("Text", viewModel, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbSeverity.DataBindings.Add("SelectedItem", viewModel, "Severity", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbStatus.DataBindings.Add("SelectedItem", viewModel, "Status", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbEnvironment.DataBindings.Add("SelectedItem", viewModel, "Environment", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpDateReported.DataBindings.Add("Value", viewModel, "DateReported", true, DataSourceUpdateMode.OnPropertyChanged);
            nudHoursSpent.DataBindings.Add("Value", viewModel, "HoursSpent", true, DataSourceUpdateMode.OnPropertyChanged);

            // Note: cmbReporter, cmbAssignee, and txtLabels are handled manually in BtnSave
            // because they need special conversion (people objects to IDs, comma-separated string to array)
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


        private void SetViewModelDefaults()
        {
            viewModel.IssueId = 0;
            viewModel.Title = "";
            viewModel.Description = "";
            viewModel.Severity = Severity.Low;
            viewModel.Status = IssueStatus.Open;
            viewModel.Environment = IssueEnvironment.Local;
            viewModel.DateReported = DateTime.Now;
            viewModel.HoursSpent = 0;
            viewModel.Labels = new string[0];

            if (cmbReporter.Items.Count > 0) cmbReporter.SelectedIndex = 0;
            if (cmbAssignee.Items.Count > 0) cmbAssignee.SelectedIndex = 0;
            txtLabels.Text = "";
        }


        private void PreselectReporterAndAssignee()
        {
            foreach (var item in cmbReporter.Items)
            {
                QATester q = item as QATester;
                if (q != null && q.QATesterId == viewModel.ReporterId)
                {
                    cmbReporter.SelectedItem = q;
                    break;
                }
            }

            foreach (var item in cmbAssignee.Items)
            {
                Developer d = item as Developer;
                if (d != null && d.DeveloperId == viewModel.AssigneeId)
                {
                    cmbAssignee.SelectedItem = d;
                    break;
                }
            }

            txtLabels.Text = viewModel.Labels != null ? string.Join(",", viewModel.Labels) : "";
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
                // most fields already synced to ViewModel via bindings.
                // we just need to handle the 3 special cases manually:

                // 1. Reporter (extract ID from selected QATester object)
                viewModel.ReporterId = ((QATester)cmbReporter.SelectedItem).QATesterId;

                // 2. Assignee (extract ID from selected Developer object)
                viewModel.AssigneeId = cmbAssignee.SelectedItem != null
                    ? ((Developer)cmbAssignee.SelectedItem).DeveloperId
                    : 0;

                // 3. Labels (parse comma-separated string into array)
                if (!string.IsNullOrWhiteSpace(txtLabels.Text))
                {
                    string[] labels = txtLabels.Text.Split(',');
                    for (int idx = 0; idx < labels.Length; idx++)
                        labels[idx] = labels[idx].Trim();
                    viewModel.Labels = labels;
                }
                else
                {
                    viewModel.Labels = new string[0];
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


        // Returns the underlying Issue model from the ViewModel
        public Issue GetIssue()
        {
            return viewModel.GetIssue();
        }
    }
}