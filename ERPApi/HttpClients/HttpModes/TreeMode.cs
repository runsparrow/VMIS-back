using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ERPApi.HttpClients.HttpModes.TreeMode;

namespace ERPApi.HttpClients.HttpModes
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeMode<T>
    {
        #region Request

        #region Base Request
        /// <summary>
        /// 
        /// </summary>
        public class Request
        {
            #region Request 属性
            /// <summary>
            /// 关键字
            /// </summary>
            [JsonProperty(PropertyName = "keyWord")]
            public virtual string KeyWord { get; set; }
            /// <summary>
            /// JWT的Token
            /// </summary>
            [JsonProperty(PropertyName = "token")]
            public virtual string Token { get; set; } = "";
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "pageSize")]
            public int PageSize { get; set; } = int.MaxValue;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "pageIndex")]
            public int PageIndex { get; set; } = 1;
            /// <summary>
            /// 状态
            /// </summary>
            [JsonProperty(PropertyName = "status")]
            public virtual ModeBase.Status Status { get; set; }
            /// <summary>
            /// startDate
            /// </summary>
            [JsonProperty(PropertyName = "startDate")]
            public virtual DateTime StartDate { get; set; }
            /// <summary>
            /// endDate
            /// </summary>
            [JsonProperty(PropertyName = "endDate")]
            public virtual DateTime EndDate { get; set; }
            /// <summary>
            /// Service中的方法
            /// </summary>
            [JsonProperty(PropertyName = "function")]
            public virtual ModeBase.Function Function { get; set; } = new ModeBase.Function();

            #endregion

            #region Request 方法
            /// <summary>
            /// 
            /// </summary>
            /// <param name="rows"></param>
            /// <returns></returns>
            public virtual Response ToResponse(List<T> rows)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Request = this;
                response.Rows = rows;
                return response;
            }
            #endregion
        }
        #endregion

        #region BootstrapTreeViewRequest
        /// <summary>
        /// 
        /// </summary>
        public class BootstrapTreeViewRequest : Request
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "config")]
            public virtual BootstrapTreeView<T>.Config Config { get; set; } = new BootstrapTreeView<T>.Config();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="rows"></param>
            /// <returns></returns>
            public new virtual BootstrapTreeViewResponse ToResponse(List<T> rows)
            {
                BootstrapTreeViewResponse response = new BootstrapTreeViewResponse();
                response.Request = this;
                response.Rows = rows;
                return response;
            }
        }
        #endregion

        #endregion

        #region Response

        #region Base Response
        /// <summary>
        /// 
        /// </summary>
        public class Response
        {
            #region Response 属性
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "request")]
            public virtual Request Request { get; set; } = new Request();
            /// <summary>
            /// 
            /// </summary>
            [JsonIgnore]
            [JsonProperty(PropertyName = "rows")]
            public virtual List<T> Rows { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "error")]
            public virtual string Error { get; set; }
            #endregion
        }
        #endregion

        #region BootstrapTreeViewResponse
        /// <summary>
        /// 
        /// </summary>
        public class BootstrapTreeViewResponse : Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "request")]
            public new virtual BootstrapTreeViewRequest Request { get; set; } = new BootstrapTreeViewRequest();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "tree")]
            public virtual List<BootstrapTreeView<T>.Node> Tree
            {
                get
                {
                    return new BootstrapTreeView<T>().ToTree(Rows, Request.Config);
                }
            }

        }
        #endregion

        #endregion
    }
}