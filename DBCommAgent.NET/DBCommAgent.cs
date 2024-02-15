using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DBCommAgent.NET
{

    [ComImport]
    [Guid("A1C1EAC9-87BE-4AC8-B193-0FC8049425A9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _DDBCommAgent
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(1)]
        int CommInit();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(2)]
        void CommTerminate(int bSocketClose);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(3)]
        int CommGetConnectState();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(4)]
        int CommLogin([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sPwd, [MarshalAs(UnmanagedType.BStr)] string sCertPwd);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(5)]
        int CommLogout([MarshalAs(UnmanagedType.BStr)] string sUserID);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(6)]
        int GetLoginState();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(7)]
        void SetLoginMode(int nOption, int nMode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(8)]
        int GetLoginMode(int nOption);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(10)]
        int LoadTranResource([MarshalAs(UnmanagedType.BStr)] string strFilePath);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(11)]
        int LoadRealResource([MarshalAs(UnmanagedType.BStr)] string strFilePath);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(15)]
        int CreateRequestID();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(16)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommRecvOptionValue(int nOptionType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(17)]
        void ReleaseRqId(int nRqId);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(20)]
        int SetTranInputData(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecName, [MarshalAs(UnmanagedType.BStr)] string strItem, [MarshalAs(UnmanagedType.BStr)] string strValue);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(21)]
        int RequestTran(int nRqId, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sIsBenefit, [MarshalAs(UnmanagedType.BStr)] string sPrevOrNext, [MarshalAs(UnmanagedType.BStr)] string sPrevNextKey, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sTranType, int nRequestCount);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(22)]
        int GetTranOutputRowCnt([MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(23)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetTranOutputData([MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecName, [MarshalAs(UnmanagedType.BStr)] string strItemName, int nRow);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(24)]
        int SetTranInputArrayCnt(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecName, int nRecCnt);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(25)]
        int SetTranInputArrayData(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecName, [MarshalAs(UnmanagedType.BStr)] string strItem, [MarshalAs(UnmanagedType.BStr)] string strValue, int nArrayIndex);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(30)]
        int SetFidInputData(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strFID, [MarshalAs(UnmanagedType.BStr)] string strValue);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(31)]
        int RequestFid(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strOutputFidList, [MarshalAs(UnmanagedType.BStr)] string strScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(32)]
        int RequestFidArray(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strOutputFidList, [MarshalAs(UnmanagedType.BStr)] string strPreNext, [MarshalAs(UnmanagedType.BStr)] string strPreNextContext, [MarshalAs(UnmanagedType.BStr)] string strScreenNo, int nRequestCount);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(33)]
        int GetFidOutputRowCnt(int nRequestId);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(34)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetFidOutputData(int nRequestId, [MarshalAs(UnmanagedType.BStr)] string strFID, int nRow);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(35)]
        int GetCommFidDataBlock([ComAliasName("DBCommAgentLib.LONG_PTR")] long pVVector);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(36)]
        int SetPortfolioFidInputData(int nRqId, [MarshalAs(UnmanagedType.BStr)] string strSymbolCode, [MarshalAs(UnmanagedType.BStr)] string strSymbolMarket);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(40)]
        int RegisterReal([MarshalAs(UnmanagedType.BStr)] string strRealName, [MarshalAs(UnmanagedType.BStr)] string strRealKey);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(41)]
        int UnRegisterReal([MarshalAs(UnmanagedType.BStr)] string strRealName, [MarshalAs(UnmanagedType.BStr)] string strRealKey);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(42)]
        int AllUnRegisterReal();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(43)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetRealOutputData([MarshalAs(UnmanagedType.BStr)] string strRealName, [MarshalAs(UnmanagedType.BStr)] string strItemName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(44)]
        int GetCommRealRecvDataBlock([ComAliasName("DBCommAgentLib.LONG_PTR")] long pVector);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(50)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLastErrMsg();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(51)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetApiAgentModulePath();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(52)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetEncrpyt([MarshalAs(UnmanagedType.BStr)] string strPlainText);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(53)]
        void SetOffAgentMessageBox(int nOption);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(54)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string SetOptionalFunction(int nOption, int nValue1, int nValue2, [MarshalAs(UnmanagedType.BStr)] string strValue1, [MarshalAs(UnmanagedType.BStr)] string strValue2);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(60)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetAccInfo(int nOption, [MarshalAs(UnmanagedType.BStr)] string szAccNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(61)]
        int GetUserAccCnt();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(62)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetUserAccNo(int nIndex);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(70)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLBSIPList();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(71)]
        void SetConnectIPList([MarshalAs(UnmanagedType.BStr)] string strIP);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(72)]
        void SetChangePort(int bChangePort);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(73)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLinkTagData([MarshalAs(UnmanagedType.BStr)] string strTag);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(80)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string SendStockOrder(short nRqId, short nOrderType, [MarshalAs(UnmanagedType.BStr)] string strAccNo, [MarshalAs(UnmanagedType.BStr)] string strAccPwd, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string strHogaGb, int lQty, int lPrice, int bCreditOrder, [MarshalAs(UnmanagedType.BStr)] string strCreditType, [MarshalAs(UnmanagedType.BStr)] string strLoanDate, [MarshalAs(UnmanagedType.BStr)] string strCommdaCode, [MarshalAs(UnmanagedType.BStr)] string strOrgOrdNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(81)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string SendFOOrder(short nRqId, short nOrderType, [MarshalAs(UnmanagedType.BStr)] string strAccNo, [MarshalAs(UnmanagedType.BStr)] string strAccPwd, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string strHogaGb, int lQty, [MarshalAs(UnmanagedType.BStr)] string strPrice, [MarshalAs(UnmanagedType.BStr)] string strCommdaCode, [MarshalAs(UnmanagedType.BStr)] string strOrgOrdNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(82)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string SendNightFOOrder(short nRqId, short nOrderType, [MarshalAs(UnmanagedType.BStr)] string strAccNo, [MarshalAs(UnmanagedType.BStr)] string strAccPwd, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string strHogaGb, int lQty, [MarshalAs(UnmanagedType.BStr)] string strPrice, [MarshalAs(UnmanagedType.BStr)] string strCommdaCode, [MarshalAs(UnmanagedType.BStr)] string strOrgOrdNo);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("5674A780-58D5-4314-A947-6A0E37FB0F3D")]
    public interface _DDBCommAgentEvents
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(1)]
        void OnGetTranData(int nRequestId, [MarshalAs(UnmanagedType.BStr)] string pBlock, int nBlockLength);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(2)]
        void OnGetFidData(int nRequestId, [MarshalAs(UnmanagedType.BStr)] string pBlock, int nBlockLength);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(3)]
        void OnGetRealData([MarshalAs(UnmanagedType.BStr)] string strRealName, [MarshalAs(UnmanagedType.BStr)] string strRealKey, [MarshalAs(UnmanagedType.BStr)] string pBlock, int nBlockLength);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(4)]
        void OnAgentEventHandler(int nEventType, int nParam, [MarshalAs(UnmanagedType.BStr)] string strParam);
    }

    public class _DDBCommAgentEvents_OnGetTranDataEvent : EventArgs
    {
        public int nRequestId;

        public string pBlock;

        public int nBlockLength;

        public _DDBCommAgentEvents_OnGetTranDataEvent(int nRequestId, string pBlock, int nBlockLength)
        {
            this.nRequestId = nRequestId;
            this.pBlock = pBlock;
            this.nBlockLength = nBlockLength;
        }
    }

    public class _DDBCommAgentEvents_OnGetFidDataEvent : EventArgs
    {
        public int nRequestId;

        public string pBlock;

        public int nBlockLength;

        public _DDBCommAgentEvents_OnGetFidDataEvent(int nRequestId, string pBlock, int nBlockLength)
        {
            this.nRequestId = nRequestId;
            this.pBlock = pBlock;
            this.nBlockLength = nBlockLength;
        }
    }

    public class _DDBCommAgentEvents_OnGetRealDataEvent : EventArgs
    {
        public string strRealName;

        public string strRealKey;

        public string pBlock;

        public int nBlockLength;

        public _DDBCommAgentEvents_OnGetRealDataEvent(string strRealName, string strRealKey, string pBlock, int nBlockLength)
        {
            this.strRealName = strRealName;
            this.strRealKey = strRealKey;
            this.pBlock = pBlock;
            this.nBlockLength = nBlockLength;
        }
    }

    public class _DDBCommAgentEvents_OnAgentEventHandlerEvent : EventArgs
    {
        public int nEventType;

        public int nParam;

        public string strParam;

        public _DDBCommAgentEvents_OnAgentEventHandlerEvent(int nEventType, int nParam, string strParam)
        {
            this.nEventType = nEventType;
            this.nParam = nParam;
            this.strParam = strParam;
        }
    }

    public delegate void _DDBCommAgentEvents_OnGetTranDataEventHandler(object sender, _DDBCommAgentEvents_OnGetTranDataEvent e);
    public delegate void _DDBCommAgentEvents_OnGetFidDataEventHandler(object sender, _DDBCommAgentEvents_OnGetFidDataEvent e);
    public delegate void _DDBCommAgentEvents_OnGetRealDataEventHandler(object sender, _DDBCommAgentEvents_OnGetRealDataEvent e);
    public delegate void _DDBCommAgentEvents_OnAgentEventHandlerEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e);

    [ClassInterface(ClassInterfaceType.None)]
    public class AxDBCommAgentEventMulticaster : _DDBCommAgentEvents
    {
        private AxDBCommAgent parent;

        public AxDBCommAgentEventMulticaster(AxDBCommAgent parent)
        {
            this.parent = parent;
        }

        public virtual void OnGetTranData(int nRequestId, string pBlock, int nBlockLength)
        {
            _DDBCommAgentEvents_OnGetTranDataEvent e = new _DDBCommAgentEvents_OnGetTranDataEvent(nRequestId, pBlock, nBlockLength);
            parent.RaiseOnOnGetTranData(parent, e);
        }

        public virtual void OnGetFidData(int nRequestId, string pBlock, int nBlockLength)
        {
            _DDBCommAgentEvents_OnGetFidDataEvent e = new _DDBCommAgentEvents_OnGetFidDataEvent(nRequestId, pBlock, nBlockLength);
            parent.RaiseOnOnGetFidData(parent, e);
        }

        public virtual void OnGetRealData(string strRealName, string strRealKey, string pBlock, int nBlockLength)
        {
            _DDBCommAgentEvents_OnGetRealDataEvent e = new _DDBCommAgentEvents_OnGetRealDataEvent(strRealName, strRealKey, pBlock, nBlockLength);
            parent.RaiseOnOnGetRealData(parent, e);
        }

        public virtual void OnAgentEventHandler(int nEventType, int nParam, string strParam)
        {
            _DDBCommAgentEvents_OnAgentEventHandlerEvent e = new _DDBCommAgentEvents_OnAgentEventHandlerEvent(nEventType, nParam, strParam);
            parent.RaiseOnOnAgentEventHandler(parent, e);
        }
    }

    public class AxDBCommAgent
    {
        private _DDBCommAgent ocx;

        //private AxDBCommAgentEventMulticaster eventMulticaster;

        //private ConnectionPointCookie cookie;

        public event _DDBCommAgentEvents_OnGetTranDataEventHandler OnGetTranData;

        public event _DDBCommAgentEvents_OnGetFidDataEventHandler OnGetFidData;

        public event _DDBCommAgentEvents_OnGetRealDataEventHandler OnGetRealData;

        public event _DDBCommAgentEvents_OnAgentEventHandlerEventHandler OnAgentEventHandler;

        public virtual int CommInit()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommInit", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommInit();
        }

        public virtual void CommTerminate(int bSocketClose)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.CommTerminate(bSocketClose);
        }

        public virtual int CommGetConnectState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommGetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommGetConnectState();
        }

        public virtual int CommLogin(string sUserID, string sPwd, string sCertPwd)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommLogin", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommLogin(sUserID, sPwd, sCertPwd);
        }

        public virtual int CommLogout(string sUserID)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommLogout", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommLogout(sUserID);
        }

        public virtual int GetLoginState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginState();
        }

        public virtual void SetLoginMode(int nOption, int nMode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetLoginMode", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetLoginMode(nOption, nMode);
        }

        public virtual int GetLoginMode(int nOption)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginMode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginMode(nOption);
        }

        public virtual int LoadTranResource(string strFilePath)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("LoadTranResource", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.LoadTranResource(strFilePath);
        }

        public virtual int LoadRealResource(string strFilePath)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("LoadRealResource", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.LoadRealResource(strFilePath);
        }

        public virtual int CreateRequestID()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CreateRequestID", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CreateRequestID();
        }

        public virtual string GetCommRecvOptionValue(int nOptionType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRecvOptionValue", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRecvOptionValue(nOptionType);
        }

        public virtual void ReleaseRqId(int nRqId)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("ReleaseRqId", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.ReleaseRqId(nRqId);
        }

        public virtual int SetTranInputData(int nRqId, string strTrCode, string strRecName, string strItem, string strValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetTranInputData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetTranInputData(nRqId, strTrCode, strRecName, strItem, strValue);
        }

        public virtual int RequestTran(int nRqId, string sTrCode, string sIsBenefit, string sPrevOrNext, string sPrevNextKey, string sScreenNo, string sTranType, int nRequestCount)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("RequestTran", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.RequestTran(nRqId, sTrCode, sIsBenefit, sPrevOrNext, sPrevNextKey, sScreenNo, sTranType, nRequestCount);
        }

        public virtual int GetTranOutputRowCnt(string strTrCode, string strRecName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetTranOutputRowCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetTranOutputRowCnt(strTrCode, strRecName);
        }

        public virtual string GetTranOutputData(string strTrCode, string strRecName, string strItemName, int nRow)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetTranOutputData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetTranOutputData(strTrCode, strRecName, strItemName, nRow);
        }

        public virtual int SetTranInputArrayCnt(int nRqId, string strTrCode, string strRecName, int nRecCnt)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetTranInputArrayCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetTranInputArrayCnt(nRqId, strTrCode, strRecName, nRecCnt);
        }

        public virtual int SetTranInputArrayData(int nRqId, string strTrCode, string strRecName, string strItem, string strValue, int nArrayIndex)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetTranInputArrayData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetTranInputArrayData(nRqId, strTrCode, strRecName, strItem, strValue, nArrayIndex);
        }

        public virtual int SetFidInputData(int nRqId, string strFID, string strValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetFidInputData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetFidInputData(nRqId, strFID, strValue);
        }

        public virtual int RequestFid(int nRqId, string strOutputFidList, string strScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("RequestFid", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.RequestFid(nRqId, strOutputFidList, strScreenNo);
        }

        public virtual int RequestFidArray(int nRqId, string strOutputFidList, string strPreNext, string strPreNextContext, string strScreenNo, int nRequestCount)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("RequestFidArray", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.RequestFidArray(nRqId, strOutputFidList, strPreNext, strPreNextContext, strScreenNo, nRequestCount);
        }

        public virtual int GetFidOutputRowCnt(int nRequestId)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetFidOutputRowCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetFidOutputRowCnt(nRequestId);
        }

        public virtual string GetFidOutputData(int nRequestId, string strFID, int nRow)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetFidOutputData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetFidOutputData(nRequestId, strFID, nRow);
        }

        public virtual int GetCommFidDataBlock(long pVVector)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommFidDataBlock", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommFidDataBlock(pVVector);
        }

        public virtual int SetPortfolioFidInputData(int nRqId, string strSymbolCode, string strSymbolMarket)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetPortfolioFidInputData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetPortfolioFidInputData(nRqId, strSymbolCode, strSymbolMarket);
        }

        public virtual int RegisterReal(string strRealName, string strRealKey)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("RegisterReal", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.RegisterReal(strRealName, strRealKey);
        }

        public virtual int UnRegisterReal(string strRealName, string strRealKey)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("UnRegisterReal", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.UnRegisterReal(strRealName, strRealKey);
        }

        public virtual int AllUnRegisterReal()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("AllUnRegisterReal", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.AllUnRegisterReal();
        }

        public virtual string GetRealOutputData(string strRealName, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetRealOutputData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetRealOutputData(strRealName, strItemName);
        }

        public virtual int GetCommRealRecvDataBlock(long pVector)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRealRecvDataBlock", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRealRecvDataBlock(pVector);
        }

        public virtual string GetLastErrMsg()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLastErrMsg", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLastErrMsg();
        }

        public virtual string GetApiAgentModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetApiAgentModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetApiAgentModulePath();
        }

        public virtual string GetEncrpyt(string strPlainText)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetEncrpyt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetEncrpyt(strPlainText);
        }

        public virtual void SetOffAgentMessageBox(int nOption)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetOffAgentMessageBox", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetOffAgentMessageBox(nOption);
        }

        public virtual string SetOptionalFunction(int nOption, int nValue1, int nValue2, string strValue1, string strValue2)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetOptionalFunction", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetOptionalFunction(nOption, nValue1, nValue2, strValue1, strValue2);
        }

        public virtual string GetAccInfo(int nOption, string szAccNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetAccInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetAccInfo(nOption, szAccNo);
        }

        public virtual int GetUserAccCnt()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetUserAccCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetUserAccCnt();
        }

        public virtual string GetUserAccNo(int nIndex)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetUserAccNo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetUserAccNo(nIndex);
        }

        public virtual string GetLBSIPList()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLBSIPList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLBSIPList();
        }

        public virtual void SetConnectIPList(string strIP)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetConnectIPList", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetConnectIPList(strIP);
        }

        public virtual void SetChangePort(int bChangePort)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetChangePort", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetChangePort(bChangePort);
        }

        public virtual string GetLinkTagData(string strTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLinkTagData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLinkTagData(strTag);
        }

        public virtual string SendStockOrder(short nRqId, short nOrderType, string strAccNo, string strAccPwd, string sTrCode, string strHogaGb, int lQty, int lPrice, int bCreditOrder, string strCreditType, string strLoanDate, string strCommdaCode, string strOrgOrdNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendStockOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendStockOrder(nRqId, nOrderType, strAccNo, strAccPwd, sTrCode, strHogaGb, lQty, lPrice, bCreditOrder, strCreditType, strLoanDate, strCommdaCode, strOrgOrdNo);
        }

        public virtual string SendFOOrder(short nRqId, short nOrderType, string strAccNo, string strAccPwd, string sTrCode, string strHogaGb, int lQty, string strPrice, string strCommdaCode, string strOrgOrdNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendFOOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendFOOrder(nRqId, nOrderType, strAccNo, strAccPwd, sTrCode, strHogaGb, lQty, strPrice, strCommdaCode, strOrgOrdNo);
        }

        public virtual string SendNightFOOrder(short nRqId, short nOrderType, string strAccNo, string strAccPwd, string sTrCode, string strHogaGb, int lQty, string strPrice, string strCommdaCode, string strOrgOrdNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendNightFOOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendNightFOOrder(nRqId, nOrderType, strAccNo, strAccPwd, sTrCode, strHogaGb, lQty, strPrice, strCommdaCode, strOrgOrdNo);
        }

        //protected override void CreateSink()
        //{
        //    //IL_0023: Unknown result type (might be due to invalid IL or missing references)
        //    //IL_002d: Expected O, but got Unknown
        //    try
        //    {
        //        eventMulticaster = new AxDBCommAgentEventMulticaster(this);
        //        cookie = new ConnectionPointCookie((object)ocx, (object)eventMulticaster, typeof(_DDBCommAgentEvents));
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //protected override void DetachSink()
        //{
        //    try
        //    {
        //        cookie.Disconnect();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //protected override void AttachInterfaces()
        //{
        //    try
        //    {
        //        ocx = (_DDBCommAgent)((AxHost)this).GetOcx();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        internal void RaiseOnOnGetTranData(object sender, _DDBCommAgentEvents_OnGetTranDataEvent e)
        {
            OnGetTranData?.Invoke(sender, e);
        }

        internal void RaiseOnOnGetFidData(object sender, _DDBCommAgentEvents_OnGetFidDataEvent e)
        {
            OnGetFidData?.Invoke(sender, e);
        }

        internal void RaiseOnOnGetRealData(object sender, _DDBCommAgentEvents_OnGetRealDataEvent e)
        {
            OnGetRealData?.Invoke(sender, e);
        }

        internal void RaiseOnOnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
        {
            OnAgentEventHandler?.Invoke(sender, e);
        }

        public enum ActiveXInvokeKind
        {
            MethodInvoke,
            PropertyGet,
            PropertySet,
        }
        public class InvalidActiveXStateException : Exception
        {
            private readonly string _name;
            private readonly ActiveXInvokeKind _kind;

            public InvalidActiveXStateException(string name, ActiveXInvokeKind kind)
            {
                _name = name;
                _kind = kind;
            }

            public override string ToString()
            {
                return _kind switch
                {
                    ActiveXInvokeKind.MethodInvoke => string.Format("AXInvalidMethodInvoke {0}", _name),
                    ActiveXInvokeKind.PropertyGet => string.Format("AXInvalidPropertyGet {0}", _name),
                    ActiveXInvokeKind.PropertySet => string.Format("AXInvalidPropertySet {0}", _name),
                    _ => base.ToString(),
                };
            }
        }

        // additonal code
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool AtlAxWinInit();
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int AtlAxGetControl(IntPtr h, [MarshalAs(UnmanagedType.IUnknown)] out object pp);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool DestroyWindow(IntPtr hWnd);

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;

        private IntPtr hWndContainer = IntPtr.Zero;

        private System.Runtime.InteropServices.ComTypes.IConnectionPoint _pConnectionPoint;
        private int _nCookie = 0;
        private bool bInitialized = false;

        public bool Created => bInitialized;
        public AxDBCommAgent(IntPtr hWndParent)
        {
            string clsid = "{81942bfa-60e0-48cb-8573-a28f9416f6ee}";

            if (AtlAxWinInit())
            {
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9003, IntPtr.Zero, IntPtr.Zero);
                if (hWndContainer != IntPtr.Zero)
                {
                    try
                    {
                        object pUnknown;
                        AtlAxGetControl(hWndContainer, out pUnknown);
                        if (pUnknown != null)
                        {
                            ocx = (_DDBCommAgent)pUnknown;
                            if (ocx != null)
                            {
                                Guid guidEvents = typeof(_DDBCommAgentEvents).GUID;
                                System.Runtime.InteropServices.ComTypes.IConnectionPointContainer pConnectionPointContainer;
                                pConnectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)pUnknown;
                                pConnectionPointContainer.FindConnectionPoint(ref guidEvents, out _pConnectionPoint);
                                if (_pConnectionPoint != null)
                                {
                                    AxDBCommAgentEventMulticaster pEventSink = new AxDBCommAgentEventMulticaster(this);
                                    _pConnectionPoint.Advise(pEventSink, out _nCookie);
                                    bInitialized = true;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        DestroyWindow(hWndContainer);
                        hWndContainer = IntPtr.Zero;
                    }
                }
            }
        }

    }

}
