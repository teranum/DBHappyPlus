using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


#if !NETCOREAPP
namespace System.Runtime.CompilerServices { internal class IsExternalInit { } }
#endif

#pragma warning disable CS1591

namespace DBCommAgent.NET
{
    public class DBCommAgentApi
    {
        private readonly AxDBCommAgent _axApi;
        private string _user_id;
        public DBCommAgentApi(nint Handle)
        {
            _user_id = string.Empty;
            _axApi = new(Handle);
            _axApi.OnAgentEventHandler += AxApi_OnAgentEventHandler;
            _axApi.OnGetFidData += AxApi_OnGetFidData;
            _axApi.OnGetTranData += AxApi_OnGetTranData;
            _axApi.OnGetRealData += AxApi_OnGetRealData;

            if (_axApi.Created)
            {
                string folder = _axApi.GetApiAgentModulePath();
                ModelHelper.LoadResFolder(folder + "\\res");
            }
        }

        public AxDBCommAgent AxApi => _axApi;
        public bool IsCreated => _axApi.Created;
        public bool IsSimulation { get; private set; }
        public bool IsLogined { get; private set; }
        public int LastCode { get; private set; }
        public string LastMessage { get; private set; }

        private void AxApi_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
        {
            Debug.WriteLine($"OnAgentEventHandler: nEventType={e.nEventType}, nParam={e.nParam}, strParam={e.strParam}");
        }

        private void AxApi_OnGetRealData(object sender, _DDBCommAgentEvents_OnGetRealDataEvent e)
        {
            throw new NotImplementedException();
        }

        private void AxApi_OnGetTranData(object sender, _DDBCommAgentEvents_OnGetTranDataEvent e)
        {
            throw new NotImplementedException();
        }

        private void AxApi_OnGetFidData(object sender, _DDBCommAgentEvents_OnGetFidDataEvent e)
        {
            throw new NotImplementedException();
        }

        public bool Login(string UserId, string Password, string CertPwd)
        {
            if (!IsCreated)
            {
                LastMessage = "Api가 설치되어 있지 않습니다";
                return false;
            }

            _axApi.SetOffAgentMessageBox(1);

            IsLogined = _axApi.GetLoginState() == 1;
            if (IsLogined)
            {
                LastMessage = "이미 로그인 되었습니다";
                return true;
            }

            IsSimulation = CertPwd.Length == 0;
            _axApi.SetLoginMode(0, IsSimulation ? 1 : 0); // 로그인모드설정: 0:실거래 1:모의투자

            // 통신 초기화
            if (0 > _axApi.CommInit())
            {
                LastMessage = "통신초기화 실패";
                return false;
            }

            // 로그인
            if (1 != _axApi.CommLogin(UserId, Password, CertPwd))
            {
                LastMessage = "로그인 요청실패";
                _axApi.CommTerminate(1);
                return false;
            }

            IsLogined = _axApi.GetLoginState() == 1;
            if (!IsLogined)
            {
                LastMessage = "로그인 실패";
                _axApi.CommTerminate(1);
                return false;
            }

            _user_id = UserId;

            LastMessage = "로그인 성공";
            return true;
        }

        public void Logout()
        {
            if (IsLogined)
            {
                _axApi.AllUnRegisterReal();
                _axApi.CommLogout(_user_id);
                _axApi.CommTerminate(1);
                IsLogined = false;
            }
        }

        public string GetEncrpyt(string inputPwd) => _axApi.GetEncrpyt(inputPwd);

        List<AccountInfo> _accounts = [];
        public async Task<IList<AccountInfo>> GetAccountsAsync()
        {
            if (_accounts.Count != 0)
            {
                return _accounts;
            }

            // Tran조회: MCJDD20016: API승인계좌내역조회
            var InData = new Dictionary<string, object>(StringComparer.Ordinal);
            InData["cmd"] = "X";        // CMD (X)
            InData["userid"] = _user_id;      // 고객ID
            InData["gb"] = "H";        // 사용자 구분
            InData["clntno"] = _axApi.GetLinkTagData("USER_NO");         // 고객번호
            var recvData = await GetTRDataAsync("MCMAM08102", InData);
            if (recvData is null || recvData.Count < 2)
            {
                return [];
            }
            var outblock2 = recvData[1].OutDatas;
            for (int i = 0; i < outblock2.Length; i++)
            {
                var strings = outblock2[i];
                _accounts.Add(new()
                {
                    계좌번호 = strings[1].Trim(),
                    계좌명 = strings[2].Trim(),
                    상품유형코드 = strings[4].Trim(),
                    상품상세코드 = strings[6].Trim(),
                    상품상세코드명 = strings[7].Trim(),

                    비밀번호 = IsSimulation ? "0000" : string.Empty,
                });
            }

            return _accounts;
        }

        public async Task<MasterInfo[]> GetMarketInfoAsync(GroupKind groupKind)
        {
            // 단축코드, 표준종목코드, 한글종목명, <시장구분, 거래승수>, 기준가, 전일거래량
            // 1: 단축코드, 2: 표준종목코드, 3: 한글종목명,     16: 기준가, 28: 전일거래량
            // 827: 시장구분, 19: 시가총액, 2615: 권리 유형 구분 코드('C':콜 'E':기타 'P':풋)
            // 1773: 거래승수, 1373: ATM구분코드 ( 1:ATM 2:ITM 3:OTM ), 1877: 기초자산코드
            // 1449: 콜풋구분( 2: 콜, 3: 풋 )
            string 입력조건시장분류코드 = 시장분류코드[(int)groupKind];
            (string GID, string ReqCodes) = groupKind switch
            {
                GroupKind.주식 => ("1199", "1,2,3,827,19,16,28"),
                GroupKind.업종 => ("1298", "1,2,3,827,19,16,28"),
                GroupKind.ELW => ("1399", "1,2,3,2615,19,16,28"),

                GroupKind.지수선물 => ("1499", "1,2,3,1877,1773,16,28"),
                GroupKind.주식선물 => ("1499", "1,2,3,1877,1773,16,28"),
                GroupKind.야간선물 => ("1499", "1,2,3,1877,1773,16,28"),
                GroupKind.미니선물 => ("1499", "1,2,3,1877,1773,16,28"),
                GroupKind.상품선물 => ("1499", "1,2,3,1877,1773,16,28"),
                GroupKind.유로스톡스50 => ("1499", "1,2,3,1877,1773,16,28"),


                GroupKind.주식옵션 => ("1899", "1,2,3,1449,1773,16,28"),
                GroupKind.지수옵션 => ("1899", "1,2,3,1373,1773,16,28"),
                GroupKind.위클리옵션 => ("1899", "1,2,3,1373,1773,16,28"),
                GroupKind.코스닥150옵션 => ("1899", "1,2,3,1373,1773,16,28"),
                GroupKind.야간옵션 => ("1899", "1,2,3,1373,1773,16,28"),
                GroupKind.미니옵션 => ("1899", "1,2,3,1373,1773,16,28"),
                GroupKind.상품옵션 => ("1899", "1,2,3,1373,1773,16,28"),

                _ => throw new ArgumentException("정의되지 않았습니다.", nameof(groupKind)),
            };
            var OutRec = await GetFIDDataArrayAsync([new("9001", 입력조건시장분류코드), new("GID", GID)], ReqCodes, 9000);
            if (OutRec == null) return [];
            int item_count = OutRec.OutDatas.Length;
            var item_infos = new MasterInfo[item_count];
            for (int i = 0; i < item_count; i++)
            {
                var strings = OutRec.OutDatas[i];
                item_infos[i] = new()
                {
                    단축코드 = strings[0],
                    표준종목코드 = strings[1],
                    한글종목명 = strings[2],
                    시장구분 = strings[3],
                    거래승수 = double.Parse(strings[4]), // 시가총액
                    기준가 = double.Parse(strings[5]),
                    전일거래량 = double.Parse(strings[6]),
                };
            }
            return item_infos;
        }

        public async Task<SiseInfo> GetSiseInfoAsync(GroupKind groupKind, string symbol)
        {
            string 입력조건시장분류코드 = 시장분류코드[(int)groupKind];
            string ReqCodes = "13,14,15,4,11,16,28,29,30,31,32,33,39,40,41,42,43,63,64,65,66,67,73,74,75,76,77,151,152,153,154,155,161,162,163,164,165";
            var OutRec = await GetFIDDataAsync([new("9001", 입력조건시장분류코드), new("9002", symbol), new("GID", "1000")], ReqCodes);
            if (OutRec == null || OutRec.OutDatas.Length < 1) return null;

            var strings = OutRec.OutDatas[0];
            if (strings.Length < 37 || strings[0].Length == 0) return null;
            var sise_info = new SiseInfo()
            {
                시가 = double.Parse(strings[0]),
                고가 = double.Parse(strings[1]),
                저가 = double.Parse(strings[2]),
                현재가 = double.Parse(strings[3]),
                거래량 = double.Parse(strings[4]),
                기준가 = double.Parse(strings[5]),
                전일거래량 = double.Parse(strings[6]),

                매도1호가 = double.Parse(strings[7]),
                매도2호가 = double.Parse(strings[8]),
                매도3호가 = double.Parse(strings[9]),
                매도4호가 = double.Parse(strings[10]),
                매도5호가 = double.Parse(strings[11]),
                매수1호가 = double.Parse(strings[12]),
                매수2호가 = double.Parse(strings[13]),
                매수3호가 = double.Parse(strings[14]),
                매수4호가 = double.Parse(strings[15]),
                매수5호가 = double.Parse(strings[16]),
                매도호가잔량1 = int.Parse(strings[17]),
                매도호가잔량2 = int.Parse(strings[18]),
                매도호가잔량3 = int.Parse(strings[19]),
                매도호가잔량4 = int.Parse(strings[20]),
                매도호가잔량5 = int.Parse(strings[21]),
                매수호가잔량1 = int.Parse(strings[22]),
                매수호가잔량2 = int.Parse(strings[23]),
                매수호가잔량3 = int.Parse(strings[24]),
                매수호가잔량4 = int.Parse(strings[25]),
                매수호가잔량5 = int.Parse(strings[26]),
                매도호가잔량증감1 = int.Parse(strings[27]),
                매도호가잔량증감2 = int.Parse(strings[28]),
                매도호가잔량증감3 = int.Parse(strings[29]),
                매도호가잔량증감4 = int.Parse(strings[30]),
                매도호가잔량증감5 = int.Parse(strings[31]),
                매수호가잔량증감1 = int.Parse(strings[32]),
                매수호가잔량증감2 = int.Parse(strings[33]),
                매수호가잔량증감3 = int.Parse(strings[34]),
                매수호가잔량증감4 = int.Parse(strings[35]),
                매수호가잔량증감5 = int.Parse(strings[36]),

            };
            return sise_info;
        }

        public async Task<IList<DayTradeInfo>> GetDayTradeInfoAsync(GroupKind groupKind, string symbol, int count = 9999)
        {
            string 입력조건시장분류코드 = 시장분류코드[(int)groupKind];
            string ReqCodes = "8,4,5,988,989";
            var OutRec = await GetFIDDataArrayAsync([new("9001", 입력조건시장분류코드), new("9002", symbol), new("GID", "1001")], ReqCodes, count);
            if (OutRec == null || OutRec.OutDatas.Length < 1) return null;

            int item_count = OutRec.OutDatas.Length;
            var dayTrade_infos = new DayTradeInfo[item_count];
            for (int i = 0; i < item_count; i++)
            {
                var strings = OutRec.OutDatas[i];
                dayTrade_infos[i] = new()
                {
                    시간 = int.Parse(strings[0]),
                    현재가 = double.Parse(strings[1]),
                    전일대비 = double.Parse(strings[2]),
                    매수체결량 = strings[3].Length == 0 ? 0 : int.Parse(strings[3]),
                    매도체결량 = strings[4].Length == 0 ? 0 : int.Parse(strings[4]),
                };
            }
            return dayTrade_infos;
        }

        public async Task<OutRecData> GetPortfolioAsync(GroupKind groupKind, string[] symbols, string strOutputFidList)
        {
            string 입력조건시장분류코드 = 시장분류코드[(int)groupKind];
            var symbolMarekets = symbols.Select(x => new KeyValuePair<string, string>(x, 입력조건시장분류코드));
            return await GetPortfolioAsync(symbolMarekets, strOutputFidList);
        }

        public async Task<OutRecData> GetPortfolioAsync(IEnumerable<KeyValuePair<string, string>> symbolMarekets, string strOutputFidList)
        {
            OutRecData OutRec = null;
            int nReturn = await _axApi.RequestPortfolioAsync(symbolMarekets, strOutputFidList, "9999",
                (ov, e) =>
                {
                    int.TryParse(ov.MsgCode, out int nMsgCode);
                    LastCode = nMsgCode;
                    LastMessage = ov.Msg;
                    var FieldInfos = strOutputFidList.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(s => new FieldInfo() { CAPTION = s, }).ToList();

                    int nRowCnt = _axApi.GetFidOutputRowCnt(e.nRequestId);
                    if (nRowCnt > 0)
                    {
                        var datas = _axApi.ParseFidBlockArray(nRowCnt, e.pBlock);
                        OutRec = new()
                        {
                            RecName = "FID",
                            FieldInfos = FieldInfos,
                            OutDatas = datas,
                        };
                    }
                }
                );
            if (nReturn < 0)
            {
                LastCode = nReturn;
                LastMessage = $"RequestTranAsync failed({nReturn}): {_axApi.GetLastErrMsg()}";
                return null;
            }
            return OutRec;
        }

        public async Task<CandleData[]> GetCandleDataAsync(GroupKind groupKind, string symbol, CandleRoundType candleRoundType, int interval, int reqCount)
        {
            string 입력조건시장분류코드 = groupKind switch
            {
                GroupKind.주식 => "J",
                GroupKind.업종 => "U",
                GroupKind.ELW => "W",
                GroupKind.지수선물 => "F",
                GroupKind.지수옵션 => "O",
                GroupKind.주식선물 => "JF",
                GroupKind.주식옵션 => "JO",
                GroupKind.야간선물 => "CM",
                _ => throw new ArgumentException("정의되지 않았습니다.", nameof(groupKind)),
            };
            IList<KeyValuePair<string, object>> InDatas =
            [
                new KeyValuePair<string, object>("9001", 입력조건시장분류코드),
                new KeyValuePair<string, object>("9002", symbol),
                new KeyValuePair<string, object>("9034", "00000000"/*DateTime.Today.ToString("yyyyMMdd")*/),
                new KeyValuePair<string, object>("9035", DateTime.Today.ToString("yyyyMMdd")),
            ];

            if (candleRoundType == CandleRoundType.틱)
            {
                InDatas.Add(new("9119", interval.ToString()));
                InDatas.Add(new("GID", "1002"));
            }
            else if (candleRoundType == CandleRoundType.분)
            {
                InDatas.Add(new("9119", (60 * interval).ToString()));
                InDatas.Add(new("GID", "1005"));
            }
            else if (candleRoundType == CandleRoundType.일)
            {
                InDatas.Add(new("9011", "W"));
                InDatas.Add(new("GID", "1007"));
            }
            else if (candleRoundType == CandleRoundType.주)
            {
                InDatas.Add(new("9011", "W"));
                InDatas.Add(new("GID", "1009"));
            }
            else if (candleRoundType == CandleRoundType.월)
            {
                InDatas.Add(new("9011", "M"));
                InDatas.Add(new("GID", "1009"));
            }

            string strInputFidList;
            if (candleRoundType < CandleRoundType.일)
            {
                strInputFidList = "9,8,13,14,15,4,83"; // 9:일자, 8:시간, 13:시가, 14:고가, 15:저가, 4:종가, 83:거래량
            }
            else
            {
                strInputFidList = "9,8,13,14,15,4,11"; // 9:일자, 8:시간, 13:시가, 14:고가, 15:저가, 4:종가, 11:거래량
            }

            var OutRec = await GetFIDDataArrayAsync(InDatas, strInputFidList, reqCount);
            if (OutRec == null || OutRec.OutDatas.Length < 1) return null;

            int item_count = OutRec.OutDatas.Length;
            var candles = new CandleData[item_count];
            for (int i = 0; i < item_count; i++)
            {
                var strings = OutRec.OutDatas[i];
                candles[i] = new()
                {
                    일자 = int.Parse(strings[0]),
                    시간 = strings[1].Length == 0 ? 0 : int.Parse(strings[1]),
                    시가 = double.Parse(strings[2]),
                    고가 = double.Parse(strings[3]),
                    저가 = double.Parse(strings[4]),
                    종가 = double.Parse(strings[5]),
                    거래량 = strings[6].Length == 0 ? 0 : double.Parse(strings[6]),
                };
            }
            return candles;
        }

        public async Task<IList<OutRecData>> GetTRDataAsync(string strTrCode, IEnumerable<KeyValuePair<string, object>> InDatas
            , int Count = 9999, string ScreenNumber = "9999")
        {
            var resInfo = ModelHelper.GetResInfo(strTrCode);
            if (resInfo is null) return null;

            if (resInfo.InRecs.Count == 0) return null;
            IList<OutRecData> list = [];
            if (resInfo.IS_TRAN)
            {
                int nReturn = await _axApi.RequestTranAsync(resInfo.InRecs[0].REC_NAME, InDatas, strTrCode, "N", "0", "", ScreenNumber, "Q", Count,
                    (ov, e) =>
                    {
                        int.TryParse(ov.MsgCode, out int nMsgCode);
                        LastCode = nMsgCode;
                        LastMessage = ov.Msg;

                        foreach (var outrec in resInfo.OutRecs)
                        {
                            int nRowCnt = _axApi.GetTranOutputRowCnt(strTrCode, outrec.REC_NAME);
                            string[][] OutDatas = new string[nRowCnt][];
                            for (int nRow = 0; nRow < nRowCnt; nRow++)
                            {
                                string[] fileds = new string[outrec.Fields.Count];
                                for (int nCol = 0; nCol < outrec.Fields.Count; nCol++)
                                {
                                    var field = outrec.Fields[nCol];
                                    var value = _axApi.GetTranOutputData(strTrCode, outrec.REC_NAME, field.ITEM, nRow).Trim();
                                    fileds[nCol] = value;
                                }
                                OutDatas[nRow] = fileds;
                            }
                            OutRecData new_outData = new()
                            {
                                RecName = outrec.REC_NAME,
                                FieldInfos = outrec.Fields,
                                OutDatas = OutDatas,
                            };
                            list.Add(new_outData);
                        }
                    }
                    );
                if (nReturn < 0)
                {
                    LastCode = nReturn;
                    LastMessage = $"RequestTranAsync failed({nReturn}): {_axApi.GetLastErrMsg()}";
                    return null;
                }

                return list;
            }
            else
            {
                // is FID
                string strOutputFidList = string.Join(",", resInfo.OutRecs[0].Fields.Select(x => x.ITEM));
                int nReturn = await _axApi.RequestFidArrayAsync(InDatas, resInfo.OutRecs[0].REC_NAME, strOutputFidList, "0", "", ScreenNumber, Count,
                    (ov, e) =>
                    {
                        int.TryParse(ov.MsgCode, out int nMsgCode);
                        LastCode = nMsgCode;
                        LastMessage = ov.Msg;

                        var outrec = resInfo.OutRecs[0];

                        int nRowCnt = _axApi.GetFidOutputRowCnt(e.nRequestId);
                        if (nRowCnt > 0)
                        {
                            var datas = _axApi.ParseFidBlockArray(nRowCnt, e.pBlock);
                            OutRecData new_outData = new()
                            {
                                RecName = outrec.REC_NAME,
                                FieldInfos = outrec.Fields,
                                OutDatas = datas,
                            };
                            list.Add(new_outData);
                        }

                        // 메모리 블럭에서 데이터를 읽어온다.
                        //var commRecvData = _axApi.GetCommFidDataBlock(); // 콜백함수에서만 사용가능
                        //int nRowCnt = commRecvData.Rows;
                        //string[][] OutDatas = new string[nRowCnt][];
                        //for (int i = 0; i < commRecvData.Rows; i++)
                        //{
                        //    string[] fileds = new string[commRecvData.Cols];
                        //    for (int nCol = 0; nCol < commRecvData.Cols; nCol++)
                        //    {
                        //        fileds[nCol] = commRecvData[i, nCol];
                        //    }
                        //    OutDatas[i] = fileds;
                        //}
                        //OutRecData new_outData = new()
                        //{
                        //    RecName = outrec.REC_NAME,
                        //    FieldInfos = outrec.Fields,
                        //    OutDatas = OutDatas,
                        //};
                        //list.Add(new_outData);
                    }
                    );
                if (nReturn < 0)
                {
                    LastCode = nReturn;
                    LastMessage = $"RequestTranAsync failed({nReturn}): {_axApi.GetLastErrMsg()}";
                    return null;
                }

                return list;
            }
        }

        protected async Task<OutRecData> GetFIDDataAsync(IEnumerable<KeyValuePair<string, object>> InDatas, string strOutputFidList, string ScreenNumber = "9999")
        {
            OutRecData outRecData = null;
            int nReturn = await _axApi.RequestFidAsync(InDatas, string.Empty, strOutputFidList, ScreenNumber,
                (ov, e) =>
                {
                    int.TryParse(ov.MsgCode, out int nMsgCode);
                    LastCode = nMsgCode;
                    LastMessage = ov.Msg;
                    var FieldInfos = strOutputFidList.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(s => new FieldInfo() { CAPTION = s, }).ToList();

                    int nRowCnt = _axApi.GetFidOutputRowCnt(e.nRequestId);
                    if (nRowCnt > 0)
                    {
                        var datas = _axApi.ParseFidBlockArray(nRowCnt, e.pBlock);
                        outRecData = new()
                        {
                            RecName = "FID",
                            FieldInfos = FieldInfos,
                            OutDatas = datas,
                        };
                    }
                }
                );
            if (nReturn < 0)
            {
                LastCode = nReturn;
                LastMessage = $"RequestTranAsync failed({nReturn}): {_axApi.GetLastErrMsg()}";
                return null;
            }

            return outRecData;
        }

        protected async Task<OutRecData> GetFIDDataArrayAsync(IEnumerable<KeyValuePair<string, object>> InDatas, string strOutputFidList, int nRequestCount, string ScreenNumber = "9999")
        {
            OutRecData outRecData = null;
            int nReturn = await _axApi.RequestFidArrayAsync(InDatas, string.Empty, strOutputFidList, "0", "", ScreenNumber, nRequestCount,
                (ov, e) =>
                {
                    int.TryParse(ov.MsgCode, out int nMsgCode);
                    LastCode = nMsgCode;
                    LastMessage = ov.Msg;
                    var FieldInfos = strOutputFidList.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(s => new FieldInfo() { CAPTION = s, }).ToList();

                    int nRowCnt = _axApi.GetFidOutputRowCnt(e.nRequestId);
                    if (nRowCnt > 0)
                    {
                        var datas = _axApi.ParseFidBlockArray(nRowCnt, e.pBlock);
                        outRecData = new()
                        {
                            RecName = "FID",
                            FieldInfos = FieldInfos,
                            OutDatas = datas,
                        };
                    }
                    //var commRecvData = _axApi.GetCommFidDataBlock(); // 콜백함수에서만 사용가능
                    //int nRowCnt = commRecvData.Rows;
                    //string[][] OutDatas = new string[nRowCnt][];
                    //for (int i = 0; i < commRecvData.Rows; i++)
                    //{
                    //    string[] fileds = new string[commRecvData.Cols];
                    //    for (int nCol = 0; nCol < commRecvData.Cols; nCol++)
                    //    {
                    //        fileds[nCol] = commRecvData[i, nCol];
                    //    }
                    //    OutDatas[i] = fileds;
                    //}

                    //outRecData = new()
                    //{
                    //    RecName = "FID",
                    //    FieldInfos = FieldInfos,
                    //    OutDatas = OutDatas,
                    //};
                }
                );
            if (nReturn < 0)
            {
                LastCode = nReturn;
                LastMessage = $"RequestTranAsync failed({nReturn}): {_axApi.GetLastErrMsg()}";
                return null;
            }

            return outRecData;
        }

        public string[] 시장분류코드 { get; } =
            [
            "J", "U", "W", "F",
            "O", "JF", "JO", "CM",
            "WO", "SO", "EU", "EF",
            "KF", "KO", "CF", "CO",
            ];
    }

    public enum GroupKind
    {
        주식,
        업종,
        ELW,
        지수선물,

        지수옵션,
        주식선물,
        주식옵션,
        야간선물,

        // 기타
        위클리옵션,
        코스닥150옵션,
        야간옵션,
        유로스톡스50,

        미니선물,
        미니옵션,
        상품선물,
        상품옵션,
    }

    public class OutRecData
    {
        public string RecName { get; set; }
        public IList<FieldInfo> FieldInfos { get; set; }
        public string[][] OutDatas { get; set; }
    }

    public class AccountInfo
    {
        public string 계좌번호 { get; init; }
        public string 계좌명 { get; init; }

        /// <summary>
        /// 01: 종합매매, 03: 선물옵션, 04: 해외선물옵션
        /// </summary>
        public string 상품유형코드 { get; init; }
        public string 상품상세코드 { get; init; }
        public string 상품상세코드명 { get; init; }

        public string 비밀번호 { get; set; }
    }

    public class MasterInfo
    {
        public string 단축코드 { get; set; }
        public string 표준종목코드 { get; set; }
        public string 한글종목명 { get; set; }
        public string 시장구분 { get; set; }
        public double 거래승수 { get; set; }
        public double 기준가 { get; set; }
        public double 전일거래량 { get; set; }
    }

    public class SiseInfo
    {
        // PriceInfo
        public double 시가 { get; set; }
        public double 고가 { get; set; }
        public double 저가 { get; set; }
        public double 현재가 { get; set; }
        public double 거래량 { get; set; }
        public double 기준가 { get; set; }
        public double 전일거래량 { get; set; }

        // HogaInfo
        public double 매도1호가 { get; set; }
        public double 매도2호가 { get; set; }
        public double 매도3호가 { get; set; }
        public double 매도4호가 { get; set; }
        public double 매도5호가 { get; set; }
        public double 매수1호가 { get; set; }
        public double 매수2호가 { get; set; }
        public double 매수3호가 { get; set; }
        public double 매수4호가 { get; set; }
        public double 매수5호가 { get; set; }
        public int 매도호가잔량1 { get; set; }
        public int 매도호가잔량2 { get; set; }
        public int 매도호가잔량3 { get; set; }
        public int 매도호가잔량4 { get; set; }
        public int 매도호가잔량5 { get; set; }
        public int 매수호가잔량1 { get; set; }
        public int 매수호가잔량2 { get; set; }
        public int 매수호가잔량3 { get; set; }
        public int 매수호가잔량4 { get; set; }
        public int 매수호가잔량5 { get; set; }
        public int 매도호가잔량증감1 { get; set; }
        public int 매도호가잔량증감2 { get; set; }
        public int 매도호가잔량증감3 { get; set; }
        public int 매도호가잔량증감4 { get; set; }
        public int 매도호가잔량증감5 { get; set; }
        public int 매수호가잔량증감1 { get; set; }
        public int 매수호가잔량증감2 { get; set; }
        public int 매수호가잔량증감3 { get; set; }
        public int 매수호가잔량증감4 { get; set; }
        public int 매수호가잔량증감5 { get; set; }

    }

    public class DayTradeInfo
    {
        public int 시간 { get; set; }
        public double 현재가 { get; set; }
        public double 전일대비 { get; set; }
        public int 매수체결량 { get; set; }
        public int 매도체결량 { get; set; }
    }

    public enum CandleRoundType
    {
        틱,
        분,
        일,
        주,
        월,
    }
    public class CandleData
    {
        public int 일자 { get; set; }
        public int 시간 { get; set; }
        public double 시가 { get; set; }
        public double 고가 { get; set; }
        public double 저가 { get; set; }
        public double 종가 { get; set; }
        public double 거래량 { get; set; }
    }
}
