using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPApi.HttpClients.HttpModes
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DeleteMode<T>
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
            /// Service中的方法
            /// </summary>
            [JsonProperty(PropertyName = "function")]
            public virtual ModeBase.Function Function { get; set; } = new ModeBase.Function();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "entity")]
            public virtual T Entity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "entities")]
            public virtual List<T> Entities { get; set; }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual Response ToResponse(T entity)
            {
                Response response = new Response();
                response.Request = this;
                response.Row = entity;
                return response;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual Response ToResponse(List<T> entities)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Request = this;
                response.Rows = entities;
                return response;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public virtual Response ToResponse(int result)
            {
                Response response = new Response();
                response.Request = this;
                response.Result = result;
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
            [JsonProperty(PropertyName = "request")]
            public virtual Request Request { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "row")]
            public virtual T Row { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "rows")]
            public virtual List<T> Rows { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "result")]
            public virtual int Result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "error")]
            public virtual string Error { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Log
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "userId")]
            public virtual int UserId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "employeeId")]
            public virtual int EmployeeId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "userName")]
            public virtual string UserName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "employeeName")]
            public virtual string EmployeeName { get; set; }
        }
    }
}