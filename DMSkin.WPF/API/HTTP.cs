using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// DMSkin专用HTTP封装类
/// </summary>
namespace DMSkin.WPF
{
    #region 服务器配置
    public class ServicePath
    {
        //public static string Path = "localhost:65035/";
        public static string Path = "www.dmskin.com";

        public static readonly string HomeUrl = "http://www.dmskin.com/";
        public static readonly string IndexUrl = "http://www.dmskin.com/";
                    
        public static string GetPath
        {
            get { return Path; }
            set { Path = value; }
        }

        public static string GalleryAshx = "http://" + GetPath + "/Gallery.ashx";

        /////服务端
        /// <summary>
        /// 登录接口
        /// </summary>
        public static string Ashx = "http://" + GetPath + "/API.ashx";
    }
    #endregion

    #region 实体类
    public class ImageTask
    {
        public string ImageUrl;
        public Uri Image;
        public Action<string> action;
    }
    #endregion

    #region HTTP访问
    public class HTTP
    {
        /// <summary>
        /// 浏览器标识
        /// </summary>
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        /// <summary>
        /// 超时时间
        /// </summary>
        private static int timeout = 15000;//超时

        /// <summary>
        /// 程序启动路径
        /// </summary>
        public static string RunPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 封装参数
        /// </summary>
        private static void AddPar(Dictionary<string, string> parameters)
        {
             //封装参数
             //parameters.Add("token", Auth.Token);//用户token
             //parameters.Add("userid", Auth.PKID);//用户id
        }

        /// <summary>
        /// 打开线程请求并且回调
        /// </summary>
        /// <param name="par">参数集合</param>
        /// <param name="posturl">目标地址</param>
        /// <param name="target">目标函数</param>
        /// <param name="action">回调函数</param>
        /// <param name="erroraction">错误回调</param>
        public static void Open(Dictionary<string, string> par,string posturl,string target, Action<string> action,Action<Exception> erroraction)
        {
            Task.Factory.StartNew(() => {
                par.Add("action", target);
                #region 调用网络
                string json = "";
                try
                {
                    json = Post(posturl, par);
                    action(json);
                }
                catch (Exception ex)//全局错误-网络错误 操作错误
                {
                    Console.WriteLine(ex.Message);
                    erroraction(ex);
                }
                #endregion
            });
        }

        public static void Get(string posturl, Action<string> action, Action<Exception> erroraction)
        {
            Task.Factory.StartNew(()=> {
                #region 调用网络
                try
                {
                    string retString = "";
                    using (HttpWebResponse response = CreateGetHttpResponse(posturl))
                    {
                        //使用手册
                        //返回加密的GZIP
                        //HttpWebResponse response = HttpHelper.CreateGetHttpResponse(url, 2500, null, null);
                        //   GZipStream g = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        //   
                        //   string retString = r.ReadToEnd();
                        //   //后开先关
                        //   r.Close();
                        //   r.Dispose();
                        //   g.Close();
                        //   g.Dispose();
                        //   //处理返回的JSON
                        Stream myResponseStream = response.GetResponseStream();
                        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
                        retString = myStreamReader.ReadToEnd();

                        //GZipStream g = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        //System.IO.StreamReader r = new System.IO.StreamReader(g, Encoding.UTF8);
                        //retString = r.ReadToEnd();
                    }
                    action(retString);
                }
                catch (Exception ex)//全局错误-网络错误 操作错误
                {
                    Console.WriteLine(ex.Message);
                    erroraction(ex);
                }
                #endregion
            });
        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreateGetHttpResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Cache-Control", "max-age=0");
            request.UserAgent = DefaultUserAgent;
            request.Timeout = 25000;
           
            try
            {
                return request.GetResponse() as HttpWebResponse;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string Post(string postUrl, Dictionary<string, string> parameters)
        {
            AddPar(parameters);
            string retString = "";
            using (HttpWebResponse response = CreatePostHttpResponse(postUrl, parameters))
            {
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
                retString = myStreamReader.ReadToEnd();
            }
            return retString;
        }

        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            //request.Host = host;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = DefaultUserAgent;
            request.Timeout = timeout;
            //request.CookieContainer=cookies;

            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }


        public static void DownImage(string name, string path, Action<string> action)
        {
            Task.Factory.StartNew(() => {
                string DirectoryPath = HTTP.RunPath + "images\\";
                string ImagePath = HTTP.RunPath + "images\\" + name;

                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                if (!File.Exists(ImagePath))
                {
                    using (WebClient wb = new WebClient())
                    {
                        wb.DownloadFile(path, ImagePath);
                    }
                }
                action(ImagePath);
            });
        }

        /// <summary>
        /// 下载图片并且返回Uri
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="image"></param>
        internal static void OpenImage(string imageUrl,Action<string> action)
        {
            Task.Factory.StartNew(() => {
                using (WebClient wb = new WebClient())
                {
                    if (!Directory.Exists("images"))
                    {
                        Directory.CreateDirectory("images");
                    }
                    string fileNameTime = Guid.NewGuid().ToString();
                    //string fileNameTime = DateTime.Now.ToString("yyyyMMddhhmmss");
                    string name = Directory.GetCurrentDirectory() + "\\images\\" + fileNameTime + ".jpg";
                    wb.DownloadFile(imageUrl, name);
                    //初始化图片地址
                    action(name);
                }
            });
        }

        /// <summary>
        /// 批量下载绑定
        /// </summary>
        /// <param name="imageUrlList"></param>
        internal static void OpenImage(List<ImageTask> imageUrlList)
        {
            Task.Factory.StartNew(() => {
                using (WebClient wb = new WebClient())
                {
                    if (!Directory.Exists("images"))
                    {
                        Directory.CreateDirectory("images");
                    }
                    foreach (var item in imageUrlList)//批量下载
                    {
                        string fileNameTime = Guid.NewGuid().ToString();
                        //string fileNameTime = DateTime.Now.ToString("yyyyMMddhhmmss");
                        string imageurl = Directory.GetCurrentDirectory() + "\\images\\" + fileNameTime + ".jpg";
                        wb.DownloadFile(item.ImageUrl, imageurl);
                        //初始化图片地址
                        item.action(imageurl);
                    }
                }
            });
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.Default.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }
    }
    #endregion
}
