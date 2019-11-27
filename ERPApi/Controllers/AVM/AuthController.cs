using ERPApi.Entities.AVM;
using ERPApi.Services.AVM;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ocelot.JwtAuthorize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
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
        [HttpGet]
        public IActionResult GetToken(string accountName, string accountPwd)
        {
            var user = new UserService.SingleService().Verify(accountName, accountPwd);
            if (user != null)
            {
                var claims = new Claim[] {
                     new Claim(ClaimTypes.Sid, user.Id.ToString()),
                     new Claim(ClaimTypes.Name, user.Name),
                     new Claim(ClaimTypes.Surname, user.RealName),
                     new Claim(ClaimTypes.Role, "admin"),
                     new Claim(ClaimTypes.NameIdentifier, "ERPApi.Entities.AVM.User")
                };
                var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
                var token = _tokenBuilder.BuildJwtToken(claims, ip, DateTime.Now, DateTime.Now.AddHours(24));
                return new JsonResult(new { Result = true, Data = token, User = new { UserId = user.Id, UserName = user.Name, RealName = user.RealName, WeChatOpenId = user.WeChatOpenId } });
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
                     new Claim(ClaimTypes.Surname, user.RealName),
                     new Claim(ClaimTypes.Role, "admin"),
                     new Claim(ClaimTypes.NameIdentifier, "ERPApi.Entities.AVM.User")
                };
                var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
                var token = _tokenBuilder.BuildJwtToken(claims, ip, DateTime.Now, DateTime.Now.AddHours(24));
                return new JsonResult(new { Result = true, Data = token, User = new { UserId=user.Id, UserName = user.Name, RealName = user.RealName, WeChatOpenId = user.WeChatOpenId} });
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authEntity"></param>
        /// <returns></returns>
        [Route("ERP/Auth/GetAuthEntity", Name = "ERP_Auth_Get_Auth_Entity")]
        [HttpPost]
        public IActionResult GetAuthEntity(string token)
        {
            // 定义
            User user = new User();
            // 获取Claims
            IEnumerator<Claim> ienumerator = new JwtSecurityToken(token).Claims.GetEnumerator();
            // 遍历
            while (ienumerator.MoveNext())
            {
                var claim = ienumerator.Current;
                if (claim.Type.ToLower().EndsWith("/sid"))
                {
                    user.Id = int.Parse(claim.Value);
                }
                if (claim.Type.ToLower().EndsWith("/name"))
                {
                    user.Name = claim.Value;
                }
                if (claim.Type.ToLower().EndsWith("/surname"))
                {
                    user.RealName = claim.Value;
                }
            }
            return new JsonResult(new { Result = true, Data = token, User = new { UserId = user.Id, UserName = user.Name, RealName = user.RealName, WeChatOpenId = user.WeChatOpenId } });

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