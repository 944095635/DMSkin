using DM_Studio.Models;
using DMSkin.WPF;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DM_Studio
{
    public class API
    {
        private static API api;
        internal static API Init()
        {
            if (api == null)
            {
                api = new API();
            }
            return api;
        }




        private API()
        {

        }
        
        
        /// <summary>
        /// 翻译接口
        /// </summary>
        public void Translate(string key,string form,string to,Action<TranslateModel> action)
        {
            //地址http://fanyi.baidu.com/v2transapi
            // from: zh
            // to:en
            // query:1
            // transtype: realtime
            // simple_means_flag:3
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "from",form},
                { "to",to},
                { "query", key.Replace("\r\n", "%0A") },
                { "transtype", "realtime" },
                { "simple_means_flag", "3" }
            };
            string poststr = "http://fanyi.baidu.com/v2transapi";

            TranslateModel mod = new TranslateModel()
            {
                Data = new List<Result>(),
                Word_Means = new List<string>()
            };
            HTTP.Open(parameters,poststr,null,
                new Action<string>((str)=> 
                {
                    JObject obj =  JsonConvert.DeserializeObject<JObject>(str);
                    JObject trans_result = (JObject)obj["trans_result"];
                    //data为结果集合
                    if (obj["dict_result"] is JObject dict_result)//简明释义
                    {
                        if (dict_result["simple_means"] is JObject simple_means)//simple_means
                        {
                            if (simple_means["word_means"] is JArray word_means)
                            {
                                foreach (var item in word_means)
                                {
                                    mod.Word_Means.Add(item.ToString());
                                }
                            }
                            if (simple_means["symbols"] is JArray symbols)
                            {
                                if (symbols[0] is JObject symbol)
                                {
                                    if (symbol["symbol_mp3"] is Object Symbol_Mp3)
                                    {
                                        mod.Symbol_Mp3 = Symbol_Mp3.ToString();
                                    }
                                    if (symbol["word_symbol"] is Object Word_Symbol)
                                    {
                                        string temp = Word_Symbol.ToString();
                                        if (temp!=null&& temp!="")
                                        {
                                            mod.Word_Symbol = "[" + temp + "]";
                                        }
                                    }
                                }
                            }
                             mod.Word_Name = simple_means["word_name"].ToString();
                        }
                    }
                    //try
                    //{
                    //    JObject liju_result = (JObject)obj["liju_result"];
                    //    JValue logid = (JValue)obj["logid"];
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("翻译服务器出错！");
                    //}
                    if (trans_result!=null)
                    {
                        JArray data = (JArray)trans_result["data"];
                        foreach (JObject item in data)
                        {
                            var re = new Result() { DST = item["dst"].ToString(), SRC = item["src"].ToString() };
                            mod.Data.Add(re);
                            mod.DataString += re.DST + "\r\n";
                        }
                    }
                    action(mod);
                }),new Action<Exception>((ex) => {
                    action(mod);
                }));
        }

        internal void Langdetect(string text,Action<LanguageModel> action)
        {
            //自动检测字体语言http://fanyi.baidu.com/langdetect
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "query", text.Replace("\r\n", "%0A") },
            };
            string poststr = "http://fanyi.baidu.com/langdetect";

            LanguageModel mod = new LanguageModel()
            {
                Short = "zh",
                Text = "中文"
            };
            HTTP.Open(parameters, poststr, null,
                new Action<string>((str) =>
                {
                    JObject obj = JsonConvert.DeserializeObject<JObject>(str);
                    mod.Short = obj["lan"].ToString();
                    action(mod);
                }), new Action<Exception>((ex) => {
                    action(mod);
                }));
        }
    }
}
