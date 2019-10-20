using Newtonsoft.Json;

namespace ERPApi.HttpClients.HttpModes
{
    /// <summary>
    /// 
    /// </summary>
    public class RowMode<T>
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
            /// status
            /// </summary>
            [JsonProperty(PropertyName = "status")]
            public virtual ModeBase.Status Status { get; set; } = new ModeBase.Status();
            /// <summary>
            /// Service中的方法
            /// </summary>
            [JsonProperty(PropertyName = "function")]
            public virtual ModeBase.Function Function { get; set; } = new ModeBase.Function();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Response ToResponse(T entity)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Row = entity;
                return response;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public virtual Response ToResponse(object o)
            {
                Response response = new Response();
                response.Result = o;
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
            [JsonProperty(PropertyName = "row")]
            public virtual T Row { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "result")]
            public virtual object Result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "error")]
            public virtual string Error { get; set; }
        }
    }
}