using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TPanalyzer
{

    public struct isoTPChannelConfig
    {
        public int Rq_n_AI;
        public int Rq_n_TA;
        public int Rsp_n_AI;
        public int Rsp_n_TA;
        public int FRq_n_AI;
        public int FRq_n_TA;
        public string alias;
        public int channel;
        public Byte udsKwpSelector;      // 0 = UDS, 1 = KWP, 2..X = reserve
        public enum AdressingMode { Normal = 0, NormalFixed = 1, Extended = 2 }
        public AdressingMode adressingMode;
        public bool extendedID;

        public isoTPChannelConfig(int myRq_N_AI, int myRq_N_TA, int myRsp_N_AI, int myRsp_N_TA, int myFRq_N_AI, int myFRq_N_TA, int myChannel, string myAlias, Byte myUdsKwpSelector, AdressingMode myAdressMode, bool myExtendedID)
        {
            Rq_n_AI = myRq_N_AI;
            Rq_n_TA = myRq_N_TA;
            Rsp_n_AI = myRsp_N_AI;
            Rsp_n_TA = myRsp_N_TA;
            FRq_n_AI = myFRq_N_AI;
            FRq_n_TA = myFRq_N_TA;
            channel = myChannel;
            alias = myAlias;
            udsKwpSelector = myUdsKwpSelector;
            adressingMode = myAdressMode;
            extendedID = myExtendedID;
        }
    }

    public partial class IDselectorTemplate: UserControl
    {
        public event EventHandler IDSelectorTemp_DeleteItem;
        public event EventHandler IDSelectorTemp_ItemChanged;
        public isoTPChannelConfig IDitem = new isoTPChannelConfig();

        protected virtual void OnIDSelectorTemp_DeleteItem(EventArgs e)
        {
            if (IDSelectorTemp_DeleteItem != null)
            {
                IDSelectorTemp_DeleteItem(this, e);
            }
        }

        protected virtual void OnIDSelectorTemp_ItemChanged(EventArgs e)
        {
            if (IDSelectorTemp_ItemChanged != null)
            {
                IDSelectorTemp_ItemChanged(this, e);
            }
        }

        public IDselectorTemplate(isoTPChannelConfig itemConfig, int index)
        {
            InitializeComponent();
            IDitem = itemConfig;

            cbMode.SelectedIndex = (int)IDitem.adressingMode;
            cbExtendedID.Checked = IDitem.extendedID;
            tbRq_N_AI.Text = string.Format("0x{0} ({1} d)", IDitem.Rq_n_AI.ToString("X4"), IDitem.Rq_n_AI.ToString());
            tbRq_N_TA.Text = IDitem.Rq_n_TA.ToString();
            tbRsp_N_AI.Text = string.Format("0x{0} ({1} d)", IDitem.Rsp_n_AI.ToString("X4"), IDitem.Rsp_n_AI.ToString());
            tbRsp_N_TA.Text = IDitem.Rsp_n_TA.ToString();
            tbFRq_N_AI.Text = string.Format("0x{0} ({1} d)", IDitem.FRq_n_AI.ToString("X4"), IDitem.FRq_n_AI.ToString());
            tbFRq_N_TA.Text = IDitem.FRq_n_TA.ToString();
            tbAlias.Text = IDitem.alias;
            cbUdsKwp.SelectedIndex = (Byte)IDitem.udsKwpSelector;
            cbChannel.SelectedIndex = IDitem.channel;
            if (index % 2 != 0)
            {
                this.BackColor = Color.Gray;
                tableLayoutPanel1.BackColor = Color.Gray;
                tableLayoutPanel2.BackColor = Color.Gray;
                //cbMode.BackColor = Color.LightGray;
                //tbNAI.BackColor = Color.LightGray;
                //tbNTA.BackColor = Color.LightGray;
                //tbAlias.BackColor = Color.LightGray;
                //cbUdsKwp.BackColor = Color.LightGray;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnIDSelectorTemp_DeleteItem(e);
        }


        private void cbUdsKwp_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDitem.udsKwpSelector = (Byte)cbUdsKwp.SelectedIndex;
            OnIDSelectorTemp_ItemChanged(e);

        }

        private void tbAlias_Leave(object sender, EventArgs e)
        {
            IDitem.alias = tbAlias.Text;
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbRq_N_AI_Leave(object sender, EventArgs e)
        {
            if (tbRq_N_AI.Text.Substring(0, 2) != "0x")
            {
                Int32.TryParse(tbRq_N_AI.Text, out IDitem.Rq_n_AI);
            }
            else
            {
                IDitem.Rq_n_AI = (int)new System.ComponentModel.Int32Converter().ConvertFromString(tbRq_N_AI.Text);
            }
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbRq_N_TA_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(tbRq_N_TA.Text, out IDitem.Rq_n_TA);
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbRsp_N_AI_Leave(object sender, EventArgs e)
        {
            if (tbRsp_N_AI.Text.Substring(0, 2) != "0x")
            {
                Int32.TryParse(tbRsp_N_AI.Text, out IDitem.Rsp_n_AI);
            }
            else
            {
                IDitem.Rsp_n_AI = (int)new System.ComponentModel.Int32Converter().ConvertFromString(tbRsp_N_AI.Text);
            }
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbRsp_N_TA_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(tbRsp_N_TA.Text, out IDitem.Rsp_n_TA);
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbFRq_N_AI_Leave(object sender, EventArgs e)
        {
            if (tbFRq_N_AI.Text.Substring(0, 2) != "0x")
            {
                Int32.TryParse(tbFRq_N_AI.Text, out IDitem.FRq_n_AI);
            }
            else
            {
                IDitem.FRq_n_AI = (int)new System.ComponentModel.Int32Converter().ConvertFromString(tbFRq_N_AI.Text);
            }
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbFRq_N_TA_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(tbFRq_N_TA.Text, out IDitem.FRq_n_TA);
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void cbMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            IDitem.adressingMode = (isoTPChannelConfig.AdressingMode)cbMode.SelectedIndex;
            if (IDitem.adressingMode == isoTPChannelConfig.AdressingMode.Normal)
            {
                tbRq_N_TA.Enabled = false;
                tbRsp_N_TA.Enabled = false;
                tbFRq_N_TA.Enabled = false;
            }
            else
            {
                tbRq_N_TA.Enabled = true;
                tbRsp_N_TA.Enabled = true;
                tbFRq_N_TA.Enabled = true;
            }
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void cbExtendedID_CheckedChanged_1(object sender, EventArgs e)
        {
            IDitem.extendedID = cbExtendedID.Checked;
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void cbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDitem.channel = cbChannel.SelectedIndex;
            OnIDSelectorTemp_ItemChanged(e);
        }

    }
}
