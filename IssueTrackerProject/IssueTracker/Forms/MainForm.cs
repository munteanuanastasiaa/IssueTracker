using IssueTracker.Models;
using IssueTracker.Services;
using IssueTracker.ViewModels;
using IssueTracker.Controls;
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

        // print preview state
        private System.Drawing.Printing.PrintDocument printDoc;
        private int printRowIndex;


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

            // double-click on a row = open editor
            dgvIssues.CellDoubleClick += (s, e) => OnEditIssue(s, e);

            // selection change = update issue card
            dgvIssues.SelectionChanged += DgvIssues_SelectionChanged;
            DgvIssues_SelectionChanged(null, EventArgs.Empty);

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

            // seed sample data the first time the app is opened
            if (developers.Count == 0)
            {
                Developer d1 = new Developer(1, "Andrei", "Popescu", "andrei@qadna.ro", Specialization.Backend);
                Developer d2 = new Developer(2, "Maria", "Ionescu", "maria@qadna.ro", Specialization.Frontend);
                db.InsertDeveloper(d1);
                db.InsertDeveloper(d2);
                developers.Add(d1);
                developers.Add(d2);
            }

            // QA testers are in-memory only for now (no DB table yet)
            if (qaTesters.Count == 0)
            {
                qaTesters.Add(new QATester(1, "Anastasia", "Munteanu", "anastasia@qadna.ro"));
                qaTesters.Add(new QATester(2, "Vlad", "Stoica", "vlad@qadna.ro"));
            }
        }


        // ===== Status bar helper =====

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
        }


        // ===== Wire-up methods =====

        private void WireUpMenuEvents()
        {
            // File menu
            SafeWire(FindMenuItem("File", "New Issue"), OnNewIssue);
            SafeWire(FindMenuItem("File", "Save"), OnSaveToFile);
            SafeWire(FindMenuItem("File", "Load"), OnLoadFromFile);
            SafeWire(FindMenuItem("File", "Print Preview"), OnPrintPreview);
            ToolStripMenuItem exitItem = FindMenuItem("File", "Exit");
            if (exitItem != null) exitItem.Click += (s, e) => this.Close();

            // Edit menu (if exists)
            SafeWire(FindMenuItem("Edit", "Edit Issue"), OnEditIssue);
            SafeWire(FindMenuItem("Edit", "Delete Issue"), OnDeleteIssue);

            // Manage menu
            SafeWire(FindMenuItem("Manage", "Add Developer"), OnAddDeveloper);
            SafeWire(FindMenuItem("Manage", "Edit Selected Developer"), OnEditSelectedDeveloper);

            // Reports menu
            SafeWire(FindMenuItem("Reports", "Issues per Developer"), OnReportIssuesPerDev);
            SafeWire(FindMenuItem("Reports", "Severity Distribution"), OnReportSeverity);
            SafeWire(FindMenuItem("Reports", "Status Summary"), OnReportStatus);

            // Help menu
            SafeWire(FindMenuItem("Help", "About"), OnAbout);
        }

        // helper: only wire if item was found (avoids NullReferenceException)
        private void SafeWire(ToolStripMenuItem item, EventHandler handler)
        {
            if (item != null) item.Click += handler;
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

        // helper: find a menu item by parent name + item text (forgiving: case-insensitive, trims, strips &)
        private ToolStripMenuItem FindMenuItem(string parentText, string itemText)
        {
            foreach (ToolStripItem topItem in menuStrip1.Items)
            {
                ToolStripMenuItem topMi = topItem as ToolStripMenuItem;
                if (topMi == null) continue;
                if (!NormalizeText(topMi.Text).Equals(NormalizeText(parentText), StringComparison.OrdinalIgnoreCase))
                    continue;

                foreach (ToolStripItem child in topMi.DropDownItems)
                {
                    ToolStripMenuItem childMi = child as ToolStripMenuItem;
                    if (childMi == null) continue;
                    if (NormalizeText(childMi.Text).Equals(NormalizeText(itemText), StringComparison.OrdinalIgnoreCase))
                        return childMi;
                }
            }
            return null;
        }

        // helper: normalize menu text for comparison
        private string NormalizeText(string s)
        {
            if (s == null) return "";
            return s.Replace("&", "").Trim();
        }


        // ===== Event handlers =====

        private void OnNewIssue(object sender, EventArgs e)
        {
            IssueEditForm dlg = new IssueEditForm(developers, qaTesters);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Issue newIssue = dlg.GetIssue();
                try
                {
                    db.InsertIssue(newIssue);
                    issues.Add(newIssue);
                    UpdateStatus("Added issue #" + newIssue.IssueId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void OnEditIssue(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null) return;
            Issue selected = dgvIssues.CurrentRow.DataBoundItem as Issue;
            if (selected == null) return;

            IssueEditForm dlg = new IssueEditForm(selected, developers, qaTesters);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Issue updated = dlg.GetIssue();
                try
                {
                    db.UpdateIssue(updated);
                    int index = issues.IndexOf(selected);
                    if (index >= 0) issues.ResetItem(index);
                    UpdateStatus("Updated issue #" + updated.IssueId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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

            Button btnSaveReport = new Button();
            btnSaveReport.Text = "Save to TXT";
            btnSaveReport.Dock = DockStyle.Bottom;
            btnSaveReport.Click += (s, ev) =>
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
            reportForm.Controls.Add(btnSaveReport);
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


        // ===== Developer management =====

        private void OnAddDeveloper(object sender, EventArgs e)
        {
            DeveloperEditForm dlg = new DeveloperEditForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Developer newDev = dlg.GetDeveloper();
                try
                {
                    db.InsertDeveloper(newDev);
                    developers.Add(newDev);
                    UpdateStatus("Added developer " + newDev.FirstName + " " + newDev.LastName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void OnEditSelectedDeveloper(object sender, EventArgs e)
        {
            if (developers.Count == 0)
            {
                MessageBox.Show("No developers to edit.");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter Developer ID to edit:",
                "Edit Developer",
                developers[0].DeveloperId.ToString());

            if (string.IsNullOrEmpty(input)) return;

            int id;
            if (!int.TryParse(input, out id))
            {
                MessageBox.Show("Invalid ID.");
                return;
            }

            Developer found = null;
            foreach (Developer d in developers)
            {
                if (d.DeveloperId == id) { found = d; break; }
            }

            if (found == null)
            {
                MessageBox.Show("Developer with ID " + id + " not found.");
                return;
            }

            DeveloperEditForm dlg = new DeveloperEditForm(found);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Developer updated = dlg.GetDeveloper();
                try
                {
                    db.UpdateDeveloper(updated);
                    UpdateStatus("Updated developer #" + updated.DeveloperId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        // ===== Print preview =====

        private void OnPrintPreview(object sender, EventArgs e)
        {
            if (issues.Count == 0)
            {
                MessageBox.Show("No issues to print.");
                return;
            }

            printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
            printRowIndex = 0;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.Width = 900;
            preview.Height = 700;
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            System.Drawing.Font rowFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.Brush blackBrush = System.Drawing.Brushes.Black;

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float pageBottom = e.MarginBounds.Bottom;

            // title (first page only)
            if (printRowIndex == 0)
            {
                g.DrawString("Issue Tracker - Issue List", titleFont, blackBrush, x, y);
                y += 35;
                g.DrawString("Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                    rowFont, blackBrush, x, y);
                y += 25;
            }

            // header row
            g.DrawString("ID", headerFont, blackBrush, x, y);
            g.DrawString("Title", headerFont, blackBrush, x + 50, y);
            g.DrawString("Severity", headerFont, blackBrush, x + 300, y);
            g.DrawString("Status", headerFont, blackBrush, x + 400, y);
            g.DrawString("Hours", headerFont, blackBrush, x + 500, y);
            y += 20;

            // horizontal line under header
            g.DrawLine(System.Drawing.Pens.Black, x, y, e.MarginBounds.Right, y);
            y += 5;

            // data rows
            while (printRowIndex < issues.Count)
            {
                if (y + 20 > pageBottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                Issue issue = issues[printRowIndex];
                g.DrawString(issue.IssueId.ToString(), rowFont, blackBrush, x, y);
                g.DrawString(Truncate(issue.Title, 35), rowFont, blackBrush, x + 50, y);
                g.DrawString(issue.Severity.ToString(), rowFont, blackBrush, x + 300, y);
                g.DrawString(issue.Status.ToString(), rowFont, blackBrush, x + 400, y);
                g.DrawString(issue.HoursSpent.ToString("0.0"), rowFont, blackBrush, x + 500, y);
                y += 18;

                printRowIndex++;
            }

            e.HasMorePages = false;
        }

        private string Truncate(string s, int maxLen)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length <= maxLen) return s;
            return s.Substring(0, maxLen - 3) + "...";
        }


        // ===== Drag and drop =====

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.DragEnter += MainForm_DragEnter;
            this.DragDrop += MainForm_DragDrop;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) return;

            string file = files[0];

            try
            {
                List<Issue> loaded;
                if (file.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    loaded = FileManager.LoadIssuesFromJson(file);
                else if (file.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    loaded = FileManager.LoadIssuesFromCsv(file);
                else
                {
                    MessageBox.Show("Only .csv and .json files are supported.");
                    return;
                }

                issues.Clear();
                foreach (Issue i in loaded)
                    issues.Add(i);

                UpdateStatus("Imported " + loaded.Count + " issues from dropped file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Drop import failed: " + ex.Message);
            }
        }


        // ===== Issue card update =====

        private void DgvIssues_SelectionChanged(object sender, EventArgs e)
        {
            if (issueCard == null) return; // protect against early calls before designer init

            if (dgvIssues.CurrentRow == null)
            {
                issueCard.ClearCard();
                return;
            }

            Issue selected = dgvIssues.CurrentRow.DataBoundItem as Issue;
            if (selected == null)
            {
                issueCard.ClearCard();
                return;
            }

            issueCard.DisplayIssue(
                selected.IssueId,
                selected.Title,
                selected.Severity.ToString(),
                selected.Status.ToString(),
                selected.HoursSpent);
        }

        private void issueCard_Load(object sender, EventArgs e)
        {

        }
    }
}