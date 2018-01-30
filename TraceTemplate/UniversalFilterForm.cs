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
    public partial class UniversalFilterForm : Form
    {
        public string filterString = "";
        private DialogResult thisResult = DialogResult.None;

        public UniversalFilterForm()
        {
            InitializeComponent();
            this.Visible = false;
            this.Enabled = false;
        }

        public DialogResult ShowDialog(string currentFilterString)
        {
            thisResult = DialogResult.None;
            tbFilterString.Text = currentFilterString;
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

        private void btnOK_Click(object sender, EventArgs e)
        {

            filterString = tbFilterString.Text;
            thisResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            thisResult = DialogResult.Cancel;
        }

    }
}
