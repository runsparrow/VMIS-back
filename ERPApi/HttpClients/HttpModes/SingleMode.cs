using Newtonsoft.Json;

namespace ERPApi.HttpClients.HttpModes
{
    /// <summary>
    /// 
    /// </summary>
    public class SingleMode<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public class Request : RowMode<T>.Request
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public new virtual Response ToResponse(T entity)
            {
                Response response = new Response();
                response.Request = this;
                response.Row = entity;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Response : RowMode<T>.Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "request")]
            public virtual Request Request { get; set; }
        }
    }
}