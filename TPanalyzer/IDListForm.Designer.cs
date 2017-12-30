namespace TPanalyzer
{
    partial class IDListForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.flpSelectorRows = new System.Windows.Forms.FlowLayoutPanel();
            this.sdExport = new System.Windows.Forms.SaveFileDialog();
            this.odImport = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 159);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 46);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(121, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 40);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.Location = new System.Drawing.Point(3, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(112, 40);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(357, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(475, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(116, 40);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // flpSelectorRows
            // 
            this.flpSelectorRows.AutoScroll = true;
            this.flpSelectorRows.AutoSize = true;
            this.flpSelectorRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSelectorRows.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSelectorRows.Location = new System.Drawing.Point(0, 0);
            this.flpSelectorRows.Name = "flpSelectorRows";
            this.flpSelectorRows.Size = new System.Drawing.Size(594, 159);
            this.flpSelectorRows.TabIndex = 2;
            this.flpSelectorRows.WrapContents = false;
            // 
            // sdExport
            // 
            this.sdExport.DefaultExt = "*.xml";
            this.sdExport.FileName = "Export.xml";
            this.sdExport.RestoreDirectory = true;
            // 
            // odImport
            // 
            this.odImport.Filter = "xml files with saved configuration(*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // IDListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 205);
            this.ControlBox = false;
            this.Controls.Add(this.flpSelectorRows);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Name = "IDListForm";
            this.Text = "ID selection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FlowLayoutPanel flpSelectorRows;
        private System.Windows.Forms.SaveFileDialog sdExport;
        private System.Windows.Forms.OpenFileDialog odImport;
    }
}