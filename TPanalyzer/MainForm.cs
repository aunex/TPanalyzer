// To do LIST               

// TODO: recent files
// TODO: Form for selecting colors (in trace rows diagnostics highlight, even and odd differentiate, ID selector even and odd diferentiate)


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            prepareFileMenu();
            idListForm = new IDListForm(new List<isoTPChannelConfig>());
            idListForm.ReimportRecentConfig();  // try to load last diagnostic configuration
            isoTpIdList = idListForm.isoTpIdList;   // refresh the list after reimport

        }

        private void loadTraceFile(string filename)
        {
            bool fileFormatIsClear = true;
            string fileExtension = Path.GetExtension(filename);

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
                    numOfTraces++;
                    activeTabIndex = numOfTraces;

                    var logFile = File.ReadAllLines(filename);

                    newTrace(filename, numOfTraces);
                    setNewFilepathHistory(filename);
                    traceTemplates[activeTabIndex].isoTpIdList = isoTpIdList;
                    traceTemplates[activeTabIndex].logList = new List<string>();
                    traceTemplates[activeTabIndex].logList.Add(fileExtension);
                    traceTemplates[activeTabIndex].logList.AddRange(logFile.ToList<String>());
                    traceTemplates[activeTabIndex].startReadingTrace();

                }
        }

        private void setNewFilepathHistory(string filepath)
        {
            SetSetting("Filepath_5", GetSetting("Filepath_4"));
            SetSetting("Filepath_4", GetSetting("Filepath_3"));
            SetSetting("Filepath_3", GetSetting("Filepath_2"));
            SetSetting("Filepath_2", GetSetting("Filepath_1"));
            SetSetting("Filepath_1", filepath);
            prepareFileMenu();  // recreate file menu in order to update recent files ....
        }

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
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

        private void prepareFileMenu()
        {
            fileToolStripMenuItem.DropDownItems.Clear();
            fileToolStripMenuItem.DropDownItems.Add("Load new trace", null, btnMenuLoadTrace_Click);
            fileToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

            if (GetSetting("Filepath_1") != "")
            {
                fileToolStripMenuItem.DropDownItems.Add(GetSetting("Filepath_1"), null, RecentFile1_ClickHandler);
                if (GetSetting("Filepath_2") != "")
                {
                    fileToolStripMenuItem.DropDownItems.Add(GetSetting("Filepath_2"), null, RecentFile1_ClickHandler);
                    if (GetSetting("Filepath_3") != "")
                    {
                        fileToolStripMenuItem.DropDownItems.Add(GetSetting("Filepath_3"), null, RecentFile1_ClickHandler);
                        if (GetSetting("Filepath_4") != "")
                        {
                            fileToolStripMenuItem.DropDownItems.Add(GetSetting("Filepath_4"), null, RecentFile1_ClickHandler);
                            if (GetSetting("Filepath_5") != "")
                            {
                                fileToolStripMenuItem.DropDownItems.Add(GetSetting("Filepath_5"), null, RecentFile1_ClickHandler);
                            }
                        }
                    }
                }
            }
            fileToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            fileToolStripMenuItem.DropDownItems.Add("Exit", null, exitToolStripMenuItem_Click);

        }

        private void TraceCloseRequested(object sender, EventArgs e)
        {
            tabControlTraces.TabPages.RemoveAt(activeTabIndex);
            traceTemplates[activeTabIndex] = null;
        }
        
        private void btnMenuLoadTrace_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = openDialogTrace.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadTraceFile(openDialogTrace.FileName);
            }
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

        private void RecentFile1_ClickHandler(object sender, EventArgs e)
        {
            loadTraceFile(GetSetting("Filepath_1"));
        }

        private void RecentFile2_ClickHandler(object sender, EventArgs e)
        {
            loadTraceFile(GetSetting("Filepath_2"));
        }

        private void RecentFile3_ClickHandler(object sender, EventArgs e)
        {
            loadTraceFile(GetSetting("Filepath_3"));
        }

        private void RecentFile4_ClickHandler(object sender, EventArgs e)
        {
            loadTraceFile(GetSetting("Filepath_4"));
        }

        private void RecentFile5_ClickHandler(object sender, EventArgs e)
        {
            loadTraceFile(GetSetting("Filepath_5"));
        }

        #endregion

    }
}
