namespace IssueTracker.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIssuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuesPerDeveloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.severityDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeveloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedDeveloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.New = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.Load = new System.Windows.Forms.ToolStripButton();
            this.dgvIssues = new System.Windows.Forms.DataGridView();
            this.cmsIssueGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueCard = new IssueTracker.Controls.IssueCardControl();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).BeginInit();
            this.cmsIssueGrid.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.typeHereToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newIssuToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newIssuToolStripMenuItem
            // 
            this.newIssuToolStripMenuItem.Name = "newIssuToolStripMenuItem";
            this.newIssuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newIssuToolStripMenuItem.Text = "&New Issue";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issuesPerDeveloperToolStripMenuItem,
            this.severityDistributionToolStripMenuItem,
            this.statusSummaryToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // issuesPerDeveloperToolStripMenuItem
            // 
            this.issuesPerDeveloperToolStripMenuItem.Name = "issuesPerDeveloperToolStripMenuItem";
            this.issuesPerDeveloperToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.issuesPerDeveloperToolStripMenuItem.Text = "Issues per &Developer";
            // 
            // severityDistributionToolStripMenuItem
            // 
            this.severityDistributionToolStripMenuItem.Name = "severityDistributionToolStripMenuItem";
            this.severityDistributionToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.severityDistributionToolStripMenuItem.Text = "&Severity Distribution";
            // 
            // statusSummaryToolStripMenuItem
            // 
            this.statusSummaryToolStripMenuItem.Name = "statusSummaryToolStripMenuItem";
            this.statusSummaryToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.statusSummaryToolStripMenuItem.Text = "Status Su&mmary";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showChartToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // showChartToolStripMenuItem
            // 
            this.showChartToolStripMenuItem.Name = "showChartToolStripMenuItem";
            this.showChartToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.showChartToolStripMenuItem.Text = "Show &Chart";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // typeHereToolStripMenuItem
            // 
            this.typeHereToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeveloperToolStripMenuItem,
            this.editSelectedDeveloperToolStripMenuItem});
            this.typeHereToolStripMenuItem.Name = "typeHereToolStripMenuItem";
            this.typeHereToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.typeHereToolStripMenuItem.Text = "&Manage";
            // 
            // addDeveloperToolStripMenuItem
            // 
            this.addDeveloperToolStripMenuItem.Name = "addDeveloperToolStripMenuItem";
            this.addDeveloperToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addDeveloperToolStripMenuItem.Text = "Add Developer";
            // 
            // editSelectedDeveloperToolStripMenuItem
            // 
            this.editSelectedDeveloperToolStripMenuItem.Name = "editSelectedDeveloperToolStripMenuItem";
            this.editSelectedDeveloperToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.editSelectedDeveloperToolStripMenuItem.Text = "Edit Selected Developer";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowDrop = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Save,
            this.Load});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // New
            // 
            this.New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.New.Image = ((System.Drawing.Image)(resources.GetObject("New.Image")));
            this.New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(23, 22);
            this.New.Text = "New";
            // 
            // Save
            // 
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(23, 22);
            this.Save.Text = "Save";
            // 
            // Load
            // 
            this.Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Load.Image = ((System.Drawing.Image)(resources.GetObject("Load.Image")));
            this.Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(23, 22);
            this.Load.Text = "Load";
            // 
            // dgvIssues
            // 
            this.dgvIssues.AllowDrop = true;
            this.dgvIssues.AllowUserToAddRows = false;
            this.dgvIssues.AllowUserToDeleteRows = false;
            this.dgvIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssues.ContextMenuStrip = this.cmsIssueGrid;
            this.dgvIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIssues.Location = new System.Drawing.Point(0, 49);
            this.dgvIssues.MultiSelect = false;
            this.dgvIssues.Name = "dgvIssues";
            this.dgvIssues.ReadOnly = true;
            this.dgvIssues.Size = new System.Drawing.Size(800, 401);
            this.dgvIssues.TabIndex = 2;
            // 
            // cmsIssueGrid
            // 
            this.cmsIssueGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editIssueToolStripMenuItem,
            this.deleteIssueToolStripMenuItem,
            this.changeStatusToolStripMenuItem,
            this.copyIDToolStripMenuItem});
            this.cmsIssueGrid.Name = "cmsIssueGrid";
            this.cmsIssueGrid.Size = new System.Drawing.Size(151, 92);
            // 
            // editIssueToolStripMenuItem
            // 
            this.editIssueToolStripMenuItem.Name = "editIssueToolStripMenuItem";
            this.editIssueToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.editIssueToolStripMenuItem.Text = "Edit Issue";
            // 
            // deleteIssueToolStripMenuItem
            // 
            this.deleteIssueToolStripMenuItem.Name = "deleteIssueToolStripMenuItem";
            this.deleteIssueToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deleteIssueToolStripMenuItem.Text = "Delete Issue";
            // 
            // changeStatusToolStripMenuItem
            // 
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.changeStatusToolStripMenuItem.Text = "Change Status";
            // 
            // copyIDToolStripMenuItem
            // 
            this.copyIDToolStripMenuItem.Name = "copyIDToolStripMenuItem";
            this.copyIDToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyIDToolStripMenuItem.Text = "Copy ID";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printPreviewToolStripMenuItem.Text = "&Print Preview";
            // 
            // issueCard
            // 
            this.issueCard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.issueCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.issueCard.Location = new System.Drawing.Point(488, 295);
            this.issueCard.Name = "issueCard";
            this.issueCard.Size = new System.Drawing.Size(300, 130);
            this.issueCard.TabIndex = 5;
            this.issueCard.Load += new System.EventHandler(this.issueCard_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.issueCard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvIssues);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "IssueTracker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).EndInit();
            this.cmsIssueGrid.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvIssues;
        private System.Windows.Forms.ContextMenuStrip cmsIssueGrid;
        private System.Windows.Forms.ToolStripMenuItem newIssuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuesPerDeveloperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem severityDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton New;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripButton Load;
        private System.Windows.Forms.ToolStripMenuItem editIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyIDToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem typeHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeveloperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedDeveloperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private Controls.IssueCardControl issueCard;
    }
}