using System;
using System.Windows.Forms;
using IssueTracker.Models;

namespace IssueTracker.Forms
{
    public partial class DeveloperEditForm : Form
    {
        private Developer editedDev;
        private bool isEditMode;

        // Constructor 1: create new developer
        public DeveloperEditForm()
        {
            InitializeComponent();
            isEditMode = false;
            editedDev = null;

            PopulateSpecialization();
            SetFormDefaults();
            WireUpEvents();

            this.Text = "New Developer";
        }

        // Constructor 2: edit existing developer
        public DeveloperEditForm(Developer existing)
        {
            InitializeComponent();
            isEditMode = true;
            editedDev = existing;

            PopulateSpecialization();
            LoadDevIntoForm(existing);
            WireUpEvents();

            this.Text = "Edit Developer #" + existing.DeveloperId;
        }


        private void PopulateSpecialization()
        {
            cmbSpecialization.Items.Clear();
            foreach (Specialization s in Enum.GetValues(typeof(Specialization)))
                cmbSpecialization.Items.Add(s);
        }


        private void SetFormDefaults()
        {
            nudDevId.Value = 0;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            cmbSpecialization.SelectedItem = Specialization.FullStack;
            dtpHireDate.Value = DateTime.Now;
            nudBugsFixed.Value = 0;
        }


        private void LoadDevIntoForm(Developer d)
        {
            nudDevId.Value = d.DeveloperId;
            nudDevId.Enabled = false;
            txtFirstName.Text = d.FirstName;
            txtLastName.Text = d.LastName;
            txtEmail.Text = d.Email;
            cmbSpecialization.SelectedItem = d.Specialization;
            dtpHireDate.Value = d.HireDate;
            nudBugsFixed.Value = d.BugsFixedCount;
        }


        private void WireUpEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtFirstName.Validating += TxtFirstName_Validating;
            txtLastName.Validating += TxtLastName_Validating;
        }


        private void TxtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                errorProvider1.SetError(txtFirstName, "First name cannot be empty.");
            else
                errorProvider1.SetError(txtFirstName, "");
        }

        private void TxtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                errorProvider1.SetError(txtLastName, "Last name cannot be empty.");
            else
                errorProvider1.SetError(txtLastName, "");
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name cannot be empty.", "Validation Error");
                txtFirstName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last name cannot be empty.", "Validation Error");
                txtLastName.Focus();
                return;
            }

            try
            {
                if (editedDev == null)
                    editedDev = new Developer();

                editedDev.DeveloperId = (int)nudDevId.Value;
                editedDev.FirstName = txtFirstName.Text;
                editedDev.LastName = txtLastName.Text;
                editedDev.Email = txtEmail.Text;
                editedDev.Specialization = (Specialization)cmbSpecialization.SelectedItem;
                editedDev.HireDate = dtpHireDate.Value;
                editedDev.BugsFixedCount = (int)nudBugsFixed.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        public Developer GetDeveloper()
        {
            return editedDev;
        }
    }
}
