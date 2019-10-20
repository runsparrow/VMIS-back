using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ERPApi.HttpClients.HttpModes
{

    /// <summary>
    /// 
    /// </summary>
    public class RowsMode<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public class Request
        {
            /// <summary>
            /// JWT的Token
            /// </summary>
            [JsonProperty(PropertyName = "token")]
            public virtual string Token { get; set; } = "";
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
            /// statusValues
            /// </summary>
            [JsonProperty(PropertyName = "status")]
            public virtual ModeBase.Status Status { get; set; }
            /// <summary>
            /// sort
            /// </summary>
            [JsonProperty(PropertyName = "sort")]
            public virtual ModeBase.Sort Sort { get; set; } = new ModeBase.Sort();
            /// <summary>
            /// Service中的方法
            /// </summary>
            [JsonProperty(PropertyName = "function")]
            public virtual ModeBase.Function Function { get; set; } = new ModeBase.Function();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public virtual Response ToResponse(List<T> entityList)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Rows = entityList;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "rows")]
            public virtual List<T> Rows { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "error")]
            public virtual string Error { get; set; }
        }

    }
}