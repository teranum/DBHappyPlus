using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DBCommAgent.NET
{
    [ComImport]
    [Guid("A1C1EAC9-87BE-4AC8-B193-0FC8049425A9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface _DDBCommAgent
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
    internal interface _DDBCommAgentEvents
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

    /// <summary>
    /// Tran조회응답 이벤트
    /// </summary>
    /// <param name="nRequestId">조회고유ID(Request ID), CreateRequestID메소드로 생성</param>
    /// <param name="pBlock">응답 데이터 블록</param>
    /// <param name="nBlockLength">응답 데이터 블록 크기</param>
    public class _DDBCommAgentEvents_OnGetTranDataEvent(int nRequestId, string pBlock, int nBlockLength) : EventArgs
    {
        /// <summary>
        /// 조회고유ID(Request ID), CreateRequestID메소드로 생성
        /// </summary>
        public int nRequestId = nRequestId;
        /// <summary>
        /// 응답 데이터 블록
        /// </summary>
        public string pBlock = pBlock;
        /// <summary>
        /// 응답 데이터 블록 크기
        /// </summary>
        public int nBlockLength = nBlockLength;
    }

    /// <summary>
    /// FID조회응답 이벤트
    /// </summary>
    /// <param name="nRequestId">조회고유ID(Request ID), CreateRequestID메소드로 생성</param>
    /// <param name="pBlock">응답 데이터 블록</param>
    /// <param name="nBlockLength">응답 데이터 블록 크기</param>
    public class _DDBCommAgentEvents_OnGetFidDataEvent(int nRequestId, string pBlock, int nBlockLength) : EventArgs
    {
        /// <summary>
        /// 조회고유ID(Request ID), CreateRequestID메소드로 생성
        /// </summary>
        public int nRequestId = nRequestId;
        /// <summary>
        /// 응답 데이터 블록
        /// </summary>
        public string pBlock = pBlock;
        /// <summary>
        /// 응답 데이터 블록 크기
        /// </summary>
        public int nBlockLength = nBlockLength;
    }

    /// <summary>
    /// 실시간데이터 수신 이벤트
    /// </summary>
    /// <param name="strRealName">실시간 수신 데이터 실시간코드명, 실시간 리소스파일(*.res)파일의 ' REAL_NAME=' 항목(ex-> "S00")</param>
    /// <param name="strRealKey">실시간 수신 실시간등록키(ex-> "000660" : SK하이닉스 종목코드)</param>
    /// <param name="pBlock">수신 데이터 블록</param>
    /// <param name="nBlockLength">수신 데이터 블록 크기</param>
    public class _DDBCommAgentEvents_OnGetRealDataEvent(string strRealName, string strRealKey, string pBlock, int nBlockLength) : EventArgs
    {
        /// <summary>
        /// 실시간 수신 데이터 실시간코드명, 실시간 리소스파일(*.res)파일의 ' REAL_NAME=' 항목(ex-> "S00")
        /// </summary>
        public string strRealName = strRealName;
        /// <summary>
        /// 실시간 수신 실시간등록키(ex-> "000660" : SK하이닉스 종목코드)
        /// </summary>
        public string strRealKey = strRealKey;
        /// <summary>
        /// 수신 데이터 블록
        /// </summary>
        public string pBlock = pBlock;
        /// <summary>
        /// 수신 데이터 블록 크기
        /// </summary>
        public int nBlockLength = nBlockLength;
    }

    /// <summary>
    /// Agent로부터 받은 메시지 수신 이벤트
    /// </summary>
    /// <param name="nEventType"></param>
    /// <param name="nParam"></param>
    /// <param name="strParam"></param>
    public class _DDBCommAgentEvents_OnAgentEventHandlerEvent(int nEventType, int nParam, string strParam) : EventArgs
    {
        /// <summary>
        /// CommAgentEvent 종류
        /// </summary>
        public int nEventType = nEventType;
        /// <summary>
        /// 
        /// </summary>
        public int nParam = nParam;
        /// <summary>
        /// 
        /// </summary>
        public string strParam = strParam;
    }


    [ClassInterface(ClassInterfaceType.None)]
    internal class AxDBCommAgentEventMulticaster(AxDBCommAgent parent) : _DDBCommAgentEvents
    {
        private readonly AxDBCommAgent parent = parent;

        public virtual void OnGetTranData(int nRequestId, string pBlock, int nBlockLength) => parent.RaiseOnOnGetTranData(parent, new(nRequestId, pBlock, nBlockLength));

        public virtual void OnGetFidData(int nRequestId, string pBlock, int nBlockLength) => parent.RaiseOnOnGetFidData(parent, new(nRequestId, pBlock, nBlockLength));

        public virtual void OnGetRealData(string strRealName, string strRealKey, string pBlock, int nBlockLength) => parent.RaiseOnOnGetRealData(parent, new(strRealName, strRealKey, pBlock, nBlockLength));

        public virtual void OnAgentEventHandler(int nEventType, int nParam, string strParam) => parent.RaiseOnOnAgentEventHandler(parent, new(nEventType, nParam, strParam));
    }

    /// <summary>
    /// OCX Wrapper
    /// </summary>
    public class AxDBCommAgent
    {
        private readonly _DDBCommAgent ocx;

        //private AxDBCommAgentEventMulticaster eventMulticaster;

        //private ConnectionPointCookie cookie;

        /// <inheritdoc cref="_DDBCommAgentEvents_OnGetTranDataEvent"/>
        public event EventHandler<_DDBCommAgentEvents_OnGetTranDataEvent> OnGetTranData;

        /// <inheritdoc cref="_DDBCommAgentEvents_OnGetFidDataEvent"/>
        public event EventHandler<_DDBCommAgentEvents_OnGetFidDataEvent> OnGetFidData;

        /// <inheritdoc cref="_DDBCommAgentEvents_OnGetRealDataEvent"/>
        public event EventHandler<_DDBCommAgentEvents_OnGetRealDataEvent> OnGetRealData;

        /// <inheritdoc cref="_DDBCommAgentEvents_OnAgentEventHandlerEvent"/>
        public event EventHandler<_DDBCommAgentEvents_OnAgentEventHandlerEvent> OnAgentEventHandler;

        /// <summary>
        /// 통신모듈 초기화 및 연결
        /// <para>로그인 처리전에 호출한다.</para>
        /// </summary>
        /// <returns>0 : 성공, 음수 : 오류</returns>
        public virtual int CommInit() => ocx.CommInit();

        /// <summary>
        /// 연결 해제
        /// <para>로그아웃 처리 이후에 호출한다.</para>
        /// </summary>
        /// <param name="bSocketClose"></param>
        public virtual void CommTerminate(int bSocketClose) => ocx.CommTerminate(bSocketClose);

        /// <summary>
        /// 통신연결 상태 확인
        /// <para>CommInit 메소드 호출 후 통신연결 상태 확인을 위해 호출한다.</para>
        /// </summary>
        /// <returns></returns>
        public virtual int CommGetConnectState() => ocx.CommGetConnectState();

        /// <summary>
        /// 로그인 처리
        /// <para>CommInit 호출 이후 통신 연결이 완료된 이후에 호출한다.</para>
        /// </summary>
        /// <param name="sUserID">로그인 ID</param>
        /// <param name="sPwd">로그인 비밀번호</param>
        /// <param name="sCertPwd">공인인증 비밀번호</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int CommLogin(string sUserID, string sPwd, string sCertPwd) => ocx.CommLogin(sUserID, sPwd, sCertPwd);

        /// <summary>
        /// 로그아웃 처리
        /// <para>CommTerminate 호출 전에 호출한다.</para>
        /// </summary>
        /// <param name="sUserID">로그인 ID</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int CommLogout(string sUserID) => ocx.CommLogout(sUserID);

        /// <summary>
        /// 로그인상태 확인
        /// <para>CommLogin 메소드 호출 이후, 로그인 상태 확인 목적으로 호출한다.</para>
        /// </summary>
        /// <returns>0 : 로그아웃, 1 : 로그인</returns>
        public virtual int GetLoginState() => ocx.GetLoginState();

        /// <summary>
        /// 로그인모드 설정
        /// <para>CommLogin 메소드 호출전, 로그인 접속 설정을 한다.</para>
        /// </summary>
        /// <param name="nOption">0 : 모의투자 구분, 1 : 시세전용 구분</param>
        /// <param name="nMode">
        /// nOption(0)  0:실거래, 1:국내모의, 2:해외모의;
        /// nOption(1)  0:공인인증, 1:시세전용
        /// </param>
        public virtual void SetLoginMode(int nOption, int nMode) => ocx.SetLoginMode(nOption, nMode);

        /// <summary>
        /// 로그인상태 확인
        /// <para>CommLogin 메소드 호출 이후, 로그인 상태 확인 목적으로 호출한다.</para>
        /// </summary>
        /// <param name="nOption">0 : 모의투자 체크, 1 : 시제전용, 2 : 직원/고객 로그인</param>
        /// <returns>-1 : 실패, 성공 : -1보다 큰 양수</returns>
        public virtual int GetLoginMode(int nOption) => ocx.GetLoginMode(nOption);

        /// <summary>
        /// Tran조회 I/O Block 정보 리소스파일 로드
        /// <para>Tran조회 시에 반드시 리소스파일이 에이전트 컨트롤에 적재되어 있어야한다.</para>
        /// </summary>
        /// <param name="strFilePath">Tran I/O Block 정보 리소스파일(*.res) 경로</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int LoadTranResource(string strFilePath) => ocx.LoadTranResource(strFilePath);

        /// <summary>
        /// 실시간 Block 정보 리소스파일 로드
        /// <para>실시간 등록 시에 반드시 리소스파일이 에이전트 컨트롤에 적재되어 있어야한다.</para>
        /// </summary>
        /// <param name="strFilePath">실시간Block정보 리소스 파일(*.res) 경로</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int LoadRealResource(string strFilePath) => ocx.LoadRealResource(strFilePath);

        /// <summary>
        /// 조회고유ID 생성(Request ID)
        /// <para>Tran/FID조회 시, RQ ID를 먼저 생성한다.</para>
        /// </summary>
        /// <returns>신규 RQ ID 반환(음수 : 실패, 2보다 큰 정수 : 성공)</returns>
        public virtual int CreateRequestID() => ocx.CreateRequestID();

        /// <summary>
        /// 조회응답 부가정보/옵션값 반환
        /// <para>Tran/FID조회(OnGetTranData, OnGetFidData) 응답 이벤트 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="nOptionType">CommRecvOpt 값</param>
        /// <returns>nOptionType에 대응하는 문자열값 반환</returns>
        public virtual string GetCommRecvOptionValue(int nOptionType) => ocx.GetCommRecvOptionValue(nOptionType);

        /// <summary>ReleaseRqId</summary>
        /// <param name="nRqId">조회고유ID</param>
        public virtual void ReleaseRqId(int nRqId) => ocx.ReleaseRqId(nRqId);

        /// <summary>
        /// Tran조회, 항목별 입력값을 입력한다.
        /// <para>RequestTran 호출 전에 통신 Input데이터 입력 목적으로 호출한다.</para>
        /// </summary>
        /// <param name="nRqId">조회고유ID(Request ID)</param>
        /// <param name="strTrCode">서비스Tr코드(Tran 리소스파일(*.res)파일의 ' TR_CODE=' 항목)</param>
        /// <param name="strRecName">Input레코드명(Tran 리소스파일(*.res)파일의 ' RecName=' 항목)</param>
        /// <param name="strItem">Input항목명(Tran 리소스파일(*.res)파일의 'ITEM=' 항목)</param>
        /// <param name="strValue">Input항목에 대응하는 입력값</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int SetTranInputData(int nRqId, string strTrCode, string strRecName, string strItem, string strValue) => ocx.SetTranInputData(nRqId, strTrCode, strRecName, strItem, strValue);

        /// <summary>
        /// Tran조회 요청
        /// <para>서버에 Tran조회 요청 시 호출</para>
        /// </summary>
        /// <param name="nRqId">조회고유ID(Request ID)</param>
        /// <param name="sTrCode">서비스Tr코드(Tran 리소스파일(*.res)파일의 ' TR_CODE=' 항목)</param>
        /// <param name="sIsBenefit">수익계좌 여부("Y", "N")</param>
        /// <param name="sPrevOrNext">연속조회 구분("0" :일반조회, "1" : 연속조회 첫 조회, "2" : 이전조회, "3" : 다음조회)</param>
        /// <param name="sPrevNextKey">다음/이전 조회 시 연속구분이 되는 키값 입력(조회응답으로 내려 온다.)</param>
        /// <param name="sScreenNo">화면번호(ex-> "9999")</param>
        /// <param name="sTranType">Q':조회, 'U':Update(보통 조회는 'Q', 주문 등은 'U'를 입력한다.)</param>
        /// <param name="nRequestCount">조회 응답으로 받을 최대 데이터 건수(Maxium : 9999)</param>
        /// <returns>음수 : 실패, 0보다 큰 정수 : 성공</returns>
        public virtual int RequestTran(int nRqId, string sTrCode, string sIsBenefit, string sPrevOrNext, string sPrevNextKey, string sScreenNo, string sTranType, int nRequestCount) => ocx.RequestTran(nRqId, sTrCode, sIsBenefit, sPrevOrNext, sPrevNextKey, sScreenNo, sTranType, nRequestCount);

        /// <summary>
        /// Tran조회응답 데이터 건수 반환
        /// <para>Tran조회응답 이벤트(OnGetTranData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="strTrCode">서비스 Tr코드(Tran 리소스파일(*.res)파일의 ' TR_CODE=' 항목)</param>
        /// <param name="strRecName">Input 레코드명(Tran 리소스파일(*.res)파일의 ' RecName=' 항목)</param>
        /// <returns>0 : 데이터 없음, 0보다 큰 정수 : 데이터 건수</returns>
        public virtual int GetTranOutputRowCnt(string strTrCode, string strRecName) => ocx.GetTranOutputRowCnt(strTrCode, strRecName);

        /// <summary>
        /// Tran조회 항목별 응답데이터 반환
        /// <para>Tran조회 응답 이벤트(OnGetTranData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="strTrCode"></param>
        /// <param name="strRecName"></param>
        /// <param name="strItemName"></param>
        /// <param name="nRow"></param>
        /// <returns></returns>
        public virtual string GetTranOutputData(string strTrCode, string strRecName, string strItemName, int nRow) => ocx.GetTranOutputData(strTrCode, strRecName, strItemName, nRow);

        /// <summary>
        /// Tran조회 입력 데이터 건수 설정
        /// <para>RequestTran 호출 전에 통신 Input데이터 건수 입력 목적으로 호출한다.</para>
        /// </summary>
        /// <param name="nRqId"></param>
        /// <param name="strTrCode"></param>
        /// <param name="strRecName">입력 레코드명</param>
        /// <param name="nRecCnt">데이터 입력 건수</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int SetTranInputArrayCnt(int nRqId, string strTrCode, string strRecName, int nRecCnt) => ocx.SetTranInputArrayCnt(nRqId, strTrCode, strRecName, nRecCnt);

        /// <summary>
        /// Tran조회 복수건 입력
        /// <para>RequestTran 호출 전에 통신 복수건 Input데이터 입력 목적으로 호출한다.</para>
        /// </summary>
        /// <param name="nRqId"></param>
        /// <param name="strTrCode"></param>
        /// <param name="strRecName">입력 레코드명</param>
        /// <param name="strItem">항목명</param>
        /// <param name="strValue">입력값</param>
        /// <param name="nArrayIndex">레코드 인덱스(0부터 시작)</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int SetTranInputArrayData(int nRqId, string strTrCode, string strRecName, string strItem, string strValue, int nArrayIndex) => ocx.SetTranInputArrayData(nRqId, strTrCode, strRecName, strItem, strValue, nArrayIndex);

        /// <summary>
        /// FID조회 시, 항목별 입력값 입력
        /// <para>RequestFid 또는 RequestFidArray 호출 전에 조회 Input데이터 입력 목적으로 호출한다.</para>
        /// </summary>
        /// <param name="nRqId">조회고유ID(Request ID)</param>
        /// <param name="strFID">FID번호(ex-> "9002")</param>
        /// <param name="strValue">FID번호에 대응하는 입력값 (ex-> "000660")</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int SetFidInputData(int nRqId, string strFID, string strValue) => ocx.SetFidInputData(nRqId, strFID, strValue);

        /// <summary>
        /// FID조회 요청 - 응답데이터가 단건(single)
        /// <para>서버에 FID조회 요청 시 호출(응답으로 받을 데이터 단건일 경우에 사용)</para>
        /// </summary>
        /// <param name="nRqId">조회고유ID(Request ID)</param>
        /// <param name="strOutputFidList">응답으로 받을 FID번호들(ex-> "4,6,5,7,11,28,13,14,15")</param>
        /// <param name="strScreenNo">화면번호 (ex-> "9999")</param>
        /// <returns>음수 : 실패, 1 : 성공 : 2보다 큰 정수</returns>
        public virtual int RequestFid(int nRqId, string strOutputFidList, string strScreenNo) => ocx.RequestFid(nRqId, strOutputFidList, strScreenNo);

        /// <summary>
        /// FID조회 요청 - 응답 데이터가 복수건(array)
        /// <para>서버에 FID조회 요청 시 호출(응답받을 데이터가 복수건인 경우에 사용)</para>
        /// </summary>
        /// <param name="nRqId">조회고유ID(Request ID)</param>
        /// <param name="strOutputFidList">응답으로 받을 FID번호들(ex-> "4,6,5,7,11,28,13,14,15")</param>
        /// <param name="strPreNext">연속조회 구분("0" :일반, "1" : 연속 첫 조회, "2" : 이전 조회, "3" : 다음 조회)</param>
        /// <param name="strPreNextContext">조회 응답으로 받은 연속거래키</param>
        /// <param name="strScreenNo">화면변호(ex-> "9999")</param>
        /// <param name="nRequestCount">조회 응답으로 받을 최대 데이터 건수(Maxium : 9999)</param>
        /// <returns>음수 : 실패, 1 : 성공 : 2보다 큰 정수</returns>
        public virtual int RequestFidArray(int nRqId, string strOutputFidList, string strPreNext, string strPreNextContext, string strScreenNo, int nRequestCount) => ocx.RequestFidArray(nRqId, strOutputFidList, strPreNext, strPreNextContext, strScreenNo, nRequestCount);

        /// <summary>
        /// FID조회 응답데이터 건수
        /// <para>FID조회응답 이벤트(OnGetFidData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="nRequestId">조회고유ID(Request ID)</param>
        /// <returns>0 : 데이터 없음, 0보다 큰 정수 : 데이터 건수</returns>
        public virtual int GetFidOutputRowCnt(int nRequestId) => ocx.GetFidOutputRowCnt(nRequestId);

        /// <summary>
        /// FID조회 항목별 응답 데이터 반환
        /// <para>FID조회응답 이벤트(OnGetFidData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="nRequestId">조회고유ID(Request ID)</param>
        /// <param name="strFID">응답 받은 FID번호(ex-> "4")</param>
        /// <param name="nRow">항목값이 위치한 행 인덱스 - 단건(single)  : 0, - 복수건(array) : 해당 행의 인덱스 번호</param>
        /// <returns></returns>
        public virtual string GetFidOutputData(int nRequestId, string strFID, int nRow) => ocx.GetFidOutputData(nRequestId, strFID, nRow);

        /// <summary>
        /// FID조회 응답데이터 메모리 블럭 포인터
        /// <para>FID조회응답 이벤트(OnGetFidData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="pVVector">응답데이터 접근 데이터 블럭 포인터</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int GetCommFidDataBlock(long pVVector) => ocx.GetCommFidDataBlock(pVVector);

        /// <summary>
        /// 관심종목형(Portfolio) FID조회 시, 항목별 입력값 입력
        /// <para>RequestFid 또는 RequestFidArray 호출 전에 조회 Input데이터 입력 목적으로 호출한다.</para>
        /// </summary>
        /// <param name="nRqId">조회고유ID(Request ID)</param>
        /// <param name="strSymbolCode">종목코드</param>
        /// <param name="strSymbolMarket">종목 시장코드</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int SetPortfolioFidInputData(int nRqId, string strSymbolCode, string strSymbolMarket) => ocx.SetPortfolioFidInputData(nRqId, strSymbolCode, strSymbolMarket);

        /// <summary>
        /// 실시간 등록한다.
        /// <para>로그인 처리가 완료된 이후 또는 Tran/FID조회응답 이벤트 안에서 호출한다.</para>
        /// </summary>
        /// <param name="strRealName">실시간 등록할 실시간코드명: 실시간 리소스파일(*.res)파일의 ' REAL_NAME=' 항목(ex-> "S00")</param>
        /// <param name="strRealKey">실시간 수신 시 데이터 구분키가 될 값(ex-> "000660" : SK하이닉스 종목코드)</param>
        /// <returns>음수 : 실패, 0 : 성공</returns>
        public virtual int RegisterReal(string strRealName, string strRealKey) => ocx.RegisterReal(strRealName, strRealKey);

        /// <summary>
        /// 실시간등록 해제한다.
        /// <para>RegisterReal 함수 호출 이후에 호출한다.</para>
        /// </summary>
        /// <param name="strRealName">실시간등록 해제할 실시간코드명: 실시간 리소스파일(*.res)파일의 ' REAL_NAME=' 항목(ex-> "S00")</param>
        /// <param name="strRealKey">실시간등록 해제할 실시간등록키(ex-> "000660" : SK하이닉스 종목코드)</param>
        /// <returns>음수 : 실패, 1 : 성공</returns>
        public virtual int UnRegisterReal(string strRealName, string strRealKey) => ocx.UnRegisterReal(strRealName, strRealKey);

        /// <summary>
        /// 모든 실시간등록 해제한다.
        /// </summary>
        /// <returns>음수 : 실패, 1 : 성공</returns>
        public virtual int AllUnRegisterReal() => ocx.AllUnRegisterReal();

        /// <summary>
        /// 항목별 실시간 수신 데이터를 반환한다.
        /// <para>실시간데이터 수신 이벤트(OnGetRealData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="strRealName">실시간 수신 데이터 실시간코드명: 실시간 리소스파일(*.res)파일의 ' REAL_NAME=' 항목(ex-> "S00")</param>
        /// <param name="strItemName">실시간 리소스파일(*.res)파일의 ' ITEM=' 항목(ex-> " SHRN_ISCD")</param>
        /// <returns>해당 strItemName에 대응하는 데이터값 반환</returns>
        public virtual string GetRealOutputData(string strRealName, string strItemName) => ocx.GetRealOutputData(strRealName, strItemName);

        /// <summary>
        /// 실시간 수신 데이터 메모리 블럭 포인터 제공
        /// <para>실시간데이터 수신 이벤트(OnGetRealData) 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="pVector">응답데이터 직접 접근에 사용될 메모리 포인터</param>
        /// <returns>0 : 실패, 1 : 성공</returns>
        public virtual int GetCommRealRecvDataBlock(long pVector) => ocx.GetCommRealRecvDataBlock(pVector);

        /// <summary>
        /// 에러 메시지 확인
        /// <para>API메소드에서 에러가 발생했을 경우, 에러메시지 확인하기 위해 호출한다.</para>
        /// </summary>
        /// <returns>마지막으로 호출된 API메소드에서 에러가 발생했을 경우 에러메시지 반환</returns>
        public virtual string GetLastErrMsg() => ocx.GetLastErrMsg();

        /// <summary>
        /// OpenAPI 에이전트 모듈 파일경로 반환
        /// <para>에이전트 오브젝트 생성 이후에 호출</para>
        /// </summary>
        /// <returns>OpenAPI 에이전트 모듈 파일경로 반환</returns>
        public virtual string GetApiAgentModulePath() => ocx.GetApiAgentModulePath();

        /// <summary>
        /// 계좌비밀번호는 단방향 암호화를 해야된다
        /// </summary>
        /// <param name="strPlainText"></param>
        /// <returns>암호화된 문자열</returns>
        public virtual string GetEncrpyt(string strPlainText) => ocx.GetEncrpyt(strPlainText);

        /// <summary>
        /// 메시지 박스 출력 유/무 설정
        /// </summary>
        /// <param name="nOption">1: off, 0: on</param>
        public virtual void SetOffAgentMessageBox(int nOption) => ocx.SetOffAgentMessageBox(nOption);

        /// <summary>SetOptionalFunction</summary>
        public virtual string SetOptionalFunction(int nOption, int nValue1, int nValue2, string strValue1, string strValue2) => ocx.SetOptionalFunction(nOption, nValue1, nValue2, strValue1, strValue2);

        /// <summary>
        /// 계좌 정보
        /// </summary>
        /// <param name="nOption">0 : 계좌번호, 1 : 계좌상품번호</param>
        /// <param name="szAccNo">계좌번호</param>
        /// <returns>옵션에 해당하는 값</returns>
        public virtual string GetAccInfo(int nOption, string szAccNo) => ocx.GetAccInfo(nOption, szAccNo);

        /// <summary>
        /// 보유계좌 수
        /// </summary>
        /// <returns>보유계좌 수</returns>
        public virtual int GetUserAccCnt() => ocx.GetUserAccCnt();

        /// <summary>
        /// 보유계좌 반환
        /// </summary>
        /// <param name="nIndex">보유계좌 인덱스</param>
        /// <returns>계좌번호반환(종합계좌번호(8) + 계좌상품번호(3))</returns>
        public virtual string GetUserAccNo(int nIndex) => ocx.GetUserAccNo(nIndex);

        /// <summary>GetLBSIPList</summary>
        public virtual string GetLBSIPList() => ocx.GetLBSIPList();

        /// <summary>
        /// 강제 접속 IP 셋팅
        /// </summary>
        /// <param name="strIP">IP</param>
        public virtual void SetConnectIPList(string strIP) => ocx.SetConnectIPList(strIP);

        /// <summary>SetChangePort</summary>
        public virtual void SetChangePort(int bChangePort) => ocx.SetChangePort(bChangePort);

        /// <summary>
        /// GetLinkTagData("USER_NO") : 고객번호
        /// </summary>
        /// <param name="strTag"></param>
        /// <returns></returns>
        public virtual string GetLinkTagData(string strTag) => ocx.GetLinkTagData(strTag);

        /// <summary>
        /// 현물 주문
        /// </summary>
        /// <param name="nRqId">서비스 RqID</param>
        /// <param name="nOrderType">주문구분 (1-매도주문, 2-매수주문, 3-정정주문, 4-취소주문) </param>
        /// <param name="strAccNo">계좌번호</param>
        /// <param name="strAccPwd">계좌비밀번호</param>
        /// <param name="sTrCode">종목코드</param>
        /// <param name="strHogaGb">호가구분</param>
        /// <param name="lQty">주문수량</param>
        /// <param name="lPrice">주문가격</param>
        /// <param name="bCreditOrder">신용여부(신용:TRUE, 현금 : FALSE)</param>
        /// <param name="strCreditType">신용구분</param>
        /// <param name="strLoanDate">신용일자</param>
        /// <param name="strCommdaCode">매체구분코드(API :73고정)</param>
        /// <param name="strOrgOrdNo">원주문번호</param>
        /// <returns>Y성공 N 실패</returns>
        public virtual string SendStockOrder(short nRqId, short nOrderType, string strAccNo, string strAccPwd, string sTrCode, string strHogaGb, int lQty, int lPrice, int bCreditOrder, string strCreditType, string strLoanDate, string strCommdaCode, string strOrgOrdNo) => ocx.SendStockOrder(nRqId, nOrderType, strAccNo, strAccPwd, sTrCode, strHogaGb, lQty, lPrice, bCreditOrder, strCreditType, strLoanDate, strCommdaCode, strOrgOrdNo);

        /// <summary>
        /// 파생 주문
        /// </summary>
        /// <param name="nRqId">서비스 RqID</param>
        /// <param name="nOrderType">주문구분 (1-매도주문, 2-매수주문, 3-정정주문, 4-취소주문)</param>
        /// <param name="strAccNo">계좌번호</param>
        /// <param name="strAccPwd">계좌비밀번호</param>
        /// <param name="sTrCode">종목코드</param>
        /// <param name="strHogaGb">호가구분</param>
        /// <param name="lQty">주문수량</param>
        /// <param name="strPrice">주문가격</param>
        /// <param name="strCommdaCode">매체구분코드(API :73고정)</param>
        /// <param name="strOrgOrdNo">원주문번호</param>
        /// <returns></returns>
        public virtual string SendFOOrder(short nRqId, short nOrderType, string strAccNo, string strAccPwd, string sTrCode, string strHogaGb, int lQty, string strPrice, string strCommdaCode, string strOrgOrdNo) => ocx.SendFOOrder(nRqId, nOrderType, strAccNo, strAccPwd, sTrCode, strHogaGb, lQty, strPrice, strCommdaCode, strOrgOrdNo);

        /// <summary>
        /// 야간 파생 주문
        /// </summary>
        /// <param name="nRqId">서비스 RqID</param>
        /// <param name="nOrderType">주문구분 (1-매도주문, 2-매수주문, 3-정정주문, 4-취소주문)</param>
        /// <param name="strAccNo">계좌번호</param>
        /// <param name="strAccPwd">계좌비밀번호</param>
        /// <param name="sTrCode">종목코드</param>
        /// <param name="strHogaGb">호가구분</param>
        /// <param name="lQty">주문수량</param>
        /// <param name="strPrice">주문가격</param>
        /// <param name="strCommdaCode">매체구분코드(CME (88)고정)</param>
        /// <param name="strOrgOrdNo">원주문번호</param>
        /// <returns></returns>
        public virtual string SendNightFOOrder(short nRqId, short nOrderType, string strAccNo, string strAccPwd, string sTrCode, string strHogaGb, int lQty, string strPrice, string strCommdaCode, string strOrgOrdNo) => ocx.SendNightFOOrder(nRqId, nOrderType, strAccNo, strAccPwd, sTrCode, strHogaGb, lQty, strPrice, strCommdaCode, strOrgOrdNo);

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
            int async_ident_id = AsyncNode.GetIdentId([e.nRequestId]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is not null)
            {
                _async_list.Remove(async_node);
                async_node._async_tran_data_action?.Invoke(GetCommRecvOptionValues(), e);
                async_node._async_wait.Set();
                return;
            }
            OnGetTranData?.Invoke(this, e);
        }

        internal void RaiseOnOnGetFidData(object sender, _DDBCommAgentEvents_OnGetFidDataEvent e)
        {
            int async_ident_id = AsyncNode.GetIdentId([e.nRequestId]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is not null)
            {
                _async_list.Remove(async_node);
                async_node._async_fid_data_action?.Invoke(GetCommRecvOptionValues(), e);
                async_node._async_wait.Set();
                return;
            }
            OnGetFidData?.Invoke(this, e);
        }

        internal void RaiseOnOnGetRealData(object sender, _DDBCommAgentEvents_OnGetRealDataEvent e)
        {
            OnGetRealData?.Invoke(this, e);
        }

        internal void RaiseOnOnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
        {
            OnAgentEventHandler?.Invoke(this, e);
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
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;

        private readonly IntPtr hWndContainer = IntPtr.Zero;

        private readonly System.Runtime.InteropServices.ComTypes.IConnectionPoint _pConnectionPoint;
        private readonly bool bInitialized = false;
        private int _async_TimeOut = 5000;
        /// <summary>
        /// 비동기요청 타임아웃 (단위: ms)
        /// </summary>
        public int AsyncTimeOut
        {
            get => _async_TimeOut;
            set
            {
                _async_TimeOut = (value < 1000) ? 1000 : value;
            }
        }

        /// <summary>
        /// ApiAgent 객체 생성 여부
        /// </summary>
        public bool Created => bInitialized;

        /// <summary>
        /// ApiAgent 객체생성자
        /// </summary>
        /// <param name="hWndParent">윈도우 핸들</param>
        public AxDBCommAgent(nint hWndParent = 0)
        {
            if (hWndParent == IntPtr.Zero)
            {
                hWndParent = Process.GetCurrentProcess().MainWindowHandle;
                if (hWndParent == IntPtr.Zero)
                {
                    hWndParent = GetConsoleWindow();
                }
            }

            string clsid = "{81942bfa-60e0-48cb-8573-a28f9416f6ee}";

            if (AtlAxWinInit())
            {
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9004, IntPtr.Zero, IntPtr.Zero);
                if (hWndContainer != IntPtr.Zero)
                {
                    try
                    {
                        AtlAxGetControl(hWndContainer, out object pUnknown);
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
                                    AxDBCommAgentEventMulticaster pEventSink = new(this);
                                    _pConnectionPoint.Advise(pEventSink, out int nCookie);
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

        #region 비동기 확장함수 추가
        class AsyncNode(object[] objs)
        {
            public readonly int _ident_id = GetIdentId(objs);

            public static int GetIdentId(object[] objs)
            {
                int id = 0;
                for (int i = 0; i < objs.Length; i++)
                {
                    id = id * 31 + objs[i].GetHashCode();
                }
                return id;
            }

            public readonly ManualResetEvent _async_wait = new(initialState: false);
            public Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetTranDataEvent> _async_tran_data_action = null;
            public Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetFidDataEvent> _async_fid_data_action = null;
        }

        readonly List<AsyncNode> _async_list = [];

        /// <summary>
        /// RequestTran 비동기 확장함수
        /// <code>
        /// string strTrCode = "MCMAM20016"; // API승인계좌내역조회
        /// int nReturn = await api.RequestTranAsync(
        ///     ("InRec1", [            // 블록네임
        ///     ("divMedia", "D"),      // 메체구분 D:API
        ///     ("divUser", "H"),       // 유저구분  H:HTS
        ///     ("htsId", UserId),      // 고객ID
        ///     ("procTp", "0"),        // 조회구분0:조회1:연속
        ///     ("nxtKey", ""),         // 연속키
        ///     ]), strTrCode, "N", "0", "", "9999", "Q", 0,
        ///     (ov, e) =>
        ///     {
        ///         _ = int.TryParse(api.GetTranOutputData(strTrCode, "OutRec1", "Count", 0), out int nRowCnt);
        ///         OutLog($"API승인계좌개수: {nRowCnt}");
        ///         for (int nRow = 0; nRow &lt; nRowCnt; nRow++)
        ///         {
        ///             string strAPNO = api.GetTranOutputData(strTrCode, "OutRec2", "acntGoods", nRow);    //계좌상품번호	
        ///             string strCANO = api.GetTranOutputData(strTrCode, "OutRec2", "acntNo", nRow);       //계좌번호
        ///             OutLog($"계좌{nRow + 1}: {strAPNO}, {strCANO}");
        ///         }
        ///     }
        ///     );
        /// </code>
        /// 이벤트 콜백함수 action 으로 (<see cref="CommRecvOptionValue"/>, <see cref="_DDBCommAgentEvents_OnGetTranDataEvent"/>) 값 전달된다
        /// </summary>
        /// <param name="inputTrans">입력Trans 배열</param>
        /// <param name="sTrCode">서비스Tr코드(Tran 리소스파일(*.res)파일의 ' TR_CODE=' 항목)</param>
        /// <param name="sIsBenefit">수익계좌 여부("Y", "N")</param>
        /// <param name="sPrevOrNext">연속조회 구분("0" :일반조회, "1" : 연속조회 첫 조회, "2" : 이전조회, "3" : 다음조회)</param>
        /// <param name="sPrevNextKey">다음/이전 조회 시 연속구분이 되는 키값 입력(조회응답으로 내려 온다.)</param>
        /// <param name="sScreenNo">화면번호(ex-> "9999")</param>
        /// <param name="sTranType">Q':조회, 'U':Update(보통 조회는 'Q', 주문 등은 'U'를 입력한다.)</param>
        /// <param name="nRequestCount">조회 응답으로 받을 최대 데이터 건수(Maxium : 9999)</param>
        /// <param name="action">이벤트 콜백함수</param>
        /// <returns>음수 : 실패, 0보다 큰 정수 : 성공, -902: 요청 타임아웃</returns>
        public virtual async Task<int> RequestTranAsync((string BlockName, (string Key, string Value)[] KeyValues) inputTrans, string sTrCode, string sIsBenefit,
            string sPrevOrNext, string sPrevNextKey, string sScreenNo, string sTranType, int nRequestCount,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetTranDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            foreach (var (Key, Value) in inputTrans.KeyValues)
            {
                SetTranInputData(nRequstId, sTrCode, inputTrans.BlockName, Key, Value);
            }
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_tran_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestTran(nRequstId, sTrCode, sIsBenefit, sPrevOrNext, sPrevNextKey, sScreenNo, sTranType, nRequestCount);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        /// <summary>
        /// RequestTran 비동기 확장함수
        /// </summary>
        /// <param name="InBlockName"></param>
        /// <param name="KeyValues"></param>
        /// <param name="sTrCode"></param>
        /// <param name="sIsBenefit"></param>
        /// <param name="sPrevOrNext"></param>
        /// <param name="sPrevNextKey"></param>
        /// <param name="sScreenNo"></param>
        /// <param name="sTranType"></param>
        /// <param name="nRequestCount"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task<int> RequestTranAsync(string InBlockName, IEnumerable<KeyValuePair<string, object>> KeyValues, string sTrCode, string sIsBenefit,
            string sPrevOrNext, string sPrevNextKey, string sScreenNo, string sTranType, int nRequestCount,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetTranDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            foreach (var keyValue in KeyValues)
            {
                SetTranInputData(nRequstId, sTrCode, InBlockName, keyValue.Key, keyValue.Value.ToString());
            }
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_tran_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestTran(nRequstId, sTrCode, sIsBenefit, sPrevOrNext, sPrevNextKey, sScreenNo, sTranType, nRequestCount);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }



        /// <summary>
        /// RequestFid 비동기 확장함수
        /// <code>
        /// // 지수선물리스트 조회
        /// int nReturn = await api.RequestFidArrayAsync([
        ///     ("9001", "F"),
        ///     ("GID", "1499"),
        ///     ], "1,2,3,16", "0", "", "9999", 0,
        ///     (ov, e) =>
        ///     {
        ///         int nRowCnt = api.GetFidOutputRowCnt(e.nRequestId);
        ///         if (nRowCnt > 0)
        ///         {
        ///             var datas = api.ParseFidBlockArray(nRowCnt, e.pBlock);
        ///             for (int i = 0; i &lt; datas.Length; i++)
        ///             {
        ///                 OutLog($"{i}: {datas[i][0]}, {datas[i][1]}, {datas[i][2]}, {datas[i][3]}");
        ///             }
        ///         }
        ///     }
        ///     );
        /// </code>
        /// 이벤트 콜백함수 action 으로 (<see cref="CommRecvOptionValue"/>, <see cref="_DDBCommAgentEvents_OnGetFidDataEvent"/>) 값 전달된다
        /// </summary>
        /// <param name="inputFids">입력FIDs 배열</param>
        /// <param name="strOutputFidList">응답으로 받을 FID번호들(ex-> "4,6,5,7,11,28,13,14,15")</param>
        /// <param name="strScreenNo">화면변호(ex-> "9999")</param>
        /// <param name="action">이벤트 콜백함수</param>
        /// <returns>음수 : 실패, 1 : 성공 : 2보다 큰 정수, -902: 요청 타임아웃</returns>
        public virtual async Task<int> RequestFidAsync((string Key, string Value)[] inputFids, string strOutputFidList, string strScreenNo,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetFidDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            foreach (var (Key, Value) in inputFids)
            {
                SetFidInputData(nRequstId, Key, Value);
            }
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_fid_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestFid(nRequstId, strOutputFidList, strScreenNo);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        /// <summary>
        /// RequestFid 비동기 확장함수
        /// </summary>
        /// <param name="KeyValues"></param>
        /// <param name="strGID"></param>
        /// <param name="strOutputFidList"></param>
        /// <param name="strScreenNo"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task<int> RequestFidAsync(IEnumerable<KeyValuePair<string, object>> KeyValues, string strGID, string strOutputFidList, string strScreenNo,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetFidDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            foreach (var keyValue in KeyValues)
            {
                SetFidInputData(nRequstId, keyValue.Key, keyValue.Value.ToString());
            }
            if (strGID.Length > 0) SetFidInputData(nRequstId, "GID", strGID);
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_fid_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestFid(nRequstId, strOutputFidList, strScreenNo);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        /// <summary>
        /// RequestFidArray 비동기 확장함수
        /// <code>
        /// // 지수선물리스트 조회
        /// int nReturn = await api.RequestFidArrayAsync([
        ///     ("9001", "F"),
        ///     ("GID", "1499"),
        ///     ], "1,2,3,16", "0", "", "9999", 0,
        ///     (ov, e) =>
        ///     {
        ///         int nRowCnt = api.GetFidOutputRowCnt(e.nRequestId);
        ///         if (nRowCnt > 0)
        ///         {
        ///             var datas = api.ParseFidBlockArray(nRowCnt, e.pBlock);
        ///             for (int i = 0; i &lt; datas.Length; i++)
        ///             {
        ///                 OutLog($"{i}: {datas[i][0]}, {datas[i][1]}, {datas[i][2]}, {datas[i][3]}");
        ///             }
        ///         }
        ///     }
        ///     );
        /// </code>
        /// 이벤트 콜백함수 action 으로 (<see cref="CommRecvOptionValue"/>, <see cref="_DDBCommAgentEvents_OnGetFidDataEvent"/>) 값 전달된다
        /// </summary>
        /// <param name="inputFids">입력FIDs 배열</param>
        /// <param name="strOutputFidList">응답으로 받을 FID번호들(ex-> "4,6,5,7,11,28,13,14,15")</param>
        /// <param name="strPreNext">연속조회 구분("0" :일반, "1" : 연속 첫 조회, "2" : 이전 조회, "3" : 다음 조회)</param>
        /// <param name="strPreNextContext">조회 응답으로 받은 연속거래키</param>
        /// <param name="strScreenNo">화면변호(ex-> "9999")</param>
        /// <param name="nRequestCount">조회 응답으로 받을 최대 데이터 건수(Maxium : 9999)</param>
        /// <param name="action">이벤트 콜백함수</param>
        /// <returns>음수 : 실패, 1 : 성공 : 2보다 큰 정수, -902: 요청 타임아웃</returns>
        public virtual async Task<int> RequestFidArrayAsync((string Key, string Value)[] inputFids, string strOutputFidList, string strPreNext, string strPreNextContext, string strScreenNo, int nRequestCount,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetFidDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            foreach (var (Key, Value) in inputFids)
            {
                SetFidInputData(nRequstId, Key, Value);
            }
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_fid_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestFidArray(nRequstId, strOutputFidList, strPreNext, strPreNextContext, strScreenNo, nRequestCount);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        /// <summary>
        /// RequestFidArray 비동기 확장함수
        /// </summary>
        /// <param name="KeyValues"></param>
        /// <param name="strGID"></param>
        /// <param name="strOutputFidList"></param>
        /// <param name="strPreNext"></param>
        /// <param name="strPreNextContext"></param>
        /// <param name="strScreenNo"></param>
        /// <param name="nRequestCount"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task<int> RequestFidArrayAsync(IEnumerable<KeyValuePair<string, object>> KeyValues, string strGID, string strOutputFidList, string strPreNext, string strPreNextContext, string strScreenNo, int nRequestCount,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetFidDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            foreach (var keyValue in KeyValues)
            {
                SetFidInputData(nRequstId, keyValue.Key, keyValue.Value.ToString());

            }
            if (strGID.Length > 0)
                SetFidInputData(nRequstId, "GID", strGID);
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_fid_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestFidArray(nRequstId, strOutputFidList, strPreNext, strPreNextContext, strScreenNo, nRequestCount);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        /// <summary>
        /// RequestPortfolio 비동기 확장함수
        /// </summary>
        /// <param name="SymbolMarkets"></param>
        /// <param name="strOutputFidList"></param>
        /// <param name="strScreenNo"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task<int> RequestPortfolioAsync(IEnumerable<KeyValuePair<string, string>> SymbolMarkets, string strOutputFidList, string strScreenNo,
            Action<CommRecvOptionValue, _DDBCommAgentEvents_OnGetFidDataEvent> action
            )
        {
            int nRequstId = CreateRequestID();
            if (nRequstId < 0)
            {
                return nRequstId;
            }
            int nRequestCount = 0;
            foreach (var symbol_market in SymbolMarkets)
            {
                nRequestCount++;
                SetPortfolioFidInputData(nRequstId, symbol_market.Key, symbol_market.Value);
            }
            SetFidInputData(nRequstId, "GID", "5000");
            var newAsync = new AsyncNode([nRequstId])
            {
                _async_fid_data_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = RequestFidArray(nRequstId, strOutputFidList, "0", "", strScreenNo, nRequestCount);
            if (nRet > 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        /// <summary>
        /// 조회응답 부가정보/옵션값 전체 반환
        /// <para>Tran/FID조회(OnGetTranData, OnGetFidData) 응답 이벤트 안에서만 호출한다.</para>
        /// </summary>
        /// <returns>CommRecvOption 값 반환</returns>
        public CommRecvOptionValue GetCommRecvOptionValues()
        {
            return new CommRecvOptionValue()
            {
                TranCode = GetCommRecvOptionValue((int)CommRecvOption.TranCode),
                PrevNextCode = GetCommRecvOptionValue((int)CommRecvOption.PrevNextCode),
                PrevNextKey = GetCommRecvOptionValue((int)CommRecvOption.PrevNextKey),
                MsgCode = GetCommRecvOptionValue((int)CommRecvOption.MsgCode),
                Msg = GetCommRecvOptionValue((int)CommRecvOption.Msg),
                SubMsgCode = GetCommRecvOptionValue((int)CommRecvOption.SubMsgCode),
                SubMsg = GetCommRecvOptionValue((int)CommRecvOption.SubMsg),
                Error = GetCommRecvOptionValue((int)CommRecvOption.Error),
            };
        }

        /// <summary>
        /// 이벤트 pBlock 데이터 파싱
        /// <code>
        /// int nRowCnt = api.GetFidOutputRowCnt(e.nRequestId);
        /// string[][] datas = api.ParseFidBlockArray(nRowCnt, e.pBlock);
        /// ...
        /// </code>
        /// <para>FID조회(OnGetFidData) 응답 이벤트 안에서만 호출한다.</para>
        /// </summary>
        /// <param name="nRowCnt">Row 개수</param>
        /// <param name="pBlock">e.pBlock</param>
        /// <returns>2중 문자열 배열</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string[][] ParseFidBlockArray(int nRowCnt, string pBlock)
        {
            if (nRowCnt <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nRowCnt), "nRowCnt must be greater than 0");
            }
            // Splite in Record Separator(0x1E), Group Separator(0x1D), Unit Separator(0x1F)
            var blockData = pBlock.Split(['\u001E', '\u001D', '\u001F',]);
            int fieldCount = blockData.Length / nRowCnt;
            var result = new string[nRowCnt][];
            for (int i = 0; i < nRowCnt; i++)
            {
                result[i] = new string[fieldCount];
                for (int j = 0; j < fieldCount; j++)
                {
                    result[i][j] = blockData[i * fieldCount + j];
                }
            }
            return result;
        }

        /// <summary>
        /// FID조회 응답데이터 메모리 블럭 가져오기, 대량의 데이터 처리 시 GetFidOutputData 함수 호출보다 빠른 성능을 보인다.
        /// <para>FID조회응답 이벤트(OnGetFidData) 안에서만 호출한다.</para>
        /// <code>
        /// // 국내지수 선물 15분 차트 데이터 가져오기 샘플
        /// List&lt;(double T, double O, double H, double L, double C, double V)> chartDatas = [];
        /// string code = "101V3000";
        /// string date = DateTime.Today.ToString("yyyyMMdd");
        /// int nReturn = await api.RequestFidArrayAsync(
        ///     [
        ///     ("9001", "F"),
        ///     ("9002", code),
        ///     ("9034", date),
        ///     ("9035", date),
        ///     ("9119", "900"), // 15분봉
        ///     ("GID", "1005"),
        ///     ], "9,8,13,14,15,4,83", "0", "", "9999", 100,
        ///     (ov, e) =>
        ///     {
        ///         var commRecvData = api.GetCommFidDataBlock();
        ///         chartDatas.Capacity = commRecvData.Rows;
        ///         for (int i = 0; i &lt; commRecvData.Rows; i++)
        ///         {
        ///             chartDatas.Add((
        ///                 double.Parse(commRecvData[i, 0]) * 1000000
        ///                 + double.Parse(commRecvData[i, 1]), // T = 일자*1000000 + 시간
        ///                 double.Parse(commRecvData[i, 2]),   // O
        ///                 double.Parse(commRecvData[i, 3]),   // H
        ///                 double.Parse(commRecvData[i, 4]),   // L
        ///                 double.Parse(commRecvData[i, 5]),   // C
        ///                 double.Parse(commRecvData[i, 6])    // V
        ///                 ));
        ///         }
        ///     }
        ///     );
        /// if (nReturn &lt; 0)
        /// {
        ///     OutLog($"RequestFidArrayAsync failed({nReturn}): {api.GetLastErrMsg()}");
        ///     return;
        /// }
        /// 
        /// OutLog($"returned 차트요청: {nReturn}");
        /// OutLog($"지수차트요청 [{code}]: 데이터개수: {chartDatas.Count}");
        /// ...
        /// </code>
        /// </summary>
        /// <returns>실패시 Rows값이 0</returns>
        public virtual CommRecvData GetCommFidDataBlock()
        {
            nint ptr = 0;
            try
            {
                ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf<CommRecvData>());
                if (GetCommFidDataBlock((long)ptr) != 1)
                {
                    return default;
                }
                return Marshal.PtrToStructure<CommRecvData>(ptr);
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }

        /// <summary>
        /// 실시간 수신 데이터 메모리 블럭 가져오기, 대량의 데이터 처리 시 GetRealOutputData 함수 호출보다 빠른 성능을 보인다.
        /// <para>실시간데이터 수신 이벤트(OnGetRealData) 안에서만 호출한다.</para>
        /// </summary>
        /// <returns>실패시 Rows값이 0</returns>
        public virtual CommRecvData GetCommRealRecvDataBlock()
        {
            nint ptr = 0;
            try
            {
                ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf<CommRecvData>());
                if (GetCommRealRecvDataBlock((long)ptr) != 1)
                {
                    return default;
                }
                return Marshal.PtrToStructure<CommRecvData>(ptr);
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }
        #endregion
    }

    /// <summary>
    /// CommRecvOptionValue
    /// </summary>
    public class CommRecvOptionValue
    {
        /// <summary>
        /// Tr코드
        /// </summary>
        public string TranCode;
        /// <summary>
        /// 연속데이타 구분(0:없음, 1:이전, 2:다음, 3:이전/다음)
        /// </summary>
        public string PrevNextCode;
        /// <summary>
        /// 연속조회키
        /// </summary>
        public string PrevNextKey;
        /// <summary>
        /// 메시지코드
        /// </summary>
        public string MsgCode;
        /// <summary>
        /// 메시지
        /// </summary>
        public string Msg;
        /// <summary>
        /// 부가메시지코드
        /// </summary>
        public string SubMsgCode;
        /// <summary>
        /// 부가메시지
        /// </summary>
        public string SubMsg;
        /// <summary>
        /// 에러여부
        /// </summary>
        public string Error;
    }

    /// <summary>
    /// CommRecvOption
    /// </summary>
    public enum CommRecvOption
    {
        /// <summary>
        /// Tr코드
        /// </summary>
        TranCode = 0,
        /// <summary>
        /// 연속데이타 구분(0:없음, 1:이전, 2:다음, 3:이전/다음)
        /// </summary>
        PrevNextCode = 1,
        /// <summary>
        /// 연속조회키
        /// </summary>
        PrevNextKey = 2,
        /// <summary>
        /// 메시지코드
        /// </summary>
        MsgCode = 3,
        /// <summary>
        /// 메시지
        /// </summary>
        Msg = 4,
        /// <summary>
        /// 부가메시지코드
        /// </summary>
        SubMsgCode = 5,
        /// <summary>
        /// 부가메시지
        /// </summary>
        SubMsg = 6,
        /// <summary>
        /// 에러여부
        /// </summary>
        Error = 7,
    };

    /// <summary>
    /// OnAgentEventHandler 이벤트 nEventType 값
    /// </summary>
    public enum CommAgentEvent
    {
        /// <summary>
        /// 연결 완료
        /// </summary>
        Connected = 100,
        /// <summary>
        /// 소켓연결중
        /// </summary>
        Connecting = 101,
        /// <summary>
        /// 소켓 단절 상태
        /// </summary>
        Closed = 102,
        /// <summary>
        /// 소켓 단절 중
        /// </summary>
        Closing = 103,
        /// <summary>
        /// 재접속 요청
        /// </summary>
        ReconnectRequest = 104,
        /// <summary>
        /// 소켓 연결 실패
        /// </summary>
        ConnectFail = 105,
        /// <summary>
        /// 승인처리 완료
        /// </summary>
        LoginComplete = 106,
        /// <summary>
        /// 승인처리 실패
        /// </summary>
        LoginFail = 107,
        /// <summary>
        /// 데이터 송신 성공
        /// </summary>
        SendSuccess = 108,
        /// <summary>
        /// 다중접속 알림 메시지
        /// </summary>
        NotifyMultiLogin = 150,
        /// <summary>
        /// DB금융투자 긴급공지
        /// </summary>
        NotifyEmergency = 151,
        /// <summary>
        /// DB금융투자 팝업 이벤트
        /// </summary>
        PopUpMsg = 160,
    }

    /// <summary>
    /// 수신데이터를 직접 추출한다. (FID 또는 REAL 데이터 보관용)
    /// 종목리스트, 차트 데이터 같은 대량의 데이터 처리 시
    /// 에이전트 컨트롤의 GetFidOutputData 함수 호출보다 빠른 성능을 보인다.
    /// 대량의 실시간 데이터 처리 시에는 에이전트 컨트롤 GetRealOutputData 함수 호출보다 빠른 성능을 보인다.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CommRecvData
    {
        private readonly nint native_vfTable;
        private readonly IntPtr m_ptrBuf;

        /// <summary>
        /// 레코드 개수
        /// </summary>
        public readonly int Rows;

        /// <summary>
        /// 필드 개수
        /// </summary>
        public readonly int Cols;

        /// <inheritdoc cref="Rows"/>
        public readonly int GetRowCnt() => Rows;

        /// <inheritdoc cref="Cols"/>
        public readonly int GetColCnt() => Cols;

        /// <summary>
        /// 메모리 블럭에서 데이터 추출
        /// </summary>
        /// <param name="nRow">레코드 index</param>
        /// <param name="nCol">필드 index</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public readonly string GetItem(int nRow, int nCol)
        {
            if (nRow < 0 || nRow >= Rows)
                throw new ArgumentOutOfRangeException(nameof(nRow), "nRow is out of range");

            if (nCol < 0 || nCol >= Cols)
                throw new ArgumentOutOfRangeException(nameof(nCol), "nCol is out of range");

            int nindex = (nRow * Cols) + nCol;
            nint ptr = Marshal.PtrToStructure<nint>(m_ptrBuf + IntPtr.Size * nindex);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <inheritdoc cref="GetItem"/>
        public readonly string this[int nRow, int nCol] => GetItem(nRow, nCol);
    }

}
