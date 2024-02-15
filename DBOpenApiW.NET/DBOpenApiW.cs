using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DBOpenApiW.NET
{

    [ComImport]
    [InterfaceType(2)]
    [Guid("CC26D710-1FB2-4698-9AD9-86B4FF4CB3C8")]
    public interface _DDBOpenApiW
    {
        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(231)]
        int CommConnect(int nAutoUpgrade);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(232)]
        int CommRqData([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sPrevNext, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(233)]
        void SetInputValue([MarshalAs(UnmanagedType.BStr)] string sID, [MarshalAs(UnmanagedType.BStr)] string sValue);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(234)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommData([MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecordName, int nIndex, [MarshalAs(UnmanagedType.BStr)] string strItemName);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(235)]
        void CommTerminate();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(236)]
        int GetRepeatCnt([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(237)]
        void DisconnectRealData([MarshalAs(UnmanagedType.BStr)] string sScnNo);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(238)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommRealData([MarshalAs(UnmanagedType.BStr)] string strRealType, int nFid);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(239)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetChjanData(int nFid);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(240)]
        int SendOrder([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, [MarshalAs(UnmanagedType.BStr)] string sPrice, [MarshalAs(UnmanagedType.BStr)] string sStop, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(241)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLoginInfo([MarshalAs(UnmanagedType.BStr)] string sTag);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(242)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemlist();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(243)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionItemlist();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(244)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(245)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(246)]
        int GetConnectState();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(247)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetAPIModulePath();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(248)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommonFunc([MarshalAs(UnmanagedType.BStr)] string sFuncName, [MarshalAs(UnmanagedType.BStr)] string sParam);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(249)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetConvertPrice([MarshalAs(UnmanagedType.BStr)] string sCode, [MarshalAs(UnmanagedType.BStr)] string sPrice, int nType);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(250)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutOpCodeInfoByType(int nGubu, [MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(251)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutOpCodeInfoByCode([MarshalAs(UnmanagedType.BStr)] string sCode);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(252)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemlistByType([MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(253)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureCodeByItemMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(254)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionCodeByMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sCPGubun, [MarshalAs(UnmanagedType.BStr)] string sActPrice, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(255)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionMonthByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(256)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionActPriceByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(257)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemTypelist();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(258)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommFullData([MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecordName, int nGubun);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(259)]
        int SendOrderWithUserData([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, [MarshalAs(UnmanagedType.BStr)] string sPrice, [MarshalAs(UnmanagedType.BStr)] string sStop, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo, [MarshalAs(UnmanagedType.BStr)] string sUserData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(301)]
        void SetMultipleUser(int nOn);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(302)]
        int DBOACommRqData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sPrevNext, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(303)]
        int DBOASetInputValue([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sID, [MarshalAs(UnmanagedType.BStr)] string sValue);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(304)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetCommData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecordName, int nIndex, [MarshalAs(UnmanagedType.BStr)] string strItemName);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(305)]
        int DBOAGetRepeatCnt([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(306)]
        int DBOADisconnectRealData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sScnNo);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(307)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetCommRealData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string strRealType, int nFid);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(308)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetChjanData([MarshalAs(UnmanagedType.BStr)] string sUserID, int nFid);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(309)]
        int DBOASendOrder([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, [MarshalAs(UnmanagedType.BStr)] string sPrice, [MarshalAs(UnmanagedType.BStr)] string sStop, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo, [MarshalAs(UnmanagedType.BStr)] string sUserData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(310)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetLoginInfo([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sTag);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(311)]
        int DBOAGetConnectState([MarshalAs(UnmanagedType.BStr)] string sUserID);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(312)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetCommFullData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecordName, int nGubun);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(313)]
        int DBOACommLogin([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sPassword, [MarshalAs(UnmanagedType.BStr)] string sCertPassword, int nDemoOn);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(314)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAFunctionExtended([MarshalAs(UnmanagedType.BStr)] string sUserID, int nFuctionType, [MarshalAs(UnmanagedType.BStr)] string sInputData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(315)]
        int DBOACommConnect();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(316)]
        void DBOACommTerminate();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(317)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutureItemlist();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(318)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalOptionItemlist();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(319)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutureCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(320)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalOptionCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(321)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetAPIModulePath();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(322)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetConvertPrice([MarshalAs(UnmanagedType.BStr)] string sCode, [MarshalAs(UnmanagedType.BStr)] string sPrice, int nType);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(323)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutOpCodeInfoByType(int nGubu, [MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(324)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutOpCodeInfoByCode([MarshalAs(UnmanagedType.BStr)] string sCode);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(325)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutureItemlistByType([MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(326)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutureCodeByItemMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(327)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalOptionCodeByMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sCPGubun, [MarshalAs(UnmanagedType.BStr)] string sActPrice, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(328)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalOptionMonthByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(329)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalOptionActPriceByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(330)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string DBOAGetGlobalFutureItemTypelist();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(331)]
        int DBOASaveAccountPassword([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sAccount, [MarshalAs(UnmanagedType.BStr)] string sPassword);
    }

    [ComImport]
    [Guid("E6113AFD-7F2F-4DF0-B9E8-5DF1E86CF191")]
    [InterfaceType(2)]
    public interface _DDBOpenApiWEvents
    {
        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(221)]
        void OnReceiveTrData([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, [MarshalAs(UnmanagedType.BStr)] string sPreNext);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(222)]
        void OnReceiveRealData([MarshalAs(UnmanagedType.BStr)] string sJongmokCode, [MarshalAs(UnmanagedType.BStr)] string sRealType, [MarshalAs(UnmanagedType.BStr)] string sRealData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(223)]
        void OnReceiveMsg([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sMsg);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(224)]
        void OnReceiveChejanData([MarshalAs(UnmanagedType.BStr)] string sGubun, int nItemCnt, [MarshalAs(UnmanagedType.BStr)] string sFidList);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(225)]
        void OnEventConnect(int nErrCode);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(261)]
        void OnDBOAReceiveTrData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, [MarshalAs(UnmanagedType.BStr)] string sPreNext, [MarshalAs(UnmanagedType.BStr)] string sData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(262)]
        void OnDBOAReceiveRealData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sJongmokCode, [MarshalAs(UnmanagedType.BStr)] string sRealType, [MarshalAs(UnmanagedType.BStr)] string sRealData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(263)]
        void OnDBOAReceiveMsg([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sMsg);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(264)]
        void OnDBOAReceiveChejanData([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sGubun, int nItemCnt, [MarshalAs(UnmanagedType.BStr)] string sFidList);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(265)]
        void OnDBOAEventConnect([MarshalAs(UnmanagedType.BStr)] string sUserID, int nErrCode);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(266)]
        void OnDBOAEventExtended([MarshalAs(UnmanagedType.BStr)] string sUserID, int nEventType, [MarshalAs(UnmanagedType.BStr)] string sData);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(267)]
        void OnDBOAEventNotify([MarshalAs(UnmanagedType.BStr)] string sUserID, [MarshalAs(UnmanagedType.BStr)] string sNotifyType, [MarshalAs(UnmanagedType.BStr)] string sData);
    }

    public class _DDBOpenApiWEvents_OnReceiveTrDataEvent : EventArgs
    {
        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sRecordName;

        public string sPreNext;

        public _DDBOpenApiWEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext)
        {
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sRecordName = sRecordName;
            this.sPreNext = sPreNext;
        }
    }
    public class _DDBOpenApiWEvents_OnReceiveRealDataEvent : EventArgs
    {
        public string sJongmokCode;

        public string sRealType;

        public string sRealData;

        public _DDBOpenApiWEvents_OnReceiveRealDataEvent(string sJongmokCode, string sRealType, string sRealData)
        {
            this.sJongmokCode = sJongmokCode;
            this.sRealType = sRealType;
            this.sRealData = sRealData;
        }
    }
    public class _DDBOpenApiWEvents_OnReceiveMsgEvent : EventArgs
    {
        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sMsg;

        public _DDBOpenApiWEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sMsg = sMsg;
        }
    }
    public class _DDBOpenApiWEvents_OnReceiveChejanDataEvent : EventArgs
    {
        public string sGubun;

        public int nItemCnt;

        public string sFidList;

        public _DDBOpenApiWEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFidList)
        {
            this.sGubun = sGubun;
            this.nItemCnt = nItemCnt;
            this.sFidList = sFidList;
        }
    }
    public class _DDBOpenApiWEvents_OnEventConnectEvent : EventArgs
    {
        public int nErrCode;

        public _DDBOpenApiWEvents_OnEventConnectEvent(int nErrCode)
        {
            this.nErrCode = nErrCode;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent : EventArgs
    {
        public string sUserID;

        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sRecordName;

        public string sPreNext;

        public string sData;

        public _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent(string sUserID, string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext, string sData)
        {
            this.sUserID = sUserID;
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sRecordName = sRecordName;
            this.sPreNext = sPreNext;
            this.sData = sData;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent : EventArgs
    {
        public string sUserID;

        public string sJongmokCode;

        public string sRealType;

        public string sRealData;

        public _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent(string sUserID, string sJongmokCode, string sRealType, string sRealData)
        {
            this.sUserID = sUserID;
            this.sJongmokCode = sJongmokCode;
            this.sRealType = sRealType;
            this.sRealData = sRealData;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent : EventArgs
    {
        public string sUserID;

        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sMsg;

        public _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent(string sUserID, string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            this.sUserID = sUserID;
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sMsg = sMsg;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent : EventArgs
    {
        public string sUserID;

        public string sGubun;

        public int nItemCnt;

        public string sFidList;

        public _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent(string sUserID, string sGubun, int nItemCnt, string sFidList)
        {
            this.sUserID = sUserID;
            this.sGubun = sGubun;
            this.nItemCnt = nItemCnt;
            this.sFidList = sFidList;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAEventConnectEvent : EventArgs
    {
        public string sUserID;

        public int nErrCode;

        public _DDBOpenApiWEvents_OnDBOAEventConnectEvent(string sUserID, int nErrCode)
        {
            this.sUserID = sUserID;
            this.nErrCode = nErrCode;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAEventExtendedEvent : EventArgs
    {
        public string sUserID;

        public int nEventType;

        public string sData;

        public _DDBOpenApiWEvents_OnDBOAEventExtendedEvent(string sUserID, int nEventType, string sData)
        {
            this.sUserID = sUserID;
            this.nEventType = nEventType;
            this.sData = sData;
        }
    }
    public class _DDBOpenApiWEvents_OnDBOAEventNotifyEvent : EventArgs
    {
        public string sUserID;

        public string sNotifyType;

        public string sData;

        public _DDBOpenApiWEvents_OnDBOAEventNotifyEvent(string sUserID, string sNotifyType, string sData)
        {
            this.sUserID = sUserID;
            this.sNotifyType = sNotifyType;
            this.sData = sData;
        }
    }
    public delegate void _DDBOpenApiWEvents_OnReceiveTrDataEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveTrDataEvent e);
    public delegate void _DDBOpenApiWEvents_OnReceiveRealDataEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveRealDataEvent e);
    public delegate void _DDBOpenApiWEvents_OnReceiveMsgEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveMsgEvent e);
    public delegate void _DDBOpenApiWEvents_OnReceiveChejanDataEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveChejanDataEvent e);
    public delegate void _DDBOpenApiWEvents_OnEventConnectEventHandler(object sender, _DDBOpenApiWEvents_OnEventConnectEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveTrDataEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveRealDataEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveMsgEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAEventConnectEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAEventExtendedEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAEventExtendedEvent e);
    public delegate void _DDBOpenApiWEvents_OnDBOAEventNotifyEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAEventNotifyEvent e);

    [ClassInterface(ClassInterfaceType.None)]
    public class AxDBOpenApiWEventMulticaster : _DDBOpenApiWEvents
    {
        private AxDBOpenApiW parent;

        public AxDBOpenApiWEventMulticaster(AxDBOpenApiW parent)
        {
            this.parent = parent;
        }

        public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext)
        {
            _DDBOpenApiWEvents_OnReceiveTrDataEvent e = new _DDBOpenApiWEvents_OnReceiveTrDataEvent(sScrNo, sRQName, sTrCode, sRecordName, sPreNext);
            parent.RaiseOnOnReceiveTrData(parent, e);
        }

        public virtual void OnReceiveRealData(string sJongmokCode, string sRealType, string sRealData)
        {
            _DDBOpenApiWEvents_OnReceiveRealDataEvent e = new _DDBOpenApiWEvents_OnReceiveRealDataEvent(sJongmokCode, sRealType, sRealData);
            parent.RaiseOnOnReceiveRealData(parent, e);
        }

        public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            _DDBOpenApiWEvents_OnReceiveMsgEvent e = new _DDBOpenApiWEvents_OnReceiveMsgEvent(sScrNo, sRQName, sTrCode, sMsg);
            parent.RaiseOnOnReceiveMsg(parent, e);
        }

        public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFidList)
        {
            _DDBOpenApiWEvents_OnReceiveChejanDataEvent e = new _DDBOpenApiWEvents_OnReceiveChejanDataEvent(sGubun, nItemCnt, sFidList);
            parent.RaiseOnOnReceiveChejanData(parent, e);
        }

        public virtual void OnEventConnect(int nErrCode)
        {
            _DDBOpenApiWEvents_OnEventConnectEvent e = new _DDBOpenApiWEvents_OnEventConnectEvent(nErrCode);
            parent.RaiseOnOnEventConnect(parent, e);
        }

        public virtual void OnDBOAReceiveTrData(string sUserID, string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext, string sData)
        {
            _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent e = new _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent(sUserID, sScrNo, sRQName, sTrCode, sRecordName, sPreNext, sData);
            parent.RaiseOnOnDBOAReceiveTrData(parent, e);
        }

        public virtual void OnDBOAReceiveRealData(string sUserID, string sJongmokCode, string sRealType, string sRealData)
        {
            _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent e = new _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent(sUserID, sJongmokCode, sRealType, sRealData);
            parent.RaiseOnOnDBOAReceiveRealData(parent, e);
        }

        public virtual void OnDBOAReceiveMsg(string sUserID, string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent e = new _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent(sUserID, sScrNo, sRQName, sTrCode, sMsg);
            parent.RaiseOnOnDBOAReceiveMsg(parent, e);
        }

        public virtual void OnDBOAReceiveChejanData(string sUserID, string sGubun, int nItemCnt, string sFidList)
        {
            _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent e = new _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent(sUserID, sGubun, nItemCnt, sFidList);
            parent.RaiseOnOnDBOAReceiveChejanData(parent, e);
        }

        public virtual void OnDBOAEventConnect(string sUserID, int nErrCode)
        {
            _DDBOpenApiWEvents_OnDBOAEventConnectEvent e = new _DDBOpenApiWEvents_OnDBOAEventConnectEvent(sUserID, nErrCode);
            parent.RaiseOnOnDBOAEventConnect(parent, e);
        }

        public virtual void OnDBOAEventExtended(string sUserID, int nEventType, string sData)
        {
            _DDBOpenApiWEvents_OnDBOAEventExtendedEvent e = new _DDBOpenApiWEvents_OnDBOAEventExtendedEvent(sUserID, nEventType, sData);
            parent.RaiseOnOnDBOAEventExtended(parent, e);
        }

        public virtual void OnDBOAEventNotify(string sUserID, string sNotifyType, string sData)
        {
            _DDBOpenApiWEvents_OnDBOAEventNotifyEvent e = new _DDBOpenApiWEvents_OnDBOAEventNotifyEvent(sUserID, sNotifyType, sData);
            parent.RaiseOnOnDBOAEventNotify(parent, e);
        }
    }

    //[Clsid("{fc13e42d-e584-419a-a54b-402bc213a44b}")]
    public class AxDBOpenApiW
    {
        private readonly _DDBOpenApiW ocx;

        //private AxDBOpenApiWEventMulticaster eventMulticaster;

        //private ConnectionPointCookie cookie;

        public event _DDBOpenApiWEvents_OnReceiveTrDataEventHandler OnReceiveTrData;

        public event _DDBOpenApiWEvents_OnReceiveRealDataEventHandler OnReceiveRealData;

        public event _DDBOpenApiWEvents_OnReceiveMsgEventHandler OnReceiveMsg;

        public event _DDBOpenApiWEvents_OnReceiveChejanDataEventHandler OnReceiveChejanData;

        public event _DDBOpenApiWEvents_OnEventConnectEventHandler OnEventConnect;

        public event _DDBOpenApiWEvents_OnDBOAReceiveTrDataEventHandler OnDBOAReceiveTrData;

        public event _DDBOpenApiWEvents_OnDBOAReceiveRealDataEventHandler OnDBOAReceiveRealData;

        public event _DDBOpenApiWEvents_OnDBOAReceiveMsgEventHandler OnDBOAReceiveMsg;

        public event _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEventHandler OnDBOAReceiveChejanData;

        public event _DDBOpenApiWEvents_OnDBOAEventConnectEventHandler OnDBOAEventConnect;

        public event _DDBOpenApiWEvents_OnDBOAEventExtendedEventHandler OnDBOAEventExtended;

        public event _DDBOpenApiWEvents_OnDBOAEventNotifyEventHandler OnDBOAEventNotify;

        public virtual int CommConnect(int nAutoUpgrade)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommConnect(nAutoUpgrade);
        }

        public virtual int CommRqData(string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
        }

        public virtual void SetInputValue(string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetInputValue(sID, sValue);
        }

        public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
        }

        public virtual void CommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.CommTerminate();
        }

        public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetRepeatCnt(sTrCode, sRecordName);
        }

        public virtual void DisconnectRealData(string sScnNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DisconnectRealData(sScnNo);
        }

        public virtual string GetCommRealData(string strRealType, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRealData(strRealType, nFid);
        }

        public virtual string GetChjanData(int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetChjanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetChjanData(nFid);
        }

        public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStop, string sHogaGb, string sOrgOrderNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStop, sHogaGb, sOrgOrderNo);
        }

        public virtual string GetLoginInfo(string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginInfo(sTag);
        }

        public virtual string GetGlobalFutureItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlist();
        }

        public virtual string GetGlobalOptionItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionItemlist();
        }

        public virtual string GetGlobalFutureCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodelist(sItem);
        }

        public virtual string GetGlobalOptionCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodelist(sItem);
        }

        public virtual int GetConnectState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConnectState();
        }

        public virtual string GetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetAPIModulePath();
        }

        public virtual string GetCommonFunc(string sFuncName, string sParam)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommonFunc", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommonFunc(sFuncName, sParam);
        }

        public virtual string GetConvertPrice(string sCode, string sPrice, int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConvertPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConvertPrice(sCode, sPrice, nType);
        }

        public virtual string GetGlobalFutOpCodeInfoByType(int nGubu, string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByType(nGubu, sType);
        }

        public virtual string GetGlobalFutOpCodeInfoByCode(string sCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByCode(sCode);
        }

        public virtual string GetGlobalFutureItemlistByType(string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlistByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlistByType(sType);
        }

        public virtual string GetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodeByItemMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodeByItemMonth(sItem, sMonth);
        }

        public virtual string GetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActPrice, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodeByMonth(sItem, sCPGubun, sActPrice, sMonth);
        }

        public virtual string GetGlobalOptionMonthByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionMonthByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionMonthByItem(sItem);
        }

        public virtual string GetGlobalOptionActPriceByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionActPriceByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionActPriceByItem(sItem);
        }

        public virtual string GetGlobalFutureItemTypelist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemTypelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemTypelist();
        }

        public virtual string GetCommFullData(string strTrCode, string strRecordName, int nGubun)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommFullData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommFullData(strTrCode, strRecordName, nGubun);
        }

        public virtual int SendOrderWithUserData(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStop, string sHogaGb, string sOrgOrderNo, string sUserData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrderWithUserData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrderWithUserData(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStop, sHogaGb, sOrgOrderNo, sUserData);
        }

        public virtual void SetMultipleUser(int nOn)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetMultipleUser", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetMultipleUser(nOn);
        }

        public virtual int DBOACommRqData(string sUserID, string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOACommRqData(sUserID, sRQName, sTrCode, sPrevNext, sScreenNo);
        }

        public virtual int DBOASetInputValue(string sUserID, string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOASetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOASetInputValue(sUserID, sID, sValue);
        }

        public virtual string DBOAGetCommData(string sUserID, string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetCommData(sUserID, strTrCode, strRecordName, nIndex, strItemName);
        }

        public virtual int DBOAGetRepeatCnt(string sUserID, string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetRepeatCnt(sUserID, sTrCode, sRecordName);
        }

        public virtual int DBOADisconnectRealData(string sUserID, string sScnNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOADisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOADisconnectRealData(sUserID, sScnNo);
        }

        public virtual string DBOAGetCommRealData(string sUserID, string strRealType, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetCommRealData(sUserID, strRealType, nFid);
        }

        public virtual string DBOAGetChjanData(string sUserID, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetChjanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetChjanData(sUserID, nFid);
        }

        public virtual int DBOASendOrder(string sUserID, string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStop, string sHogaGb, string sOrgOrderNo, string sUserData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOASendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOASendOrder(sUserID, sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStop, sHogaGb, sOrgOrderNo, sUserData);
        }

        public virtual string DBOAGetLoginInfo(string sUserID, string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetLoginInfo(sUserID, sTag);
        }

        public virtual int DBOAGetConnectState(string sUserID)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetConnectState(sUserID);
        }

        public virtual string DBOAGetCommFullData(string sUserID, string strTrCode, string strRecordName, int nGubun)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetCommFullData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetCommFullData(sUserID, strTrCode, strRecordName, nGubun);
        }

        public virtual int DBOACommLogin(string sUserID, string sPassword, string sCertPassword, int nDemoOn)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommLogin", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOACommLogin(sUserID, sPassword, sCertPassword, nDemoOn);
        }

        public virtual string DBOAFunctionExtended(string sUserID, int nFuctionType, string sInputData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAFunctionExtended", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAFunctionExtended(sUserID, nFuctionType, sInputData);
        }

        public virtual int DBOACommConnect()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOACommConnect();
        }

        public virtual void DBOACommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DBOACommTerminate();
        }

        public virtual string DBOAGetGlobalFutureItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureItemlist();
        }

        public virtual string DBOAGetGlobalOptionItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionItemlist();
        }

        public virtual string DBOAGetGlobalFutureCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureCodelist(sItem);
        }

        public virtual string DBOAGetGlobalOptionCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionCodelist(sItem);
        }

        public virtual string DBOAGetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetAPIModulePath();
        }

        public virtual string DBOAGetConvertPrice(string sCode, string sPrice, int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetConvertPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetConvertPrice(sCode, sPrice, nType);
        }

        public virtual string DBOAGetGlobalFutOpCodeInfoByType(int nGubu, string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutOpCodeInfoByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutOpCodeInfoByType(nGubu, sType);
        }

        public virtual string DBOAGetGlobalFutOpCodeInfoByCode(string sCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutOpCodeInfoByCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutOpCodeInfoByCode(sCode);
        }

        public virtual string DBOAGetGlobalFutureItemlistByType(string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureItemlistByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureItemlistByType(sType);
        }

        public virtual string DBOAGetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureCodeByItemMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureCodeByItemMonth(sItem, sMonth);
        }

        public virtual string DBOAGetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActPrice, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionCodeByMonth(sItem, sCPGubun, sActPrice, sMonth);
        }

        public virtual string DBOAGetGlobalOptionMonthByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionMonthByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionMonthByItem(sItem);
        }

        public virtual string DBOAGetGlobalOptionActPriceByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionActPriceByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionActPriceByItem(sItem);
        }

        public virtual string DBOAGetGlobalFutureItemTypelist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureItemTypelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureItemTypelist();
        }

        public virtual int DBOASaveAccountPassword(string sUserID, string sAccount, string sPassword)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOASaveAccountPassword", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOASaveAccountPassword(sUserID, sAccount, sPassword);
        }

        //protected override void CreateSink()
        //{
        //    try
        //    {
        //        eventMulticaster = new AxDBOpenApiWEventMulticaster(this);
        //        cookie = new ConnectionPointCookie((object)ocx, (object)eventMulticaster, typeof(_DDBOpenApiWEvents));
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
        //        ocx = (_DDBOpenApiW)((AxHost)this).GetOcx();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        internal void RaiseOnOnReceiveTrData(object sender, _DDBOpenApiWEvents_OnReceiveTrDataEvent e)
        {
            int async_ident_id = AsyncNode.GetIdentId([e.sRQName, e.sTrCode]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is not null)
            {
                _async_list.Remove(async_node);
                async_node._async_tr_action?.Invoke(e);
                async_node._async_wait.Set();
                return;
            }
            OnReceiveTrData?.Invoke(sender, e);
        }

        internal void RaiseOnOnReceiveRealData(object sender, _DDBOpenApiWEvents_OnReceiveRealDataEvent e)
        {
            OnReceiveRealData?.Invoke(sender, e);
        }

        internal void RaiseOnOnReceiveMsg(object sender, _DDBOpenApiWEvents_OnReceiveMsgEvent e)
        {
            OnReceiveMsg?.Invoke(sender, e);
        }

        internal void RaiseOnOnReceiveChejanData(object sender, _DDBOpenApiWEvents_OnReceiveChejanDataEvent e)
        {
            OnReceiveChejanData?.Invoke(sender, e);
        }

        internal void RaiseOnOnEventConnect(object sender, _DDBOpenApiWEvents_OnEventConnectEvent e)
        {
            OnEventConnect?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAReceiveTrData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent e)
        {
            int async_ident_id = AsyncNode.GetIdentId([e.sUserID, e.sRQName, e.sTrCode]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is not null)
            {
                _async_list.Remove(async_node);
                async_node._async_dboa_tr_action?.Invoke(e);
                async_node._async_wait.Set();
                return;
            }
            OnDBOAReceiveTrData?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAReceiveRealData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent e)
        {
            OnDBOAReceiveRealData?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAReceiveMsg(object sender, _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent e)
        {
            OnDBOAReceiveMsg?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAReceiveChejanData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent e)
        {
            OnDBOAReceiveChejanData?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
        {
            OnDBOAEventConnect?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAEventExtended(object sender, _DDBOpenApiWEvents_OnDBOAEventExtendedEvent e)
        {
            OnDBOAEventExtended?.Invoke(sender, e);
        }

        internal void RaiseOnOnDBOAEventNotify(object sender, _DDBOpenApiWEvents_OnDBOAEventNotifyEvent e)
        {
            this.OnDBOAEventNotify?.Invoke(sender, e);
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

        public AxDBOpenApiW(IntPtr hWndParent)
        {
            string clsid = "{fc13e42d-e584-419a-a54b-402bc213a44b}";

            if (AtlAxWinInit())
            {
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9004, IntPtr.Zero, IntPtr.Zero);
                if (hWndContainer != IntPtr.Zero)
                {
                    try
                    {
                        object pUnknown;
                        AtlAxGetControl(hWndContainer, out pUnknown);
                        if (pUnknown != null)
                        {
                            ocx = (_DDBOpenApiW)pUnknown;
                            if (ocx != null)
                            {
                                Guid guidEvents = typeof(_DDBOpenApiWEvents).GUID;
                                System.Runtime.InteropServices.ComTypes.IConnectionPointContainer pConnectionPointContainer;
                                pConnectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)pUnknown;
                                pConnectionPointContainer.FindConnectionPoint(ref guidEvents, out _pConnectionPoint);
                                if (_pConnectionPoint != null)
                                {
                                    AxDBOpenApiWEventMulticaster pEventSink = new AxDBOpenApiWEventMulticaster(this);
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

        #region 비동기 확장함수 추가
        class AsyncNode(string[] strings)
        {
            public readonly int _ident_id = GetIdentId(strings);

            public static int GetIdentId(string[] strings)
            {
                int id = 0;
                for (int i = 0; i < strings.Length; i++)
                {
                    id = id * 31 + StringComparer.Ordinal.GetHashCode(strings[i]);
                }
                return id;
            }

            public readonly ManualResetEvent _async_wait = new(initialState: false);
            public Action<_DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent> _async_dboa_tr_action = null;
            public Action<_DDBOpenApiWEvents_OnReceiveTrDataEvent> _async_tr_action = null;
        }

        List<AsyncNode> _async_list = [];

        public virtual async Task<int> DBOACommRqDataAsync(string sUserID, string sRQName, string sTrCode, string sPrevNext, string sScreenNo, Action<_DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent> action)
        {
            var newAsync = new AsyncNode([sUserID, sRQName, sTrCode])
            {
                _async_dboa_tr_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = DBOACommRqData(sUserID, sRQName, sTrCode, sPrevNext, sScreenNo);
            if (nRet == 0)
            {
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(5000))
                    {
                        // 5초 대기후에도 이벤트가 발생하지 않으면 -902 리턴
                        nRet = -902;
                    }
                });
                await taskAsync.ConfigureAwait(true);
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        public virtual async Task<int> CommRqDataAsync(string sRQName, string sTrCode, string sPrevNext, string sScreenNo, Action<_DDBOpenApiWEvents_OnReceiveTrDataEvent> action)
        {
            var newAsync = new AsyncNode([sRQName, sTrCode])
            {
                _async_tr_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
            if (nRet == 0)
            {
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(5000))
                    {
                        // 5초 대기후에도 이벤트가 발생하지 않으면 -902 리턴
                        nRet = -902;
                    }
                });
                await taskAsync.ConfigureAwait(true);
            }
            _async_list.Remove(newAsync);
            return nRet;
        }

        #endregion
    }

}
