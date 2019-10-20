using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.HttpClients.HttpModes
{

    /// <summary>
    /// 
    /// </summary>
    public class QueryMode<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public class Request : RowsMode<T>.Request
        {
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
            /// 使用于client端的分页，即实体类集合结果数作为total变量
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public new virtual Response ToResponse(List<T> entityList)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Request = this;
                response.Total = entityList.Count();
                response.Rows = entityList;
                return response;
            }
            /// <summary>
            ///  使用于server端的分页，也就是实体类集合只返回当页数据，total是同查询条件的查询结果数
            /// </summary>
            /// <param name="entityList"></param>
            /// <param name="total"></param>
            /// <returns></returns>
            public virtual Response ToResponse(List<T> entityList, int total)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Request = this;
                response.Total = total;
                response.Rows = entityList;
                return response;
            }
            /// <summary>
            ///  使用于server端的分页，也就是实体类集合只返回当页数据，total是同查询条件的查询结果数
            /// </summary>
            /// <param name="entityList"></param>
            /// <param name="total"></param>
            /// <param name="summary"></param>
            /// <returns></returns>
            public virtual Response ToResponse(List<T> entityList, int total, dynamic summary)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Request = this;
                response.Total = total;
                response.Rows = entityList;
                response.Summary = summary;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Response : RowsMode<T>.Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "request")]
            public virtual Request Request { get; set; }
            /// <summary>
            /// 查询结果总数
            /// </summary>
            [JsonProperty(PropertyName = "total")]
            public int Total { get; set; }
            /// <summary>
            /// 汇总
            /// </summary>
            [JsonProperty(PropertyName = "summary")]
            public dynamic Summary { get; set; }
        }

    }
}