using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DBOpenApiW.NET
{

    [ComImport]
    [InterfaceType(2)]
    [Guid("CC26D710-1FB2-4698-9AD9-86B4FF4CB3C8")]
    internal interface _DDBOpenApiW
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
    internal interface _DDBOpenApiWEvents
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

    /// <summary>서버통신 후 데이터를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext) : EventArgs
    {
        /// <summary>화면번호</summary>
        public string sScrNo = sScrNo;
        /// <summary>사용자구분 명</summary>
        public string sRQName = sRQName;
        /// <summary>Transaction 코드</summary>
        public string sTrCode = sTrCode;
        /// <summary>Record 명</summary>
        public string sRecordName = sRecordName;
        /// <summary>연속조회 키값</summary>
        public string sPreNext = sPreNext;
    }

    /// <summary>실시간데이터를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnReceiveRealDataEvent(string sJongmokCode, string sRealType, string sRealData) : EventArgs
    {
        /// <summary>종목코드</summary>
        public string sJongmokCode = sJongmokCode;
        /// <summary>리얼타입</summary>
        public string sRealType = sRealType;
        /// <summary>실시간 데이터전문</summary>
        public string sRealData = sRealData;
    }

    /// <summary>서버통신 후 메시지를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg) : EventArgs
    {
        /// <summary>화면번호</summary>
        public string sScrNo = sScrNo;
        /// <summary>사용자구분 명</summary>
        public string sRQName = sRQName;
        /// <summary>Tran 명</summary>
        public string sTrCode = sTrCode;
        /// <summary>서버메시지</summary>
        public string sMsg = sMsg;
    }

    /// <summary>체결데이터를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFidList) : EventArgs
    {
        /// <summary>체결구분</summary>
        public string sGubun = sGubun;
        /// <summary>아이템갯수</summary>
        public int nItemCnt = nItemCnt;
        /// <summary>데이터리스트</summary>
        public string sFidList = sFidList;
    }

    /// <summary>서버 접속 관련 이벤트</summary>
    public class _DDBOpenApiWEvents_OnEventConnectEvent(int nErrCode) : EventArgs
    {
        /// <summary>에러 코드</summary>
        public int nErrCode = nErrCode;
    }

    /// <summary>서버통신 후 데이터를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent(string sUserID, string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext, string sData) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>화면번호</summary>
        public string sScrNo = sScrNo;
        /// <summary>사용자구분 명</summary>
        public string sRQName = sRQName;
        /// <summary>Transaction 코드</summary>
        public string sTrCode = sTrCode;
        /// <summary>Record 명</summary>
        public string sRecordName = sRecordName;
        /// <summary>연속조회 키값</summary>
        public string sPreNext = sPreNext;
        /// <summary>수신 전체데이터를 문자값으로 반환한다</summary>
        public string sData = sData;
    }

    /// <summary>실시간데이터를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent(string sUserID, string sJongmokCode, string sRealType, string sRealData) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>종목코드</summary>
        public string sJongmokCode = sJongmokCode;
        /// <summary>리얼타입</summary>
        public string sRealType = sRealType;
        /// <summary>실시간 데이터전문</summary>
        public string sRealData = sRealData;
    }

    /// <summary>서버통신 후 메시지를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent(string sUserID, string sScrNo, string sRQName, string sTrCode, string sMsg) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>화면번호</summary>
        public string sScrNo = sScrNo;
        /// <summary>사용자구분 명</summary>
        public string sRQName = sRQName;
        /// <summary>Tran 명</summary>
        public string sTrCode = sTrCode;
        /// <summary>서버메시지</summary>
        public string sMsg = sMsg;
    }

    /// <summary>체결데이터를 받은 시점을 알려준다.</summary>
    public class _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent(string sUserID, string sGubun, int nItemCnt, string sFidList) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>체결구분</summary>
        public string sGubun = sGubun;
        /// <summary>아이템갯수</summary>
        public int nItemCnt = nItemCnt;
        /// <summary>데이터리스트</summary>
        public string sFidList = sFidList;
    }

    /// <summary>서버 접속 관련 이벤트</summary>
    public class _DDBOpenApiWEvents_OnDBOAEventConnectEvent(string sUserID, int nErrCode) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>에러 코드</summary>
        public int nErrCode = nErrCode;
    }

    /// <summary>추후 추가 제공될 이벤트</summary>
    public class _DDBOpenApiWEvents_OnDBOAEventExtendedEvent(string sUserID, int nEventType, string sData) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>이벤트 타입</summary>
        public int nEventType = nEventType;
        /// <summary>이벤트 타입별 데이터</summary>
        public string sData = sData;
    }

    /// <summary>서버 Notify 관련 이벤트</summary>
    public class _DDBOpenApiWEvents_OnDBOAEventNotifyEvent(string sUserID, string sNotifyType, string sData) : EventArgs
    {
        /// <summary>사용자 ID</summary>
        public string sUserID = sUserID;
        /// <summary>Notify Type</summary>
        public string sNotifyType = sNotifyType;
        /// <summary>Notify 별 데이터</summary>
        public string sData = sData;
    }


    /// <summary>서버통신 후 데이터를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnReceiveTrDataEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveTrDataEvent e);
    /// <summary>실시간데이터를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnReceiveRealDataEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveRealDataEvent e);
    /// <summary>서버통신 후 메시지를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnReceiveMsgEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveMsgEvent e);
    /// <summary>체결데이터를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnReceiveChejanDataEventHandler(object sender, _DDBOpenApiWEvents_OnReceiveChejanDataEvent e);
    /// <summary>서버 접속 관련 이벤트</summary>
    public delegate void _DDBOpenApiWEvents_OnEventConnectEventHandler(object sender, _DDBOpenApiWEvents_OnEventConnectEvent e);
    /// <summary>서버통신 후 데이터를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveTrDataEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent e);
    /// <summary>실시간데이터를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveRealDataEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent e);
    /// <summary>서버통신 후 메시지를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveMsgEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent e);
    /// <summary>체결데이터를 받은 시점을 알려준다.</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent e);
    /// <summary>서버 접속 관련 이벤트</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAEventConnectEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e);
    /// <summary>추후 추가 제공될 이벤트</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAEventExtendedEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAEventExtendedEvent e);
    /// <summary>서버 Notify 관련 이벤트</summary>
    public delegate void _DDBOpenApiWEvents_OnDBOAEventNotifyEventHandler(object sender, _DDBOpenApiWEvents_OnDBOAEventNotifyEvent e);

    [ClassInterface(ClassInterfaceType.None)]
    internal class AxDBOpenApiWEventMulticaster(AxDBOpenApiW parent) : _DDBOpenApiWEvents
    {
        private readonly AxDBOpenApiW parent = parent;

        public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext) => parent.RaiseOnOnReceiveTrData(parent, new(sScrNo, sRQName, sTrCode, sRecordName, sPreNext));

        public virtual void OnReceiveRealData(string sJongmokCode, string sRealType, string sRealData) => parent.RaiseOnOnReceiveRealData(parent, new(sJongmokCode, sRealType, sRealData));

        public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg) => parent.RaiseOnOnReceiveMsg(parent, new(sScrNo, sRQName, sTrCode, sMsg));

        public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFidList) => parent.RaiseOnOnReceiveChejanData(parent, new(sGubun, nItemCnt, sFidList));

        public virtual void OnEventConnect(int nErrCode) => parent.RaiseOnOnEventConnect(parent, new(nErrCode));

        public virtual void OnDBOAReceiveTrData(string sUserID, string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext, string sData) => parent.RaiseOnOnDBOAReceiveTrData(parent, new(sUserID, sScrNo, sRQName, sTrCode, sRecordName, sPreNext, sData));

        public virtual void OnDBOAReceiveRealData(string sUserID, string sJongmokCode, string sRealType, string sRealData) => parent.RaiseOnOnDBOAReceiveRealData(parent, new(sUserID, sJongmokCode, sRealType, sRealData));

        public virtual void OnDBOAReceiveMsg(string sUserID, string sScrNo, string sRQName, string sTrCode, string sMsg) => parent.RaiseOnOnDBOAReceiveMsg(parent, new(sUserID, sScrNo, sRQName, sTrCode, sMsg));

        public virtual void OnDBOAReceiveChejanData(string sUserID, string sGubun, int nItemCnt, string sFidList) => parent.RaiseOnOnDBOAReceiveChejanData(parent, new(sUserID, sGubun, nItemCnt, sFidList));

        public virtual void OnDBOAEventConnect(string sUserID, int nErrCode) => parent.RaiseOnOnDBOAEventConnect(parent, new(sUserID, nErrCode));

        public virtual void OnDBOAEventExtended(string sUserID, int nEventType, string sData) => parent.RaiseOnOnDBOAEventExtended(parent, new(sUserID, nEventType, sData));

        public virtual void OnDBOAEventNotify(string sUserID, string sNotifyType, string sData) => parent.RaiseOnOnDBOAEventNotify(parent, new(sUserID, sNotifyType, sData));
    }

    /// <summary>
    /// OCX Wrapper
    /// </summary>
    public class AxDBOpenApiW
    {
        private readonly _DDBOpenApiW ocx;

        //private AxDBOpenApiWEventMulticaster eventMulticaster;

        //private ConnectionPointCookie cookie;

        /// <summary>서버통신 후 데이터를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnReceiveTrDataEventHandler OnReceiveTrData;
        /// <summary>실시간데이터를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnReceiveRealDataEventHandler OnReceiveRealData;
        /// <summary>서버통신 후 메시지를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnReceiveMsgEventHandler OnReceiveMsg;
        /// <summary>체결데이터를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnReceiveChejanDataEventHandler OnReceiveChejanData;
        /// <summary>서버 접속 관련 이벤트</summary>
        public event _DDBOpenApiWEvents_OnEventConnectEventHandler OnEventConnect;
        /// <summary>서버통신 후 데이터를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnDBOAReceiveTrDataEventHandler OnDBOAReceiveTrData;
        /// <summary>실시간데이터를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnDBOAReceiveRealDataEventHandler OnDBOAReceiveRealData;
        /// <summary>서버통신 후 메시지를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnDBOAReceiveMsgEventHandler OnDBOAReceiveMsg;
        /// <summary>체결데이터를 받은 시점을 알려준다.</summary>
        public event _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEventHandler OnDBOAReceiveChejanData;
        /// <summary>서버 접속 관련 이벤트</summary>
        public event _DDBOpenApiWEvents_OnDBOAEventConnectEventHandler OnDBOAEventConnect;
        /// <summary>추후 추가 제공될 이벤트</summary>
        public event _DDBOpenApiWEvents_OnDBOAEventExtendedEventHandler OnDBOAEventExtended;
        /// <summary>서버 Notify 관련 이벤트</summary>
        public event _DDBOpenApiWEvents_OnDBOAEventNotifyEventHandler OnDBOAEventNotify;

        /// <summary>
        /// 로그인 창을 실행한다.
        /// </summary>
        /// <param name="nAutoUpgrade">버전처리시, 수동 또는 자동 설정을 위한 구분값(0 : 수동진행, 1 : 자동진행)</param>
        /// <returns>0:성공, 이외 값은 실패</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int CommConnect(int nAutoUpgrade)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommConnect(nAutoUpgrade);
        }

        /// <summary>
        /// Transaction Data를 서버로 송신한다.
        /// </summary>
        /// <param name="sRQName">사용자 구분명칭</param>
        /// <param name="sTrCode">Transaction Code</param>
        /// <param name="sPrevNext">서버에서 내려준 Next키값 입력(샘플참조)</param>
        /// <param name="sScreenNo">4자리의 화면번호(1~9999 :숫자값으로만 가능)</param>
        /// <returns>0:성공, 이외 값은 실패</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int CommRqData(string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
        }

        /// <summary>
        /// Transaction Data 입력 값을 서버통신 전에 입력한다.
        /// </summary>
        /// <param name="sID">아이템명</param>
        /// <param name="sValue">입력 값</param>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void SetInputValue(string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetInputValue(sID, sValue);
        }

        /// <summary>
        /// 수신 데이터를 반환한다.
        /// </summary>
        /// <param name="strTrCode">Transaction Code</param>
        /// <param name="strRecordName">레코드명</param>
        /// <param name="nIndex">복수데이터 인덱스</param>
        /// <param name="strItemName">아이템명</param>
        /// <returns>수신 데이터</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
        }

        /// <summary>
        /// OpenAPI의 서버 접속을 해제한다.
        /// </summary>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void CommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.CommTerminate();
        }

        /// <summary>
        /// 레코드 반복횟수를 반환한다.
        /// </summary>
        /// <param name="sTrCode">Transaction Code</param>
        /// <param name="sRecordName">레코드 명</param>
        /// <returns>레코드의 반복횟수</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetRepeatCnt(sTrCode, sRecordName);
        }

        /// <summary>
        /// 화면 내 모든 리얼데이터 요청을 제거한다.
        /// </summary>
        /// <param name="sScnNo">4자리의 화면번호(1~9999 :숫자값으로만 가능)</param>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void DisconnectRealData(string sScnNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DisconnectRealData(sScnNo);
        }

        /// <summary>
        /// 실시간데이터를 반환한다.
        /// </summary>
        /// <param name="strRealType">실시간 구분</param>
        /// <param name="nFid">실시간 아이템</param>
        /// <returns>수신 데이터</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommRealData(string strRealType, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRealData(strRealType, nFid);
        }

        /// <summary>
        /// 체결잔고 데이터를 반환한다.
        /// </summary>
        /// <param name="nFid">체결잔고 아이템</param>
        /// <returns>수신 데이터</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetChjanData(int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetChjanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetChjanData(nFid);
        }

        /// <summary>
        /// 주문을 서버로 전송한다.
        /// </summary>
        /// <param name="sRQName">사용자 구분 요청 명</param>
        /// <param name="sScreenNo">화면번호[4] (1~9999 :숫자값으로만 가능) </param>
        /// <param name="sAccNo">계좌번호</param>
        /// <param name="nOrderType">주문유형 (1:신규매도, 2:신규매수, 3:매도취소, 4:매수취소, 5:매도정정, 6:매수정정)</param>
        /// <param name="sCode">종목코드</param>
        /// <param name="nQty">주문수량</param>
        /// <param name="sPrice">주문단가</param>
        /// <param name="sStop">Stop단가</param>
        /// <param name="sHogaGb">거래구분(1:시장가, 2:지정가, 3:STOP, 4:STOP LIMIT)</param>
        /// <param name="sOrgOrderNo">원주문번호</param>
        /// <returns>에러코드(에러코드표 참고)</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStop, string sHogaGb, string sOrgOrderNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStop, sHogaGb, sOrgOrderNo);
        }

        /// <summary>
        /// 로그인한 사용자 정보를 반환한다.
        /// </summary>
        /// <param name="sTag">사용자 정보 구분 TAG값</param>
        /// <returns>TAG값에 따른 데이터 반환</returns>
        /// <remarks>
        /// sTag에 들어 갈 수 있는 값은 아래와 같음 
        /// "ACCOUNT_CNT" : 전체 계좌 개수를 반환한다.
        /// "ACCNO" : 전체 계좌를 반환한다.계좌별 구분은 ‘;’이다.
        /// "USER_ID" : 사용자 ID를 반환한다.
        /// "USER_NAME" : 사용자명을 반환한다.
        /// 체결가 출력 = OCX.GetLoginInfo("HongGilDong", "ACCOUNT_CNT");.
        /// </remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetLoginInfo(string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginInfo(sTag);
        }

        /// <summary>
        /// 해외선물 상품리스트를 반환한다.
        /// </summary>
        /// <returns>해외선물 상품리스트, 상품간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlist();
        }

        /// <summary>
        /// 해외옵션 상품리스트를 반환한다.
        /// </summary>
        /// <returns>해외옵션 상품리스트, 상품간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionItemlist();
        }

        /// <summary>
        /// 해외상품별 해외선물 종목코드 리스트를 반환한다.
        /// </summary>
        /// <param name="sItem">해외상품</param>
        /// <returns>해외선물 종목코드리스트, 종목간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodelist(sItem);
        }

        /// <summary>
        /// 해외상품별 해외옵션 종목코드 리스트를 반환한다.
        /// </summary>
        /// <param name="sItem">해외상품</param>
        /// <returns>해외옵션 종목코드리스트, 종목간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodelist(sItem);
        }

        /// <summary>
        /// 현재접속상태를 반환한다.
        /// </summary>
        /// <returns>접속상태(0:미연결, 1:연결완료)</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int GetConnectState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConnectState();
        }

        /// <summary>
        /// OpenAPI모듈의 경로를 반환한다.
        /// </summary>
        /// <returns>경로</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetAPIModulePath();
        }

        /// <summary>
        /// 공통함수로 추후 추가함수가 필요시 사용할 함수이다.
        /// </summary>
        /// <param name="sFuncName">함수명</param>
        /// <param name="sParam">입력항목</param>
        /// <returns>함수에 대한 반환값</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommonFunc(string sFuncName, string sParam)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommonFunc", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommonFunc(sFuncName, sParam);
        }

        /// <summary>
        /// 가격 진법에 따라 변환된 가격을 반환한다.
        /// </summary>
        /// <param name="sCode">종목코드</param>
        /// <param name="sPrice">가격</param>
        /// <param name="nType">타입(0 : 진법->10진수, 1 : 10진수->진법)</param>
        /// <returns>문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetConvertPrice(string sCode, string sPrice, int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConvertPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConvertPrice(sCode, sPrice, nType);
        }

        /// <summary>
        /// 해외선물옵션종목코드정보를 타입별로 반환한다.
        /// </summary>
        /// <param name="nGubu">0(해외선물), 1(해외옵션)</param>
        /// <param name="sType">선물 - IDX(지수), CUR(통화), INT(금리), MLT(금속), ENG(에너지), CMD(농산물) 옵션 – 종목코드</param>
        /// <returns>종목코드정보리스트들을 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutOpCodeInfoByType(int nGubu, string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByType(nGubu, sType);
        }

        /// <summary>
        /// 해외선물옵션종목코드정보를 종목코드별로 반환한다.
        /// </summary>
        /// <param name="sCode">해외선물옵션 종목코드 입력</param>
        /// <returns>종목코드정보를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutOpCodeInfoByCode(string sCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByCode(sCode);
        }

        /// <summary>
        /// 해외선물상품리스트를 타입별로 반환한다.
        /// </summary>
        /// <param name="sType">IDX(지수), CUR(통화), INT(금리), MLT(금속), ENG(에너지), CMD(농산물)</param>
        /// <returns>상품리스트를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureItemlistByType(string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlistByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlistByType(sType);
        }

        /// <summary>
        /// 해외선물종목코드를 상품/월물별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <param name="sMonth">월물(ex: "201809")</param>
        /// <returns>종목코드를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodeByItemMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodeByItemMonth(sItem, sMonth);
        }

        /// <summary>
        /// 해외옵션종목코드를 상품/콜풋/행사가/월물별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <param name="sCPGubun">C(콜)/P(풋)</param>
        /// <param name="sActPrice">0.760</param>
        /// <param name="sMonth">"201809"</param>
        /// <returns>종목코드를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActPrice, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodeByMonth(sItem, sCPGubun, sActPrice, sMonth);
        }

        /// <summary>
        /// 해외옵션월물리스트를 상품별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <returns>월물 리스트를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionMonthByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionMonthByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionMonthByItem(sItem);
        }

        /// <summary>
        /// 해외옵션행사가리스트를 상품별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <returns>행사가 리스트를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionActPriceByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionActPriceByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionActPriceByItem(sItem);
        }

        /// <summary>
        /// 해외선물상품타입리스트를 반환한다.
        /// </summary>
        /// <returns>상품타입 리스트를 문자값으로 반환한다. (IDX;CUR;INT;MLT;ENG;CMD;)</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureItemTypelist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemTypelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemTypelist();
        }

        /// <summary>
        /// 수신된 전체데이터를 반환한다.
        /// </summary>
        /// <param name="strTrCode">Transaction 코드 </param>
        /// <param name="strRecordName">레코드명</param>
        /// <param name="nGubun">0 : 전체(싱글+멀티), 1 : 싱글데이타, 2 : 멀티데이타</param>
        /// <returns>수신 전체데이터를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommFullData(string strTrCode, string strRecordName, int nGubun)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommFullData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommFullData(strTrCode, strRecordName, nGubun);
        }

        /// <summary>
        /// 주문을 서버로 전송한다.
        /// </summary>
        /// <param name="sRQName">사용자 구분 요청 명</param>
        /// <param name="sScreenNo">화면번호[4] (1~9999 :숫자값으로만 가능) </param>
        /// <param name="sAccNo">계좌번호</param>
        /// <param name="nOrderType">주문유형 (1:신규매도, 2:신규매수, 3:매도취소, 4:매수취소, 5:매도정정, 6:매수정정)</param>
        /// <param name="sCode">종목코드</param>
        /// <param name="nQty">주문수량</param>
        /// <param name="sPrice">주문단가</param>
        /// <param name="sStop">Stop단가</param>
        /// <param name="sHogaGb">거래구분(1:시장가, 2:지정가, 3:STOP, 4:STOP LIMIT)</param>
        /// <param name="sOrgOrderNo">원주문번호</param>
        /// <param name="sUserData">사용자 데이터</param>
        /// <returns>에러코드(에러코드표 참고)</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int SendOrderWithUserData(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStop, string sHogaGb, string sOrgOrderNo, string sUserData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrderWithUserData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrderWithUserData(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStop, sHogaGb, sOrgOrderNo, sUserData);
        }

        /// <summary>
        /// 멀티유저모드를 설정한다.
        /// </summary>
        /// <param name="nOn">1: 멀티유저(default), 0: 싱글유저</param>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void SetMultipleUser(int nOn)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetMultipleUser", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetMultipleUser(nOn);
        }

        /// <summary>
        /// Transaction Data를 서버로 송신한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sRQName">사용자 구분명칭</param>
        /// <param name="sTrCode">Transaction Code</param>
        /// <param name="sPrevNext">서버에서 내려준 Next키값 입력(샘플참조)</param>
        /// <param name="sScreenNo">4자리의 화면번호(1~9999 :숫자값으로만 가능)</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOACommRqData(string sUserID, string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOACommRqData(sUserID, sRQName, sTrCode, sPrevNext, sScreenNo);
        }

        /// <summary>
        /// Transaction Data 입력 값을 서버통신 전에 입력한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sID">아이템명</param>
        /// <param name="sValue">입력 값</param>
        /// <returns>0:성공, 이외 값은 실패</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOASetInputValue(string sUserID, string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOASetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOASetInputValue(sUserID, sID, sValue);
        }

        /// <summary>
        /// 수신 데이터를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="strTrCode">Transaction Code</param>
        /// <param name="strRecordName">레코드명</param>
        /// <param name="nIndex">복수데이터 인덱스</param>
        /// <param name="strItemName">아이템명</param>
        /// <returns>수신 데이터</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetCommData(string sUserID, string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetCommData(sUserID, strTrCode, strRecordName, nIndex, strItemName);
        }

        /// <summary>
        /// 레코드 반복횟수를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sTrCode">Transaction Code</param>
        /// <param name="sRecordName">레코드 명</param>
        /// <returns>레코드의 반복횟수</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOAGetRepeatCnt(string sUserID, string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetRepeatCnt(sUserID, sTrCode, sRecordName);
        }

        /// <summary>
        /// 화면 내 모든 리얼데이터 요청을 제거한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sScnNo">4자리의 화면번호(1~9999 :숫자값으로만 가능)</param>
        /// <returns>0:성공, 이외 값은 실패</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOADisconnectRealData(string sUserID, string sScnNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOADisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOADisconnectRealData(sUserID, sScnNo);
        }

        /// <summary>
        /// 실시간데이터를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="strRealType">실시간 구분</param>
        /// <param name="nFid">실시간 아이템</param>
        /// <returns>수신 데이터</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetCommRealData(string sUserID, string strRealType, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetCommRealData(sUserID, strRealType, nFid);
        }

        /// <summary>
        /// 체결잔고 데이터를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="nFid">체결잔고 아이템</param>
        /// <returns>수신 데이터</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetChjanData(string sUserID, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetChjanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetChjanData(sUserID, nFid);
        }

        /// <summary>
        /// 주문을 서버로 전송한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sRQName">사용자 구분 요청 명</param>
        /// <param name="sScreenNo">화면번호[4] (1~9999 :숫자값으로만 가능) </param>
        /// <param name="sAccNo">계좌번호</param>
        /// <param name="nOrderType">주문유형 (1:신규매도, 2:신규매수, 3:매도취소, 4:매수취소, 5:매도정정, 6:매수정정)</param>
        /// <param name="sCode">종목코드</param>
        /// <param name="nQty">주문수량</param>
        /// <param name="sPrice">주문단가</param>
        /// <param name="sStop">Stop단가</param>
        /// <param name="sHogaGb">거래구분(1:시장가, 2:지정가, 3:STOP, 4:STOP LIMIT)</param>
        /// <param name="sOrgOrderNo">원주문번호</param>
        /// <param name="sUserData">사용자 데이터</param>
        /// <returns>에러코드(에러코드표 참고)</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOASendOrder(string sUserID, string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStop, string sHogaGb, string sOrgOrderNo, string sUserData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOASendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOASendOrder(sUserID, sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStop, sHogaGb, sOrgOrderNo, sUserData);
        }

        /// <summary>
        /// 로그인한 사용자 정보를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sTag">사용자 정보 구분 TAG값</param>
        /// <returns>TAG값에 따른 데이터 반환</returns>
        /// <remarks>
        /// sTag에 들어 갈 수 있는 값은 아래와 같음 
        /// "ACCOUNT_CNT" : 전체 계좌 개수를 반환한다.
        /// "ACCNO" : 전체 계좌를 반환한다.계좌별 구분은 ‘;’이다.
        /// "USER_ID" : 사용자 ID를 반환한다.
        /// "USER_NAME" : 사용자명을 반환한다.
        /// 체결가 출력 = OCX.DBOA_GetLoginInfo("HongGilDong", "ACCOUNT_CNT");.
        /// </remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetLoginInfo(string sUserID, string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetLoginInfo(sUserID, sTag);
        }

        /// <summary>
        /// 현재접속상태를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <returns>0:미연결, 1:연결완료</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOAGetConnectState(string sUserID)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetConnectState(sUserID);
        }

        /// <summary>
        /// 수신된 전체데이터를 반환한다.
        /// </summary>
        /// <param name="sUserID">사용자 ID</param>
        /// <param name="strTrCode">Transaction 코드</param>
        /// <param name="strRecordName">레코드명</param>
        /// <param name="nGubun">0 : 전체(싱글+멀티), 1 : 싱글데이타, 2 : 멀티데이타</param>
        /// <returns>수신 전체데이터를 문자값으로 반환한다.</returns>
        /// <remarks>모든 조회에 사용 가능하며, 특히 대용량 데이터를 한번에 받아서 처리가능.</remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetCommFullData(string sUserID, string strTrCode, string strRecordName, int nGubun)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetCommFullData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetCommFullData(sUserID, strTrCode, strRecordName, nGubun);
        }

        /// <summary>
        /// 로그인 창없이 로그인을 실행한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sPassword">접속비밀번호</param>
        /// <param name="sCertPassword">공인인증 비밀번호</param>
        /// <param name="nDemoOn">모의거래 여부 : 1-모의거래, 0-실거래</param>
        /// <returns>0:성공, 이외 값은 실패</returns>
        /// <remarks>
        /// 로그인이 성공하거나 실패하는 경우 OnEventConnect 이벤트가 발생하고 
        /// 이벤트의 인자 값으로 로그인 성공 여부를 알 수 있다.
        /// </remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOACommLogin(string sUserID, string sPassword, string sCertPassword, int nDemoOn)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommLogin", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOACommLogin(sUserID, sPassword, sCertPassword, nDemoOn);
        }

        /// <summary>
        /// 추후 추가 함수가 필요시 사용할 함수이다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="nFuctionType">함수 타입</param>
        /// <param name="sInputData">입력데이타</param>
        /// <returns>문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAFunctionExtended(string sUserID, int nFuctionType, string sInputData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAFunctionExtended", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAFunctionExtended(sUserID, nFuctionType, sInputData);
        }

        /// <summary>
        /// 로그인 창을 실행한다.
        /// </summary>
        /// <returns>0:성공, 이외 값은 실패</returns>
        /// <remarks>
        /// 로그인이 성공하거나 실패하는 경우 OnEventConnect 이벤트가 발생하고 
        /// 이벤트의 인자 값으로 로그인 성공 여부를 알 수 있다.
        /// </remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int DBOACommConnect()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOACommConnect();
        }

        /// <summary>
        /// OpenAPI의 서버 접속을 해제한다.
        /// <para>통신 연결 상태는 DBOAGetConnectState 메소드로 알 수 있다.</para>
        /// </summary>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void DBOACommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOACommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DBOACommTerminate();
        }

        /// <summary>
        /// 해외선물 상품리스트를 반환한다.
        /// </summary>
        /// <returns>해외선물 상품리스트, 상품간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutureItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureItemlist();
        }

        /// <summary>
        /// 해외옵션 상품리스트를 반환한다.
        /// </summary>
        /// <returns>해외옵션 상품리스트, 상품간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalOptionItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionItemlist();
        }

        /// <summary>
        /// 해외상품별 해외선물 종목코드 리스트를 반환한다.
        /// </summary>
        /// <param name="sItem">해외상품</param>
        /// <returns>해외선물 종목코드리스트, 종목간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutureCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureCodelist(sItem);
        }

        /// <summary>
        /// 해외상품별 해외옵션 종목코드 리스트를 반환한다.
        /// </summary>
        /// <param name="sItem">해외상품</param>
        /// <returns>해외옵션 종목코드리스트, 종목간 구분은 ‘;’이다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalOptionCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionCodelist(sItem);
        }

        /// <summary>
        /// OpenAPI모듈의 경로를 반환한다.
        /// </summary>
        /// <returns>경로</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetAPIModulePath();
        }

        /// <summary>
        /// 가격 진법에 따라 변환된 가격을 반환한다.
        /// </summary>
        /// <param name="sCode">종목코드</param>
        /// <param name="sPrice">가격</param>
        /// <param name="nType">타입(0 : 진법->10진수, 1 : 10진수->진법)</param>
        /// <returns>문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetConvertPrice(string sCode, string sPrice, int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetConvertPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetConvertPrice(sCode, sPrice, nType);
        }

        /// <summary>
        /// 해외선물옵션종목코드정보를 타입별로 반환한다.
        /// </summary>
        /// <param name="nGubu">0(해외선물), 1(해외옵션)</param>
        /// <param name="sType">선물 - IDX(지수), CUR(통화), INT(금리), MLT(금속), ENG(에너지), CMD(농산물) 옵션 – 종목코드</param>
        /// <returns>종목코드정보리스트들을 문자값으로 반환한다.(아래 종목마스터파일 참조)</returns>
        /// <remarks>전체는 ""으로 보내면 된다.(옵션은 "전체" 제공하지 않음)</remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutOpCodeInfoByType(int nGubu, string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutOpCodeInfoByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutOpCodeInfoByType(nGubu, sType);
        }

        /// <summary>
        /// 해외선물옵션종목코드정보를 종목코드별로 반환한다.
        /// </summary>
        /// <param name="sCode">해외선물옵션 종목코드 입력</param>
        /// <returns>종목코드정보를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutOpCodeInfoByCode(string sCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutOpCodeInfoByCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutOpCodeInfoByCode(sCode);
        }

        /// <summary>
        /// 해외선물상품리스트를 타입별로 반환한다.
        /// </summary>
        /// <param name="sType">IDX(지수), CUR(통화), INT(금리), MLT(금속), ENG(에너지), CMD(농산물)</param>
        /// <returns>상품리스트를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutureItemlistByType(string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureItemlistByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureItemlistByType(sType);
        }

        /// <summary>
        /// 해외선물종목코드를 상품/월물별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <param name="sMonth">"201809"</param>
        /// <returns>종목코드를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureCodeByItemMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureCodeByItemMonth(sItem, sMonth);
        }

        /// <summary>
        /// 해외옵션종목코드를 상품/콜풋/행사가/월물별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <param name="sCPGubun">C(콜)/P(풋)</param>
        /// <param name="sActPrice">0.760</param>
        /// <param name="sMonth">"201809"</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActPrice, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionCodeByMonth(sItem, sCPGubun, sActPrice, sMonth);
        }

        /// <summary>
        /// 해외옵션월물리스트를 상품별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <returns>월물 리스트를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalOptionMonthByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionMonthByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionMonthByItem(sItem);
        }

        /// <summary>
        /// 해외옵션행사가리스트를 상품별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드(6A, ES..)</param>
        /// <returns>행사가 리스트를 문자값으로 반환한다.</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalOptionActPriceByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalOptionActPriceByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalOptionActPriceByItem(sItem);
        }

        /// <summary>
        /// 해외선물상품타입리스트를 반환한다.
        /// </summary>
        /// <returns>상품타입 리스트를 문자값으로 반환한다. (IDX;CUR;INT;MLT;ENG;CMD;)</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string DBOAGetGlobalFutureItemTypelist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DBOAGetGlobalFutureItemTypelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.DBOAGetGlobalFutureItemTypelist();
        }

        /// <summary>
        /// 사용계좌번호의 비밀번호를 저장한다.
        /// </summary>
        /// <param name="sUserID">사용자 ID</param>
        /// <param name="sAccount">계좌번호</param>
        /// <param name="sPassword">계좌비밀번호</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
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
            OnReceiveTrData?.Invoke(this, e);
        }

        internal void RaiseOnOnReceiveRealData(object sender, _DDBOpenApiWEvents_OnReceiveRealDataEvent e)
        {
            OnReceiveRealData?.Invoke(this, e);
        }

        internal void RaiseOnOnReceiveMsg(object sender, _DDBOpenApiWEvents_OnReceiveMsgEvent e)
        {
            OnReceiveMsg?.Invoke(this, e);
        }

        internal void RaiseOnOnReceiveChejanData(object sender, _DDBOpenApiWEvents_OnReceiveChejanDataEvent e)
        {
            OnReceiveChejanData?.Invoke(this, e);
        }

        internal void RaiseOnOnEventConnect(object sender, _DDBOpenApiWEvents_OnEventConnectEvent e)
        {
            OnEventConnect?.Invoke(this, e);
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
            OnDBOAReceiveTrData?.Invoke(this, e);
        }

        internal void RaiseOnOnDBOAReceiveRealData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent e)
        {
            OnDBOAReceiveRealData?.Invoke(this, e);
        }

        internal void RaiseOnOnDBOAReceiveMsg(object sender, _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent e)
        {
            OnDBOAReceiveMsg?.Invoke(this, e);
        }

        internal void RaiseOnOnDBOAReceiveChejanData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent e)
        {
            OnDBOAReceiveChejanData?.Invoke(this, e);
        }

        internal void RaiseOnOnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
        {
            OnDBOAEventConnect?.Invoke(this, e);
        }

        internal void RaiseOnOnDBOAEventExtended(object sender, _DDBOpenApiWEvents_OnDBOAEventExtendedEvent e)
        {
            OnDBOAEventExtended?.Invoke(this, e);
        }

        internal void RaiseOnOnDBOAEventNotify(object sender, _DDBOpenApiWEvents_OnDBOAEventNotifyEvent e)
        {
            OnDBOAEventNotify?.Invoke(this, e);
        }

        internal enum ActiveXInvokeKind
        {
            MethodInvoke,
            PropertyGet,
            PropertySet,
        }
        internal class InvalidActiveXStateException(string name, AxDBOpenApiW.ActiveXInvokeKind kind) : Exception
        {
            private readonly string _name = name;
            private readonly ActiveXInvokeKind _kind = kind;

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
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;

        private readonly IntPtr hWndContainer = IntPtr.Zero;

        private readonly System.Runtime.InteropServices.ComTypes.IConnectionPoint _pConnectionPoint;
        private readonly bool bInitialized = false;
        private int _async_TimeOut = 5000;

        /// <summary>
        /// 비동기 요청시 타임아웃 시간을 설정한다.
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
        /// ActiveX 컨트롤이 생성되었는지 여부를 반환한다.
        /// </summary>
        public bool Created => bInitialized;

        /// <summary>
        /// ActiveX 컨트롤을 생성한다.
        /// </summary>
        /// <param name="hWndParent"></param>
        public AxDBOpenApiW(nint hWndParent = 0)
        {
            if (hWndParent == IntPtr.Zero)
            {
                hWndParent = Process.GetCurrentProcess().MainWindowHandle;
                if (hWndParent == IntPtr.Zero)
                {
                    hWndParent = GetConsoleWindow();
                }
            }

            string clsid = "{fc13e42d-e584-419a-a54b-402bc213a44b}";

            if (AtlAxWinInit())
            {
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9005, IntPtr.Zero, IntPtr.Zero);
                if (hWndContainer != IntPtr.Zero)
                {
                    try
                    {
                        AtlAxGetControl(hWndContainer, out object pUnknown);
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
                                    AxDBOpenApiWEventMulticaster pEventSink = new(this);
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
            public Action<_DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent> _async_dboa_tr_action = null;
            public Action<_DDBOpenApiWEvents_OnReceiveTrDataEvent> _async_tr_action = null;
        }

        readonly List<AsyncNode> _async_list = [];

        /// <summary>
        /// 비동기로 데이터를 요청한다.
        /// </summary>
        /// <param name="sUserID">사용자ID</param>
        /// <param name="sRQName">사용자 구분명칭</param>
        /// <param name="sTrCode">Transaction Code</param>
        /// <param name="sPrevNext">서버에서 내려준 Next키값 입력(샘플참조)</param>
        /// <param name="sScreenNo">4자리의 화면번호(1~9999 :숫자값으로만 가능)</param>
        /// <param name="action">이벤트 콜백 함수</param>
        /// <returns>0:성공, 이외 값은 실패, -902: 타임아웃</returns>
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
        /// 비동기로 데이터를 요청한다.
        /// </summary>
        /// <param name="sRQName">사용자 구분명칭</param>
        /// <param name="sTrCode">Transaction Code</param>
        /// <param name="sPrevNext">서버에서 내려준 Next키값 입력(샘플참조)</param>
        /// <param name="sScreenNo">4자리의 화면번호(1~9999 :숫자값으로만 가능)</param>
        /// <param name="action">이벤트 콜백 함수</param>
        /// <returns>0:성공, 이외 값은 실패, -902: 타임아웃</returns>
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

        #endregion
    }
}
