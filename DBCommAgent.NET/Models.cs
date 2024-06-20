using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DBCommAgent.NET
{
    internal class ResInfo
    {
        public bool IS_TRAN;
        public string TR_CODE;
        public string TR_NAME;
        public string SERVER;
        public int ENCODE;
        public int COMPRESS;
        public int CERT;

        // RECORD
        public List<RecordInfo> InRecs = [];
        public List<RecordInfo> OutRecs = [];
    }

    internal class RecordInfo
    {
        public string REC_NAME;
        public int INOUT;
        public int ARRAY;
        public string ARRINFO;
        public List<FieldInfo> Fields = [];
    }

    /// <summary>
    /// 블록 필드 정보
    /// (ex: ITEM=AcntNo, TYPE=string, SIZE=20, CAPTION=계좌번호;)
    /// </summary>
    public class FieldInfo
    {
        /// <summary>ITEM</summary>
        public string ITEM;
        /// <summary>TYPE</summary>
        public string TYPE;
        /// <summary>SIZE</summary>
        public int SIZE;
        /// <summary>SIGN</summary>
        public int SIGN;
        /// <summary>CAPTION</summary>
        public string CAPTION;
    }

    internal static class ModelHelper
    {
        static Encoding encoding;
        static ModelHelper()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            encoding = Encoding.GetEncoding(949);
        }
        static Dictionary<string, ResInfo> _resInfos = [];

        public static ResInfo GetResInfo(string trCode)
        {
            if (_resInfos.TryGetValue(trCode, out var value))
                return value;
            return null;
        }

        public static void LoadResFolder(string resPath)
        {
            // load resinfo
            var root_files = Directory.GetFiles(resPath, "*.res");
            var tranres_files = Directory.GetFiles(resPath + "\\tranres", "*.res");
            var fidres_files = Directory.GetFiles(resPath + "\\fidres", "*.res");
            var all_files = root_files.Concat(fidres_files).Concat(tranres_files);

            foreach (var file in all_files)
            {
                try
                {
                    var resInfo = LoadResInfo(file);
                    if (resInfo == null)
                    {
                        Debug.WriteLine($"Error: {file}");
                        continue;
                    }

                    if (_resInfos.ContainsKey(resInfo.TR_CODE))
                    {
                        continue;
                    }
                    _resInfos.Add(resInfo.TR_CODE, resInfo);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        enum STATE
        {
            NONE,
            BEGIN_TRAN_LAYOUT,
            MUST_BEGIN_RECORD,
            WAIT_REC_NAME,
            GATHER_ITEMS,
            MUST_END_TRAN_LAYOUT,
            FINISH,
        }
        static ResInfo LoadResInfo(string filepath)
        {
            var resInfo = new ResInfo();
            resInfo.IS_TRAN = filepath.Contains("\\tranres\\");

            var lines = File.ReadAllLines(filepath, encoding);
            STATE state = STATE.NONE;

            RecordInfo recordInfo = null;

            foreach (var line in lines)
            {
                var trim_line = line.Trim();
                if (trim_line.Length == 0 || trim_line[0] == '#' || trim_line[0] == '\'')
                    continue;

                switch (state)
                {
                    case STATE.NONE:
                        {
                            if (trim_line.Equals("BEGIN_TRAN_LAYOUT"))
                                state = STATE.BEGIN_TRAN_LAYOUT;
                        }
                        break;
                    case STATE.BEGIN_TRAN_LAYOUT:
                        {
                            // TR_CODE=CACAM10100, TR_NAME=고객기본정보 조회, SERVER=B, ENCODE=0, COMPRESS=0, CERT=0;
                            var val_infos = trim_line.Split([',', ';'], StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in val_infos)
                            {
                                var trim_trInfo = item.Trim();
                                var keyValue = trim_trInfo.Split('=');
                                if (keyValue.Length != 2)
                                    continue;
                                var key = keyValue[0].Trim();
                                var value = keyValue[1].Trim();
                                switch (key)
                                {
                                    case "TR_CODE":
                                        resInfo.TR_CODE = value;
                                        break;
                                    case "TR_NAME":
                                        resInfo.TR_NAME = value;
                                        break;
                                    case "SERVER":
                                        resInfo.SERVER = value;
                                        break;
                                    case "ENCODE":
                                        resInfo.ENCODE = int.Parse(value);
                                        break;
                                    case "COMPRESS":
                                        resInfo.COMPRESS = int.Parse(value);
                                        break;
                                    case "CERT":
                                        resInfo.CERT = int.Parse(value);
                                        break;
                                    default:
                                        Debug.Assert(false);
                                        break;
                                }
                            }

                            state = STATE.MUST_BEGIN_RECORD;
                        }
                        break;
                    case STATE.MUST_BEGIN_RECORD:
                        {
                            Debug.Assert(trim_line.Equals("BEGIN_RECORD"));
                            state = STATE.WAIT_REC_NAME;
                        }
                        break;
                    case STATE.WAIT_REC_NAME:
                        {
                            if (trim_line.StartsWith("END_RECORD"))
                            {
                                state = STATE.MUST_END_TRAN_LAYOUT;
                                continue;
                            }
                            if (trim_line.StartsWith("REC_NAME="))
                            {
                                Debug.Assert(recordInfo == null);
                                recordInfo = new RecordInfo();
                                // RecName=InRec1, INOUT=0, ARRAY=0, ARRINFO=;
                                var val_infos = trim_line.Split([',', ';'], StringSplitOptions.RemoveEmptyEntries);
                                foreach (var item in val_infos)
                                {
                                    var trim_trInfo = item.Trim();
                                    var keyValue = trim_trInfo.Split('=');
                                    if (keyValue.Length != 2)
                                        continue;
                                    var key = keyValue[0].Trim();
                                    var value = keyValue[1].Trim();
                                    switch (key)
                                    {
                                        case "REC_NAME":
                                            recordInfo.REC_NAME = value;
                                            break;
                                        case "INOUT":
                                            recordInfo.INOUT = int.Parse(value);
                                            break;
                                        case "ARRAY":
                                            recordInfo.ARRAY = int.Parse(value);
                                            break;
                                        case "ARRINFO":
                                            recordInfo.ARRINFO = value;
                                            break;
                                        default:
                                            Debug.Assert(false);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.Assert(recordInfo != null);
                                Debug.Assert(trim_line.Equals(recordInfo.INOUT == 0 ? $"BEGIN_INPUT{resInfo.InRecs.Count}_ITEM" : $"BEGIN_OUTPUT{resInfo.OutRecs.Count}_ITEM"));
                                state = STATE.GATHER_ITEMS;
                            }
                        }
                        break;
                    case STATE.GATHER_ITEMS:
                        {
                            if (trim_line.StartsWith("INDEX="))
                            {
                                var fieldInfo = new FieldInfo();
                                // ITEM=htsId, TYPE=S, SIZE=8, CAPTION=고객ID;
                                var val_infos = trim_line.Split([',', ';'], StringSplitOptions.RemoveEmptyEntries);
                                foreach (var item in val_infos)
                                {
                                    var trim_trInfo = item.Trim();
                                    var keyValue = trim_trInfo.Split('=');
                                    if (keyValue.Length != 2)
                                        continue;
                                    var key = keyValue[0].Trim();
                                    var value = keyValue[1].Trim();
                                    switch (key)
                                    {
                                        case "INDEX":
                                            //Debug.Assert(recordInfo.Fields.Count == int.Parse(value));
                                            break;
                                        case "ITEM":
                                            fieldInfo.ITEM = value;
                                            break;
                                        case "TYPE":
                                            fieldInfo.TYPE = value;
                                            break;
                                        case "SIZE":
                                            fieldInfo.SIZE = int.Parse(value);
                                            break;
                                        case "SIGN":
                                            fieldInfo.SIGN = int.Parse(value);
                                            break;
                                        case "CAPTION":
                                            fieldInfo.CAPTION = value;
                                            break;
                                        default:
                                            Debug.Assert(false);
                                            break;
                                    }
                                }
                                recordInfo.Fields.Add(fieldInfo);
                            }
                            else
                            {
                                if (trim_line.Equals(recordInfo.INOUT == 0 ? $"END_INPUT{resInfo.InRecs.Count}_ITEM" : $"END_OUTPUT{resInfo.OutRecs.Count}_ITEM"))
                                {
                                    if (recordInfo.INOUT == 0)
                                        resInfo.InRecs.Add(recordInfo);
                                    else
                                        resInfo.OutRecs.Add(recordInfo);
                                    recordInfo = null;
                                    state = STATE.WAIT_REC_NAME;
                                }
                                else
                                {
                                    Debug.Assert(false);
                                }
                            }
                        }
                        break;
                    case STATE.MUST_END_TRAN_LAYOUT:
                        {
                            Debug.Assert(trim_line.Equals("END_TRAN_LAYOUT"));
                            state = STATE.FINISH;
                        }
                        break;
                    default:
                        break;
                }


            }

            return resInfo;
        }
    }
}
