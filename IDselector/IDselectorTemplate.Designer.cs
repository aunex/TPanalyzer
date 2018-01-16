namespace IDselector
{
    partial class IDselectorTemplate
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
            this.tbNAI = new System.Windows.Forms.MaskedTextBox();
            this.tbNTA = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbAlias = new System.Windows.Forms.MaskedTextBox();
            this.cbExtendedID = new System.Windows.Forms.CheckBox();
            this.cbUdsKwp = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNAI
            // 
            this.tbNAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNAI.Location = new System.Drawing.Point(195, 3);
            this.tbNAI.Name = "tbNAI";
            this.tbNAI.Size = new System.Drawing.Size(144, 20);
            this.tbNAI.TabIndex = 4;
            this.tbNAI.Leave += new System.EventHandler(this.tbNAI_Leave);
            // 
            // tbNTA
            // 
            this.tbNTA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNTA.Location = new System.Drawing.Point(345, 3);
            this.tbNTA.Name = "tbNTA";
            this.tbNTA.Size = new System.Drawing.Size(54, 20);
            this.tbNTA.TabIndex = 5;
            this.tbNTA.Leave += new System.EventHandler(this.tbNTA_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.cbMode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbAlias, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbNTA, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbExtendedID, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbNAI, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbUdsKwp, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // cbMode
            // 
            this.cbMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Normal",
            "Normal fixed",
            "Extended"});
            this.cbMode.Location = new System.Drawing.Point(33, 3);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(84, 21);
            this.cbMode.TabIndex = 8;
            this.cbMode.Text = "select...";
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelete.Location = new System.Drawing.Point(3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 24);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbAlias
            // 
            this.tbAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAlias.Location = new System.Drawing.Point(405, 3);
            this.tbAlias.Name = "tbAlias";
            this.tbAlias.Size = new System.Drawing.Size(102, 20);
            this.tbAlias.TabIndex = 6;
            this.tbAlias.Leave += new System.EventHandler(this.tbAlias_Leave);
            // 
            // cbExtendedID
            // 
            this.cbExtendedID.AutoSize = true;
            this.cbExtendedID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbExtendedID.Location = new System.Drawing.Point(123, 3);
            this.cbExtendedID.Name = "cbExtendedID";
            this.cbExtendedID.Size = new System.Drawing.Size(66, 24);
            this.cbExtendedID.TabIndex = 3;
            this.cbExtendedID.Text = "29b ID";
            this.cbExtendedID.UseVisualStyleBackColor = true;
            this.cbExtendedID.CheckedChanged += new System.EventHandler(this.cbExtendedID_CheckedChanged);
            // 
            // cbUdsKwp
            // 
            this.cbUdsKwp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUdsKwp.FormattingEnabled = true;
            this.cbUdsKwp.Items.AddRange(new object[] {
            "UDS",
            "KWP2000"});
            this.cbUdsKwp.Location = new System.Drawing.Point(513, 3);
            this.cbUdsKwp.Name = "cbUdsKwp";
            this.cbUdsKwp.Size = new System.Drawing.Size(84, 21);
            this.cbUdsKwp.TabIndex = 9;
            this.cbUdsKwp.Text = "select...";
            this.cbUdsKwp.SelectedIndexChanged += new System.EventHandler(this.cbUdsKwp_SelectedIndexChanged);
            // 
            // IDselectorTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IDselectorTemplate";
            this.Size = new System.Drawing.Size(600, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox tbNAI;
        private System.Windows.Forms.MaskedTextBox tbNTA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.MaskedTextBox tbAlias;
        private System.Windows.Forms.CheckBox cbExtendedID;
        private System.Windows.Forms.ComboBox cbUdsKwp;
    }
}
