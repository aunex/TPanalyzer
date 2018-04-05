namespace TPanalyzer
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
            this.cbUdsKwp = new System.Windows.Forms.ComboBox();
            this.cbExtendedID = new System.Windows.Forms.CheckBox();
            this.tbAlias = new System.Windows.Forms.TextBox();
            this.tbRq_N_AI = new System.Windows.Forms.TextBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbRq_N_TA = new System.Windows.Forms.TextBox();
            this.tbRsp_N_TA = new System.Windows.Forms.TextBox();
            this.tbRsp_N_AI = new System.Windows.Forms.TextBox();
            this.tbFRq_N_TA = new System.Windows.Forms.TextBox();
            this.tbFRq_N_AI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChannel = new System.Windows.Forms.ComboBox();
            this.lblMessageName = new System.Windows.Forms.Label();
            this.tbMessageRequest = new System.Windows.Forms.TextBox();
            this.tbMessageResponse = new System.Windows.Forms.TextBox();
            this.tbMessageFRequest = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUdsKwp
            // 
            this.cbUdsKwp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUdsKwp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbUdsKwp.FormattingEnabled = true;
            this.cbUdsKwp.Items.AddRange(new object[] {
            "UDS",
            "KWP2000"});
            this.cbUdsKwp.Location = new System.Drawing.Point(351, 3);
            this.cbUdsKwp.Name = "cbUdsKwp";
            this.cbUdsKwp.Size = new System.Drawing.Size(112, 21);
            this.cbUdsKwp.TabIndex = 10;
            this.cbUdsKwp.Text = "Select UDS/KWP";
            this.cbUdsKwp.SelectedIndexChanged += new System.EventHandler(this.cbUdsKwp_SelectedIndexChanged);
            // 
            // cbExtendedID
            // 
            this.cbExtendedID.AutoSize = true;
            this.cbExtendedID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbExtendedID.Location = new System.Drawing.Point(235, 3);
            this.cbExtendedID.Name = "cbExtendedID";
            this.cbExtendedID.Size = new System.Drawing.Size(110, 22);
            this.cbExtendedID.TabIndex = 11;
            this.cbExtendedID.Text = "29b ID";
            this.cbExtendedID.UseVisualStyleBackColor = true;
            this.cbExtendedID.CheckedChanged += new System.EventHandler(this.cbExtendedID_CheckedChanged_1);
            // 
            // tbAlias
            // 
            this.tbAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAlias.Location = new System.Drawing.Point(3, 3);
            this.tbAlias.Name = "tbAlias";
            this.tbAlias.Size = new System.Drawing.Size(110, 20);
            this.tbAlias.TabIndex = 14;
            this.tbAlias.Leave += new System.EventHandler(this.tbAlias_Leave);
            // 
            // tbRq_N_AI
            // 
            this.tbRq_N_AI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRq_N_AI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRq_N_AI.Location = new System.Drawing.Point(96, 27);
            this.tbRq_N_AI.Name = "tbRq_N_AI";
            this.tbRq_N_AI.Size = new System.Drawing.Size(110, 20);
            this.tbRq_N_AI.TabIndex = 15;
            this.tbRq_N_AI.Leave += new System.EventHandler(this.tbRq_N_AI_Leave);
            // 
            // cbMode
            // 
            this.cbMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Normal",
            "Normal fixed",
            "Extended"});
            this.cbMode.Location = new System.Drawing.Point(119, 3);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(110, 21);
            this.cbMode.TabIndex = 15;
            this.cbMode.Text = "Select addr. mode";
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(34, 125);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbRq_N_TA
            // 
            this.tbRq_N_TA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRq_N_TA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRq_N_TA.Location = new System.Drawing.Point(212, 27);
            this.tbRq_N_TA.Name = "tbRq_N_TA";
            this.tbRq_N_TA.Size = new System.Drawing.Size(110, 20);
            this.tbRq_N_TA.TabIndex = 17;
            this.tbRq_N_TA.Leave += new System.EventHandler(this.tbRq_N_TA_Leave);
            // 
            // tbRsp_N_TA
            // 
            this.tbRsp_N_TA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRsp_N_TA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRsp_N_TA.Location = new System.Drawing.Point(212, 51);
            this.tbRsp_N_TA.Name = "tbRsp_N_TA";
            this.tbRsp_N_TA.Size = new System.Drawing.Size(110, 20);
            this.tbRsp_N_TA.TabIndex = 19;
            this.tbRsp_N_TA.Leave += new System.EventHandler(this.tbRsp_N_TA_Leave);
            // 
            // tbRsp_N_AI
            // 
            this.tbRsp_N_AI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRsp_N_AI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRsp_N_AI.Location = new System.Drawing.Point(96, 51);
            this.tbRsp_N_AI.Name = "tbRsp_N_AI";
            this.tbRsp_N_AI.Size = new System.Drawing.Size(110, 20);
            this.tbRsp_N_AI.TabIndex = 18;
            this.tbRsp_N_AI.Leave += new System.EventHandler(this.tbRsp_N_AI_Leave);
            // 
            // tbFRq_N_TA
            // 
            this.tbFRq_N_TA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFRq_N_TA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFRq_N_TA.Location = new System.Drawing.Point(212, 75);
            this.tbFRq_N_TA.Name = "tbFRq_N_TA";
            this.tbFRq_N_TA.Size = new System.Drawing.Size(110, 20);
            this.tbFRq_N_TA.TabIndex = 21;
            this.tbFRq_N_TA.Leave += new System.EventHandler(this.tbFRq_N_TA_Leave);
            // 
            // tbFRq_N_AI
            // 
            this.tbFRq_N_AI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFRq_N_AI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFRq_N_AI.Location = new System.Drawing.Point(96, 75);
            this.tbFRq_N_AI.Name = "tbFRq_N_AI";
            this.tbFRq_N_AI.Size = new System.Drawing.Size(110, 20);
            this.tbFRq_N_AI.TabIndex = 20;
            this.tbFRq_N_AI.Leave += new System.EventHandler(this.tbFRq_N_AI_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(96, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "n_Ai";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(212, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "n_Ta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tbAlias, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbMode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbExtendedID, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbUdsKwp, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(34, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 28);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbFRq_N_AI, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbFRq_N_TA, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbRsp_N_AI, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbRsp_N_TA, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbRq_N_TA, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbRq_N_AI, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbChannel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMessageName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbMessageRequest, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbMessageResponse, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbMessageFRequest, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(34, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(466, 97);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Func. request";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Request";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Response";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbChannel
            // 
            this.cbChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbChannel.FormattingEnabled = true;
            this.cbChannel.Items.AddRange(new object[] {
            "All channels",
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4",
            "Channel 5",
            "Channel 6",
            "Channel 7",
            "Channel 8",
            "Channel 9",
            "Channel 20",
            "Channel 21",
            "Channel 22",
            "Channel 23",
            "Channel 24",
            "Channel 25",
            "Channel 26",
            "Channel 27",
            "Channel 28",
            "Channel 29",
            "Channel 30"});
            this.cbChannel.Location = new System.Drawing.Point(3, 3);
            this.cbChannel.Name = "cbChannel";
            this.cbChannel.Size = new System.Drawing.Size(87, 21);
            this.cbChannel.TabIndex = 27;
            this.cbChannel.Text = "Channel 1";
            this.cbChannel.SelectedIndexChanged += new System.EventHandler(this.cbChannel_SelectedIndexChanged);
            // 
            // lblMessageName
            // 
            this.lblMessageName.AutoSize = true;
            this.lblMessageName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageName.Location = new System.Drawing.Point(328, 0);
            this.lblMessageName.Name = "lblMessageName";
            this.lblMessageName.Size = new System.Drawing.Size(135, 24);
            this.lblMessageName.TabIndex = 28;
            this.lblMessageName.Text = "Message name";
            this.lblMessageName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tbMessageRequest
            // 
            this.tbMessageRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessageRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessageRequest.Location = new System.Drawing.Point(328, 27);
            this.tbMessageRequest.Name = "tbMessageRequest";
            this.tbMessageRequest.Size = new System.Drawing.Size(135, 20);
            this.tbMessageRequest.TabIndex = 29;
            this.tbMessageRequest.Leave += new System.EventHandler(this.tbMessageRequest_Leave);
            // 
            // tbMessageResponse
            // 
            this.tbMessageResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessageResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessageResponse.Location = new System.Drawing.Point(328, 51);
            this.tbMessageResponse.Name = "tbMessageResponse";
            this.tbMessageResponse.Size = new System.Drawing.Size(135, 20);
            this.tbMessageResponse.TabIndex = 30;
            this.tbMessageResponse.Leave += new System.EventHandler(this.tbMessageResponse_Leave);
            // 
            // tbMessageFRequest
            // 
            this.tbMessageFRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessageFRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessageFRequest.Location = new System.Drawing.Point(328, 75);
            this.tbMessageFRequest.Name = "tbMessageFRequest";
            this.tbMessageFRequest.Size = new System.Drawing.Size(135, 20);
            this.tbMessageFRequest.TabIndex = 31;
            this.tbMessageFRequest.Leave += new System.EventHandler(this.tbMessageFRequest_Leave);
            // 
            // IDselectorTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnDelete);
            this.Name = "IDselectorTemplate";
            this.Size = new System.Drawing.Size(500, 125);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbUdsKwp;
        private System.Windows.Forms.CheckBox cbExtendedID;
        private System.Windows.Forms.TextBox tbAlias;
        private System.Windows.Forms.TextBox tbRq_N_AI;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbRq_N_TA;
        private System.Windows.Forms.TextBox tbRsp_N_TA;
        private System.Windows.Forms.TextBox tbRsp_N_AI;
        private System.Windows.Forms.TextBox tbFRq_N_TA;
        private System.Windows.Forms.TextBox tbFRq_N_AI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbChannel;
        private System.Windows.Forms.Label lblMessageName;
        private System.Windows.Forms.TextBox tbMessageRequest;
        private System.Windows.Forms.TextBox tbMessageResponse;
        private System.Windows.Forms.TextBox tbMessageFRequest;
    }
}
