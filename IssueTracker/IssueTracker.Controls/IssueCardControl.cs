using System;
using System.Drawing;
using System.Windows.Forms;

namespace IssueTracker.Controls
{
    public class IssueCardControl : UserControl
    {
        private Label lblId;
        private Label lblTitle;
        private Label lblSeverityCaption;
        private Label lblSeverity;
        private Label lblStatusCaption;
        private Label lblStatus;
        private Label lblHoursCaption;
        private Label lblHours;

        public IssueCardControl()
        {
            InitializeControls();
            ClearCard();
        }

        private void InitializeControls()
        {
            this.Size = new Size(300, 130);
            this.BackColor = SystemColors.ControlLight;
            this.BorderStyle = BorderStyle.FixedSingle;

            lblId = new Label();
            lblId.AutoSize = true;
            lblId.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblId.Location = new Point(8, 8);
            lblId.Text = "ID: --";

            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F);
            lblTitle.Location = new Point(8, 30);
            lblTitle.MaximumSize = new Size(280, 0);
            lblTitle.Text = "(no issue selected)";

            lblSeverityCaption = new Label();
            lblSeverityCaption.AutoSize = true;
            lblSeverityCaption.Location = new Point(8, 60);
            lblSeverityCaption.Text = "Severity:";

            lblSeverity = new Label();
            lblSeverity.AutoSize = true;
            lblSeverity.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            lblSeverity.Location = new Point(75, 60);
            lblSeverity.Text = "--";

            lblStatusCaption = new Label();
            lblStatusCaption.AutoSize = true;
            lblStatusCaption.Location = new Point(8, 80);
            lblStatusCaption.Text = "Status:";

            lblStatus = new Label();
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(75, 80);
            lblStatus.Text = "--";

            lblHoursCaption = new Label();
            lblHoursCaption.AutoSize = true;
            lblHoursCaption.Location = new Point(8, 100);
            lblHoursCaption.Text = "Hours:";

            lblHours = new Label();
            lblHours.AutoSize = true;
            lblHours.Location = new Point(75, 100);
            lblHours.Text = "--";

            this.Controls.Add(lblHours);
            this.Controls.Add(lblHoursCaption);
            this.Controls.Add(lblStatus);
            this.Controls.Add(lblStatusCaption);
            this.Controls.Add(lblSeverity);
            this.Controls.Add(lblSeverityCaption);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblId);
        }

        // Public method: caller passes primitive data
        public void DisplayIssue(int id, string title, string severity, string status, double hours)
        {
            lblId.Text = "ID: " + id;
            lblTitle.Text = title;
            lblSeverity.Text = severity;
            lblStatus.Text = status;
            lblHours.Text = hours.ToString("0.0") + " h";

            switch (severity)
            {
                case "Critical": lblSeverity.ForeColor = Color.DarkRed; break;
                case "High": lblSeverity.ForeColor = Color.OrangeRed; break;
                case "Medium": lblSeverity.ForeColor = Color.DarkOrange; break;
                case "Low": lblSeverity.ForeColor = Color.SeaGreen; break;
                default: lblSeverity.ForeColor = Color.Black; break;
            }
        }

        public void ClearCard()
        {
            lblId.Text = "ID: --";
            lblTitle.Text = "(no issue selected)";
            lblSeverity.Text = "--";
            lblStatus.Text = "--";
            lblHours.Text = "--";
            lblSeverity.ForeColor = Color.Black;
        }
    }
}