﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IDselector
{

    public struct isoTPChannelConfig
    {
        public int n_AI;
        public int n_TA;
        public string alias;
        public int udsKwpSelector;      // 0 = UDS, 1 = KWP, 2..X = reserve
        public enum AdressingMode { Normal = 0, NormalFixed = 1, Extended = 2 }
        public AdressingMode adressingMode;
        public bool extendedID;

        public isoTPChannelConfig(int myN_AI, int myN_TA, string myAlias, int myUdsKwpSelector, AdressingMode myAdressMode, bool myExtendedID)
        {
            n_AI = myN_AI;
            n_TA = myN_TA;
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

        public IDselectorTemplate(isoTPChannelConfig itemConfig)
        {
            InitializeComponent();
            IDitem = itemConfig;

            cbMode.SelectedIndex = (int)IDitem.adressingMode;
            cbExtendedID.Checked = IDitem.extendedID;
            tbNAI.Text = IDitem.n_AI.ToString();
            tbNTA.Text = IDitem.n_TA.ToString();
            tbAlias.Text = IDitem.alias;
            cbUdsKwp.SelectedIndex = (int)IDitem.udsKwpSelector;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnIDSelectorTemp_DeleteItem(e);
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDitem.adressingMode = (isoTPChannelConfig.AdressingMode)cbMode.SelectedIndex;
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void cbUdsKwp_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDitem.udsKwpSelector = cbUdsKwp.SelectedIndex;
            OnIDSelectorTemp_ItemChanged(e);

        }

        private void cbExtendedID_CheckedChanged(object sender, EventArgs e)
        {
            IDitem.extendedID = cbExtendedID.Checked;
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbNAI_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(tbNAI.Text, out IDitem.n_AI);
            OnIDSelectorTemp_ItemChanged(e);

        }

        private void tbNTA_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(tbNTA.Text, out IDitem.n_TA);
            OnIDSelectorTemp_ItemChanged(e);
        }

        private void tbAlias_Leave(object sender, EventArgs e)
        {
            IDitem.alias = tbAlias.Text;
            OnIDSelectorTemp_ItemChanged(e);
        }
    }
}