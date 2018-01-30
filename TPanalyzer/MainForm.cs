// To do LIST               

// TODO: recent files
// TODO: Form for selecting colors (in trace rows diagnostics highlight, even and odd differentiate, ID selector even and odd diferentiate)


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TPanalyzer;
using System.Drawing;

namespace TPanalyzer
{
    public partial class analyzerMainForm : Form
    {
        public List<DiagServiceconfig> UDSCONFIG = new List<DiagServiceconfig>()
        {
         //   {new DiagServiceconfig(Byte.ClearDiagInfo, 1, "ClearDiagInfo", "Clear diagnostic information",new string[1] {"GroupOfDTC"}, new int [1] {0}, new int [1] {21})},
         //   {new DiagServiceconfig(Byte.DiagnosticSessionControl, 2, "DiagSessionControl", "Diagnostic session control",new string[2] {"SPR", "DiagnosticSessionType"}, new int [2] {0,1}, new int [2] {1, 7})}
        };
           
        // ===========================================================================================================================================================

        private const int MAXCOUNTOFTABS = 10;
        private TPanalyzer.TraceTemplate[] traceTemplates = new TPanalyzer.TraceTemplate[MAXCOUNTOFTABS];             // trace template array - main visual component on working tab - dynamically created for every new tab
        private IDListForm idListForm;
        private TxtFileSelector txtSelector;
        public List<isoTPChannelConfig> isoTpIdList = new List<isoTPChannelConfig>();    // list with IDs which are supposed to contain ISO-TP data coding (including alias and UDS/KWP selector) 
        public string APP_VERSION = "0.0.0.0 - not from instalation"; // not installed

        public int numOfTraces = -1;                       // information about number of traces loaded - tabindex is set according this var
        public int activeTabIndex = 0;                     // information about current active tab (variable is used for selection in the arrays)

        public analyzerMainForm()
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            InitializeComponent();

            APP_VERSION = (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) ? System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : "0.0.0.0 - not from instalation";
            this.Text = "Aunex TP analyzer - " + APP_VERSION;

            tabControlTraces.TabPages.Clear();

        }

        private void loadTraceFile(bool newTab)
        {

            DialogResult result = new DialogResult();
            bool fileFormatIsClear = true;

            result = openDialogTrace.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(openDialogTrace.FileName);
                if (fileExtension == ".txt")
                {
                    fileFormatIsClear = false;
                    txtSelector = new TxtFileSelector();
                    var DialogResult = txtSelector.ShowDialog();
                    if (DialogResult == DialogResult.OK)
                    {
                        switch (txtSelector.formatSelection)
                        {
                            case 0: // Clif datalogger
                                {
                                    fileExtension = ".txtCLIF";
                                    fileFormatIsClear = true;
                                    break;
                                }
                            case 1: // TPCA diag
                                {
                                    fileExtension = ".txtTPCA";
                                    fileFormatIsClear = true;
                                    MessageBox.Show("Unsupported for now");//TODO: TPCA format
                                    break;
                                }
                        }
                    }
                }

                if ((fileFormatIsClear == true))
                {
                    if (newTab)
                    {
                        numOfTraces++;
                        activeTabIndex = numOfTraces;
                    }
                    var logFile = File.ReadAllLines(openDialogTrace.FileName);

                    if (newTab)
                    {
                        newTrace(openDialogTrace.SafeFileName, numOfTraces);
                    }

                    traceTemplates[activeTabIndex].isoTpIdList = isoTpIdList;
                    traceTemplates[activeTabIndex].logList = new List<string>();
                    traceTemplates[activeTabIndex].logList.Add(fileExtension);
                    traceTemplates[activeTabIndex].logList.AddRange(logFile.ToList<String>());

                    traceTemplates[activeTabIndex].startReadingTrace();

                }
            }
        }

        private void newTrace(string tabName, int number)
        {

            TabPage newPage = new TabPage(tabName);
            tabControlTraces.TabPages.Add(newPage);
            tabControlTraces.SelectedIndex = numOfTraces;   // activate new tab imediatelly
            traceTemplates[number] = new TPanalyzer.TraceTemplate { Dock = DockStyle.Fill};
            tabControlTraces.TabPages[number].Controls.Add(traceTemplates[number]);

            if (splitTraceWindowToolStripMenuItem.Checked)
            {
                traceTemplates[number].doubleAnalyzerEnable(splitTraceWindowToolStripMenuItem.Checked);
            }

            traceTemplates[number].Trace_CloseRequest += new EventHandler(closeTrace);
        }

        public void closeTrace(object sender, EventArgs e)
        {
            tabControlTraces.TabPages[activeTabIndex].Controls.RemoveAt(0);
            traceTemplates[activeTabIndex] = null;
            for (int i = activeTabIndex; i < (MAXCOUNTOFTABS - 1); i++)
            {
                traceTemplates[i] = traceTemplates[i + 1];
            }
            tabControlTraces.TabPages.RemoveAt(activeTabIndex);
            numOfTraces--;
        }


        /// ===================   UI callbacks and related methods =========================================================

        #region UI related methods

        private void TraceCloseRequested(object sender, EventArgs e)
        {
            tabControlTraces.TabPages.RemoveAt(activeTabIndex);
            traceTemplates[activeTabIndex] = null;
        }
        
        private void btnMenuLoadTrace_Click(object sender, EventArgs e)
        {
            loadTraceFile(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }


        private void splitTraceWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitTraceWindowToolStripMenuItem.Checked = !splitTraceWindowToolStripMenuItem.Checked;

            for (int i = 0; i < MAXCOUNTOFTABS; i++)
            {
                if (traceTemplates[activeTabIndex] != null)
                {
                    if (traceTemplates[activeTabIndex].doubleAnalyzerState)
                    {
                        traceTemplates[activeTabIndex].doubleAnalyzerEnable(splitTraceWindowToolStripMenuItem.Checked);
                    }
                    else
                    {
                        traceTemplates[activeTabIndex].doubleAnalyzerEnable(splitTraceWindowToolStripMenuItem.Checked);
                    }
                }
            }
        }

        private void tabControlTraces_Selected(object sender, TabControlEventArgs e)
        {
            activeTabIndex = tabControlTraces.SelectedIndex;
        }

        private void autoResizeTraceCollumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iDListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idListForm = new IDListForm(new List<isoTPChannelConfig>());
            DialogResult myResult = idListForm.ShowDialog(isoTpIdList);
            if (myResult == DialogResult.OK)
            {
                isoTpIdList = idListForm.isoTpIdList;
                for (int i = 0; i < MAXCOUNTOFTABS; i++)
                {
                    if (traceTemplates[i] != null)
                    {
                        traceTemplates[i].isoTpIdList = isoTpIdList;
                        traceTemplates[i].startReadingTrace();
                    }
                }
            }
        }

        #endregion

    }
}
