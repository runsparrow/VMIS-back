using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPApi.Controllers
{
    public class TestController: Controller
    {
        /// <summary>
        /// 测试ERPApi连接
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/Test", Name = "ERP_Test")]
        [HttpGet]
        public IActionResult Test()
        {
            try
            {
                return new OkObjectResult(new TestObject() { Title="测试通过", Content="ERP Test Success！" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class TestObject
        {
            /// <summary>
            /// 
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Content { get; set; }
        }
    }
}
