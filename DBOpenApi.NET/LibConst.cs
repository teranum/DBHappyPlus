namespace DBOpenApi.NET;

/// <summary>
/// 상수 정의
/// </summary>
public static class LibConst
{
    /// <summary>API 서버 주소</summary>
    public const string BaseUrl = "https://openapi.db-fi.com:8443";

    /// <summary>웹소켓 서버 주소(모의투자)</summary>
    public const string WssUrlReal = "wss://openapi.db-fi.com:7070";

    /// <summary>웹소켓 서버 주소(실시간)</summary>
    public const string WssUrlSimulation = "wss://openapi.db-fi.com:17070";

    /// <summary>웹소켓 서버 주소(해외선물옵션 실시간)</summary>
    public const string WssUrlGlobal = "wss://openapi.db-fi.com:7071";

    /// <summary>
    /// TR_GROUP
    /// </summary>
    public enum TR_GROUP
    {
        /// <summary>국내주식주문</summary>
        국내주식주문,
        /// <summary>국내주식시세</summary>
        국내주식시세,
        /// <summary>국내주식시세_실시간</summary>
        국내주식시세_실시간,
        /// <summary>국내선물옵션주문</summary>
        국내선물옵션주문,
        /// <summary>국내선물옵션시세</summary>
        국내선물옵션시세,
        /// <summary>국내선물옵션시세_실시간</summary>
        국내선물옵션시세_실시간,
        /// <summary>국내주식_선물차트</summary>
        국내주식_선물차트,
        /// <summary>해외주식주문</summary>
        해외주식주문,
        /// <summary>해외주식시세</summary>
        해외주식시세,
        /// <summary>해외주식시세_실시간</summary>
        해외주식시세_실시간,
        /// <summary>해외선물옵션주문</summary>
        해외선물옵션주문,
        /// <summary>해외선물옵션시세</summary>
        해외선물옵션시세,
        /// <summary>해외선물옵션시세_실시간</summary>
        해외선물옵션시세_실시간,
        /// <summary>장내채권주문</summary>
        장내채권주문,
        /// <summary>장내채권시세</summary>
        장내채권시세,
        /// <summary>장내채권시세_실시간</summary>
        장내채권시세_실시간,
    };

    /// <summary>
    /// TR 명세
    /// </summary>
    /// <param name="Group">API그럽</param>
    /// <param name="Code">Tr코드</param>
    /// <param name="Desc">Tr설명</param>
    /// <param name="Path">경로URL</param>
    public record TrSpec(TR_GROUP Group, string Code, string Desc, string Path);

    /// <summary>TR 목록</summary>
    public static readonly IList<TrSpec> TrSpecs;


    /// <summary>TR요청 URL</summary>
    public static readonly IDictionary<string, TrSpec> Paths;

    /// <summary>계좌관련 실시간 코드</summary>
    public static readonly IList<string> AccountRealTimes;


    static LibConst()
    {
        TrSpecs = [
            new (TR_GROUP.국내주식주문, "CSPAT00600", "주식종합주문", "/api/v1/trading/kr-stock/order"),
            new (TR_GROUP.국내주식주문, "CSPAT00700", "주식정정주문", "/api/v1/trading/kr-stock/order-revision"),
            new (TR_GROUP.국내주식주문, "CSPAT00800", "주식취소주문", "/api/v1/trading/kr-stock/order-cancel"),
            new (TR_GROUP.국내주식주문, "CSPAQ04800", "체결/미체결조회", "/api/v1/trading/kr-stock/inquiry/transaction-history"),
            new (TR_GROUP.국내주식주문, "CSPBQ00100", "주식주문가능수량조회", "/api/v1/trading/kr-stock/inquiry/able-orderqty"),
            new (TR_GROUP.국내주식주문, "CSPAQ03420", "주식잔고조회", "/api/v1/trading/kr-stock/inquiry/balance"),
            new (TR_GROUP.국내주식주문, "CDPCQ00100", "계좌예수금조회", "/api/v1/trading/kr-stock/inquiry/acnt-deposit"),
            new (TR_GROUP.국내주식주문, "CSPEQ00400", "일자별매매내역", "/api/v1/trading/kr-stock/inquiry/daliy-trade-report"),
            new (TR_GROUP.국내주식주문, "FOCCQ10800", "임의기간수익률집계", "/api/v1/trading/kr-stock/inquiry/rdterm-ernrate"),
            new (TR_GROUP.국내주식주문, "CSPAQ07800", "종목별수익률조회", "/api/v1/trading/kr-stock/inquiry/stock-ernrate"),
            new (TR_GROUP.국내주식주문, "CSPAQ00600", "계좌별신용한도조회", "/api/v1/trading/kr-stock/inquiry/able-crdlimit"),
            new (TR_GROUP.국내주식주문, "CSPAQ09400", "신용상환가능총수량조회", "/api/v1/trading/kr-stock/inquiry/able-crdrepayment"),

            new (TR_GROUP.국내주식시세, "JCODES", "주식종목 조회", "/api/v1/quote/kr-stock/inquiry/stock-ticker"),
            new (TR_GROUP.국내주식시세, "WCODES", "ELW 종목 조회", "/api/v1/quote/kr-stock/inquiry/elw-ticker"),
            new (TR_GROUP.국내주식시세, "PRICE", "현재가조회", "/api/v1/quote/kr-stock/inquiry/price"),
            new (TR_GROUP.국내주식시세, "HOGA", "호가조회", "/api/v1/quote/kr-stock/inquiry/orderbook"),
            new (TR_GROUP.국내주식시세, "CONCLUSION", "시간대별체결조회", "/api/v1/quote/kr-stock/inquiry/hour-price"),
            new (TR_GROUP.국내주식시세, "DAYTRADE", "일별체결조회", "/api/v1/quote/kr-stock/inquiry/daily-price"),
            new (TR_GROUP.국내주식시세, "RANKLIST", "주식조건상승하락조회", "/api/v1/quote/kr-stock/inquiry/rank-list"),

            new (TR_GROUP.국내주식시세_실시간, "IS1", "[실시간]주식주문체결", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "IS0", "[실시간]주식주문접수", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "S01", "[실시간]주식호가", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "S00", "[실시간]주식체결가", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "W01", "[실시간]ELW호가", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "W00", "[실시간]ELW체결", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "U00", "[실시간]업종지수체결가", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "U03", "[실시간]업종지수등락", "/websocket"),
            new (TR_GROUP.국내주식시세_실시간, "U05", "[실시간]업종별투자자", "/websocket"),

            new (TR_GROUP.국내선물옵션주문, "CFOAT00100", "선물옵션 주문", "/api/v1/trading/kr-futureoption/order"),
            new (TR_GROUP.국내선물옵션주문, "CFOAT00200", "선물옵션 정정주문", "/api/v1/trading/kr-futureoption/order-revision"),
            new (TR_GROUP.국내선물옵션주문, "CFOAT00300", "선물옵션 취소주문", "/api/v1/trading/kr-futureoption/order-cancel"),
            new (TR_GROUP.국내선물옵션주문, "CFOAQ04000", "선물옵션 체결조회", "/api/v1/trading/kr-futureoption/inquiry/transaction-history"),
            new (TR_GROUP.국내선물옵션주문, "CFOAQ42400", "선물옵션 주문가능수량", "/api/v1/trading/kr-futureoption/inquiry/able-orderqty"),
            new (TR_GROUP.국내선물옵션주문, "CFOAQ02500", "선물옵션 잔고조회", "/api/v1/trading/kr-futureoption/inquiry/balance"),
            new (TR_GROUP.국내선물옵션주문, "CFOAQ50100", "선물옵션 잔고_평가현황조회", "/api/v1/trading/kr-futureoption/inquiry/balance-evalstatus"),
            new (TR_GROUP.국내선물옵션주문, "CFOAQ02600", "선물옵션 당일실현손익", "/api/v1/trading/kr-futureoption/inquiry/day-rlzpnl"),
            new (TR_GROUP.국내선물옵션주문, "CFOEQ11100", "선물옵션 가정산예탁금 상세", "/api/v1/trading/kr-futureoption/inquiry/deposit-detail"),
            new (TR_GROUP.국내선물옵션주문, "CFOHT00100", "선물옵션 주문 (야간)", "/api/v1/trading/night-futureoption/order"),
            new (TR_GROUP.국내선물옵션주문, "CFOHT00200", "선물옵션 정정주문 (야간)", "/api/v1/trading/night-futureoption/order-revision"),
            new (TR_GROUP.국내선물옵션주문, "CFOHT00300", "선물옵션 취소주문 (야간)", "/api/v1/trading/night-futureoption/order-cancel"),
            new (TR_GROUP.국내선물옵션주문, "CFOHQ04000", "선물옵션 체결조회 (야간)", "/api/v1/trading/night-futureoption/inquiry/cmedt"),
            new (TR_GROUP.국내선물옵션주문, "CFOHQ02500", "선물옵션 잔고조회 (야간)", "/api/v1/trading/night-futureoption/inquiry/balance"),

            new (TR_GROUP.국내선물옵션시세, "FCODES", "선물종목 조회", "/api/v1/quote/kr-futureoption/inquiry/future-ticker"),
            new (TR_GROUP.국내선물옵션시세, "OCODES", "옵션종목 조회", "/api/v1/quote/kr-futureoption/inquiry/option-ticker"),
            new (TR_GROUP.국내선물옵션시세, "FPRICE", "현재가조회", "/api/v1/quote/kr-futureoption/inquiry/price"),
            new (TR_GROUP.국내선물옵션시세, "FHOGA", "호가조회", "/api/v1/quote/kr-futureoption/inquiry/orderbook"),
            new (TR_GROUP.국내선물옵션시세, "FDAYTRADE", "일별체결조회", "/api/v1/quote/kr-futureoption/inquiry/daily-price"),
            new (TR_GROUP.국내선물옵션시세, "FCONCLUSION", "시간대별체결조회", "/api/v1/quote/kr-futureoption/inquiry/hour-price"),

            new (TR_GROUP.국내선물옵션시세_실시간, "IF0", "[실시간]선물옵션주문체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F01", "[실시간]지수선물호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F00", "[실시간]지수선물체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F91", "[실시간]미니지수선물호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F90", "[실시간]미니지수선물체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F71", "[실시간]섹터지수선물호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F70", "[실시간]섹터지수선물체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F21", "[실시간]주식선물호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F20", "[실시간]주식선물체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F11", "[실시간]상품선물호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F10", "[실시간]상품선물체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O01", "[실시간]지수옵션호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O00", "[실시간]지수옵션체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O21", "[실시간]주식옵션호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O20", "[실시간]주식옵션체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O91", "[실시간]미니지수옵션호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O90", "[실시간]미니지수옵션체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "OB1", "[실시간]K200지수위클리옵션호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "OB0", "[실시간]K200지수위클리옵션체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "OA1", "[실시간]KOSDAQ150옵션호가", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "OA0", "[실시간]KOSDAQ150옵션체결", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F40", "[실시간]선물체결(야간)", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "F41", "[실시간]선물호가(야간)", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O30", "[실시간]옵션체결(야간)", "/websocket"),
            new (TR_GROUP.국내선물옵션시세_실시간, "O31", "[실시간]옵션호가(야간)", "/websocket"),

            new (TR_GROUP.국내주식_선물차트, "CHARTTICK", "틱차트조회", "/api/v1/quote/kr-chart/tick"),
            new (TR_GROUP.국내주식_선물차트, "CHARTMIN", "분차트조회", "/api/v1/quote/kr-chart/min"),
            new (TR_GROUP.국내주식_선물차트, "CHARTDAY", "일차트조회", "/api/v1/quote/kr-chart/day"),
            new (TR_GROUP.국내주식_선물차트, "CHARTWEEK", "주차트조회", "/api/v1/quote/kr-chart/week"),
            new (TR_GROUP.국내주식_선물차트, "CHARTMONTH", "월차트조회", "/api/v1/quote/kr-chart/month"),

            new (TR_GROUP.해외주식주문, "CAZCT00100", "해외주식 주문", "/api/v1/trading/overseas-stock/order"),
            new (TR_GROUP.해외주식주문, "CAZCQ00100", "해외주식 체결내역조회", "/api/v1/trading/overseas-stock/inquiry/transaction-history"),
            new (TR_GROUP.해외주식주문, "CAZCQ00400", "해외주식 잔고/증거금 조회", "/api/v1/trading/overseas-stock/inquiry/balance-margin"),
            new (TR_GROUP.해외주식주문, "CAZCQ00200", "해외주식 매매내역 조회", "/api/v1/trading/overseas-stock/inquiry/trading-history"),
            new (TR_GROUP.해외주식주문, "CAZCQ01600", "해외주식 거래내역 조회", "/api/v1/trading/overseas-stock/inquiry/trade-history"),
            new (TR_GROUP.해외주식주문, "CAZCQ01300", "해외주식 주문가능금액 조회", "/api/v1/trading/overseas-stock/inquiry/able-orderqty"),
            new (TR_GROUP.해외주식주문, "CAZCQ00300", "해외주식 실현손익 조회", "/api/v1/trading/overseas-stock/inquiry/day-rlzpnl"),
            new (TR_GROUP.해외주식주문, "CAZCQ01400", "해외주식 예수금상세", "/api/v1/trading/overseas-stock/inquiry/deposit-detail"),
            new (TR_GROUP.해외주식주문, "CAZCQ03400", "해외주식 평균매입단가 조회", "/api/v1/trading/overseas-stock/inquiry/avg-pur-price"),

            new (TR_GROUP.해외주식시세, "FSTKCODES", "해외주식 종목조회", "/api/v1/quote/overseas-stock/inquiry/stock-ticker"),
            new (TR_GROUP.해외주식시세, "FSTKPRICE", "해외주식 현재가조회", "/api/v1/quote/overseas-stock/inquiry/price"),
            new (TR_GROUP.해외주식시세, "FSTKHOGA", "해외주식 호가조회", "/api/v1/quote/overseas-stock/inquiry/orderbook"),
            new (TR_GROUP.해외주식시세, "FSTKCONCLUSION", "해외주식 시간대별체결조회", "/api/v1/quote/overseas-stock/inquiry/hour-price"),
            new (TR_GROUP.해외주식시세, "FSTKCHARTTICK", "해외주식 틱차트조회", "/api/v1/quote/overseas-stock/chart/tick"),
            new (TR_GROUP.해외주식시세, "FSTKCHARTMIN", "해외주식 분차트조회", "/api/v1/quote/overseas-stock/chart/min"),
            new (TR_GROUP.해외주식시세, "FSTKCHARTDAY", "해외주식 일차트조회", "/api/v1/quote/overseas-stock/chart/day"),
            new (TR_GROUP.해외주식시세, "FSTKCHARTWEEK", "해외주식 주차트조회", "/api/v1/quote/overseas-stock/chart/week"),
            new (TR_GROUP.해외주식시세, "FSTKCHARTMONTH", "해외주식 월차트조회", "/api/v1/quote/overseas-stock/chart/month"),

            new (TR_GROUP.해외주식시세_실시간, "IS2", "[실시간]해외주식 주문체결", "/websocket"),
            new (TR_GROUP.해외주식시세_실시간, "V60", "[실시간]해외주식 체결가", "/websocket"),
            new (TR_GROUP.해외주식시세_실시간, "V61", "[실시간]해외주식 호가", "/websocket"),
            new (TR_GROUP.해외주식시세_실시간, "V10", "[실시간]해외주식 지연체결가", "/websocket"),
            new (TR_GROUP.해외주식시세_실시간, "V11", "[실시간]해외주식 지연호가", "/websocket"),

            new (TR_GROUP.해외선물옵션주문, "ph700101o", "해외선물옵션주문", "/api/v1/trading/overseas-futureoption/order"),
            new (TR_GROUP.해외선물옵션주문, "ph700201o", "해외선물옵션정정취소주문", "/api/v1/trading/overseas-futureoption/order-revision"),
            new (TR_GROUP.해외선물옵션주문, "ph710201o", "해외선물옵션주문가능수량조회", "/api/v1/trading/overseas-futureoption/inquiry/able-orderqty"),
            new (TR_GROUP.해외선물옵션주문, "ph800404o", "해외선물옵션상품별증거금조회", "/api/v1/trading/overseas-futureoption/inquiry/product-margin"),
            new (TR_GROUP.해외선물옵션주문, "ph020101o", "해외선물옵션주문내역조회", "/api/v1/trading/overseas-futureoption/inquiry/order-history"),
            new (TR_GROUP.해외선물옵션주문, "ph020301o", "해외선물옵션체결내역조회", "/api/v1/trading/overseas-futureoption/inquiry/transaction-history"),
            new (TR_GROUP.해외선물옵션주문, "ph020201o", "해외선물옵션미체결내역조회", "/api/v1/trading/overseas-futureoption/inquiry/untransaction-history"),
            new (TR_GROUP.해외선물옵션주문, "ph020401o", "해외선물옵션미결제약정조회", "/api/v1/trading/overseas-futureoption/inquiry/open-interest"),
            new (TR_GROUP.해외선물옵션주문, "ph131101o", "해외선물옵션일별미결제약정내역", "/api/v1/trading/overseas-futureoption/inquiry/daily-open-interest"),
            new (TR_GROUP.해외선물옵션주문, "ph131601o", "해외선물옵션예탁잔고현황", "/api/v1/trading/overseas-futureoption/inquiry/balance"),
            new (TR_GROUP.해외선물옵션주문, "ph135102o", "해외선물옵션기간별거래내역조회", "/api/v1/trading/overseas-futureoption/inquiry/term-trade-history"),

            new (TR_GROUP.해외선물옵션시세, "pibo7042", "해외선물옵션호가현재가조회", "/api/v1/quote/overseas-futureoption/inquiry/orderbook-price"),
            new (TR_GROUP.해외선물옵션시세, "pibo7044", "해외선물옵션일자별시세추이", "/api/v1/quote/overseas-futureoption/inquiry/daily-price"),
            new (TR_GROUP.해외선물옵션시세, "pibg7301", "해외선물틱차트조회", "/api/v1/quote/overseas-futureoption/future-chart/tick"),
            new (TR_GROUP.해외선물옵션시세, "pibg7302", "해외선물분차트조회", "/api/v1/quote/overseas-futureoption/future-chart/min"),
            new (TR_GROUP.해외선물옵션시세, "pibg7303", "해외선물일주월차트조회", "/api/v1/quote/overseas-futureoption/future-chart/dwmonth"),
            new (TR_GROUP.해외선물옵션시세, "pibg7401", "해외옵션틱차트조회", "/api/v1/quote/overseas-futureoption/option-chart/tick"),
            new (TR_GROUP.해외선물옵션시세, "pibg7402", "해외옵션분차트조회", "/api/v1/quote/overseas-futureoption/option-chart/min"),
            new (TR_GROUP.해외선물옵션시세, "pibg7403", "해외옵션일주월차트조회", "/api/v1/quote/overseas-futureoption/option-chart/dwmonth"),

            new (TR_GROUP.해외선물옵션시세_실시간, "O", "[실시간]주문체결", "/websocket"),
            new (TR_GROUP.해외선물옵션시세_실시간, "P", "[실시간]잔고", "/websocket"),
            new (TR_GROUP.해외선물옵션시세_실시간, "L01", "[실시간]해외선물호가", "/websocket"),
            new (TR_GROUP.해외선물옵션시세_실시간, "K01", "[실시간]해외선물시세", "/websocket"),
            new (TR_GROUP.해외선물옵션시세_실시간, "K02", "[실시간]해외옵션시세", "/websocket"),
            new (TR_GROUP.해외선물옵션시세_실시간, "L02", "[실시간]해외옵션호가", "/websocket"),

            new (TR_GROUP.장내채권주문, "CSPAT02000", "채권주문", "/api/v1/trading/krx-bond/order"),
            new (TR_GROUP.장내채권주문, "CSPAT02100", "채권정정주문", "/api/v1/trading/krx-bond/order-revision"),
            new (TR_GROUP.장내채권주문, "CSPAT02200", "채권취소주문", "/api/v1/trading/krx-bond/order-cancel"),
            new (TR_GROUP.장내채권주문, "CSPAQ05700", "채권주문체결조회", "/api/v1/trading/krx-bond/inquiry/transaction-history"),
            new (TR_GROUP.장내채권주문, "CSPAQ01200", "채권잔고조회", "/api/v1/trading/krx-bond/inquiry/balance"),
            new (TR_GROUP.장내채권주문, "CSPAQ07900", "채권잔고평가조회", "/api/v1/trading/krx-bond/inquiry/balance-evalstatus"),

            new (TR_GROUP.장내채권시세, "BO_SEARCH", "장내채권 상세검색", "/api/v1/quote/krx-bond/search"),
            new (TR_GROUP.장내채권시세, "BO_SISE", "장내채권 현재가조회", "/api/v1/quote/krx-bond/inquiry/price"),
            new (TR_GROUP.장내채권시세, "BO_HOGA", "장내채권 호가조회", "/api/v1/quote/krx-bond/inquiry/orderbook"),

            new (TR_GROUP.장내채권시세_실시간, "B00", "[실시간]일반채권체결", "/websocket"),
            new (TR_GROUP.장내채권시세_실시간, "B01", "[실시간]일반채권호가", "/websocket"),
            new (TR_GROUP.장내채권시세_실시간, "B10", "[실시간]소액채권체결", "/websocket"),
            new (TR_GROUP.장내채권시세_실시간, "B11", "[실시간]소액채권호가", "/websocket"),
            ];

        Paths = new Dictionary<string, TrSpec>();
        foreach (var tr in TrSpecs)
        {
            Paths[tr.Code] = tr;
        }

        AccountRealTimes = [
            "IS1", // [실시간]주식 주문체결
            "IS0", // [실시간]주식 주문접수
            "IF0", // [실시간]선물옵션 주문체결
            "IS2", // [실시간]해외주식 주문체결
            "O", // [실시간]해외선물옵션 주문체결
            "P", // [실시간]해외선물옵션 잔고
            ];
    }
}
