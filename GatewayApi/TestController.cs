﻿

using Microsoft.AspNetCore.Mvc;
using System;

namespace GatewayApi
{
    public class TestController: Controller
    {

        /// <summary>
        /// 测试Ocelot连接
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Ocelot/Test", Name = "Ocelot_Test")]
        [HttpGet]
        public IActionResult Test()
        {
            try
            {
                return new OkObjectResult(new TestObject() { Title = "测试通过", Content = "Ocelot Test Success！" });
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
