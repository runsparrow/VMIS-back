using ERPApi.Services.AVM;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ocelot.JwtAuthorize;
using System;
using System.ComponentModel;
using System.Security.Claims;

namespace ERPApi.Controllers.AVM
{
    /// <summary>
    /// 验证
    /// </summary>
    public class AuthController : Controller
    {
        /// <summary>
        ///  ITokenBuilder是用来生成Token的
        /// </summary>
        private readonly ITokenBuilder _tokenBuilder;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenBuilder"></param>
        public AuthController(ITokenBuilder tokenBuilder)
        {
            _tokenBuilder = tokenBuilder;
        }

        #region IActionResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authEntity"></param>
        /// <returns></returns>
        [Route("ERP/Auth/GetToken", Name = "ERP_Auth_Get_Token")]
        [HttpPost]
        public IActionResult GetToken([FromForm]HttpEntity authEntity)
        {
            var user = new UserService.SingleService().Verify(authEntity.AccountName, authEntity.AccountPwd);
            if (user != null)
            {
                var claims = new Claim[] {
                     new Claim(ClaimTypes.Sid, user.Id.ToString()),
                     new Claim(ClaimTypes.Name, user.Name),
                     new Claim(ClaimTypes.Role, "admin"),
                     new Claim(ClaimTypes.NameIdentifier, "ERPApi.Entities.AVM.User")
                };
                var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
                var token = _tokenBuilder.BuildJwtToken(claims, ip, DateTime.UtcNow, DateTime.Now.AddSeconds(1200));
                return new JsonResult(new { Result = true, Data = token, User = user });
            }
            else
            {
                return new JsonResult(new
                {
                    Result = false,
                    Message = "Authentication Failure"
                });
            }
        }
        #endregion

        #region HttpEntity

        /// <summary>
        /// 
        /// </summary>
        public class HttpEntity
        {
            [Description("账户名")]
            [JsonProperty("accountName")]
            public string AccountName { get; set; }
            [Description("账户密码")]
            [JsonProperty("accountPwd")]
            public string AccountPwd { get; set; }
        }
        #endregion

    }
}