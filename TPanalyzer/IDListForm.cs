using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDselector;
using System.Xml.Serialization;
using System.IO;

namespace TPanalyzer
{
    public partial class IDListForm : Form
    {
        private DialogResult thisResult = DialogResult.None;
        public List<isoTPChannelConfig> isoTpIdList = new List<isoTPChannelConfig>();    // list with IDs which are supposed to contain ISO-TP data coding (including alias and UDS/KWP selector)

        public IDListForm(List<isoTPChannelConfig> initialList)
        {
            InitializeComponent();
            this.Visible = false;
            this.Enabled = false;
            isoTpIdList = initialList;

            loadListToTemplates();
        }

        private void loadListToTemplates()
        {
            flpSelectorRows.Controls.Clear();    // delete all previous items from form

            foreach (isoTPChannelConfig oneConfig in isoTpIdList)
            {
                IDselectorTemplate newSelectorRow = new IDselectorTemplate(oneConfig, isoTpIdList.IndexOf(oneConfig));  // add the row with IDselector for every ID in the list
                newSelectorRow.Tag = isoTpIdList.IndexOf(oneConfig);
                flpSelectorRows.Controls.Add(newSelectorRow);
                this.Width = newSelectorRow.Width + 25;
                newSelectorRow.IDSelectorTemp_DeleteItem += new EventHandler(this.OneIDSelectorTemp_DeleteItem);
                newSelectorRow.IDSelectorTemp_ItemChanged += new EventHandler(this.OneIDSelectorTemp_ItemChnaged);
            }
            if (this.Height < (105 + (36 * isoTpIdList.Count)))
            {
                this.Height = 105 + (36 * isoTpIdList.Count);
            }
        }

        private void AddNewID(object sender, EventArgs e)
        {
            isoTpIdList.Add(new isoTPChannelConfig(0, 0, "Alias_" + (isoTpIdList.Count + 1).ToString(), 0, isoTPChannelConfig.AdressingMode.Normal, false));
            loadListToTemplates();
        }

        public DialogResult ShowDialog(List<isoTPChannelConfig> initialList)
        {
            thisResult = DialogResult.None;
            isoTpIdList = initialList;
            loadListToTemplates();

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            thisResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            thisResult = DialogResult.OK;
        }

        private void OneIDSelectorTemp_DeleteItem(object sender, EventArgs e)
        {
            int tempInt = -1;
            Int32.TryParse((sender as IDselectorTemplate).Tag.ToString(), out tempInt);
            isoTpIdList.RemoveAt(tempInt);
            loadListToTemplates();
        }

        private void OneIDSelectorTemp_ItemChnaged(object sender, EventArgs e)
        {
            int tempInt = -1;
            Int32.TryParse((sender as IDselectorTemplate).Tag.ToString(), out tempInt);

            foreach (object myObject in flpSelectorRows.Controls)
            {
                if (myObject is IDselectorTemplate)
                {
                    if ((myObject as IDselectorTemplate).Tag.ToString() == tempInt.ToString())
                    {
                        isoTpIdList[tempInt] = (myObject as IDselectorTemplate).IDitem;
                    }
                }
            }

            loadListToTemplates();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = sdExport.ShowDialog();
            if (myDialogResult == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<isoTPChannelConfig>));
                TextWriter FileStream = new StreamWriter(sdExport.FileName);
                serializer.Serialize(FileStream, isoTpIdList);
                FileStream.Close();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = odImport.ShowDialog();
            XmlSerializer serializer = new XmlSerializer(typeof(List<isoTPChannelConfig>));
            if (myDialogResult == DialogResult.OK)
            {
                using (FileStream stream = File.OpenRead(odImport.FileName))
                {
                    try
                    {
                        isoTpIdList = (List<isoTPChannelConfig>)serializer.Deserialize(stream);
                        loadListToTemplates();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isoTpIdList.Add(new isoTPChannelConfig(0, 0, "Alias_" + (isoTpIdList.Count + 1).ToString(), 0, isoTPChannelConfig.AdressingMode.Normal, false));
            loadListToTemplates();
        }

        private void IDListForm_Resize(object sender, EventArgs e)
        {
            this.Width = 624;
        }

        private void IDListForm_ResizeBegin(object sender, EventArgs e)
        {
            this.Width = 624;
        }
    }
}
