// To do LIST               

// TODO: recent files
// TODO: nacteni filtru ze souboru a refresh isotp a uds dat v tracu .... pravdepodobne bude nutne znovu spustit parsovani....
// TODO: zadávání ID v hexa formátu


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using traceTemplate;
using IDselector;

namespace TPanalyzer
{
    public struct oneDiagServiceInfo
    {
        public enum Sid
        {
            // Requests
            // Diagnostic and communications management
            DiagnosticSessionControl = 0x10,
            ECUReset = 0x11,
            SecurityAcces = 0x27,
            CommunicationControl = 0x28,
            TesterPresent = 0x3E,
            AccesTimingParameters = 0x83,
            SecuredDataTransmission = 0x84,
            ControlDTCSettings = 0x85,
            ResponseOnEvent = 0x86,
            LinkControl = 0x87,
            //Data transmission
            ReadDataById = 0x22,
            ReadMemoryByAddress = 0x23,
            ReadScalingDataByIdentifier = 0x24,
            ReadDataByPeriodicIdentifier = 0x2A,
            DynamicallyDefineDataIdentifier = 0x2C,
            WriteDataById = 0x2E,
            WriteMemoryByAddress = 0x3D,
            //Stored data transmission
            ClearDiagInfo = 0x14,
            ReadDiagInfo = 0x19,
            //Input/output control
            InOutControlByIdentifier = 0x2F,
            //Remote activation of routine
            RoutineControl = 0x31,
            //Upload and download
            RequestDownload = 0x34,
            RequestUpload = 0x35,
            TransferDat = 0x36,
            RequestTransferExit = 0x37,
            RequestFileTransfer = 0x38,

            // Positive Responses
            PosResp_DiagnosticSessionControl = 0x50,
            PosResp_ECUReset = 0x51,
            PosResp_SecurityAcces = 0x67,
            PosResp_CommunicationControl = 0x68,
            PosResp_TesterPresent = 0x7E,
            PosResp_AccesTimingParameters = 0xC3,
            PosResp_SecuredDataTransmission = 0xC4,
            PosResp_ControlDTCSettings = 0xC5,
            PosResp_ResponseOnEvent = 0xC6,
            PosResp_LinkControl = 0xC7,
            //Data transmission
            PosResp_ReadDataById = 0x62,
            PosResp_ReadMemoryByAddress = 0x63,
            PosResp_ReadScalingDataByIdentifier = 0x64,
            PosResp_ReadDataByPeriodicIdentifier = 0x6A,
            PosResp_DynamicallyDefineDataIdentifier = 0x6C,
            PosResp_WriteDataById = 0x6E,
            PosResp_WriteMemoryByAddress = 0x7D,
            //Stored data transmission
            PosResp_ClearDiagInfo = 0x54,
            PosResp_ReadDiagInfo = 0x59,
            //Input/output control
            PosResp_InOutControlByIdentifier = 0x6F,
            //Remote activation of routine
            PosResp_RoutineControl = 0x71,
            //Upload and download
            PosResp_RequestDownload = 0x74,
            PosResp_RequestUpload = 0x75,
            PosResp_TransferDat = 0x76,
            PosResp_RequestTransferExit = 0x77,
            PosResp_RequestFileTransfer = 0x78,
            // Negative response
            NegativeResponse = 0x7F
        }
        public Sid sid;
        public int did;
        public byte[] parameters;
        public bool validData;       // frame contain the correct number of bytes for all bytes = true

        public oneDiagServiceInfo(Sid mySID, int myDID, byte[] pars)
        {
            sid = mySID;
            did = myDID;
            parameters = pars;
            validData = true;
        }
    }

    public struct DiagServiceconfig
    {   // template/structure with information about every KWP and UDS service
        oneDiagServiceInfo.Sid sid;
        int parByteCount;
        string shortName;
        string longName;
        string[] parNames;
        int[] startBits;
        int[] endBits;

        public DiagServiceconfig(oneDiagServiceInfo.Sid newSID, int newParByteCount, string newShortName, string newLongName, string[] newParNames, int[] newStartBits, int[] newEndtBits)
        {
            sid = newSID;
            parByteCount = newParByteCount;
            shortName = newShortName;
            longName = newLongName;
            parNames = newParNames;
            startBits = newStartBits;
            endBits = newEndtBits;
        }
    }

    public struct stringTraceInterface
    {
        public string strTimestamp;
        public string strType;
        public string strChannel;
        public string strId;
        public string strDirection;
        public string strDLC;
        public string strData;
        public string strOthers;
    }

    public partial class analyzerMainForm : Form
    {

        public class IsoTpInformation
        {
            public int byteCount { get; set; }       // Number of bytes, which are ISOTP information
            public byte[] segmentData { get; set; }  // data of this one segment of Frame
            public enum FrameType {None = -1, Single = 0, First = 1, Consecutive = 2, Flowcontrol = 3 };
            public FrameType frameType { get; set; } // 0 = Single frame, 1 = First frame, 2 = Consecutive frame, 3 = Flowcontrol frame
            public enum FcFlag {None = -1, CTS = 0, Wait = 1, Overflow = 2 }; // three posibilities of fcFlag
            public FcFlag fcFlag { get; set; }       // flow control flag transfered in flowcontrol frame
            public int blockSize { get; set; }       // block size transfered in flowcontrol frame
            public int separationTime { get; set; }  // separation time transfered in flowcontrol frame
            public int consIndex { get; set; }       // index of consecutive frame
            public int frameGroup { get; set; }      // number, which says, that frame with same frameGroup belongs together (means first frame and respective consecutive and flowcontrol frames has the same frameGroup)
            public int higherLayerDataLength { get; set; }  // Total length of data in whole frame
            public byte[] higherLayerData { get; set; }     // data for higher level for examplel UDS or KWP  
            public int n_AI { get; set; }           // Network address information = CAN ID of this frame in case of normal adressing
            public int n_TA { get; set; }           // Network target adress - in case of extended adressing is not part of n_AI
            public bool errorInFrame { get; set; }   // information whether the frame contains any error e.g. missing one of frames

            public IsoTpInformation()
            {
                byteCount = -1;
                segmentData = null;
                frameType = IsoTpInformation.FrameType.None;
                fcFlag = IsoTpInformation.FcFlag.None;
                blockSize = -1;
                separationTime = -1;
                consIndex = -1;
                frameGroup = -1;
                higherLayerDataLength = -1;
                higherLayerData = null;
                n_AI = -1;
                n_TA = -1;
                errorInFrame = false;
            }
        }

        public class IsoTPBuffer
        {
            public struct isoTpBufferItem
            {
               public int n_AI;
               public int n_TA;
               public Byte[] dataBytes;
               public int dataBytesCountTarget;
               public int dataBytesCountBuffered;
               public int dataBytesPointer;
            }
            private isoTpBufferItem[] tpBuffer = new isoTpBufferItem[16];

            public IsoTPBuffer()
            {
                this.tpBuffer = new isoTpBufferItem[16] ;
            }

            /// <summary>
            /// Method adds the temporary data into the buffer for respective CAN ID. If dataBytesCountTarget > 0 method also sets the dataBytesCountTarget in tpBuffer. If there is no item in buffer with respective CAN ID, method creates the new one.  
            /// </summary>
            /// <param name="canID"> CAN Identifier of iso-TP channel, which data should be added to.</param>
            /// <param name="dataBytesCountTarget">Data bytes count for whole frame. While add the first frame, this parameter should be set, and while add the consecutive frames, the parameter must be set = 0. </param>
            /// <param name="data"> Data bytes array to copy into the buffer.</param>
            /// <returns>int return value: 0 = Error during buffering of data; 1 = data added to new frame. Frame is NOT finished; 2 = data added to existing frame. Frame is NOT finished; 3 = data added to existing frame. Frame is finished; 4 = data added to new frame, but previous unfinished frame was overwritten. New frame is NOT finished; </returns>
            public int AddDataToBuffer(int n_AI, int n_TA, int dataBytesCountTarget, byte[] data)
            {
                int result = -1;
                int i,j = 0;

                for (i = 0; i < tpBuffer.Length; i++ )
                {
                    if ((tpBuffer[i].n_AI == n_AI) && (tpBuffer[i].n_TA == n_TA))
                    {   // item with this Address information already exists
                        if (dataBytesCountTarget > 0)
                        {// new first frame, while unfinished frame was in the buffer - overwrite previous unfinished frame and return error. 
                            Array.Resize(ref tpBuffer[i].dataBytes, dataBytesCountTarget);
                            tpBuffer[i].dataBytesPointer = 0;
                            tpBuffer[i].dataBytesCountTarget = dataBytesCountTarget;
                            for (j = 0; j < data.Length; j++)
                            {
                                if ((tpBuffer[i].dataBytesPointer + j) < tpBuffer[i].dataBytes.Length)
                                {
                                    tpBuffer[i].dataBytes[tpBuffer[i].dataBytesPointer + j] = data[j];
                                }
                                else
                                {   // data to copy was longer then expected from the first frame information - ignore rest of data bytes (0xAA or 0x55 fillers)

                                }
                            }
                            tpBuffer[i].dataBytesPointer += data.Length;
                            tpBuffer[i].dataBytesCountBuffered += data.Length;
                            result = 4;
                        }
                        else
                        {// consecutive frame - add data to existing item and check, wheather the frame is already finished or not.

                            for (j = 0; j < data.Length; j++)
                            {
                                if ((tpBuffer[i].dataBytesPointer + j) < tpBuffer[i].dataBytes.Length)
                                {
                                    tpBuffer[i].dataBytes[tpBuffer[i].dataBytesPointer + j] = data[j];
                                }
                                else
                                {   // data to copy was longer then expected from the first frame information - ignore rest of data bytes (0xAA or 0x55 fillers)

                                }
                            }
                            tpBuffer[i].dataBytesPointer += data.Length;
                            tpBuffer[i].dataBytesCountBuffered += data.Length;

                            if (tpBuffer[i].dataBytesCountBuffered >= tpBuffer[i].dataBytesCountTarget)
                            {
                                result = 3;
                            }
                            else
                            {
                                result = 2;
                            }
                        }
                    }
                }
                if (result == -1)
                {// item with this CAN ID doesn't exist in the buffer and therefore must be created in first empty (null) position 
                    if (dataBytesCountTarget > 0)
                    {// new first frame - create the isoTpBufferItem with number of dataBytes according dataBytesCountTarget 
                        for (i = 0; i < tpBuffer.Length; i++)
                        {
                            if (tpBuffer[i].dataBytes == null)
                            {
                                tpBuffer[i].dataBytes = new byte[dataBytesCountTarget];
                                tpBuffer[i].n_AI = n_AI;
                                tpBuffer[i].n_TA = n_TA;
                                tpBuffer[i].dataBytesCountTarget = dataBytesCountTarget;
                                tpBuffer[i].dataBytesPointer = 0;

                                for (j = 0; j < data.Length; j++)
                                {
                                    if ((tpBuffer[i].dataBytesPointer + j) < tpBuffer[i].dataBytes.Length)
                                    {
                                        tpBuffer[i].dataBytes[tpBuffer[i].dataBytesPointer + j] = data[j];
                                    }
                                    else
                                    {   // not expected - first frame must be full of data and data must not be longer then datalength information from this frame

                                    }
                                }
                                tpBuffer[i].dataBytesPointer += data.Length;
                                tpBuffer[i].dataBytesCountBuffered += data.Length;
                            }
                        }
                        result = 1;
                    }
                    else
                    {// consecutive frame - no previous information about length of frame = ERROR
                        result = 0;
                    }
                }
                return result;
            }

            /// <summary>
            /// Method returns the isoTpInformation structure of the finished frame with respective CAN identifier.
            /// </summary>
            /// <param name="canID">CAN ID of frame, which should be returned.</param>
            /// <param name="deleteAfterReturn">Should the frame in buffer be deleted?</param>
            /// <returns>isoTpInformation structure of the finished frame with respective CAN identifier</returns>
            public IsoTpInformation getFinishedFrame(int n_AI, int n_TA, bool deleteAfterReturn)
            {
                int i = 0;
                IsoTpInformation result = new IsoTpInformation();

                for (i = 0; i < tpBuffer.Length; i++)
                {
                    if ((tpBuffer[i].n_AI == n_AI) && (tpBuffer[i].dataBytesCountBuffered >= tpBuffer[i].dataBytesCountTarget))
                    {
                        result.n_AI = n_AI;
                        result.higherLayerDataLength = tpBuffer[i].dataBytesCountTarget;
                        result.higherLayerData = tpBuffer[i].dataBytes;
                    }

                    if (deleteAfterReturn)
                    {
                        tpBuffer[i].n_AI = -1;
                        tpBuffer[i].dataBytes = null;
                        tpBuffer[i].dataBytesPointer = 0;
                        tpBuffer[i].dataBytesCountBuffered = 0;
                        tpBuffer[i].dataBytesCountTarget = 0;
                    }
                }

                if (result.n_AI != n_AI)     // no finished frame with requested CAN ID has been found
                {
                    result = null;
                }

                return result;
            }

            public void DeleteBufferItem(int canID)
            {
                int i = 0;

                for (i = 0; i < tpBuffer.Length; i++)
                {
                    if ((tpBuffer[i].n_AI == canID) && (tpBuffer[i].dataBytesCountBuffered >= tpBuffer[i].dataBytesCountTarget))
                    {
                        tpBuffer[i].n_AI = -1;
                        tpBuffer[i].dataBytes = null;
                        tpBuffer[i].dataBytesPointer = 0;
                        tpBuffer[i].dataBytesCountBuffered = 0;
                        tpBuffer[i].dataBytesCountTarget = 0;
                    }
                }
            }

        }
        
        public class DiagFrameInformation
        {


            public int servicesCount;
            public oneDiagServiceInfo[] services { get; set; }


            public DiagFrameInformation()
            {
                servicesCount = 0;
                this.services = new oneDiagServiceInfo[15];
            }

            public void AddService(oneDiagServiceInfo.Sid sid, int did, byte[] pars)
            {
                servicesCount++;
                services[servicesCount] = new oneDiagServiceInfo(sid, did, pars);
            }

            public void clearAllServices()
            {       // only set the pointer to zero
                servicesCount = 0;
            }
        }


        public List<DiagServiceconfig> UDSCONFIG = new List<DiagServiceconfig>()
        {
            {new DiagServiceconfig(oneDiagServiceInfo.Sid.ClearDiagInfo, 1, "ClearDiagInfo", "Clear diagnostic information",new string[1] {"GroupOfDTC"}, new int [1] {0}, new int [1] {21})},
            {new DiagServiceconfig(oneDiagServiceInfo.Sid.DiagnosticSessionControl, 2, "DiagSessionControl", "Diagnostic session control",new string[2] {"SPR", "DiagnosticSessionType"}, new int [2] {0,1}, new int [2] {1, 7})}
        };

        //{ oneUdsServiceInfo.Sid.ClearDiagInfo, 1 },
        //{ oneUdsServiceInfo.Sid.CommunicationControl, 1 },
        //{ oneUdsServiceInfo.Sid.ControlDTCSettings, 1 },
        //{ oneUdsServiceInfo.Sid.DiagnosticSessionControl, 1 },
        //{ oneUdsServiceInfo.Sid.DynamicallyDefineDataIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.ECUReset, 1 },
        //{ oneUdsServiceInfo.Sid.InOutControlByIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.LinkControl, 1 },
        //{ oneUdsServiceInfo.Sid.NegativeResponse, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_AccesTimingParameters, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ClearDiagInfo, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_CommunicationControl, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ControlDTCSettings, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_DiagnosticSessionControl, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_DynamicallyDefineDataIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ECUReset, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_InOutControlByIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_LinkControl,1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDataById, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDataByPeriodicIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDiagInfo, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadMemoryByAddress, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadScalingDataByIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDataByPeriodicIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDataByPeriodicIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDataByPeriodicIdentifier, 1 },
        //{ oneUdsServiceInfo.Sid.PosResp_ReadDataByPeriodicIdentifier, 1 },

            
        // ===========================================================================================================================================================

        static BackgroundWorker bwParseTrace;    // Background worker for running analysis of ASC file in the seperate thread
        public IsoTPBuffer myIsoTpBuffer = new IsoTPBuffer();  // create isoTP buffer instance for handling temporary isoTP data  
        private UniversalFilterForm myFilterForm = new UniversalFilterForm();   // Filter form - setup form for setup rowfilter criterion
        public List<String>[] logList = new List<string>[MAXCOUNTOFTABS];

        private const int MAXCOUNTOFTABS = 8;
        public DataTable[] dtTracesA = new DataTable[MAXCOUNTOFTABS];    // dataTable as a datasource for datagridview on the Top of trace teplate
        public DataTable[] dtTracesB = new DataTable[MAXCOUNTOFTABS];    // dataTable as a datasource for datagridview on the Bottom of trace teplate
        public List<IsoTpInformation>[] isoTpInfoList = new List<IsoTpInformation>[MAXCOUNTOFTABS];             // ISO-TP information array - for every tab is seperate
        public List<DiagFrameInformation>[] diagInfoList = new List<DiagFrameInformation>[MAXCOUNTOFTABS];  // UDS information array - for every tab is seperate
        private TraceTemplate[] traceTemplates = new TraceTemplate[MAXCOUNTOFTABS];             // trace template array - main visual component on working tab - dynamically created for every new tab
        private IDListForm idListForm;
        private TxtFileSelector txtSelector;
        public List<isoTPChannelConfig> isoTpIdList = new List<isoTPChannelConfig>();    // list with IDs which are supposed to contain ISO-TP data coding (including alias and UDS/KWP selector) 


        public int numOfTraces = -1;                       // information about number of traces loaded - tabindex is set according this var
        public int activeTabIndex = 0;                     // information about current active tab (variable is used for selection in the arrays)
        public int rowInTrace = 0;                         // information about number of rows in trace currently loaded
        public int rowOfTraceLoaded = 0;                   // information about actual number of loaded rows from trace


        public analyzerMainForm()
        {
            InitializeComponent();
            tabControlTraces.TabPages.Clear();
            updateLabelStrip("Load the trace file in 'File' menu.");
            updateProgresBarStrip(0);

            isoTpIdList.Add(new isoTPChannelConfig(402391170, 0, "Request", 0, 0, true));       // temporary assingment !!!
            isoTpIdList.Add(new isoTPChannelConfig(402522242, 0, "Response", 0, 0, true));     // temporary assingment !!!
            isoTpIdList.Add(new isoTPChannelConfig(0x700, 0, "Request all", 0, 0, false));      // temporary assingment !!!
            isoTpIdList.Add(new isoTPChannelConfig(0x710, 0, "GW_Req", 0, 0, false));      // temporary assingment !!!
            isoTpIdList.Add(new isoTPChannelConfig(0x77A, 0, "GW_Resp", 0, 0, false));      // temporary assingment !!!
            isoTpIdList.Add(new isoTPChannelConfig(0x4AE, 0, "GW_Req1", 0, 0, false));      // temporary assingment !!!
            isoTpIdList.Add(new isoTPChannelConfig(0x772, 0, "GW_Resp1", 0, 0, false));      // temporary assingment !!!

            bwParseTrace = new BackgroundWorker { WorkerReportsProgress = false, WorkerSupportsCancellation = true };
            bwParseTrace.DoWork += bwParseTrace_ParseTrace;
            bwParseTrace.ProgressChanged += bwParseTrace_ProgressChanged;
            bwParseTrace.RunWorkerCompleted += bwParseTrace_ParseCompleted;

        }

        private void bwParseTrace_ParseTrace(object sender, DoWorkEventArgs e)
        {   // content of this method is running on seperate working thread
            updateLabelStrip("Loading trace...");
            switch (logList[activeTabIndex][0])
            {
                case (".asc"):
                    {
                        logList[activeTabIndex].ForEach(parseASCLine);
                        break;
                    }
                case (".trc"):
                    {
                        logList[activeTabIndex].ForEach(parseTRCLine);
                        break;
                    }
                case (".txtCLIF"):
                    {
                        logList[activeTabIndex].ForEach(parseCLIFLine);
                        break;
                    }
                case (".txtTPCA"):
                    {
                        logList[activeTabIndex].ForEach(parseTPCALine);
                        break;
                    }
            }
        }

        private void bwParseTrace_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Console.WriteLine("Hotovo procent " + e.ProgressPercentage + "%");
            //updateLabelStrip("Loading trace...(" + e.ProgressPercentage + " % done)");
        }

        private void bwParseTrace_ParseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   // content of this method is running after working is finished
            updateLabelStrip("Trace is completely loaded");
            updateProgresBarStrip(0);
            traceTemplates[activeTabIndex].ChangeAutoSizeCollumnsMode(DataGridViewAutoSizeColumnsMode.None);
            traceTemplates[activeTabIndex].UpdateDGVs();
        }

        private void newTrace(string tabName, int number)
        {

            tabControlTraces.TabPages.Add(tabName, tabName, numOfTraces);
            tabControlTraces.SelectedIndex = numOfTraces;   // activate new tab imediatelly
            isoTpInfoList[number] = new List<IsoTpInformation>();
            diagInfoList[number] = new List<DiagFrameInformation>();

            traceTemplates[number] = new TraceTemplate {Dock = DockStyle.Fill};
            tabControlTraces.TabPages[number].Controls.Add(traceTemplates[number]);

            traceTemplates[number].TimestampFilter_ChangeRequested += new EventHandler(this.TimestampFilterRequest);
            traceTemplates[number].TypeFilter_ChangeRequested += new EventHandler(this.TypeFilterRequest);
            traceTemplates[number].ChannelFilter_ChangeRequested += new EventHandler(this.ChannelFilterRequest);
            traceTemplates[number].IdFilter_ChangeRequested += new EventHandler(this.IdFilterRequest);
            traceTemplates[number].AliasFilter_ChangeRequested += new EventHandler(this.AliasFilterRequest);
            traceTemplates[number].DirectionFilter_ChangeRequested += new EventHandler(this.DirectionFilterRequest);
            traceTemplates[number].DLCFilter_ChangeRequested += new EventHandler(this.DLCFilterRequest);
            traceTemplates[number].DataFilter_ChangeRequested += new EventHandler(this.DataFilterRequest);
            traceTemplates[number].IsoTPDataFilter_ChangeRequested += new EventHandler(this.IsoTPDataFilterRequest);
            traceTemplates[number].IsoTPDetailsFilter_ChangeRequested += new EventHandler(this.IsoTPDetailsFilterRequest);
            traceTemplates[number].UdsDataFilter_ChangeRequested += new EventHandler(this.UdsDataFilterRequest);
            traceTemplates[number].UdsDetailsFilter_ChangeRequested += new EventHandler(this.UdsDetailsFilterRequest);
            traceTemplates[number].OthersFilter_ChangeRequested += new EventHandler(this.OthersFilterRequest);
            traceTemplates[number].TraceRowTop_ChangeSelection += new EventHandler(this.TraceTopRowSelectionChanged);
            traceTemplates[number].TraceRowBottom_ChangeSelection += new EventHandler(this.TraceBottomRowSelectionChanged);
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

                if ((!bwParseTrace.IsBusy) && (fileFormatIsClear == true))
                {
                    if (newTab)
                    {
                        numOfTraces++;
                        activeTabIndex = numOfTraces;
                    }
                    updateLabelStrip("Loading trace...");
                    var logFile = File.ReadAllLines(openDialogTrace.FileName);
                    logList[activeTabIndex] = new List<string>();
                    logList[activeTabIndex].Add(fileExtension);
                    logList[activeTabIndex].AddRange(logFile.ToList<String>());

                    if (newTab)
                    {
                        newTrace(openDialogTrace.SafeFileName, numOfTraces);
                    }

                    rowInTrace = logList[activeTabIndex].Count;
                    rowOfTraceLoaded = 1;

                    prepareDataTables();            // clear and prepare blank datatables
                    traceTemplates[activeTabIndex].DataSourceTop = dtTracesA[activeTabIndex];
                    traceTemplates[activeTabIndex].DataSourceBottom = dtTracesB[activeTabIndex];

                    bwParseTrace.RunWorkerAsync();    // start the background process, which fill the data tables with actual data 
                }
                else if (bwParseTrace.IsBusy)
                {
                    MessageBox.Show("Trace parsing not ready - parser is busy. Repeat your request later.");
                }
            }
        }

        public void prepareDataTables()
        {
            if (dtTracesA[activeTabIndex] != null)
            {
                dtTracesA[activeTabIndex].Clear();
                dtTracesA[activeTabIndex].Dispose();
                isoTpInfoList[activeTabIndex].Clear();
                diagInfoList[activeTabIndex].Clear();
            }

            if (dtTracesB[activeTabIndex] != null)
            {
                dtTracesB[activeTabIndex].Clear();
                dtTracesB[activeTabIndex].Dispose();
            }

            dtTracesA[activeTabIndex] = new DataTable();
            dtTracesA[activeTabIndex].Columns.Add("Timestamp", typeof(float));
            dtTracesA[activeTabIndex].Columns.Add("Type", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("Channel", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("ID", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("Alias", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("Direction", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("DLC", typeof(int));
            dtTracesA[activeTabIndex].Columns.Add("CAN_Data", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("TP_Data", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("TP_Details", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("UDS/KWP_Data", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("UDS/KWP_Details", typeof(string));
            dtTracesA[activeTabIndex].Columns.Add("Others", typeof(string));

            dtTracesB[activeTabIndex] = new DataTable();
            dtTracesB[activeTabIndex].Columns.Add("Timestamp", typeof(float));
            dtTracesB[activeTabIndex].Columns.Add("Type", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("Channel", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("ID", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("Alias", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("Direction", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("DLC", typeof(int));
            dtTracesB[activeTabIndex].Columns.Add("CAN_Data", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("TP_Data", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("TP_Details", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("UDS/KWP_Data", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("UDS/KWP_Details", typeof(string));
            dtTracesB[activeTabIndex].Columns.Add("Others", typeof(string));


        }

        public void parseASCLine(string s)
        {
            stringTraceInterface result = new stringTraceInterface();
            int i, id, dlc, tempInt = 0;
            string tempString = "";

            if (s.Substring(0, 1) == " ")   // skip lines, where any text is from the first collumn == comments and useless trace texts
            {
                // ============ Timestamp ====================================
                result.strTimestamp = s.Substring(1, 10);
                result.strTimestamp = result.strTimestamp.Trim();

                //============== Channel / Type =====================================
                result.strChannel = s.Substring(12, 2);
                result.strChannel = result.strChannel.Trim();

                if (int.TryParse(result.strChannel, out tempInt) == false)
                {
                    result.strChannel = s.Substring(12, (s.Length - 12));
                    result.strChannel = result.strChannel.Trim();
                    result.strOthers = result.strChannel;
                    result.strChannel = "";
                    result.strType = "Other";
                }
                else
                {
                    result.strType = "CAN";
                    result.strOthers = "";
                }

                // ============= ID ==========================================
                result.strId = s.Substring(15, 8);
                result.strId = result.strId.Trim();

                try
                {
                    id = Convert.ToInt32(result.strId, 16);
                }
                catch (Exception e)
                {
                    result.strOthers = s.Substring(15, s.Length - 15);
                    result.strId = "";
                }

                if (result.strId != "")
                {
                    // ============= Direction ===================================
                    result.strDirection = s.Substring(31, 4);
                    result.strDirection = result.strDirection.Trim();

                    // ============= DLC ========================================
                    result.strDLC = s.Substring(38, 1);
                    result.strDLC = result.strDLC.Trim();
                    int.TryParse(result.strDLC, out dlc);

                    // ============= data =======================================
                    result.strData = " ";
                    for (i = 0; i < dlc; i++)
                    {
                        tempString = s.Substring((40 + (3 * i)), 2);
                        tempString = tempString.Trim();
                        result.strData += tempString + "   ";
                    }
                    result.strData = result.strData.TrimEnd();

                }
                parseInterface(result);
            }

        }

        public void parseTRCLine(string s)
        {
            stringTraceInterface result = new stringTraceInterface();
            int i, id, dlc, tempInt = 0;
            string tempString = "";

            if ((s.Substring(0, 1) != "!") && (s.Substring(0, 1) == " "))   // skip line with comments
            {
                // ============ Timestamp ====================================
                result.strTimestamp = s.Substring(9, 13);
                result.strTimestamp = result.strTimestamp.Trim();

                //============== Channel / Type =====================================

                result.strType = s.Substring(23, 2);
                result.strType = result.strType.Trim();

                if (result.strType == "DT")
                {
                    result.strType = "CAN";     // DT means CAN type
                }

                result.strChannel = s.Substring(26, 2);
                result.strChannel = result.strChannel.Trim();

                // ============= ID ==========================================
                result.strId = s.Substring(29, 8);
                result.strId = result.strId.Trim();

                try
                {
                    id = Convert.ToInt32(result.strId, 16);
                }
                catch (Exception e)
                {
                    result.strOthers = s.Substring(14, s.Length - 15);
                    result.strId = "";
                }

                if (result.strId != "")
                {
                    // ============= Direction ===================================
                    result.strDirection = s.Substring(38, 2);
                    result.strDirection = result.strDirection.Trim();

                    // ============= DLC ========================================
                    result.strDLC = s.Substring(44, 4);
                    result.strDLC = result.strDLC.Trim();
                    int.TryParse(result.strDLC, out dlc);

                    // ============= data =======================================
                    result.strData = " ";
                    for (i = 0; i < dlc; i++)
                    {
                        tempString = s.Substring((49 + (3 * i)), 2);
                        tempString = tempString.Trim();
                        result.strData += tempString + "   ";
                    }
                    result.strData = result.strData.TrimEnd();

                }
                parseInterface(result);
            }

        }

        public void parseCLIFLine(string s)
        {
            stringTraceInterface result = new stringTraceInterface();
            int i, id, dlc, index = 0;
            string[] tempString = new string[15];
            int[] itemDelimiter = new int[15];
            if (s != "")    // skip empty lines
            {
                if (s.Substring(0, 1) == " ")   // skip line with comments
                {
                    itemDelimiter[index++] = s.IndexOf(" ");
                    while (itemDelimiter[index - 1] >= 0)
                    {
                        itemDelimiter[index++] = s.IndexOf(' ', itemDelimiter[index - 2] + 1);
                        if (index == itemDelimiter.Length)
                        {
                            break;
                        }
                    }

                    for (i = 0; i < index -1; i++)
                    {
                        if (itemDelimiter[i+1] != -1)
                        {
                            tempString[i] = s.Substring(itemDelimiter[i]+1, (itemDelimiter[i + 1] - itemDelimiter[i]));
                        } 
                    }


                    // ============ Timestamp ====================================
                    result.strTimestamp = tempString[0];
                    result.strTimestamp = result.strTimestamp.Trim();

                    if (tempString[1] != null)
                    {
                        result.strId = tempString[1];
                        result.strId = result.strId.Trim();
                        result.strType = "CAN";
                        result.strChannel = "1";
                        try
                        {
                            id = Convert.ToInt32(result.strId, 16);
                        }
                        catch (Exception e)
                        {
                            result.strOthers = s.Substring(itemDelimiter[1] + 1);
                            result.strId = "";
                            result.strType = "Other";
                            result.strDLC = "";
                        }
                    }
                    else
                    {
                        result.strOthers = s.Substring(itemDelimiter[1] + 1);
                        result.strId = "";
                        result.strType = "Other";
                        result.strDLC = "";
                    }

                    if (result.strId != "")
                    {
                        // ============= Direction ===================================
                        result.strDirection = "";   // not used in this type of trace

                        // ============= DLC ========================================
                        result.strDLC = tempString[2];
                        int.TryParse(result.strDLC, out dlc);

                        // ============= data =======================================
                        result.strData = " ";
                        for (i = 0; i < dlc; i++)
                        {
                            result.strData += tempString[i+3] + "  ";       // only two spaces, because every tempString contains already one
                        }
                        result.strData = result.strData.TrimEnd();

                    }
                    parseInterface(result);
                }

            }

        }

        public void parseTPCALine(string s)
        {
            stringTraceInterface result = new stringTraceInterface();
            int i, id, dlc, index = 0;
            string[] tempString = new string[15];
            int[] itemDelimiter = new int[15];
            if (s != "")    // skip empty lines
            {
                if (s.Substring(0, 1) == " ")   // skip line with comments
                {
                    itemDelimiter[index] = 0;
                    do
                    {
                        itemDelimiter[index] = s.IndexOf(" ", itemDelimiter[index]+1);
                    }
                    while (s.Substring((itemDelimiter[index] + 1), 1) == " ");
                    index++;
                    while (itemDelimiter[index - 1] >= 0)
                    {
                        itemDelimiter[index++] = s.IndexOf(' ', itemDelimiter[index - 2] + 1);
                        if (index == itemDelimiter.Length)
                        {
                            break;
                        }
                    }

                    for (i = 0; i < index - 1; i++)
                    {
                        if (itemDelimiter[i + 1] != -1)
                        {
                            tempString[i] = s.Substring(itemDelimiter[i] + 1, (itemDelimiter[i + 1] - itemDelimiter[i]));
                        }
                    }


                    // ============ Timestamp ====================================
                    result.strTimestamp = tempString[0];
                    result.strTimestamp = result.strTimestamp.Trim();

                    if ((tempString[1] != null) && (tempString[2] != null) && (tempString[3] != null))      // timestamp, direction, ID and DLC are all conditions for CAN frames
                    {
                        result.strDirection = tempString[1];
                        result.strDirection = result.strDirection.Trim();
                            result.strId = tempString[2];
                            result.strId = result.strId.Trim();
                            result.strType = "CAN";
                            result.strChannel = "1";
                            try
                            {
                                id = Convert.ToInt32(result.strId, 16);
                            }
                            catch (Exception e)
                            {
                                result.strOthers = s.Substring(itemDelimiter[1] + 1);
                                result.strId = "";
                                result.strType = "Other";
                                result.strDLC = "";
                            }

                    }
                    else
                    {
                        result.strOthers = s.Substring(itemDelimiter[1] + 1);
                        result.strDirection = "";
                        result.strId = "";
                        result.strType = "Other";
                        result.strDLC = "";
                    }

                    if (result.strId != "")
                    {
                        // ============= DLC ========================================
                        result.strDLC = tempString[3];
                        int.TryParse(result.strDLC, out dlc);

                        // ============= data =======================================
                        result.strData = " ";
                        for (i = 0; i < dlc; i++)
                        {
                            result.strData += tempString[i + 4] + "  ";       // only two spaces, because every tempString contains already one
                        }
                        result.strData = result.strData.TrimEnd();

                    }
                    parseInterface(result);
                }

            }

        }

        public void parseInterface(stringTraceInterface strInterface)
        {

            int i = 0;
            string tempString = "";
            float floatTimestamp = 0f;
            string strIsoTp = "";
            string strIsoTpDetails = "";
            string strUdsKwp = "";
            string strUdsKwpDetails = "";
            string strAlias = "";
            int dlc = 0;
            int id = 0;
            Byte[] dataByte = new Byte[8];
            IsoTpInformation tpInfo = new IsoTpInformation();
            DiagFrameInformation diagFrameInfo = new DiagFrameInformation();
            bool goOnWithParsing = true;


//            Application.DoEvents();
            if (true)   
            {
                // ============ Timestamp ====================================

                float.TryParse(strInterface.strTimestamp.Replace('.', ','), out floatTimestamp);

                //============== Channel / Type =====================================
                if (strInterface.strType != "CAN")
                {
                    goOnWithParsing = false;
                }

                if (goOnWithParsing)
                {
                    // ============= ID ==========================================

                    try
                    {
                        id = Convert.ToInt32(strInterface.strId, 16);
                    }
                    catch (Exception e)
                    {
                        goOnWithParsing = false;
                    }

                    if (goOnWithParsing)
                    {
                        // ============= Direction ===================================

                        // ============= DLC ========================================

                        int.TryParse(strInterface.strDLC, out dlc);

                        // ============= data =======================================
                        for (i = 0; i < dlc; i++)
                        {
                            tempString = strInterface.strData.Substring ((1+(5 * i)), 2);
                            tempString = tempString.Trim();
                            try
                            {
                                dataByte[i] = Convert.ToByte(tempString, 16);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }

                        strInterface.strData = strInterface.strData.TrimEnd();

                        // ========= ISO TP ========================================
                        goOnWithParsing = false;
                        foreach (isoTPChannelConfig config in isoTpIdList)  // try to find out, whether this N_AI matches with any item in isotp ID list
                        {
                            if ((config.n_AI == id) && (config.adressingMode != isoTPChannelConfig.AdressingMode.Extended))
                            {
                                goOnWithParsing = true;
                                strAlias = config.alias;
                                tpInfo = parseISOTPData(id, dataByte, false);         // parse this segment with normal addressing mode
                                break;
                            }
                            else if ((config.n_AI == id) && (config.n_TA == dataByte[0]) && (config.adressingMode == isoTPChannelConfig.AdressingMode.Extended))
                            {
                                goOnWithParsing = true;
                                strAlias = config.alias;
                                tpInfo = parseISOTPData(id, dataByte, true);        // parse this segment with extended addressing mode
                                break;
                            }
                        }


                        if (goOnWithParsing)   // if this network adress information matches with any item in isotp ID list
                        {
                            strIsoTp = strInterface.strData.Substring(0, (5 * tpInfo.byteCount));
                            isoTpInfoList[activeTabIndex].Add(tpInfo);

                            if (tpInfo.frameType == IsoTpInformation.FrameType.First)
                            {
                                strIsoTpDetails = "FF ";
                                if (tpInfo.n_TA != -1)
                                {
                                    strIsoTpDetails += string.Format(", N_AI = 0x{0}, N_TA = 0x{1}", tpInfo.n_AI.ToString("X4"), tpInfo.n_TA.ToString("X2"));
                                }
                                strIsoTpDetails += string.Format(", DL = {0}", tpInfo.higherLayerDataLength.ToString());
                                strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 5), (5 * (8 - tpInfo.byteCount)) - 2);
                                diagInfoList[activeTabIndex].Add(null);
                            }
                            else if (tpInfo.frameType == IsoTpInformation.FrameType.Single)
                            {
                                strIsoTpDetails = "SF ";
                                if (tpInfo.n_TA != -1)
                                {
                                    strIsoTpDetails += string.Format(", N_AI = 0x{0}, N_TA = 0x{1}", tpInfo.n_AI.ToString("X4"), tpInfo.n_TA.ToString("X2"));
                                }
                                strIsoTpDetails += string.Format(", DL = {0}", tpInfo.higherLayerDataLength.ToString());
                                strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 5), (5 * (tpInfo.higherLayerDataLength)) - 2);
                                diagFrameInfo = parseDiagData(tpInfo.higherLayerData);
                                diagInfoList[activeTabIndex].Add(diagFrameInfo);
                                strUdsKwpDetails = string.Format("{0}", diagFrameInfo.services[0].sid.ToString());
                                if (diagFrameInfo.services[0].did != -1)
                                {
                                    strUdsKwpDetails += string.Format(", DID = 0x{0}", diagFrameInfo.services[0].did.ToString("X4"));
                                }
                                strUdsKwpDetails += string.Format(", Parameters count = {0}", diagFrameInfo.services[0].parameters.Length);
                            }
                            else if (tpInfo.frameType == IsoTpInformation.FrameType.Consecutive)
                            {
                                strIsoTpDetails = string.Format("CF, Index = {0}", tpInfo.consIndex.ToString());
                                if (tpInfo.higherLayerData != null) // consecutive frame with higher layer data is the last one = whole frame is finished
                                {   // last consecutive frame
                                    strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 5), (5 * (8 - tpInfo.byteCount)) - 2);
                                    diagFrameInfo = parseDiagData(tpInfo.higherLayerData);
                                    diagInfoList[activeTabIndex].Add(diagFrameInfo);
                                    strUdsKwpDetails = string.Format("{0}", diagFrameInfo.services[0].sid.ToString());
                                    if (diagFrameInfo.services[0].did != -1)
                                    {
                                        strUdsKwpDetails += string.Format(", DID = 0x{0}", diagFrameInfo.services[0].did.ToString("X4"));
                                    }
                                    strUdsKwpDetails += string.Format(", Parameters count = {0}", diagFrameInfo.services[0].parameters.Length);
                                }
                                else
                                {
                                    strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 5), (5 * (8 - tpInfo.byteCount)) - 2);
                                    diagInfoList[activeTabIndex].Add(null);
                                }
                                
                            }
                            else if (tpInfo.frameType == IsoTpInformation.FrameType.Flowcontrol)
                            {
                                strIsoTpDetails = string.Format("FCF, Flag = {0}, BS = {1}, STmin = {2}", tpInfo.fcFlag, tpInfo.blockSize.ToString(), tpInfo.separationTime.ToString());
                                diagInfoList[activeTabIndex].Add(null);
                            }
                        }
                        else
                        {
                            isoTpInfoList[activeTabIndex].Add(null);
                            diagInfoList[activeTabIndex].Add(null);
                        }
                    }
                    else
                    { 
                        isoTpInfoList[activeTabIndex].Add(null);
                        diagInfoList[activeTabIndex].Add(null);
                    }
                }
                else
                {   // all values in lists must be null
                    strInterface.strDLC = "";   // if the frame is not CAN, hide the zero in the DLC field
                    isoTpInfoList[activeTabIndex].Add(null);
                    diagInfoList[activeTabIndex].Add(null);
                }
                dtTracesA[activeTabIndex].Rows.Add(new object[]{floatTimestamp, strInterface.strType, strInterface.strChannel, strInterface.strId, strAlias, strInterface.strDirection, dlc, strInterface.strData, strIsoTp, strIsoTpDetails, strUdsKwp, strUdsKwpDetails, strInterface.strOthers });
                dtTracesB[activeTabIndex].Rows.Add(new object[]{floatTimestamp, strInterface.strType, strInterface.strChannel, strInterface.strId, strAlias, strInterface.strDirection, dlc, strInterface.strData, strIsoTp, strIsoTpDetails, strUdsKwp, strUdsKwpDetails, strInterface.strOthers });
            }
            rowOfTraceLoaded++;
            //updateProgresBarStrip((int)((float)rowOfTraceLoaded / (float)rowInTrace * 100F));
        }
         
        public void updateLabelStrip(string text)
        {
//            analyzerMainForm myMainForm = new analyzerMainForm();
            lblToolStrip.Text = text;
        }

        public void updateProgresBarStrip(int percentage)
        {
//            analyzerMainForm myMainForm = new analyzerMainForm();
            if (percentage < pbBottomStrip.Minimum)
            {
                pbBottomStrip.Value = 0;
            }
            else if (percentage > pbBottomStrip.Maximum)
            {
                pbBottomStrip.Value = pbBottomStrip.Maximum;
            }
            else
            {
                pbBottomStrip.Value = percentage;
            }

        }

        public IsoTpInformation parseISOTPData(int canID, Byte[] dataToParse, bool extendedAdresing)
        {
            IsoTpInformation result = new IsoTpInformation();

            result.n_AI = canID;
            if (extendedAdresing)
            {
                result.n_TA = dataToParse[0];
                result.frameType = (IsoTpInformation.FrameType)((dataToParse[1] & 0xF0) >> 4);
                switch (result.frameType)
                {
                    case IsoTpInformation.FrameType.Single: // single frame - 1B of isotp information = high nibble frame type information and low nibble data count
                        {
                            result.byteCount = 2;
                            result.higherLayerDataLength = (dataToParse[1] & 0x0F);    // low half of first byte
                            result.higherLayerData = new byte[result.higherLayerDataLength];
                            for (int i = 0; i < result.higherLayerDataLength; i++)
                            {
                                result.higherLayerData[i] = dataToParse[i + result.byteCount];
                            }
                            break;
                        }
                    case IsoTpInformation.FrameType.First: // first frame - 3B of isotp information = 
                        {
                            result.byteCount = 3;
                            result.higherLayerDataLength = dataToParse[2] + (256 * (dataToParse[1] & 0x0F));
                            byte[] tempArray = new byte[6];
                            for (int i = 0; i < (8 - result.byteCount); i++)
                            {
                                tempArray[i] = dataToParse[i + result.byteCount];
                            }
                            myIsoTpBuffer.AddDataToBuffer(canID, 0, result.higherLayerDataLength, tempArray);
                            result.higherLayerData = null;
                            break;
                        }
                    case IsoTpInformation.FrameType.Consecutive: // consecutive frame - 1B of isotp information = 
                        {
                            result.byteCount = 2;
                            byte[] tempArray = new byte[7];
                            for (int i = 0; i < (8 - result.byteCount); i++)
                            {
                                tempArray[i] = dataToParse[i + result.byteCount];
                            }
                            int tempResult = (myIsoTpBuffer.AddDataToBuffer(canID, 0, 0, tempArray));
                            if (tempResult == 3)        // means that frame is already finished
                            {
                                result = myIsoTpBuffer.getFinishedFrame(canID, 0, true); // get the whole frame data for higher layer and delete the temporary data from buffer
                            }
                            result.n_AI = canID;
                            result.frameType = IsoTpInformation.FrameType.Consecutive;
                            result.byteCount = 1;
                            result.consIndex = (dataToParse[0] & 0x0F);
                            break;
                        }
                    case IsoTpInformation.FrameType.Flowcontrol: // flowcontrol frame - 3B of isotp information = 
                        {
                            result.byteCount = 4;
                            result.fcFlag = (IsoTpInformation.FcFlag)(dataToParse[0] & 0x0F);
                            result.blockSize = dataToParse[1];
                            result.separationTime = dataToParse[2];
                            break;
                        }
                    default:
                        {
                            result.frameType = IsoTpInformation.FrameType.None;
                            break;
                        }
                }
            }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            else
            {
                result.frameType = (IsoTpInformation.FrameType)((dataToParse[0] & 0xF0) >> 4);
                switch (result.frameType)
                {
                    case IsoTpInformation.FrameType.Single: // single frame - 1B of isotp information = high nibble frame type information and low nibble data count
                        {
                            result.byteCount = 1;
                            result.higherLayerDataLength = (dataToParse[0] & 0x0F);    // low half of first byte
                            result.higherLayerData = new byte[result.higherLayerDataLength];
                            for (int i = 0; i < result.higherLayerDataLength; i++)
                            {
                                result.higherLayerData[i] = dataToParse[i + result.byteCount];
                            }
                            break;
                        }
                    case IsoTpInformation.FrameType.First: // first frame - 3B of isotp information = 
                        {
                            result.byteCount = 2;
                            result.higherLayerDataLength = dataToParse[1] + (256 * (dataToParse[0] & 0x0F));
                            byte[] tempArray = new byte[6];
                            for (int i = 0; i < (8 - result.byteCount); i++)
                            {
                                tempArray[i] = dataToParse[i + result.byteCount];
                            }
                            myIsoTpBuffer.AddDataToBuffer(canID, 0, result.higherLayerDataLength, tempArray);
                            result.higherLayerData = null;
                            break;
                        }
                    case IsoTpInformation.FrameType.Consecutive: // consecutive frame - 1B of isotp information = 
                        {
                            result.byteCount = 1;
                            byte[] tempArray = new byte[7];
                            for (int i = 0; i < (8 - result.byteCount); i++)
                            {
                                tempArray[i] = dataToParse[i + result.byteCount];
                            }
                            int tempResult = (myIsoTpBuffer.AddDataToBuffer(canID, 0, 0, tempArray));
                            if (tempResult == 3)        // means that frame is already finished
                            {
                                result = myIsoTpBuffer.getFinishedFrame(canID, 0, true); // get the whole frame data for higher layer and delete the temporary data from buffer
                            }
                            result.n_AI = canID;
                            result.frameType = IsoTpInformation.FrameType.Consecutive;
                            result.byteCount = 1;
                            result.consIndex = (dataToParse[0] & 0x0F);
                            break;
                        }
                    case IsoTpInformation.FrameType.Flowcontrol: // flowcontrol frame - 3B of isotp information = 
                        {
                            result.byteCount = 3;
                            result.fcFlag = (IsoTpInformation.FcFlag)(dataToParse[0] & 0x0F);
                            result.blockSize = dataToParse[1];
                            result.separationTime = dataToParse[2];
                            break;
                        }
                    default:
                        {
                            result.frameType = IsoTpInformation.FrameType.None;
                            break;
                        }
                }
            }
            return result;
        }

        public int getNumberOfDiagParBytes(oneDiagServiceInfo.Sid sid)
        {
            int result = -1;

            switch (sid)
            {
                case (oneDiagServiceInfo.Sid.AccesTimingParameters):
                    {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                    }
                case (oneDiagServiceInfo.Sid.ClearDiagInfo):
                    {
                        result = 3;        
                        break;
                    }
                case (oneDiagServiceInfo.Sid.CommunicationControl):
                    {
                        result = 2;       
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ControlDTCSettings):
                    {
                        result = 4;      
                        break;
                    }
                case (oneDiagServiceInfo.Sid.DiagnosticSessionControl):
                    {
                        result = 1;
                        break;
                    }
                case (oneDiagServiceInfo.Sid.DynamicallyDefineDataIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ECUReset):
                    {
                        result = 1;  
                        break;
                    }
                case (oneDiagServiceInfo.Sid.InOutControlByIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.LinkControl):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.NegativeResponse):
                    {
                        result = 2;       
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_AccesTimingParameters):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ClearDiagInfo):
                    {
                        result = 0;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_CommunicationControl):
                    {
                        result = 1; 
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ControlDTCSettings):
                    {
                        result = 1;  
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_DiagnosticSessionControl):
                    {
                        result = 5;  
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_DynamicallyDefineDataIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ECUReset):
                    {
                        result = 1;        
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_InOutControlByIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_LinkControl):
                    {
                        result = 1;       
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ReadDataById):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ReadDataByPeriodicIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ReadDiagInfo):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ReadMemoryByAddress):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ReadScalingDataByIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_RequestDownload):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_RequestFileTransfer):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_RequestTransferExit):
                    {
                        result = 0; 
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_RequestUpload):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_ResponseOnEvent):
                    {
                        result = 6;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_RoutineControl):
                    {
                        result = 6;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_SecuredDataTransmission):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_SecurityAcces):
                    {
                        result = -1;        // not fix number of parameters bytes in case of seed transfer = 5 and in case of key acknowledge = 1
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_TesterPresent):
                    {
                        result = 0;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_TransferDat):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_WriteDataById):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.PosResp_WriteMemoryByAddress):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ReadDataById):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ReadDataByPeriodicIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ReadDiagInfo):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ReadMemoryByAddress):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ReadScalingDataByIdentifier):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.RequestDownload):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.RequestFileTransfer):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.RequestTransferExit):
                    {
                        result = 0; 
                        break;
                    }
                case (oneDiagServiceInfo.Sid.RequestUpload):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.ResponseOnEvent):
                    {
                        result = 6; 
                        break;
                    }
                case (oneDiagServiceInfo.Sid.RoutineControl):
                    {
                        result = 6;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.SecuredDataTransmission):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.SecurityAcces):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.TesterPresent):
                    {
                        result = 1; 
                        break;
                    }
                case (oneDiagServiceInfo.Sid.TransferDat):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.WriteDataById):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }
                case (oneDiagServiceInfo.Sid.WriteMemoryByAddress):
                    {
                        result = -1;        // not fix number of parameters bytes or parameters count unknown
                        break;
                    }

                default:
                {
                        result = -1;
                        break;
                }
            }


            return result;
        }

        public int getDIDposition(oneDiagServiceInfo.Sid sid)
        {
            {
                int result = -1;

                switch (sid)
                {
                    case (oneDiagServiceInfo.Sid.PosResp_InOutControlByIdentifier):
                        {
                            result = 1;
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.PosResp_ReadDataById):
                        {
                            result = 1;
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.PosResp_ReadScalingDataByIdentifier):
                        {
                            result = 1;        
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.PosResp_RoutineControl):
                        {
                            result = 2;        
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.PosResp_WriteDataById):
                        {
                            result = 1;        
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.ReadDataById):
                        {
                            result = 1;        
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.ReadDataByPeriodicIdentifier):
                        {
                            result = 1;        
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.ReadScalingDataByIdentifier):
                        {
                            result = 1;   
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.RoutineControl):
                        {
                            result = 1;       
                            break;
                        }
                    case (oneDiagServiceInfo.Sid.WriteDataById):
                        {
                            result = 1;      
                            break;
                        }

                    default:
                        {
                            result = -1;
                            break;
                        }
                }
                return result;
            }

        }

        public DiagFrameInformation parseDiagData(Byte[] dataToParse)
        {
            DiagFrameInformation result = new DiagFrameInformation();
            int pointer = 0;
            int tempByteCount = 0;

            tempByteCount = getNumberOfDiagParBytes((oneDiagServiceInfo.Sid)(dataToParse[pointer]));

            if (tempByteCount == 0)
            {
                result.services[result.servicesCount] = new oneDiagServiceInfo((oneDiagServiceInfo.Sid)(dataToParse[pointer]), -1, new byte[0]);//
                result.services[result.servicesCount].sid = (oneDiagServiceInfo.Sid)(dataToParse[pointer]);
            }

            else if (tempByteCount == -1)
            {
                result.services[result.servicesCount] = new oneDiagServiceInfo((oneDiagServiceInfo.Sid)(dataToParse[pointer]), -1, new byte[(dataToParse.Length - 1)]);
                result.services[result.servicesCount].sid = (oneDiagServiceInfo.Sid)(dataToParse[pointer]);
                for (int i = 0; i < (dataToParse.Length-1); i++)
                {
                    if ((pointer + 1 + i) <= dataToParse.Length)
                    {
                        result.services[result.servicesCount].parameters[i] = dataToParse[pointer + 1 + i];
                    }
                    else
                    {
                        result.services[result.servicesCount].validData = false;
                    }
                }
                pointer += (dataToParse.Length);
            }

            else if (tempByteCount > 0)
            {
                result.services[result.servicesCount] = new oneDiagServiceInfo((oneDiagServiceInfo.Sid)(dataToParse[pointer]), -1, new byte[tempByteCount]);//
                result.services[result.servicesCount].sid = (oneDiagServiceInfo.Sid)(dataToParse[pointer]);
                for (int i = 0; i < tempByteCount; i++)
                {
                    if ((pointer + 1 + i) <= dataToParse.Length)
                    {
                        result.services[result.servicesCount].parameters[i] = dataToParse[pointer + 1 + i];
                    }
                    else
                    {
                        result.services[result.servicesCount].validData = false;
                    }
                    pointer += tempByteCount + 1;
                }
            }

            var tempDIDposition = getDIDposition(result.services[result.servicesCount].sid);

            if (tempDIDposition != -1)
            {
                result.services[result.servicesCount].did = (result.services[result.servicesCount].parameters[tempDIDposition - 1] << 8);
                result.services[result.servicesCount].did += (result.services[result.servicesCount].parameters[tempDIDposition]);
            }

            return result;
        }


        /// ===================   UI callbacks and related methods =========================================================

        #region UI related methods

        private void TraceTopRowSelectionChanged(object sender, EventArgs e)
        {
            traceTemplates[activeTabIndex].rtbDetailsTopText = createDetail(traceTemplates[activeTabIndex].dgvTopSelectedRows, new isoTPChannelConfig());        
        }

        private void TraceBottomRowSelectionChanged(object sender, EventArgs e)
        {
            traceTemplates[activeTabIndex].rtbDetailsBottomText = createDetail(traceTemplates[activeTabIndex].dgvBottomSelectedRows, new isoTPChannelConfig());
        }

        private string createDetail(DataGridViewSelectedRowCollection rowSelected, isoTPChannelConfig idConfig)
        {
            string result = "";

            if ((rowSelected.Count <= 4) && (traceTemplates[activeTabIndex] != null))    // Single line detail
            {
                foreach (DataGridViewRow row in rowSelected)
                {
                    int rowIndex = row.Index;
                    if (rowIndex < dtTracesA[activeTabIndex].Rows.Count)
                    { 
                        if (dtTracesA[activeTabIndex].Rows[rowIndex] != null )
                        {
                            result += "Details for single selected message:\n\n";
                            result += "Selected row = " + rowIndex.ToString() + "\n";
                            result += "Timestamp = " + dtTracesA[activeTabIndex].Rows[rowIndex].Field<float>(0).ToString() + "\n";
                            result += "Type of record = " + dtTracesA[activeTabIndex].Rows[rowIndex].Field<string>(1) + "\n";
                            result += "Identifier = 0x" + dtTracesA[activeTabIndex].Rows[rowIndex].Field<string>(3) + "\n";
                            result += "CAN message data = " + dtTracesA[activeTabIndex].Rows[rowIndex].Field<string>(7) + "\n\n";

                            if ((row != null) && (rowIndex > 0) && (rowIndex < isoTpInfoList[activeTabIndex].Count))
                            {
                                if (isoTpInfoList[activeTabIndex][rowIndex] != null)
                                {
                                    result += "ISO-TP details:\n";
                                    result += string.Format("Network address information  (n_AI): 0x{0} \n", isoTpInfoList[activeTabIndex][rowIndex].n_AI.ToString("X4"));
                                    if (isoTpInfoList[activeTabIndex][rowIndex].n_TA != -1)
                                    {
                                        result += "Network target address (n_TA): 0x" + isoTpInfoList[activeTabIndex][rowIndex].n_TA + "\n";
                                    }
                                    result += "N_PDU type : " + isoTpInfoList[activeTabIndex][rowIndex].frameType.ToString() + "\n";
                                    if (isoTpInfoList[activeTabIndex][rowIndex].frameType == IsoTpInformation.FrameType.First)
                                    {
                                        result += "Higher layer data length: " + isoTpInfoList[activeTabIndex][rowIndex].higherLayerDataLength.ToString() + "\n\n";
                                        result += "WholeFrameDataCount: " + isoTpInfoList[activeTabIndex][rowIndex].higherLayerDataLength.ToString() + "\n";
                                    }

                                    if (isoTpInfoList[activeTabIndex][rowIndex].frameType == IsoTpInformation.FrameType.Single)
                                    {
                                        result += "Higher layer data length: " + isoTpInfoList[activeTabIndex][rowIndex].higherLayerDataLength.ToString() + "\n\n";
                                    }

                                    if (isoTpInfoList[activeTabIndex][rowIndex].frameType == IsoTpInformation.FrameType.Consecutive)
                                    {
                                        result += "Consecutive frame index: " + isoTpInfoList[activeTabIndex][rowIndex].consIndex.ToString() + "\n";
                                        if (isoTpInfoList[activeTabIndex][rowIndex].higherLayerData != null)
                                        {
                                            result += "Higher layer data:\n" + BitConverter.ToString(isoTpInfoList[activeTabIndex][rowIndex].higherLayerData).Replace("-", "  ") + "\n\n";
                                        }
                                    }

                                    if (isoTpInfoList[activeTabIndex][rowIndex].frameType == IsoTpInformation.FrameType.Flowcontrol)
                                    {
                                        result += "Flow control flag: " + isoTpInfoList[activeTabIndex][rowIndex].fcFlag + "\n";
                                        result += "Separation time: " + isoTpInfoList[activeTabIndex][rowIndex].separationTime.ToString() + "\n";
                                        result += "Block size: " + isoTpInfoList[activeTabIndex][rowIndex].blockSize.ToString() + "\n";
                                        result += "Higher layer data length: " + isoTpInfoList[activeTabIndex][rowIndex].higherLayerDataLength.ToString() + "\n\n";
                                    }
                                    else
                                    {// for all frametypes except flowcontrol add the data to the end of details

                                    }

                                }

                                if (diagInfoList[activeTabIndex][rowIndex] != null)
                                {
                                    result += "UDS / KWP  details:\n";
                                    result += string.Format("Service = {0} (0x{1}) \n", diagInfoList[activeTabIndex][rowIndex].services[0].sid.ToString(), ((int)(diagInfoList[activeTabIndex][rowIndex].services[0].sid)).ToString("X2"));
                                    if (diagInfoList[activeTabIndex][rowIndex].services[0].did != -1)
                                    {
                                        result += string.Format("DID = 0x{0} \n", diagInfoList[activeTabIndex][rowIndex].services[0].did.ToString("X4"));
                                    }
                                    result += "\n";
                                }
                            }
                            result += "=========================================================================\n";
                        }
                    }
                }
            }
            return result;
        }
        
        private void btnMenuLoadTrace_Click(object sender, EventArgs e)
        {
            loadTraceFile(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void TimestampFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].timestampFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].timestampFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }
        }

        private void TypeFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].typeFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].typeFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }
        }

        private void ChannelFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].channelFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].channelFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }
        }

        private void IdFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].idFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].idFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void AliasFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].aliasFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].aliasFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void DirectionFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].directionFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].directionFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }
        }

        private void DLCFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].dlcFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].dlcFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }
        }

        private void DataFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].dataFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].dataFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void IsoTPDataFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].tpDataFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].tpDataFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void IsoTPDetailsFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].tpDetailsFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].tpDetailsFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void UdsDataFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].udsDataFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].tpDataFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void UdsDetailsFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].udsDetailsFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].tpDetailsFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }

        }

        private void OthersFilterRequest(object sender, EventArgs e)
        {
            DialogResult myResult = myFilterForm.ShowDialog(traceTemplates[activeTabIndex].othersFilter);
            if (myResult == DialogResult.OK)
            {
                traceTemplates[activeTabIndex].othersFilter = myFilterForm.filterString;
                traceTemplates[activeTabIndex].UpdateRowFilters();
            }
        }

        private void splitTraceWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (traceTemplates[activeTabIndex].doubleAnalyzerState)
            { 
                traceTemplates[activeTabIndex].doubleAnalyzerEnable (false);
            }
            else
            {
                traceTemplates[activeTabIndex].doubleAnalyzerEnable(true);
            }
        }

        private void tabControlTraces_Selected(object sender, TabControlEventArgs e)
        {
            activeTabIndex = tabControlTraces.SelectedIndex;
        }

        private void autoResizeTraceCollumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                
            }).Start();

        }

        private void iDListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idListForm = new IDListForm(new List<isoTPChannelConfig>());
            DialogResult myResult = idListForm.ShowDialog(isoTpIdList);
            if (myResult == DialogResult.OK)
            {
                isoTpIdList = idListForm.isoTpIdList;
                if ((!bwParseTrace.IsBusy) && (logList[activeTabIndex] != null))
                {
                    prepareDataTables();    // clear and prepare blank datatables

                    if (traceTemplates[activeTabIndex] != null)     // if any trace is loaded = trace template is already prepared
                    {
                        traceTemplates[activeTabIndex].DataSourceTop = dtTracesA[activeTabIndex];
                        traceTemplates[activeTabIndex].DataSourceBottom = dtTracesB[activeTabIndex];
                    }
                    bwParseTrace.RunWorkerAsync();    // start the background process, which fill the data tables with actual data
                }
                else if (bwParseTrace.IsBusy)
                {
                    MessageBox.Show("Trace parsing not ready - parser is bussy.");
                } 
            }

        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

    }
}
