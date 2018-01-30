namespace TPanalyzer
{
    partial class TraceTemplate
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scHorizontal = new System.Windows.Forms.SplitContainer();
            this.scVerticalTop = new System.Windows.Forms.SplitContainer();
            this.dgvTraceTop = new System.Windows.Forms.DataGridView();
            this.cMenuIDHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timestampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.filterSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseTraceBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbDetailsTop = new System.Windows.Forms.RichTextBox();
            this.cMenuRTBoxTop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sellectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scVerticalBottom = new System.Windows.Forms.SplitContainer();
            this.dgvTraceBottom = new System.Windows.Forms.DataGridView();
            this.rtbDetailsBottom = new System.Windows.Forms.RichTextBox();
            this.cMenuRTBoxBottom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scHorizontal)).BeginInit();
            this.scHorizontal.Panel1.SuspendLayout();
            this.scHorizontal.Panel2.SuspendLayout();
            this.scHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scVerticalTop)).BeginInit();
            this.scVerticalTop.Panel1.SuspendLayout();
            this.scVerticalTop.Panel2.SuspendLayout();
            this.scVerticalTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraceTop)).BeginInit();
            this.cMenuIDHeader.SuspendLayout();
            this.cMenuRTBoxTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scVerticalBottom)).BeginInit();
            this.scVerticalBottom.Panel1.SuspendLayout();
            this.scVerticalBottom.Panel2.SuspendLayout();
            this.scVerticalBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraceBottom)).BeginInit();
            this.cMenuRTBoxBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // scHorizontal
            // 
            this.scHorizontal.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scHorizontal.Location = new System.Drawing.Point(0, 0);
            this.scHorizontal.Name = "scHorizontal";
            this.scHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scHorizontal.Panel1
            // 
            this.scHorizontal.Panel1.Controls.Add(this.scVerticalTop);
            this.scHorizontal.Panel1MinSize = 0;
            // 
            // scHorizontal.Panel2
            // 
            this.scHorizontal.Panel2.Controls.Add(this.scVerticalBottom);
            this.scHorizontal.Panel2MinSize = 0;
            this.scHorizontal.Size = new System.Drawing.Size(800, 600);
            this.scHorizontal.SplitterDistance = 300;
            this.scHorizontal.SplitterWidth = 3;
            this.scHorizontal.TabIndex = 0;
            // 
            // scVerticalTop
            // 
            this.scVerticalTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scVerticalTop.Location = new System.Drawing.Point(0, 0);
            this.scVerticalTop.Name = "scVerticalTop";
            // 
            // scVerticalTop.Panel1
            // 
            this.scVerticalTop.Panel1.Controls.Add(this.dgvTraceTop);
            this.scVerticalTop.Panel1MinSize = 200;
            // 
            // scVerticalTop.Panel2
            // 
            this.scVerticalTop.Panel2.Controls.Add(this.rtbDetailsTop);
            this.scVerticalTop.Panel2MinSize = 200;
            this.scVerticalTop.Size = new System.Drawing.Size(800, 300);
            this.scVerticalTop.SplitterDistance = 560;
            this.scVerticalTop.SplitterWidth = 3;
            this.scVerticalTop.TabIndex = 0;
            this.scVerticalTop.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.scVerticalTop_SplitterMoving);
            this.scVerticalTop.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scVerticalTop_SplitterMoved);
            // 
            // dgvTraceTop
            // 
            this.dgvTraceTop.AllowUserToOrderColumns = true;
            this.dgvTraceTop.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dgvTraceTop.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTraceTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTraceTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTraceTop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTraceTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraceTop.ContextMenuStrip = this.cMenuIDHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTraceTop.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTraceTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraceTop.Location = new System.Drawing.Point(0, 0);
            this.dgvTraceTop.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dgvTraceTop.Name = "dgvTraceTop";
            this.dgvTraceTop.ReadOnly = true;
            this.dgvTraceTop.RowHeadersVisible = false;
            this.dgvTraceTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTraceTop.Size = new System.Drawing.Size(560, 300);
            this.dgvTraceTop.TabIndex = 0;
            this.dgvTraceTop.Tag = "Top";
            this.dgvTraceTop.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTraceTop_CellFormatting);
            this.dgvTraceTop.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraceTop_CellMouseEnter);
            this.dgvTraceTop.SelectionChanged += new System.EventHandler(this.dgvTraceTop_SelectionChanged);
            this.dgvTraceTop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvTraceTop_MouseClick);
            // 
            // cMenuIDHeader
            // 
            this.cMenuIDHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideColumnToolStripMenuItem,
            this.showColumnsToolStripMenuItem,
            this.toolStripSeparator4,
            this.filterSetupToolStripMenuItem,
            this.resetAllFiltersToolStripMenuItem,
            this.toolStripSeparator2,
            this.CloseTraceBtn});
            this.cMenuIDHeader.Name = "cMenuIDHeader";
            this.cMenuIDHeader.Size = new System.Drawing.Size(166, 126);
            // 
            // hideColumnToolStripMenuItem
            // 
            this.hideColumnToolStripMenuItem.Name = "hideColumnToolStripMenuItem";
            this.hideColumnToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.hideColumnToolStripMenuItem.Text = "Hide this column";
            this.hideColumnToolStripMenuItem.Click += new System.EventHandler(this.hideColumnToolStripMenuItem_Click);
            // 
            // showColumnsToolStripMenuItem
            // 
            this.showColumnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timestampToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.channelToolStripMenuItem,
            this.iDToolStripMenuItem,
            this.directionToolStripMenuItem,
            this.dLCToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.othersToolStripMenuItem,
            this.toolStripSeparator1,
            this.allToolStripMenuItem});
            this.showColumnsToolStripMenuItem.Name = "showColumnsToolStripMenuItem";
            this.showColumnsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showColumnsToolStripMenuItem.Text = "Show columns";
            // 
            // timestampToolStripMenuItem
            // 
            this.timestampToolStripMenuItem.Name = "timestampToolStripMenuItem";
            this.timestampToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.timestampToolStripMenuItem.Text = "Timestamp";
            this.timestampToolStripMenuItem.Click += new System.EventHandler(this.timestampToolStripMenuItem_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.typeToolStripMenuItem.Text = "Type";
            this.typeToolStripMenuItem.Click += new System.EventHandler(this.typeToolStripMenuItem_Click);
            // 
            // channelToolStripMenuItem
            // 
            this.channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            this.channelToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.channelToolStripMenuItem.Text = "Channel";
            this.channelToolStripMenuItem.Click += new System.EventHandler(this.channelToolStripMenuItem_Click);
            // 
            // iDToolStripMenuItem
            // 
            this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
            this.iDToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.iDToolStripMenuItem.Text = "ID";
            this.iDToolStripMenuItem.Click += new System.EventHandler(this.iDToolStripMenuItem_Click);
            // 
            // directionToolStripMenuItem
            // 
            this.directionToolStripMenuItem.Name = "directionToolStripMenuItem";
            this.directionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.directionToolStripMenuItem.Text = "Direction";
            this.directionToolStripMenuItem.Click += new System.EventHandler(this.directionToolStripMenuItem_Click);
            // 
            // dLCToolStripMenuItem
            // 
            this.dLCToolStripMenuItem.Name = "dLCToolStripMenuItem";
            this.dLCToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.dLCToolStripMenuItem.Text = "DLC";
            this.dLCToolStripMenuItem.Click += new System.EventHandler(this.dLCToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.dataToolStripMenuItem.Text = "Data";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.othersToolStripMenuItem.Text = "Others";
            this.othersToolStripMenuItem.Click += new System.EventHandler(this.othersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
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
            this.filterSetupToolStripMenuItem.Click += new System.EventHandler(this.filterSetupToolStripMenuItem_Click);
            // 
            // resetAllFiltersToolStripMenuItem
            // 
            this.resetAllFiltersToolStripMenuItem.Name = "resetAllFiltersToolStripMenuItem";
            this.resetAllFiltersToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.resetAllFiltersToolStripMenuItem.Text = "Reset all filters";
            this.resetAllFiltersToolStripMenuItem.Click += new System.EventHandler(this.resetAllFiltersToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // CloseTraceBtn
            // 
            this.CloseTraceBtn.Name = "CloseTraceBtn";
            this.CloseTraceBtn.Size = new System.Drawing.Size(165, 22);
            this.CloseTraceBtn.Text = "Close trace";
            this.CloseTraceBtn.Click += new System.EventHandler(this.CloseTraceBtn_Click);
            // 
            // rtbDetailsTop
            // 
            this.rtbDetailsTop.AutoWordSelection = true;
            this.rtbDetailsTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetailsTop.ContextMenuStrip = this.cMenuRTBoxTop;
            this.rtbDetailsTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetailsTop.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbDetailsTop.Location = new System.Drawing.Point(0, 0);
            this.rtbDetailsTop.Name = "rtbDetailsTop";
            this.rtbDetailsTop.Size = new System.Drawing.Size(237, 300);
            this.rtbDetailsTop.TabIndex = 0;
            this.rtbDetailsTop.Tag = "Top";
            this.rtbDetailsTop.Text = "";
            // 
            // cMenuRTBoxTop
            // 
            this.cMenuRTBoxTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sellectAllToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.cMenuRTBoxTop.Name = "cMenuRTBoxTop";
            this.cMenuRTBoxTop.Size = new System.Drawing.Size(124, 48);
            // 
            // sellectAllToolStripMenuItem
            // 
            this.sellectAllToolStripMenuItem.Name = "sellectAllToolStripMenuItem";
            this.sellectAllToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.sellectAllToolStripMenuItem.Text = "Sellect all";
            this.sellectAllToolStripMenuItem.Click += new System.EventHandler(this.sellectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // scVerticalBottom
            // 
            this.scVerticalBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scVerticalBottom.Location = new System.Drawing.Point(0, 0);
            this.scVerticalBottom.Name = "scVerticalBottom";
            // 
            // scVerticalBottom.Panel1
            // 
            this.scVerticalBottom.Panel1.Controls.Add(this.dgvTraceBottom);
            this.scVerticalBottom.Panel1MinSize = 200;
            // 
            // scVerticalBottom.Panel2
            // 
            this.scVerticalBottom.Panel2.Controls.Add(this.rtbDetailsBottom);
            this.scVerticalBottom.Panel2MinSize = 200;
            this.scVerticalBottom.Size = new System.Drawing.Size(800, 297);
            this.scVerticalBottom.SplitterDistance = 560;
            this.scVerticalBottom.SplitterWidth = 3;
            this.scVerticalBottom.TabIndex = 0;
            this.scVerticalBottom.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.scVerticalBottom_SplitterMoving);
            this.scVerticalBottom.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scVerticalBottom_SplitterMoved);
            // 
            // dgvTraceBottom
            // 
            this.dgvTraceBottom.AllowUserToOrderColumns = true;
            this.dgvTraceBottom.AllowUserToResizeRows = false;
            this.dgvTraceBottom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTraceBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTraceBottom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTraceBottom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTraceBottom.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTraceBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraceBottom.Location = new System.Drawing.Point(0, 0);
            this.dgvTraceBottom.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dgvTraceBottom.Name = "dgvTraceBottom";
            this.dgvTraceBottom.ReadOnly = true;
            this.dgvTraceBottom.RowHeadersVisible = false;
            this.dgvTraceBottom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTraceBottom.Size = new System.Drawing.Size(560, 297);
            this.dgvTraceBottom.TabIndex = 1;
            this.dgvTraceBottom.Tag = "Bottom";
            this.dgvTraceBottom.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTraceBottom_CellFormatting);
            this.dgvTraceBottom.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraceBottom_CellMouseEnter);
            this.dgvTraceBottom.SelectionChanged += new System.EventHandler(this.dgvTraceBottom_SelectionChanged);
            this.dgvTraceBottom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvTraceBottom_MouseClick);
            // 
            // rtbDetailsBottom
            // 
            this.rtbDetailsBottom.AutoWordSelection = true;
            this.rtbDetailsBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetailsBottom.ContextMenuStrip = this.cMenuRTBoxBottom;
            this.rtbDetailsBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetailsBottom.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbDetailsBottom.Location = new System.Drawing.Point(0, 0);
            this.rtbDetailsBottom.Name = "rtbDetailsBottom";
            this.rtbDetailsBottom.Size = new System.Drawing.Size(237, 297);
            this.rtbDetailsBottom.TabIndex = 1;
            this.rtbDetailsBottom.Tag = "Bottom";
            this.rtbDetailsBottom.Text = "";
            // 
            // cMenuRTBoxBottom
            // 
            this.cMenuRTBoxBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.cMenuRTBoxBottom.Name = "cMenuRTBoxTop";
            this.cMenuRTBoxBottom.Size = new System.Drawing.Size(124, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem1.Text = "Sellect all";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem2.Text = "Copy";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // TraceTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scHorizontal);
            this.Name = "TraceTemplate";
            this.Size = new System.Drawing.Size(800, 600);
            this.Resize += new System.EventHandler(this.TraceTemplate_Resize);
            this.scHorizontal.Panel1.ResumeLayout(false);
            this.scHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scHorizontal)).EndInit();
            this.scHorizontal.ResumeLayout(false);
            this.scVerticalTop.Panel1.ResumeLayout(false);
            this.scVerticalTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scVerticalTop)).EndInit();
            this.scVerticalTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraceTop)).EndInit();
            this.cMenuIDHeader.ResumeLayout(false);
            this.cMenuRTBoxTop.ResumeLayout(false);
            this.scVerticalBottom.Panel1.ResumeLayout(false);
            this.scVerticalBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scVerticalBottom)).EndInit();
            this.scVerticalBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraceBottom)).EndInit();
            this.cMenuRTBoxBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scHorizontal;
        private System.Windows.Forms.SplitContainer scVerticalTop;
        private System.Windows.Forms.SplitContainer scVerticalBottom;
        private System.Windows.Forms.DataGridView dgvTraceTop;
        private System.Windows.Forms.DataGridView dgvTraceBottom;
        private System.Windows.Forms.RichTextBox rtbDetailsTop;
        private System.Windows.Forms.RichTextBox rtbDetailsBottom;
        private System.Windows.Forms.ContextMenuStrip cMenuIDHeader;
        private System.Windows.Forms.ToolStripMenuItem hideColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem filterSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timestampToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cMenuRTBoxTop;
        private System.Windows.Forms.ToolStripMenuItem sellectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMenuRTBoxBottom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CloseTraceBtn;
    }
}
