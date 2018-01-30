using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPanalyzer;


namespace TPanalyzer
{
    public enum UDSSid
    {
        // Requests
        // Diagnostic and communications management
        UDS_Rq_DiagnosticSessionControl = 0x10,
        UDS_Rq_ECUReset = 0x11,
        UDS_Rq_SecurityAcces = 0x27,
        UDS_Rq_CommunicationControl = 0x28,
        UDS_Rq_TesterPresent = 0x3E,
        UDS_Rq_AccesTimingParameters = 0x83,
        UDS_Rq_SecuredDataTransmission = 0x84,
        UDS_Rq_ControlDTCSettings = 0x85,
        UDS_Rq_ResponseOnEvent = 0x86,
        UDS_Rq_LinkControl = 0x87,
        //Data transmission
        UDS_Rq_ReadDataById = 0x22,
        UDS_Rq_ReadMemoryByAddress = 0x23,
        UDS_Rq_ReadScalingDataByIdentifier = 0x24,
        UDS_Rq_ReadDataByPeriodicIdentifier = 0x2A,
        UDS_Rq_DynamicallyDefineDataIdentifier = 0x2C,
        UDS_Rq_WriteDataById = 0x2E,
        UDS_Rq_WriteMemoryByAddress = 0x3D,
        //Stored data transmission
        UDS_Rq_ClearDiagInfo = 0x14,
        UDS_Rq_ReadDiagInfo = 0x19,
        //Input/output control
        UDS_Rq_InOutControlByIdentifier = 0x2F,
        //Remote activation of routine
        UDS_Rq_RoutineControl = 0x31,
        //Upload and download
        UDS_Rq_RequestDownload = 0x34,
        UDS_Rq_RequestUpload = 0x35,
        UDS_Rq_TransferDat = 0x36,
        UDS_Rq_RequestTransferExit = 0x37,
        UDS_Rq_RequestFileTransfer = 0x38,

        // Positive Responses
        UDS_PosResp_DiagnosticSessionControl = 0x50,
        UDS_PosResp_ECUReset = 0x51,
        UDS_PosResp_SecurityAcces = 0x67,
        UDS_PosResp_CommunicationControl = 0x68,
        UDS_PosResp_TesterPresent = 0x7E,
        UDS_PosResp_AccesTimingParameters = 0xC3,
        UDS_PosResp_SecuredDataTransmission = 0xC4,
        UDS_PosResp_ControlDTCSettings = 0xC5,
        UDS_PosResp_ResponseOnEvent = 0xC6,
        UDS_PosResp_LinkControl = 0xC7,
        UDS_PosResp_ReadDataById = 0x62,
        UDS_PosResp_ReadMemoryByAddress = 0x63,
        UDS_PosResp_ReadScalingDataByIdentifier = 0x64,
        UDS_PosResp_ReadDataByPeriodicIdentifier = 0x6A,
        UDS_PosResp_DynamicallyDefineDataIdentifier = 0x6C,
        UDS_PosResp_WriteDataById = 0x6E,
        UDS_PosResp_WriteMemoryByAddress = 0x7D,
        UDS_PosResp_ClearDiagInfo = 0x54,
        UDS_PosResp_ReadDiagInfo = 0x59,
        UDS_PosResp_InOutControlByIdentifier = 0x6F,
        UDS_PosResp_RoutineControl = 0x71,
        UDS_PosResp_RequestDownload = 0x74,
        UDS_PosResp_RequestUpload = 0x75,
        UDS_PosResp_TransferDat = 0x76,
        UDS_PosResp_RequestTransferExit = 0x77,
        UDS_PosResp_RequestFileTransfer = 0x78,
        // Negative response
        UDS_NegResp_ = 0x7F
    }
    public enum UDSNrc
    {
        GeneralReject = 0x10,
        ServiceNotSupported = 0x11,
        SubfunctionNotSupported = 0x12,
        IncorrectMessageLength_InvalidFormat = 0x13,
        BussyRepeatRequest = 0x21,
        ConditionsNotCorrect = 0x22,
        RequestSequenceError = 0x24,
        NoResponseFromSubnetComponent = 0x25,
        FailurePreventsExecutionOfRequestedAction = 0x26,
        RequestOutOfRange = 0x31,
        ScurityAccesDenied = 0x33,
        InvalidKey = 0x35,
        ExceedNumberOfAttempts = 0x36,
        RequiredTimeDelayNotExpired = 0x37,
        UploadDownloadNotAccepted = 0x70,
        TransferDataSuspended = 0x71,
        GeneralProgrammingFailure = 0x72,
        WrongBlockSequenceCounter = 0x73,
        ResponsePending = 0x78,
        SubFunctionNotSupportedInActiveDiagnosticSession = 0x7E,
        ServiceNotSupportedInActiveDiagnosticSession = 0x7F,
        RpmTooHigh = 0x81,
        RpmTooLow = 0x82,
        EngineIsRunning = 0x83,
        EngineIsNotRunning = 0x84,
        EngineRunTimeTooLow = 0x85,
        TemperatureTooHigh = 0x86,
        TemperatureTooLow = 0x87,
        VehicleSpeedTooHigh = 0x88,
        VehicleSpeedTooLow = 0x89,
        ThrottlePedalTooHigh = 0x8A,
        ThrottlePedalTooLow = 0x8B,
        TransmissionRangeNotInNeutral = 0x8C,
        TransmissionRangeNotInGear = 0x8D,
        BreakSwitchNotClosed = 0x8F,
        ShifterLeverNotInPark = 0x90,
        TorqueConvertedClutchLocked = 0x91,
        VoltageTooHigh = 0x92,
        VoltageTooLow = 0x93,

    }
    public enum KWPSid
    {
        KWP_Rq_StartDiagnosticSession = 0x10,
        KWP_Rq_ReadFreezeFrameData = 0x12,
        KWP_Rq_EscCode = 0x80,
        KWP_Rq_ReadDiagnosticTroubleCodes = 0x13,
        KWP_Rq_ClearDiagnosticInformation = 0x14,
        KWP_Rq_ReadStatusOfDiagnosticTroubleCodes = 0x17,
        KWP_Rq_ReadDiagnosticTroubleCodesByStatus = 0x18,
        KWP_Rq_ReadECUIdentification = 0x1a,
        KWP_Rq_StopDiagnosticSession = 0x20,
        KWP_Rq_ReadDataByLocalIdentifier = 0x21,
        KWP_Rq_ECUReset = 0x11,
        KWP_Rq_ReadDataByCommonIdentifier = 0x22,
        KWP_Rq_ReadMemoryByAddress = 0x23,
        KWP_Rq_SetDataRates = 0x26,
        KWP_Rq_SecurityAccess = 0x27,
        KWP_Rq_DynamicallyDefineLocalIdentifier = 0x2c,
        KWP_Rq_WriteDataByCommonIdentifier = 0x2e,
        KWP_Rq_InputOutputControlByCommonIdentifier = 0x2f,
        KWP_Rq_InputOutputControlByLocalIdentifier = 0x30,
        KWP_Rq_StartRoutineByLocalIdentifier = 0x31,
        KWP_Rq_StopRoutineByLocalIdentifier = 0x32,
        KWP_Rq_RequestRoutineResultsByLocalIdentifier = 0x33,
        KWP_Rq_RequestDownload = 0x34,
        KWP_Rq_RequestUpload = 0x35,
        KWP_Rq_TransferData = 0x36,
        KWP_Rq_RequestTransferExit = 0x37,
        KWP_Rq_StartRoutineByAddress = 0x38,
        KWP_Rq_StopRoutineByAddress = 0x39,
        KWP_Rq_RequestRoutineResultsByAddress = 0x3a,
        KWP_Rq_WriteDataByLocalIdentifier = 0x3b,
        KWP_Rq_WriteMemoryByAddress = 0x3d,
        KWP_Rq_TesterPresent = 0x3e
    }
    public enum KWPNrc
    {

    }
    public struct oneDiagServiceInfo
    {
        public Byte sid;
        public int did;
        public byte[] parameters;
        public bool validData;       // frame contain the correct number of bytes for all bytes = true

        public oneDiagServiceInfo(Byte mySID, int myDID, byte[] pars)
        {
            sid = mySID;
            did = myDID;
            parameters = pars;
            validData = true;
        }
    }
    public struct DiagServiceconfig
    {   // template/structure with information about every KWP and UDS service
        Byte sid;
        int parByteCount;
        string shortName;
        string longName;
        string[] parNames;
        int[] startBits;
        int[] endBits;

        public DiagServiceconfig(Byte newSID, int newParByteCount, string newShortName, string newLongName, string[] newParNames, int[] newStartBits, int[] newEndtBits)
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

    [System.ComponentModel.ComplexBindingProperties("DataSource", "DataMember")]
    public partial class TraceTemplate: UserControl
    {
        public class IsoTpInformation
        {
            public int byteCount { get; set; }       // Number of bytes, which are ISOTP information
            public byte[] segmentData { get; set; }  // data of this one segment of Frame
            public enum FrameType { None = -1, Single = 0, First = 1, Consecutive = 2, Flowcontrol = 3 };
            public FrameType frameType { get; set; } // 0 = Single frame, 1 = First frame, 2 = Consecutive frame, 3 = Flowcontrol frame
            public enum FcFlag { None = -1, CTS = 0, Wait = 1, Overflow = 2 }; // three posibilities of fcFlag
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
                this.tpBuffer = new isoTpBufferItem[16];
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
                int i, j = 0;

                for (i = 0; i < tpBuffer.Length; i++)
                {
                    if ((tpBuffer[i].n_AI == n_AI) && (tpBuffer[i].n_TA == n_TA))
                    {   // item with this Address information already exists
                        if (dataBytesCountTarget > 0)
                        {// new first frame, while unfinished frame was in the buffer - overwrite previous unfinished frame and return error. 
                            Array.Resize(ref tpBuffer[i].dataBytes, dataBytesCountTarget);
                            tpBuffer[i].dataBytesPointer = 0;
                            tpBuffer[i].dataBytesCountBuffered = 0;
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

            public void AddService(Byte sid, int did, byte[] pars)
            {
                servicesCount++;
                services[servicesCount] = new oneDiagServiceInfo(sid, did, pars);
            }

            public void clearAllServices()
            {       // only set the pointer to zero
                servicesCount = 0;
            }
        }
        public event EventHandler Trace_CloseRequest;

        private string timestampFilter = "Timestamp";
        private string typeFilter = "Type";
        private string channelFilter = "Channel";
        private string idFilter = "ID";
        private string aliasFilter = "Alias";
        private string directionFilter = "Direction";
        private string dlcFilter = "DLC";
        private string dataFilter = "CAN_Data";
        private string tpDataFilter = "TP_Data";
        private string tpDetailsFilter = "TP_Details";
        private string udsDataFilter = "UDS/KWP_Data";
        private string udsDetailsFilter = "UDS/KWP_Details";
        private string othersFilter = "Others";
        public bool doubleAnalyzerState = false;

        public List<String> logList = new List<string>();
        private DataTable dtTracesA = new DataTable();    // dataTable as a datasource for datagridview on the Top of trace teplate
        private DataTable dtTracesB = new DataTable();    // dataTable as a datasource for datagridview on the Bottom of trace teplate
        private List<IsoTpInformation> isoTpInfoList = new List<IsoTpInformation>();             // ISO-TP information array - for every tab is seperate
        private List<DiagFrameInformation> diagInfoList = new List<DiagFrameInformation>();  // UDS information array - for every tab is seperate
        public List<isoTPChannelConfig> isoTpIdList = new List<isoTPChannelConfig>();
        private IsoTPBuffer myIsoTpBuffer = new IsoTPBuffer();  // create isoTP buffer instance for handling temporary isoTP data  
        private UniversalFilterForm myFilterForm = new UniversalFilterForm();   // Filter form - setup form for setup rowfilter criterion
        private Thread parseProcess;
        public int rowInTrace = 0;                         // information about number of rows in trace currently loaded
        public int rowOfTraceLoaded = 0;                   // information about actual number of loaded rows from trace

        int currentMouseOverColTop = 0;
        int currentMouseOverRowTop = 0;
        int currentMouseOverColBottom = 0;
        int currentMouseOverRowBottom = 0;

        public TraceTemplate()
        {
            InitializeComponent();
            scHorizontal.Panel2Collapsed = true;        // start without double analyzer feature

           // parseProcess = new Thread(this.parseProcessJob);
           // parseProcess.Priority = ThreadPriority.Highest;

            //isoTpIdList.Add(new isoTPChannelConfig(402391170, 0, "Request", 0, 0, true));       // temporary assingment !!!
            //isoTpIdList.Add(new isoTPChannelConfig(402522242, 0, "Response", 0, 0, true));     // temporary assingment !!!
            //isoTpIdList.Add(new isoTPChannelConfig(0x700, 0, "Request all", 0, 0, false));      // temporary assingment !!!
            //isoTpIdList.Add(new isoTPChannelConfig(0x710, 0, "GW_Req", 0, 0, false));      // temporary assingment !!!
            //isoTpIdList.Add(new isoTPChannelConfig(0x77A, 0, "GW_Resp", 0, 0, false));      // temporary assingment !!!
            //isoTpIdList.Add(new isoTPChannelConfig(0x4AE, 0, "GW_Req1", 0, 0, false));      // temporary assingment !!!
            //isoTpIdList.Add(new isoTPChannelConfig(0x772, 0, "GW_Resp1", 0, 0, false));      // temporary assingment !!!

        }

        private void parseProcessJob()
        {
            this.Invoke((MethodInvoker)delegate
            {
                rtbDetailsTop.Text = "Loading trace...";
                this.Cursor = Cursors.WaitCursor;
            });

            switch (logList[0])
            {
                case (".asc"):
                    {
                        logList.ForEach(parseASCLine);
                        break;
                    }
                case (".trc"):
                    {
                        logList.ForEach(parseTRCLine);
                        break;
                    }
                case (".txtCLIF"):
                    {
                        logList.ForEach(parseCLIFLine);
                        break;
                    }
                case (".txtTPCA"):
                    {
                        logList.ForEach(parseTPCALine);
                        break;
                    }
            }
            this.Invoke((MethodInvoker)delegate
            {
                rtbDetailsTop.Text = "Trace window is refreshing and autosizing...";
            });

            this.Invoke((MethodInvoker)delegate
            {
                dgvTraceTop.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode.None);
                dgvTraceTop.AutoResizeColumns();
                dgvTraceBottom.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode.None);
                dgvTraceBottom.AutoResizeColumns();
                rtbDetailsTop.Text = "Trace is completely loaded";
                this.Cursor = Cursors.Default;
            });
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

        public int getNumberOfDiagParBytes(Byte sid, Byte udsKwpSelector)
        {
            int result = -1;

            if (udsKwpSelector == 0)    // UDS
            {
                switch (sid)
                {
                    case ((Byte)UDSSid.UDS_Rq_AccesTimingParameters):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ClearDiagInfo):
                        {
                            result = 3;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_CommunicationControl):
                        {
                            result = 2;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ControlDTCSettings):
                        {
                            result = 4;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_DiagnosticSessionControl):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_DynamicallyDefineDataIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ECUReset):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_InOutControlByIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_LinkControl):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_NegResp_):
                        {
                            result = 2;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_AccesTimingParameters):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ClearDiagInfo):
                        {
                            result = 0;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_CommunicationControl):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ControlDTCSettings):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_DiagnosticSessionControl):
                        {
                            result = 5;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_DynamicallyDefineDataIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ECUReset):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_InOutControlByIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_LinkControl):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadDataById):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadDataByPeriodicIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadDiagInfo):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadMemoryByAddress):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadScalingDataByIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_RequestDownload):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_RequestFileTransfer):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_RequestTransferExit):
                        {
                            result = 0;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_RequestUpload):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ResponseOnEvent):
                        {
                            result = 6;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_RoutineControl):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_SecuredDataTransmission):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_SecurityAcces):
                        {
                            result = -1;        // not fix number of parameters bytes in case of seed transfer = 5 and in case of key acknowledge = 1
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_TesterPresent):
                        {
                            result = 0;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_TransferDat):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_WriteDataById):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_WriteMemoryByAddress):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadDataById):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadDataByPeriodicIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadDiagInfo):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadMemoryByAddress):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadScalingDataByIdentifier):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_RequestDownload):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_RequestFileTransfer):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_RequestTransferExit):
                        {
                            result = 0;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_RequestUpload):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ResponseOnEvent):
                        {
                            result = 6;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_RoutineControl):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_SecuredDataTransmission):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_SecurityAcces):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_TesterPresent):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_TransferDat):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_WriteDataById):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_WriteMemoryByAddress):
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

            }
            else if (udsKwpSelector == 1)       // KWP
                switch (sid)
                {
                    case ((Byte)KWPSid.KWP_Rq_ECUReset):
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                    //TODO: fill KWP byte counts
                    default:
                        {
                            result = -1;        // not fix number of parameters bytes or parameters count unknown
                            break;
                        }
                }


            return result;
        }

        public int getDIDposition(Byte sid, Byte udsKwpSelector)
        {
            int result = -1;
            if (udsKwpSelector == 0) // UDS
            {
                switch (sid)
                {
                    case ((Byte)UDSSid.UDS_PosResp_InOutControlByIdentifier):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadDataById):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_ReadScalingDataByIdentifier):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_RoutineControl):
                        {
                            result = 2;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_PosResp_WriteDataById):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadDataById):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadDataByPeriodicIdentifier):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_ReadScalingDataByIdentifier):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_RoutineControl):
                        {
                            result = 1;
                            break;
                        }
                    case ((Byte)UDSSid.UDS_Rq_WriteDataById):
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

            }
            else if (udsKwpSelector == 1) // KWP                
            {
                switch (sid)
                {
                    case ((Byte)KWPSid.KWP_Rq_ReadDataByLocalIdentifier):
                        {
                            result = 1;
                            break;
                        }
                    //TODO: fill KWP DID positions
                    default:
                        {
                            result = -1;
                            break;
                        }
                }
            }
            return result;
        }

        public DiagFrameInformation parseDiagData(Byte[] dataToParse, Byte udsKwpSelector)
        {
            DiagFrameInformation result = new DiagFrameInformation();
            int pointer = 0;
            int tempByteCount = 0;
            int tempDIDposition = 0;

            tempByteCount = getNumberOfDiagParBytes((dataToParse[pointer]), udsKwpSelector);
            tempDIDposition = getDIDposition((dataToParse[pointer]), udsKwpSelector);

            if (tempByteCount == 0)
            {
                result.services[result.servicesCount] = new oneDiagServiceInfo((dataToParse[pointer]), -1, new byte[0]);//
                result.services[result.servicesCount].sid = (dataToParse[pointer]);
            }

            else if (tempByteCount == -1)
            {
                result.services[result.servicesCount] = new oneDiagServiceInfo((dataToParse[pointer]), -1, new byte[(dataToParse.Length - 1)]);
                result.services[result.servicesCount].sid = (dataToParse[pointer]);
                for (int i = 0; i < (dataToParse.Length - 1); i++)
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
                result.services[result.servicesCount] = new oneDiagServiceInfo((dataToParse[pointer]), -1, new byte[tempByteCount]);//
                result.services[result.servicesCount].sid = (dataToParse[pointer]);
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
                }
                pointer += tempByteCount + 1;
            }

            if (tempDIDposition != -1)
            {
                result.services[result.servicesCount].did = (result.services[result.servicesCount].parameters[tempDIDposition - 1] << 8);
                result.services[result.servicesCount].did += (result.services[result.servicesCount].parameters[tempDIDposition]);
            }


            return result;
        }

        public void prepareDataTables()
        {
            if (dtTracesA != null)
            {
                dtTracesA.Clear();
                dtTracesA.Dispose();
                isoTpInfoList.Clear();
                diagInfoList.Clear();
            }

            if (dtTracesB != null)
            {
                dtTracesB.Clear();
                dtTracesB.Dispose();
            }

            dtTracesA = new DataTable();
            dtTracesA.Columns.Add("Timestamp", typeof(float));
            dtTracesA.Columns.Add("Type", typeof(string));
            dtTracesA.Columns.Add("Channel", typeof(string));
            dtTracesA.Columns.Add("ID", typeof(string));
            dtTracesA.Columns.Add("Alias", typeof(string));
            dtTracesA.Columns.Add("Direction", typeof(string));
            dtTracesA.Columns.Add("DLC", typeof(int));
            dtTracesA.Columns.Add("CAN_Data", typeof(string));
            dtTracesA.Columns.Add("TP_Data", typeof(string));
            dtTracesA.Columns.Add("TP_Details", typeof(string));
            dtTracesA.Columns.Add("UDS/KWP_Data", typeof(string));
            dtTracesA.Columns.Add("UDS/KWP_Details", typeof(string));
            dtTracesA.Columns.Add("Others", typeof(string));

            dtTracesB = new DataTable();
            dtTracesB.Columns.Add("Timestamp", typeof(float));
            dtTracesB.Columns.Add("Type", typeof(string));
            dtTracesB.Columns.Add("Channel", typeof(string));
            dtTracesB.Columns.Add("ID", typeof(string));
            dtTracesB.Columns.Add("Alias", typeof(string));
            dtTracesB.Columns.Add("Direction", typeof(string));
            dtTracesB.Columns.Add("DLC", typeof(int));
            dtTracesB.Columns.Add("CAN_Data", typeof(string));
            dtTracesB.Columns.Add("TP_Data", typeof(string));
            dtTracesB.Columns.Add("TP_Details", typeof(string));
            dtTracesB.Columns.Add("UDS/KWP_Data", typeof(string));
            dtTracesB.Columns.Add("UDS/KWP_Details", typeof(string));
            dtTracesB.Columns.Add("Others", typeof(string));


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
                        result.strData += tempString + " ";
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
                        result.strData += tempString + " ";
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
                            //result.strData += tempString[i+3] + "  ";       // only two spaces, because every tempString contains already one
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
                        itemDelimiter[index] = s.IndexOf(" ", itemDelimiter[index] + 1);
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
                            //result.strData += tempString[i + 4] + "  ";       // only two spaces, because every tempString contains already one
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
            int channel = 0;
            Byte[] dataByte = new Byte[8];
            IsoTpInformation tpInfo = new IsoTpInformation();
            DiagFrameInformation diagFrameInfo = new DiagFrameInformation();
            bool goOnWithParsing = true;
            Byte tempUdsKwpSelector = 0;    //  0 = UDS, 1 = KWP

            Application.DoEvents();
            if (true)
            {
                // ============ Timestamp ====================================

                float.TryParse(strInterface.strTimestamp.Replace('.', ','), out floatTimestamp);

                //============== Channel / Type =====================================
                try
                {
                    channel = Convert.ToInt32(strInterface.strChannel, 10);
                }
                catch (Exception e)
                {

                }

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
                            tempString = strInterface.strData.Substring((1 + (3 * i)), 2);
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
                            if ((config.channel == channel) || (config.channel == 0))
                            {
                                if (config.adressingMode != isoTPChannelConfig.AdressingMode.Extended)
                                {
                                    if (((config.FRq_n_AI == id) || (config.Rq_n_AI == id) || (config.Rsp_n_AI == id)))
                                    {
                                        goOnWithParsing = true;
                                        strAlias = config.alias;
                                        tpInfo = parseISOTPData(id, dataByte, false);         // parse this segment with normal addressing mode
                                        tempUdsKwpSelector = config.udsKwpSelector;
                                        break;
                                    }
                                }
                                else if ((config.FRq_n_AI == id) && (config.FRq_n_TA == dataByte[0]))    // with extended mode both parts of adress must agree (nAI and nTA)
                                {
                                    goOnWithParsing = true;
                                    strAlias = config.alias;
                                    tpInfo = parseISOTPData(id, dataByte, true);        // parse this segment with extended addressing mode
                                    tempUdsKwpSelector = config.udsKwpSelector;
                                    break;
                                }
                                else if ((config.Rq_n_AI == id) && (config.Rq_n_TA == dataByte[0]))  // with extended mode both parts of adress must agree (nAI and nTA)
                                {
                                    goOnWithParsing = true;
                                    strAlias = config.alias;
                                    tpInfo = parseISOTPData(id, dataByte, true);        // parse this segment with extended addressing mode
                                    tempUdsKwpSelector = config.udsKwpSelector;
                                    break;
                                }
                                else if ((config.Rsp_n_AI == id) && (config.Rsp_n_TA == dataByte[0]))  // with extended mode both parts of adress must agree (nAI and nTA)
                                {
                                    goOnWithParsing = true;
                                    strAlias = config.alias;
                                    tpInfo = parseISOTPData(id, dataByte, true);        // parse this segment with extended addressing mode
                                    tempUdsKwpSelector = config.udsKwpSelector;
                                    break;
                                }
                            }
                        }


                        if (goOnWithParsing)   // if this network adress information matches with any item in isotp ID list
                        {
                            strIsoTp = strInterface.strData.Substring(0, (3 * tpInfo.byteCount));
                            isoTpInfoList.Add(tpInfo);

                            if (tpInfo.frameType == IsoTpInformation.FrameType.First)
                            {
                                strIsoTpDetails = "FF";
                                if (tpInfo.n_TA != -1)
                                {
                                    strIsoTpDetails += string.Format(", N_AI = 0x{0}, N_TA = 0x{1}", tpInfo.n_AI.ToString("X4"), tpInfo.n_TA.ToString("X2"));
                                }
                                strIsoTpDetails += string.Format(", DL = {0}", tpInfo.higherLayerDataLength.ToString());
                                strUdsKwp = strInterface.strData.Substring(((tpInfo.byteCount * 3)), (3 * (8 - tpInfo.byteCount)));
                                diagInfoList.Add(null);
                            }
                            else if (tpInfo.frameType == IsoTpInformation.FrameType.Single)
                            {
                                strIsoTpDetails = "SF";
                                if (tpInfo.n_TA != -1)
                                {
                                    strIsoTpDetails += string.Format(", N_AI = 0x{0}, N_TA = 0x{1}", tpInfo.n_AI.ToString("X4"), tpInfo.n_TA.ToString("X2"));
                                }
                                strIsoTpDetails += string.Format(", DL = {0}", tpInfo.higherLayerDataLength.ToString());
                                strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 3), (3 * (tpInfo.higherLayerDataLength)));
                                diagFrameInfo = parseDiagData(tpInfo.higherLayerData, tempUdsKwpSelector);
                                diagInfoList.Add(diagFrameInfo);
                                if (tempUdsKwpSelector == 0)
                                {
                                    strUdsKwpDetails = string.Format("{0}", (UDSSid)diagFrameInfo.services[0].sid);
                                    if (diagFrameInfo.services[0].did != -1)
                                    {
                                        strUdsKwpDetails += string.Format(", DID = 0x{0}", diagFrameInfo.services[0].did.ToString("X4"));
                                    }
                                    if (diagFrameInfo.services[0].sid == (Byte)UDSSid.UDS_NegResp_)
                                    {
                                        strUdsKwpDetails += string.Format("{0}", (UDSNrc)(diagFrameInfo.services[0].parameters[1]));
                                    }
                                }
                                else if (tempUdsKwpSelector == 1)
                                {
                                    strUdsKwpDetails = string.Format("{0}", (KWPSid)diagFrameInfo.services[0].sid);
                                    if (diagFrameInfo.services[0].did != -1)
                                    {
                                        strUdsKwpDetails += string.Format(", DID = 0x{0}", diagFrameInfo.services[0].did.ToString("X4"));
                                    }
                                    //TODO: KWP NRCs
                                    //                                    if (diagFrameInfo.services[0].sid == (Byte)KWPSid.NegResp_)
                                    //                                    {
                                    //                                        strUdsKwpDetails += string.Format("{0}", (KWPNrc)(diagFrameInfo.services[0].parameters[1]));
                                    //                                    }

                                }

                            }
                            else if (tpInfo.frameType == IsoTpInformation.FrameType.Consecutive)
                            {
                                strIsoTpDetails = string.Format("CF, Index = {0}", tpInfo.consIndex.ToString());
                                if (tpInfo.higherLayerData != null) // consecutive frame with higher layer data is the last one = whole frame is finished
                                {   // last consecutive frame
                                    strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 3), (3 * (8 - tpInfo.byteCount)));
                                    diagFrameInfo = parseDiagData(tpInfo.higherLayerData, tempUdsKwpSelector);
                                    diagInfoList.Add(diagFrameInfo);
                                    if (tempUdsKwpSelector == 0)
                                    {
                                        strUdsKwpDetails = string.Format("{0}", (UDSSid)diagFrameInfo.services[0].sid);
                                        if (diagFrameInfo.services[0].did != -1)
                                        {
                                            strUdsKwpDetails += string.Format(", DID = 0x{0}", diagFrameInfo.services[0].did.ToString("X4"));
                                        }

                                        if (diagFrameInfo.services[0].sid == (Byte)UDSSid.UDS_NegResp_)
                                        {
                                            ///TODO: implement reaction for NRC without value in enum type
                                            strUdsKwpDetails += string.Format("{0}", (UDSNrc)(diagFrameInfo.services[0].parameters[1]));
                                        }
                                    }
                                    else if (tempUdsKwpSelector == 1)
                                    {
                                        strUdsKwpDetails = string.Format("{0}", (KWPSid)diagFrameInfo.services[0].sid);
                                        if (diagFrameInfo.services[0].did != -1)
                                        {
                                            strUdsKwpDetails += string.Format(", DID = 0x{0}", diagFrameInfo.services[0].did.ToString("X4"));
                                        }

                                        //if (diagFrameInfo.services[0].sid == (Byte)KWPSid.NegResp_)
                                        //{
                                        //    ///TODO: implement reaction for NRC without value in enum type
                                        //    strUdsKwpDetails += string.Format("{0}", (KWPNrc)(diagFrameInfo.services[0].parameters[1]));
                                        //}
                                    }
                                }
                                else
                                {
                                    strUdsKwp = strInterface.strData.Substring((tpInfo.byteCount * 3), (3 * (8 - tpInfo.byteCount)));
                                    diagInfoList.Add(null);
                                }

                            }
                            else if (tpInfo.frameType == IsoTpInformation.FrameType.Flowcontrol)
                            {
                                strIsoTpDetails = string.Format("FC, Flag = {0}, BS = {1}, STmin = {2}", tpInfo.fcFlag, tpInfo.blockSize.ToString(), tpInfo.separationTime.ToString());
                                diagInfoList.Add(null);
                            }
                        }
                        else
                        {
                            isoTpInfoList.Add(null);
                            diagInfoList.Add(null);
                        }
                    }
                    else
                    {
                        isoTpInfoList.Add(null);
                        diagInfoList.Add(null);
                    }
                }
                else
                {   // all values in lists must be null
                    strInterface.strDLC = "";   // if the frame is not CAN, hide the zero in the DLC field
                    isoTpInfoList.Add(null);
                    diagInfoList.Add(null);
                }
                dtTracesA.Rows.Add(new object[] { floatTimestamp, strInterface.strType, strInterface.strChannel, strInterface.strId, strAlias, strInterface.strDirection, dlc, strInterface.strData, strIsoTp, strIsoTpDetails, strUdsKwp, strUdsKwpDetails, strInterface.strOthers });
                dtTracesB.Rows.Add(new object[] { floatTimestamp, strInterface.strType, strInterface.strChannel, strInterface.strId, strAlias, strInterface.strDirection, dlc, strInterface.strData, strIsoTp, strIsoTpDetails, strUdsKwp, strUdsKwpDetails, strInterface.strOthers });
            }
            rowOfTraceLoaded++;
            this.Invoke((MethodInvoker)delegate
            {
                if (rowOfTraceLoaded == 50)     // after 50 lines loaded force to resize the form in order to resize the trace template and show the scroll bar
                {
                    this.ParentForm.Width += 1;
                    this.ParentForm.Width -= 1;
                    Update();
                }
                rtbDetailsTop.Text = string.Format("Loading trace... {0}% done", (int)(100 * ((float)rowOfTraceLoaded / (float)rowInTrace)));
            });

        }

        private string createDetail(DataGridViewSelectedRowCollection rowSelected)
        {
            string result = "";

            if ((rowSelected.Count <= 4))    // Single line detail
            {
                foreach (DataGridViewRow row in rowSelected)
                {
                    BindingManagerBase bm = this.dgvTraceTop.BindingContext[this.dgvTraceTop.DataSource, this.dgvTraceTop.DataMember];
                    DataRow dr = ((DataRowView)bm.Current).Row;
                                                            
                    int rowIndex = row.Index;
                    if (rowIndex < dtTracesA.Rows.Count)
                    {
                        if (dtTracesA.Rows[rowIndex] != null)
                        {
                            result += "Details for selected message:\n\n";
                            result += "Selected row = " + rowIndex.ToString() + "\n";
                            result += "Timestamp = " + dr.ItemArray[0].ToString() + "\n";
                            result += "Type of record = " + dr.ItemArray[1].ToString() + "\n";
                            result += "Identifier = 0x" + dr.ItemArray[3].ToString() + "\n";
                            result += "CAN message data = " + dr.ItemArray[7].ToString() + "\n\n";

                            if ((row != null) && (rowIndex > 0) && (rowIndex < isoTpInfoList.Count))
                            {
                                if (isoTpInfoList[rowIndex] != null)
                                {
                                    result += "ISO-TP details:\n";
                                    result += string.Format("Network address information  (n_AI): 0x{0} \n", isoTpInfoList[rowIndex].n_AI.ToString("X4"));
                                    if (isoTpInfoList[rowIndex].n_TA != -1)
                                    {
                                        result += "Network target address (n_TA): 0x" + isoTpInfoList[rowIndex].n_TA + "\n";
                                    }
                                    result += "N_PDU type : " + isoTpInfoList[rowIndex].frameType.ToString() + "\n";
                                    if (isoTpInfoList[rowIndex].frameType == IsoTpInformation.FrameType.First)
                                    {
                                        result += "Higher layer data length: " + isoTpInfoList[rowIndex].higherLayerDataLength.ToString() + "\n\n";
                                        result += "WholeFrameDataCount: " + isoTpInfoList[rowIndex].higherLayerDataLength.ToString() + "\n";
                                    }

                                    if (isoTpInfoList[rowIndex].frameType == IsoTpInformation.FrameType.Single)
                                    {
                                        result += "Higher layer data length: " + isoTpInfoList[rowIndex].higherLayerDataLength.ToString() + "\n\n";
                                    }

                                    if (isoTpInfoList[rowIndex].frameType == IsoTpInformation.FrameType.Consecutive)
                                    {
                                        result += "Consecutive frame index: " + isoTpInfoList[rowIndex].consIndex.ToString() + "\n";
                                        if (isoTpInfoList[rowIndex].higherLayerData != null)
                                        {
                                            result += "Higher layer data:\n" + BitConverter.ToString(isoTpInfoList[rowIndex].higherLayerData).Replace("-", "  ") + "\n\n";
                                        }
                                    }

                                    if (isoTpInfoList[rowIndex].frameType == IsoTpInformation.FrameType.Flowcontrol)
                                    {
                                        result += "Flow control flag: " + isoTpInfoList[rowIndex].fcFlag + "\n";
                                        result += "Separation time: " + isoTpInfoList[rowIndex].separationTime.ToString() + "\n";
                                        result += "Block size: " + isoTpInfoList[rowIndex].blockSize.ToString() + "\n";
                                        result += "Higher layer data length: " + isoTpInfoList[rowIndex].higherLayerDataLength.ToString() + "\n\n";
                                    }
                                    else
                                    {// for all frametypes except flowcontrol add the data to the end of details

                                    }

                                }

                                if (diagInfoList[rowIndex] != null)
                                {
                                    result += "UDS / KWP  details:\n";
                                    result += string.Format("Service = {0} (0x{1}) \n", (UDSSid)diagInfoList[rowIndex].services[0].sid, ((diagInfoList[rowIndex].services[0].sid)).ToString("X2"));
                                    if (diagInfoList[rowIndex].services[0].did != -1)
                                    {
                                        result += string.Format("DID = 0x{0} \n", diagInfoList[rowIndex].services[0].did.ToString("X4"));
                                    }
                                    if (diagInfoList[rowIndex].services[0].sid == (Byte)UDSSid.UDS_NegResp_)
                                    {
                                        result += string.Format("NRC type = {0} (0x{1}) \n", (UDSNrc)(diagInfoList[rowIndex].services[0].parameters[1]), diagInfoList[rowIndex].services[0].parameters[1]);
                                        ///TODO: implement reaction for NRC without value in enum type
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

        public void startReadingTrace()
        {
            rowInTrace = logList.Count;
            rowOfTraceLoaded = 1;

            prepareDataTables();            // clear and prepare blank datatables
            dgvTraceTop.DataSource = dtTracesA;
            dgvTraceBottom.DataSource = dtTracesB;

            //            if (parseProcess.ThreadState == ThreadState.Stopped)
            //           {
            //               parseProcess = new Thread(this.parseProcessJob);
            //               parseProcess.Priority = ThreadPriority.Highest;
            //           }

            //            parseProcess.Start();
            parseProcessJob();

            dgvTraceTop.ScrollBars = ScrollBars.None;
            dgvTraceBottom.ScrollBars = ScrollBars.None;
            dgvTraceTop.Refresh();
            dgvTraceBottom.Refresh();

            dgvTraceTop.ScrollBars = ScrollBars.Both;
            dgvTraceBottom.ScrollBars = ScrollBars.Both;

            dgvTraceTop.Refresh();
            dgvTraceBottom.Refresh();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected virtual void OnTrace_CloseRequest(EventArgs e)
        {
            if (Trace_CloseRequest != null)
            {
                Trace_CloseRequest(this, e);
            }
        }

        public void ChangeScrollBarsMode(ScrollBars newScrollBarsMode)
        {
                dgvTraceTop.ScrollBars = newScrollBarsMode;
                dgvTraceBottom.ScrollBars = newScrollBarsMode;
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
            udsDataFilter = "UDS/KWP_Data";
            udsDetailsFilter = "UDS/KWP_Details";
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
                            DialogResult myResult = myFilterForm.ShowDialog(timestampFilter);
                            if (myResult == DialogResult.OK)
                            {
                                timestampFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 1: // Type
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(typeFilter);
                            if (myResult == DialogResult.OK)
                            {
                                typeFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 2: // Channel
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(channelFilter);
                            if (myResult == DialogResult.OK)
                            {
                                channelFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 3: // ID
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(idFilter);
                            if (myResult == DialogResult.OK)
                            {
                                idFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 4: // ID
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(idFilter);
                            if (myResult == DialogResult.OK)
                            {
                                idFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 5: // Direction
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(directionFilter);
                            if (myResult == DialogResult.OK)
                            {
                                directionFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 6: // DLC
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(dlcFilter);
                            if (myResult == DialogResult.OK)
                            {
                                dlcFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 7: // Data
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(dataFilter);
                            if (myResult == DialogResult.OK)
                            {
                                dataFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 8: // ISO TP Data
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(tpDataFilter);
                            if (myResult == DialogResult.OK)
                            {
                                tpDataFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 9: // ISO TP Details
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(tpDetailsFilter);
                            if (myResult == DialogResult.OK)
                            {
                                tpDetailsFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 10: // UDS/KWP Data
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(udsDataFilter);
                            if (myResult == DialogResult.OK)
                            {
                                udsDataFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                    case 11: // UDS/KWP Details
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(udsDetailsFilter);
                            if (myResult == DialogResult.OK)
                            {
                                udsDetailsFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
                            break;
                        }
                   case 12: // Others
                        {
                            DialogResult myResult = myFilterForm.ShowDialog(othersFilter);
                            if (myResult == DialogResult.OK)
                            {
                                othersFilter = myFilterForm.filterString;
                                UpdateRowFilters();
                            }
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
            try
            {
                scHorizontal.SplitterDistance = scHorizontal.Height / 2;
                scVerticalTop.SplitterDistance = (int)(scVerticalTop.Width * 0.8);
                scVerticalBottom.SplitterDistance = (int)(scVerticalBottom.Width * 0.8);
            }
            catch
            {

            }
        }

        private void dgvTraceTop_SelectionChanged(object sender, EventArgs e)
        {
            rtbDetailsTop.Text = createDetail(dgvTraceTop.SelectedRows);
        }

        private void dgvTraceBottom_SelectionChanged(object sender, EventArgs e)
        {
            rtbDetailsBottom.Text = createDetail(dgvTraceBottom.SelectedRows);
        }

        private void sellectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDetailsTop.SelectAll();
            rtbDetailsTop.Update();
            rtbDetailsTop.Refresh();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbDetailsTop.SelectedText);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtbDetailsBottom.SelectAll();
            rtbDetailsBottom.Update();
            rtbDetailsBottom.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbDetailsBottom.SelectedText);
        }

        private void dgvTraceTop_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex>0)
            {
                if (dgvTraceTop.Rows[e.RowIndex].Cells[11].Value != null)
                {
                    if (dgvTraceTop.Rows[e.RowIndex].Cells[11].Value.ToString().Contains("NegResp_"))
                    {
                        dgvTraceTop.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else if (dgvTraceTop.Rows[e.RowIndex].Cells[11].Value.ToString().Contains("PosResp_"))
                    {
                        dgvTraceTop.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (dgvTraceTop.Rows[e.RowIndex].Cells[11].Value.ToString().Contains("Rq_"))
                    {
                        dgvTraceTop.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else if (e.RowIndex % 2 != 0)
                    {
                        dgvTraceTop.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void CloseTraceBtn_Click(object sender, EventArgs e)
        {
            OnTrace_CloseRequest(e);
        }

        private void dgvTraceBottom_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                if (dgvTraceBottom.Rows[e.RowIndex].Cells[11].Value != null)
                {
                    if (dgvTraceBottom.Rows[e.RowIndex].Cells[11].Value.ToString().Contains("NegResp_"))
                    {
                        dgvTraceBottom.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else if (dgvTraceBottom.Rows[e.RowIndex].Cells[11].Value.ToString().Contains("PosResp_"))
                    {
                        dgvTraceBottom.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (dgvTraceBottom.Rows[e.RowIndex].Cells[11].Value.ToString().Contains("Rq_"))
                    {
                        dgvTraceBottom.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else if (e.RowIndex % 2 != 0)
                    {
                        dgvTraceBottom.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
        }
    }
}
