using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ERPApi.HttpClients
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientHelper
    {
        #region Define
        /// <summary>
        /// 
        /// </summary>
        private static readonly HttpClient HTTP_CLIENT;

        #endregion

        #region Construct
        static HttpClientHelper()
        {
            // 获取 HTTP_CLIENT
            HTTP_CLIENT = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None });
        }
        #endregion

        #region Public
        /// <summary>
        /// get请求，可以对请求头进行多项设置
        /// </summary>
        /// <param name="paramArray"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGetResponse(List<KeyValuePair<string, string>> paramArray, string url)
        {
            try
            {
                string result = "";
                var response = HTTP_CLIENT.GetAsync(BuildRequestUri(url, paramArray)).Result;
                if (response.IsSuccessStatusCode)
                {
                    Stream myResponseStream = response.Content.ReadAsStreamAsync().Result;
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    result = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramArray"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGetResponseSample(List<KeyValuePair<string, string>> paramArray, string url)
        {
            return HTTP_CLIENT.GetStringAsync(BuildRequestUri(url, paramArray)).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramArray"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string HttpPostRequestAsync(string url, List<KeyValuePair<string, string>> paramArray, string contentType)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    using (Stream dataStream = new MemoryStream(ContentTypeToByteArray(paramArray, contentType)))
                    {
                        using (HttpContent content = new StreamContent(dataStream))
                        {
                            http.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)");
                            http.DefaultRequestHeaders.Add("Accept", @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                            content.Headers.Add("Content-Type", contentType);
                            var task = http.PostAsync(url, content);
                            if (task.Result != null && task.Result.StatusCode == HttpStatusCode.OK)
                            {
                                using (task.Result)
                                {
                                    return task.Result.Content.ReadAsStringAsync().Result;
                                }
                            }
                        }
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Private
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string Encode(string content, Encoding encode = null)
        {
            if (encode == null)
            {
                return content;
            }
            return HttpUtility.UrlEncode(content, encode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramArray"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string BuildRequestUri(string url, List<KeyValuePair<string, string>> paramArray, Encoding encode = null)
        {
            return String.Format("{0}?{1}", url, ContentTypeForUrlencoded(paramArray));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramArray"></param>
        /// <returns></returns>
        private static string ContentTypeForUrlencoded(List<KeyValuePair<string, string>> paramArray)
        {
            if (paramArray != null && paramArray.Count > 0)
            {
                var paramsUrl = "";
                foreach (var item in paramArray)
                {
                    paramsUrl += String.Format("{0}={1}&", Encode(item.Key, Encoding.UTF8), Encode(item.Value, Encoding.UTF8));
                }
                if (paramsUrl != "")
                {
                    paramsUrl = paramsUrl.TrimEnd('&');
                }
                return paramsUrl;
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramArray"></param>
        /// <returns></returns>
        private static string ContentTypeForJson(List<KeyValuePair<string, string>> paramArray)
        {
            if (paramArray != null && paramArray.Count > 0)
            {
                var requestStr = "";
                foreach (var item in paramArray)
                {
                    requestStr += String.Format("{0}:{1},", item.Key, item.Value);
                }
                if (requestStr != "")
                {
                    requestStr = requestStr.TrimEnd(',');
                }
                return "{" + requestStr + "}";
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramArray"></param>
        /// <returns></returns>
        private static string ContentTypeForStream(List<KeyValuePair<string, string>> paramArray)
        {
            if (paramArray != null && paramArray.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in paramArray)
                {
                    sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
                var requestStr = sb.ToString();
                if (requestStr != "")
                {
                    requestStr = requestStr.TrimEnd('&');
                }
                return requestStr;
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramArray"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        private static byte[] ContentTypeToByteArray(List<KeyValuePair<string, string>> paramArray, string contentType)
        {
            if (contentType.Equals(CONTENT_TYPE.APPLICATION_X_WWW_FORM_URLENCODED))
            {
                return Encoding.UTF8.GetBytes(ContentTypeForUrlencoded(paramArray));
            }
            else if (contentType.Equals(CONTENT_TYPE.APPLICATION_JSON))
            {
                return Encoding.UTF8.GetBytes(ContentTypeForJson(paramArray));
            }
            else
            {
                return new byte[0];
            }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="paramArray"></param>
        ///// <param name="stream"></param>
        //private static Stream FillParamArryToStream(List<KeyValuePair<string, string>> paramArray, Stream stream)
        //{
        //    if (stream == null)
        //        stream = new MemoryStream();


        //    if (paramArray != null && paramArray.Count > 0)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (var item in paramArray)
        //        {
        //            sb.AppendFormat("{0}={1}&", item.Key, item.Value);
        //        }
        //        var dataString = sb.ToString();
        //        if (dataString != "")
        //        {
        //            dataString = dataString.TrimEnd('&');
        //        }
        //        var formDataBytes = paramArray == null ? new byte[0] : Encoding.UTF8.GetBytes(dataString);
        //        stream.Write(formDataBytes, 0, formDataBytes.Length);
        //        stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
        //        return stream;
        //    }
        //    return null;
        //}
        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        public class CONTENT_TYPE
        {
            /// <summary>
            /// HTML格式
            /// </summary>
            public static string TEXT_HTML = "text/html";
            /// <summary>
            /// 纯文本格式
            /// </summary>
            public static string TEXT_PLAIN = "text/plain";
            /// <summary>
            /// XML格式
            /// </summary>
            public static string TEXT_XML = "text/xml";
            /// <summary>
            /// gif图片格式
            /// </summary>
            public static string IMAGE_GIF = "image/gif";
            /// <summary>
            /// jpg图片格式
            /// </summary>
            public static string IMAGE_JPEG = "image/jpeg";
            /// <summary>
            /// png图片格式
            /// </summary>
            public static string IMAGE_PNG = "image/png";
            /// <summary>
            /// XHTML格式
            /// </summary>
            public static string APPLICATION_XHTML_XML = "application/xhtml+xml";
            /// <summary>
            /// XML数据格式
            /// </summary>
            public static string APPLICATION_XML = "application/xml";
            /// <summary>
            /// Atom XML聚合格式
            /// </summary>
            public static string APPLICATION_ATOM_XML = "application/atom+xml";
            /// <summary>
            /// JSON数据格式
            /// </summary>
            public static string APPLICATION_JSON = "application/json";
            /// <summary>
            /// pdf格式 
            /// </summary>
            public static string APPLICATION_PDF = "application/pdf";
            /// <summary>
            /// Word文档格式
            /// </summary>
            public static string APPLICATION_MSWORD = "application/msword";
            /// <summary>
            /// 二进制流数据（如常见的文件下载）
            /// </summary>
            public static string APPLICATION_OCTET_STREAM = "application/octet-stream";
            /// <summary>
            /// form 中默认的encType，form表单数据被编码为key/value格式发送到服务器（表单默认的提交数据的格式）
            /// </summary>
            public static string APPLICATION_X_WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";
        }

        #endregion
    }
}