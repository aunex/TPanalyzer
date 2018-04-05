namespace TPanalyzer
{
    partial class analyzerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(analyzerMainForm));
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuLoadTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitTraceWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoResizeTraceCollumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlTraces = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.traceTemplate1 = new TPanalyzer.TraceTemplate();
            this.cMenuIDHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.filterSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleAnalyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.closeTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDialogTrace = new System.Windows.Forms.OpenFileDialog();
            this.timerProgressMonitor = new System.Windows.Forms.Timer(this.components);
            this.topMenuStrip.SuspendLayout();
            this.tabControlTraces.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cMenuIDHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Size = new System.Drawing.Size(1287, 24);
            this.topMenuStrip.TabIndex = 11;
            this.topMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuLoadTrace,
            this.toolStripSeparator3});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnMenuLoadTrace
            // 
            this.btnMenuLoadTrace.Name = "btnMenuLoadTrace";
            this.btnMenuLoadTrace.Size = new System.Drawing.Size(154, 22);
            this.btnMenuLoadTrace.Text = "Load new trace";
            this.btnMenuLoadTrace.Click += new System.EventHandler(this.btnMenuLoadTrace_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitTraceWindowToolStripMenuItem,
            this.autoResizeTraceCollumnsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // splitTraceWindowToolStripMenuItem
            // 
            this.splitTraceWindowToolStripMenuItem.Name = "splitTraceWindowToolStripMenuItem";
            this.splitTraceWindowToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.splitTraceWindowToolStripMenuItem.Text = "Split trace window";
            this.splitTraceWindowToolStripMenuItem.Click += new System.EventHandler(this.splitTraceWindowToolStripMenuItem_Click);
            // 
            // autoResizeTraceCollumnsToolStripMenuItem
            // 
            this.autoResizeTraceCollumnsToolStripMenuItem.Name = "autoResizeTraceCollumnsToolStripMenuItem";
            this.autoResizeTraceCollumnsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.autoResizeTraceCollumnsToolStripMenuItem.Text = "Autosize of trace collumns";
            this.autoResizeTraceCollumnsToolStripMenuItem.Click += new System.EventHandler(this.autoResizeTraceCollumnsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDListToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // iDListToolStripMenuItem
            // 
            this.iDListToolStripMenuItem.Name = "iDListToolStripMenuItem";
            this.iDListToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.iDListToolStripMenuItem.Text = "Diagnostic configuration";
            this.iDListToolStripMenuItem.Click += new System.EventHandler(this.iDListToolStripMenuItem_Click);
            // 
            // tabControlTraces
            // 
            this.tabControlTraces.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlTraces.Controls.Add(this.tabPage1);
            this.tabControlTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTraces.Location = new System.Drawing.Point(0, 24);
            this.tabControlTraces.Name = "tabControlTraces";
            this.tabControlTraces.SelectedIndex = 0;
            this.tabControlTraces.Size = new System.Drawing.Size(1287, 626);
            this.tabControlTraces.TabIndex = 14;
            this.tabControlTraces.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlTraces_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.traceTemplate1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1279, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trace 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // traceTemplate1
            // 
            this.traceTemplate1.ContextMenuStrip = this.cMenuIDHeader;
            this.traceTemplate1.DataMemberBottom = "";
            this.traceTemplate1.DataMemberTop = "";
            this.traceTemplate1.DataSourceBottom = null;
            this.traceTemplate1.DataSourceTop = null;
            this.traceTemplate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.traceTemplate1.Location = new System.Drawing.Point(3, 3);
            this.traceTemplate1.Name = "traceTemplate1";
            this.traceTemplate1.rtbDetailsBottomText = "";
            this.traceTemplate1.rtbDetailsTopText = "";
            this.traceTemplate1.Size = new System.Drawing.Size(1273, 594);
            this.traceTemplate1.TabIndex = 0;
            // 
            // cMenuIDHeader
            // 
            this.cMenuIDHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideColumnToolStripMenuItem,
            this.showColumnsToolStripMenuItem,
            this.toolStripSeparator4,
            this.filterSetupToolStripMenuItem,
            this.doubleAnalyzerToolStripMenuItem,
            this.toolStripSeparator5,
            this.closeTraceToolStripMenuItem});
            this.cMenuIDHeader.Name = "cMenuIDHeader";
            this.cMenuIDHeader.Size = new System.Drawing.Size(166, 126);
            // 
            // hideColumnToolStripMenuItem
            // 
            this.hideColumnToolStripMenuItem.Name = "hideColumnToolStripMenuItem";
            this.hideColumnToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.hideColumnToolStripMenuItem.Text = "Hide this column";
            // 
            // showColumnsToolStripMenuItem
            // 
            this.showColumnsToolStripMenuItem.Name = "showColumnsToolStripMenuItem";
            this.showColumnsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showColumnsToolStripMenuItem.Text = "Show columns";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
            // 
            // filterSetupToolStripMenuItem
            // 
            this.filterSetupToolStripMenuItem.Name = "filterSetupToolStripMenuItem";
            this.filterSetupToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.filterSetupToolStripMenuItem.Text = "Filter settings";
            // 
            // doubleAnalyzerToolStripMenuItem
            // 
            this.doubleAnalyzerToolStripMenuItem.CheckOnClick = true;
            this.doubleAnalyzerToolStripMenuItem.Name = "doubleAnalyzerToolStripMenuItem";
            this.doubleAnalyzerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.doubleAnalyzerToolStripMenuItem.Text = "Double analyzer";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(162, 6);
            // 
            // closeTraceToolStripMenuItem
            // 
            this.closeTraceToolStripMenuItem.Name = "closeTraceToolStripMenuItem";
            this.closeTraceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeTraceToolStripMenuItem.Text = "Close trace";
            // 
            // openDialogTrace
            // 
            this.openDialogTrace.RestoreDirectory = true;
            // 
            // timerProgressMonitor
            // 
            this.timerProgressMonitor.Interval = 500;
            // 
            // analyzerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 650);
            this.Controls.Add(this.tabControlTraces);
            this.Controls.Add(this.topMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenuStrip;
            this.Name = "analyzerMainForm";
            this.Text = "TP analyzer";
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.tabControlTraces.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cMenuIDHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnMenuLoadTrace;
        private System.Windows.Forms.TabControl tabControlTraces;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.OpenFileDialog openDialogTrace;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip cMenuIDHeader;
        private System.Windows.Forms.ToolStripMenuItem hideColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem doubleAnalyzerToolStripMenuItem;
        private TPanalyzer.TraceTemplate traceTemplate1;
        private System.Windows.Forms.ToolStripMenuItem splitTraceWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoResizeTraceCollumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem closeTraceToolStripMenuItem;
        private System.Windows.Forms.Timer timerProgressMonitor;
    }
}

