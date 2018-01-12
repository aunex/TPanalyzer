using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPanalyzer
{
    public partial class TxtFileSelector : Form
    {
        public int formatSelection = 0;
        private DialogResult thisResult = DialogResult.None;


        public TxtFileSelector()
        {
            InitializeComponent();
            this.Visible = false;
            this.Enabled = false;
        }

        public DialogResult ShowDialog()
        {
            thisResult = DialogResult.None;
            this.Visible = true;
            this.Enabled = true;
            while (thisResult == DialogResult.None)
            {
                Application.DoEvents();
            }
            this.Visible = false;
            this.Enabled = false;
            return thisResult;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (cbFormatSelection.SelectedIndex >= 0)
            {
                formatSelection = cbFormatSelection.SelectedIndex;
                thisResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Logging format must be selected first.");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            thisResult = DialogResult.Cancel;
        }
    }
}
