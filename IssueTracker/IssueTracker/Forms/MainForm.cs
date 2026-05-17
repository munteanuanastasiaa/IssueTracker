using IssueTracker.Models;
using IssueTracker.Services;
using IssueTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IssueTracker.Forms
{
    public partial class MainForm : Form
    {
        // data sources
        private BindingList<Issue> issues;
        private List<Developer> developers;
        private List<QATester> qaTesters;
        private DatabaseManager db;

        // file paths
        private readonly string dbPath = "issuetracker.db";


        public MainForm()
        {
            InitializeComponent();

            // init data
            developers = new List<Developer>();
            qaTesters = new List<QATester>();
            issues = new BindingList<Issue>();

            // init database
            try
            {
                db = new DatabaseManager(dbPath);
                LoadFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }

            // bind the grid
            dgvIssues.DataSource = issues;

            // wire up events
            WireUpMenuEvents();
            WireUpToolStripEvents();
            WireUpContextMenuEvents();

            UpdateStatus("Ready. " + issues.Count + " issues loaded.");
        }


        // ===== Data loading =====

        private void LoadFromDatabase()
        {
            List<Issue> loaded = db.GetAllIssues();
            issues.Clear();
            foreach (Issue i in loaded)
                issues.Add(i);

            developers = db.GetAllDevelopers();
        }


        // ===== Status bar helper =====

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
        }


        // ===== Wire-up methods =====
        // (these find menu items by name and attach Click handlers)

        private void WireUpMenuEvents()
        {
            // File menu
            FindMenuItem("File", "New Issue").Click += OnNewIssue;
            FindMenuItem("File", "Save").Click += OnSaveToFile;
            FindMenuItem("File", "Load").Click += OnLoadFromFile;
            FindMenuItem("File", "Exit").Click += (s, e) => this.Close();

            // Edit menu (if exists)
            ToolStripMenuItem editIssue = FindMenuItem("Edit", "Edit Issue");
            if (editIssue != null) editIssue.Click += OnEditIssue;

            ToolStripMenuItem deleteIssue = FindMenuItem("Edit", "Delete Issue");
            if (deleteIssue != null) deleteIssue.Click += OnDeleteIssue;

            // Reports menu
            FindMenuItem("Reports", "Issues per Developer").Click += OnReportIssuesPerDev;
            FindMenuItem("Reports", "Severity Distribution").Click += OnReportSeverity;
            FindMenuItem("Reports", "Status Summary").Click += OnReportStatus;

            // Help menu
            FindMenuItem("Help", "About").Click += OnAbout;
        }

        private void WireUpToolStripEvents()
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripButton btn)
                {
                    if (btn.Text == "New") btn.Click += OnNewIssue;
                    else if (btn.Text == "Save") btn.Click += OnSaveToFile;
                    else if (btn.Text == "Load") btn.Click += OnLoadFromFile;
                }
            }
        }

        private void WireUpContextMenuEvents()
        {
            foreach (ToolStripItem item in cmsIssueGrid.Items)
            {
                if (item is ToolStripMenuItem mi)
                {
                    if (mi.Text == "Edit Issue") mi.Click += OnEditIssue;
                    else if (mi.Text == "Delete Issue") mi.Click += OnDeleteIssue;
                    else if (mi.Text == "Copy ID") mi.Click += OnCopyId;
                    else if (mi.Text == "Change Status") mi.Click += OnChangeStatus;
                }
            }
        }

        // helper: find a menu item by parent name + item text
        private ToolStripMenuItem FindMenuItem(string parentText, string itemText)
        {
            foreach (ToolStripItem topItem in menuStrip1.Items)
            {
                ToolStripMenuItem topMi = topItem as ToolStripMenuItem;
                if (topMi == null) continue;
                if (topMi.Text.Replace("&", "") != parentText) continue;

                foreach (ToolStripItem child in topMi.DropDownItems)
                {
                    ToolStripMenuItem childMi = child as ToolStripMenuItem;
                    if (childMi == null) continue;
                    if (childMi.Text.Replace("&", "") == itemText)
                        return childMi;
                }
            }
            return null;
        }


        // ===== Event handlers (will be filled in next step) =====

        private void OnNewIssue(object sender, EventArgs e)
        {
            MessageBox.Show("New Issue clicked - form will open here");
        }

        private void OnEditIssue(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null) return;
            MessageBox.Show("Edit Issue clicked");
        }

        private void OnDeleteIssue(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null) return;

            Issue selected = dgvIssues.CurrentRow.DataBoundItem as Issue;
            if (selected == null) return;

            DialogResult dr = MessageBox.Show(
                "Delete issue '" + selected.Title + "'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    db.DeleteIssue(selected.IssueId);
                    issues.Remove(selected);
                    UpdateStatus("Deleted issue #" + selected.IssueId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message);
                }
            }
        }

        private void OnSaveToFile(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|JSON files (*.json)|*.json";
            sfd.FileName = "issues_export";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Issue> list = issues.ToList();
                    if (sfd.FileName.EndsWith(".json"))
                        FileManager.SaveIssuesToJson(list, sfd.FileName);
                    else
                        FileManager.SaveIssuesToCsv(list, sfd.FileName);

                    UpdateStatus("Saved to " + sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save failed: " + ex.Message);
                }
            }
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|JSON files (*.json)|*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Issue> loaded;
                    if (ofd.FileName.EndsWith(".json"))
                        loaded = FileManager.LoadIssuesFromJson(ofd.FileName);
                    else
                        loaded = FileManager.LoadIssuesFromCsv(ofd.FileName);

                    issues.Clear();
                    foreach (Issue i in loaded)
                        issues.Add(i);

                    UpdateStatus("Loaded " + loaded.Count + " issues from file");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load failed: " + ex.Message);
                }
            }
        }

        private void OnReportIssuesPerDev(object sender, EventArgs e)
        {
            string report = ReportGenerator.IssuesPerDeveloper(issues.ToList(), developers);
            ShowReport(report, "Issues per Developer");
        }

        private void OnReportSeverity(object sender, EventArgs e)
        {
            string report = ReportGenerator.SeverityDistribution(issues.ToList());
            ShowReport(report, "Severity Distribution");
        }

        private void OnReportStatus(object sender, EventArgs e)
        {
            string report = ReportGenerator.StatusSummary(issues.ToList());
            ShowReport(report, "Status Summary");
        }

        private void ShowReport(string content, string title)
        {
            // simple modal showing the report text + an option to save
            Form reportForm = new Form();
            reportForm.Text = title;
            reportForm.Size = new System.Drawing.Size(600, 500);
            reportForm.StartPosition = FormStartPosition.CenterParent;

            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.ReadOnly = true;
            txt.Dock = DockStyle.Fill;
            txt.Font = new System.Drawing.Font("Consolas", 10);
            txt.ScrollBars = ScrollBars.Both;
            txt.Text = content;

            Button btnSave = new Button();
            btnSave.Text = "Save to TXT";
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Click += (s, ev) =>
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text files (*.txt)|*.txt";
                sfd.FileName = title.Replace(" ", "_") + ".txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ReportGenerator.SaveReportToTxt(content, sfd.FileName);
                    MessageBox.Show("Saved to " + sfd.FileName);
                }
            };

            reportForm.Controls.Add(txt);
            reportForm.Controls.Add(btnSave);
            reportForm.ShowDialog();
        }

        private void OnCopyId(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null) return;
            Issue selected = dgvIssues.CurrentRow.DataBoundItem as Issue;
            if (selected != null)
            {
                Clipboard.SetText(selected.IssueId.ToString());
                UpdateStatus("Copied ID " + selected.IssueId + " to clipboard");
            }
        }

        private void OnChangeStatus(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null) return;
            MessageBox.Show("Change Status - dropdown will open here");
        }

        private void OnAbout(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Issue Tracker\n" +
                "PAW Project - Theme #32\n" +
                "ASE Bucharest 2026",
                "About");
        }
    }
}