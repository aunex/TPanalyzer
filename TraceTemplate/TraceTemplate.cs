using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace traceTemplate
{

    [System.ComponentModel.ComplexBindingProperties("DataSource", "DataMember")]
    public partial class TraceTemplate: UserControl
    {
        public event EventHandler TimestampFilter_ChangeRequested;
        public event EventHandler TypeFilter_ChangeRequested;
        public event EventHandler IdFilter_ChangeRequested;
        public event EventHandler AliasFilter_ChangeRequested;
        public event EventHandler ChannelFilter_ChangeRequested;
        public event EventHandler DirectionFilter_ChangeRequested;
        public event EventHandler DLCFilter_ChangeRequested;
        public event EventHandler DataFilter_ChangeRequested;
        public event EventHandler IsoTPDataFilter_ChangeRequested;
        public event EventHandler IsoTPDetailsFilter_ChangeRequested;
        public event EventHandler UdsDataFilter_ChangeRequested;
        public event EventHandler UdsDetailsFilter_ChangeRequested;
        public event EventHandler OthersFilter_ChangeRequested;
        public event EventHandler TraceRowTop_ChangeSelection;
        public event EventHandler TraceRowBottom_ChangeSelection;

        public string timestampFilter = "Timestamp";
        public string typeFilter = "Type";
        public string channelFilter = "Channel";
        public string idFilter = "ID";
        public string aliasFilter = "Alias";
        public string directionFilter = "Direction";
        public string dlcFilter = "DLC";
        public string dataFilter = "CAN_Data";
        public string tpDataFilter = "TP_Data";
        public string tpDetailsFilter = "TP_Details";
        public string udsDataFilter = "UDS/KWP_Data";
        public string udsDetailsFilter = "UDS/KWP_Details";
        public string othersFilter = "Others";
        public bool doubleAnalyzerState = false;
        public DataGridViewSelectedRowCollection dgvTopSelectedRows;
        public DataGridViewSelectedRowCollection dgvBottomSelectedRows;


        int currentMouseOverColTop = 0;
        int currentMouseOverRowTop = 0;
        int currentMouseOverColBottom = 0;
        int currentMouseOverRowBottom = 0;

        public TraceTemplate()
        {
            InitializeComponent();
            scHorizontal.Panel2Collapsed = true;        // start without double analyzer feature
         }

        protected virtual void OnTimestampFilter_ChangeRequested(EventArgs e)
        {
            if (TimestampFilter_ChangeRequested != null)
            {
                TimestampFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnTypeFilter_ChangeRequested(EventArgs e)
        {
            if (TypeFilter_ChangeRequested != null)
            {
                TypeFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnIdFilter_ChangeRequested(EventArgs e)
        {
            if (IdFilter_ChangeRequested != null)
            {
                IdFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnAliasFilter_ChangeRequested(EventArgs e)
        {
            if (AliasFilter_ChangeRequested != null)
            {
                AliasFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnChannelFilter_ChangeRequested(EventArgs e)
        {
            if (ChannelFilter_ChangeRequested != null)
            {
                ChannelFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnDirectionFilter_ChangeRequested(EventArgs e)
        {
            if (DirectionFilter_ChangeRequested != null)
            {
                DirectionFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnDLCFilter_ChangeRequested(EventArgs e)
        {
            if (DLCFilter_ChangeRequested != null)
            {
                DLCFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnDataFilter_ChangeRequested(EventArgs e)
        {
            if (DataFilter_ChangeRequested != null)
            {
                DataFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnIsoTPDataFilter_ChangeRequested(EventArgs e)
        {
            if (IsoTPDataFilter_ChangeRequested != null)
            {
                IsoTPDataFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnIsoTPDetailsFilter_ChangeRequested(EventArgs e)
        {
            if (IsoTPDetailsFilter_ChangeRequested != null)
            {
                IsoTPDetailsFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnUdsDataFilter_ChangeRequested(EventArgs e)
        {
            if (UdsDataFilter_ChangeRequested != null)
            {
                UdsDataFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnUdsDetailsFilter_ChangeRequested(EventArgs e)
        {
            if (UdsDetailsFilter_ChangeRequested != null)
            {
                UdsDetailsFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnOthersFilter_ChangeRequested(EventArgs e)
        {
            if (OthersFilter_ChangeRequested != null)
            {
                OthersFilter_ChangeRequested(this, e);
            }
        }

        protected virtual void OnTraceRowTop_ChangeSelection(EventArgs e)
        {
            if (TraceRowTop_ChangeSelection != null)
            {
                TraceRowTop_ChangeSelection(this, e);
            }
        }

        protected virtual void OnTraceRowBottom_ChangeSelection(EventArgs e)
        {
            if (TraceRowBottom_ChangeSelection != null)
            {
                TraceRowBottom_ChangeSelection(this, e);
            }
        }

        public void ChangeAutoSizeCollumnsMode(DataGridViewAutoSizeColumnsMode newMode)
        {
            dgvTraceTop.AutoSizeColumnsMode = newMode;
            if (newMode == DataGridViewAutoSizeColumnsMode.None)
            {
                dgvTraceTop.AutoResizeColumns();
            }

        }

        public void UpdateRowFilters()
        {
            string rowFilter = "";

            if (timestampFilter != "Timestamp")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", timestampFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", timestampFilter);
                }
            }

            if (typeFilter != "Type")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", typeFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", typeFilter);
                }
            }

            if (channelFilter != "Channel")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", channelFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", channelFilter);
                }
            }

            if (idFilter != "ID")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", idFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", idFilter);
                }
            }

            if (aliasFilter != "Alias")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", aliasFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", aliasFilter);
                }
            }

            if (directionFilter != "Direction")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", directionFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", directionFilter);
                }
            }

            if (dlcFilter != "DLC")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", dlcFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", dlcFilter);
                }
            }

            if (dataFilter != "CAN_Data")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", dataFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", dataFilter);
                }
            }

            if (tpDataFilter != "TP_Data")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", tpDataFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", tpDataFilter);
                }
            }

            if (tpDetailsFilter != "TP_Details")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", tpDetailsFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", tpDetailsFilter);
                }
            }

            if (udsDataFilter != "UDS/KWP_Data")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", udsDataFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", udsDataFilter);
                }
            }

            if (udsDetailsFilter != "UDS/KWP_Details")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", udsDetailsFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", udsDetailsFilter);
                }
            }

            if (othersFilter != "Others")
            {
                if (rowFilter == "")
                {
                    rowFilter += string.Format("{0}", othersFilter);
                }
                else
                {
                    rowFilter += string.Format("{0} {1}", "AND", othersFilter);
                }
            }

            try
            {
                (dgvTraceTop.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error while applying filter");
            }
            dgvTraceTop.Update();
            dgvTraceTop.Refresh();
        }

        public void ClearAllRowFilters()
        {
            timestampFilter = "Timestamp";
            typeFilter = "Type";
            channelFilter = "Channel";
            idFilter = "ID";
            directionFilter = "Direction";
            dlcFilter = "DLC";
            dataFilter = "CAN_Data";
            tpDataFilter = "TP_Data";
            tpDetailsFilter = "TP_Details";
            udsDataFilter = "TP_Data";
            udsDetailsFilter = "TP_Details";
            othersFilter = "Others";

            UpdateRowFilters();
        }

        public void ClearAllVisualComponent()
        {
            dgvTraceTop.Rows.Clear();
            dgvTraceBottom.Rows.Clear();
            dgvTraceTop.Update();
            dgvTraceBottom.Update();
        }

        public void UpdateDGVs()
        {
            dgvTraceTop.Update();
            dgvTraceBottom.Update();
        }

        private void scVerticalTop_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (doubleAnalyzerState)
            {
                scVerticalBottom.SplitterDistance = e.MouseCursorX;
            }   
        }

        private void scVerticalBottom_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (doubleAnalyzerState)
            {
                scVerticalTop.SplitterDistance = e.MouseCursorX;
            }
        }

        private void scVerticalTop_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (doubleAnalyzerState)
            {
                scVerticalBottom.SplitterDistance = scVerticalTop.SplitterDistance;
            }
        }

        private void scVerticalBottom_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (doubleAnalyzerState)
            {
                scVerticalTop.SplitterDistance = scVerticalBottom.SplitterDistance;
            }
        }

        public object DataSourceTop
        {
            get { return dgvTraceTop.DataSource; }
            set { dgvTraceTop.DataSource = value; }
        }

        public string DataMemberTop
        {
            get { return dgvTraceTop.DataMember; }
            set { dgvTraceTop.DataMember = value; }
        }

        public object DataSourceBottom
        {
            get { return dgvTraceBottom.DataSource; }
            set { dgvTraceBottom.DataSource = value; }
        }

        public string DataMemberBottom
        {
            get { return dgvTraceBottom.DataMember; }
            set { dgvTraceBottom.DataMember = value; }
        }

        public string rtbDetailsTopText
        {
            get { return rtbDetailsTop.Text; }
            set { rtbDetailsTop.Text = value; }
        }

        public string rtbDetailsBottomText
        {
            get { return rtbDetailsBottom.Text; }
            set { rtbDetailsBottom.Text = value; }
        }

        public void doubleAnalyzerEnable(bool targetState)
        {
            doubleAnalyzerState = targetState;
            scHorizontal.Panel2Collapsed = !targetState;
        }

        private void dgvTraceTop_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTraceTop.RowCount > 0 && dgvTraceTop.ColumnCount > 9)
            {
                dgvTraceTop.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;     // last empty collumn use as place holder and filler
            }
        }

        private void dgvTraceBottom_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTraceBottom.RowCount > 0 && dgvTraceBottom.ColumnCount > 9)
            {
                dgvTraceBottom.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;      // last empty collumn use as place holder and filler
            }
        }

        private void dgvTraceTop_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (currentMouseOverRowTop == -1)
                {
                    cMenuIDHeader.Show(dgvTraceTop, new Point(e.X, e.Y));
                }

            }
        }

        private void dgvTraceBottom_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (currentMouseOverRowBottom == -1)
                {
                    cMenuIDHeader.Show(dgvTraceBottom, new Point(e.X, e.Y));
                }
           }
        }

        private void dgvTraceBottom_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentMouseOverColBottom = e.ColumnIndex;
            currentMouseOverRowBottom = e.RowIndex;
        }

        private void dgvTraceTop_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentMouseOverColTop = e.ColumnIndex;
            currentMouseOverRowTop = e.RowIndex;
        }

        private void hideColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[currentMouseOverColTop].Visible = false;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[currentMouseOverColBottom].Visible = false;
            }
        }

        private void timestampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[0].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[0].Visible = true;
            }
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[1].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[1].Visible = true;
            }
        }

        private void channelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[2].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[2].Visible = true;
            }
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[3].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[3].Visible = true;
            }
        }

        private void directionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[4].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[4].Visible = true;
            }
        }

        private void dLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[5].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[5].Visible = true;
            }
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[6].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[6].Visible = true;
            }
        }

        private void othersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                dgvTraceTop.Columns[7].Visible = true;
            }
            if (currentMouseOverRowBottom == -1)
            {
                dgvTraceBottom.Columns[7].Visible = true;
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (currentMouseOverRowTop == -1)
            {
                for (i = 0; i < dgvTraceTop.ColumnCount; i++)
                {
                    dgvTraceTop.Columns[i].Visible = true;
                }
            }
            if (currentMouseOverRowBottom == -1)
            {
                for (i = 0; i < dgvTraceBottom.ColumnCount; i++)
                {
                    dgvTraceBottom.Columns[i].Visible = true;
                }
            }
        }

        private void filterSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRowTop == -1)
            {
                
                switch (currentMouseOverColTop)
                {
                    case 0: // Timestamp
                        {
                            OnTimestampFilter_ChangeRequested(e);
                            break;
                        }
                    case 1: // Type
                        {
                            OnTypeFilter_ChangeRequested(e);
                            break;
                        }
                    case 2: // Channel
                        {
                            OnChannelFilter_ChangeRequested(e);
                            break;
                        }
                    case 3: // ID
                        {
                            OnIdFilter_ChangeRequested(e);
                            break;
                        }
                    case 4: // ID
                        {
                            OnAliasFilter_ChangeRequested(e);
                            break;
                        }
                    case 5: // Direction
                        {
                            OnDirectionFilter_ChangeRequested(e);
                            break;
                        }
                    case 6: // DLC
                        {
                            OnDLCFilter_ChangeRequested(e);
                            break;
                        }
                    case 7: // Data
                        {
                            OnDataFilter_ChangeRequested(e);
                            break;
                        }
                    case 8: // ISO TP Data
                        {
                            OnIsoTPDataFilter_ChangeRequested(e);
                            break;
                        }
                    case 9: // ISO TP Details
                        {
                            OnIsoTPDetailsFilter_ChangeRequested(e);
                            break;
                        }
                    case 10: // UDS/KWP Data
                        {
                            OnUdsDataFilter_ChangeRequested(e);
                            break;
                        }
                    case 11: // UDS/KWP Details
                        {
                            OnUdsDetailsFilter_ChangeRequested(e);
                            break;
                        }
                   case 12: // Others
                        {
                            OnOthersFilter_ChangeRequested(e);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void resetAllFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAllRowFilters();
        }

        private void TraceTemplate_Resize(object sender, EventArgs e)
        {
            scHorizontal.SplitterDistance = scHorizontal.Height / 2;
            scVerticalTop.SplitterDistance = (int)(scVerticalTop.Width * 0.8);
            scVerticalBottom.SplitterDistance = (int)(scVerticalBottom.Width * 0.8);
        }

        private void dgvTraceTop_SelectionChanged(object sender, EventArgs e)
        {
            dgvTopSelectedRows = dgvTraceTop.SelectedRows;
            OnTraceRowTop_ChangeSelection(e);
        }

        private void dgvTraceBottom_SelectionChanged(object sender, EventArgs e)
        {
            dgvBottomSelectedRows = dgvTraceBottom.SelectedRows;
            OnTraceRowBottom_ChangeSelection(e);
        }

        //TODO: Dodelat copy, select all atd funkce do richtext boxu
    }
}
