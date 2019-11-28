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
using static ERPApi.HttpClients.HttpClientHelper;

namespace ERPApi.Controllers.AVM
{
    /// <summary>
    /// 验证
    /// </summary>
    public class AuthController : Controller
    {
        #region 定义&构造函数
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
        #endregion

        #region IActionResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Route("ERP/Auth/WeChatVerify", Name = "ERP_Auth_WeChat_Verify")]
        [HttpGet]
        public IActionResult WeChatVerify(string code)
        {
             WeChatEntity entity = JsonConvert.DeserializeObject<WeChatEntity>(
                HttpGetRequestAsync(
                    @"https://api.weixin.qq.com/sns/jscode2session",
                    new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("appid", "wx1682ca244fe65dc6"),
                        new KeyValuePair<string, string>("secret", "a620028546bf65c286e968f9bd416cce"),
                        new KeyValuePair<string, string>("js_code", code),
                        new KeyValuePair<string, string>("grant_type", "authorization_code")
                    },
                    CONTENT_TYPE.APPLICATION_X_WWW_FORM_URLENCODED
                )
            );
            // 微信认证判断
            if(entity != null)
            {
                var user = new UserService.RowService().ByWeChatOpenId(entity.OpenId);
                // 已有用户
                if(user != null)
                {
                    return new JsonResult(new {
                        result = true,
                        message = "微信认证成功，并找到对应系统用户！",
                        token = GenerateToken(user),
                        weChatEntity = entity,
                        user = new { userId = user.Id, userName = user.Name, realName = user.RealName, weChatOpenId = user.WeChatOpenId }
                    });
                }
                else
                {
                    return new JsonResult(new {
                        result = true,
                        message = "微信认证成功，但没有找到对应系统用户！",
                        token = "",
                        weChatEntity = entity,
                        user = new { }
                    });
                }
            }
            else
            {
                return new JsonResult(new { result = false, message = "微信认证失败", token = "", weChatEntity = new { }, user = new { } });
            }
        }
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
                return new JsonResult(new {
                    result = true,
                    message = "认证成功",
                    token = GenerateToken(user),
                    user = new { userId = user.Id, userName = user.Name, realName = user.RealName, weChatOpenId = user.WeChatOpenId }
                });
            }
            else
            {
                return new JsonResult(new
                {
                    result = false,
                    message = "认证失败",
                    token = "",
                    user = new { }
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authEntity"></param>
        /// <returns></returns>
        [Route("ERP/Auth/GetTokenByWeChatOpenId", Name = "ERP_Auth_Get_Token_ByWeChatOpenId")]
        [HttpGet]
        public IActionResult GetTokenByWeChatOpenId(string weChatOpenId)
        {
            var user = new UserService.RowService().ByWeChatOpenId(weChatOpenId);
            if (user != null)
            {
                return new JsonResult(new {
                    result = true,
                    message = "认证成功",
                    token = GenerateToken(user),
                    user = new { userId = user.Id, userName = user.Name, realName = user.RealName, weChatOpenId = user.WeChatOpenId }
                });
            }
            else
            {
                return new JsonResult(new
                {
                    result = false,
                    message = "认证失败",
                    token = "",
                    user = new { }
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authEntity"></param>
        /// <returns></returns>
        [Route("ERP/Auth/GetTokenByMobile", Name = "ERP_Auth_Get_Token_ByMobile")]
        [HttpGet]
        public IActionResult GetTokenByMobile(string mobile)
        {
            var user = new UserService.RowService().ByMobile(mobile);
            if (user != null)
            {
                return new JsonResult(new {
                    result = true,
                    message = "认证成功",
                    token = GenerateToken(user),
                    user = new { userId = user.Id, userName = user.Name, realName = user.RealName, weChatOpenId = user.WeChatOpenId }
                });
            }
            else
            {
                return new JsonResult(new
                {
                    result = false,
                    message = "认证失败",
                    token = "",
                    user = new { }
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
                return new JsonResult(new {
                    result = true,
                    message = "认证成功",
                    token = GenerateToken(user),
                    user = new { userId=user.Id, userName = user.Name, realName = user.RealName, weChatOpenId = user.WeChatOpenId}
                });
            }
            else
            {
                return new JsonResult(new
                {
                    result = false,
                    message = "认证失败",
                    token = "",
                    user = new { }
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
            return new JsonResult(new {
                result = true,
                message = "转换成功",
                token = token,
                user = new { userId = user.Id, userName = user.Name, realName = user.RealName, weChatOpenId = user.WeChatOpenId }
            });

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private TokenBuilder.Token GenerateToken(User user)
        {
            try
            {
                // 返回
                return _tokenBuilder.BuildJwtToken(
                    new Claim[] {
                         new Claim(ClaimTypes.Sid, user.Id.ToString()),
                         new Claim(ClaimTypes.Name, user.Name),
                         new Claim(ClaimTypes.Surname, user.RealName),
                         new Claim(ClaimTypes.Role, "admin"),
                         new Claim(ClaimTypes.NameIdentifier, "ERPApi.Entities.AVM.User")
                    },
                    HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString(), 
                    DateTime.Now, DateTime.Now.AddHours(24)
                );
            }
            catch(Exception ex)
            {
                throw ex;
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

        #region WeChatEntity
        /// <summary>
        /// 
        /// </summary>
        public class WeChatEntity
        {
            /// <summary>
            /// 单平台用户唯一ID
            /// </summary>
            [JsonProperty("openId")]
            public string OpenId { get; set; }
            /// <summary>
            /// 多平台用户公用唯一ID
            /// </summary>
            [JsonProperty("unionId")]
            public string UnionId { get; set; }
            /// <summary>
            /// 昵称
            /// </summary>
            [JsonProperty("nickName")]
            public string NickName { get; set; }
            /// <summary>
            /// 性别
            /// </summary>
            [JsonProperty("gender")]
            public string Gender { get; set; }
            /// <summary>
            /// 城市
            /// </summary>
            [JsonProperty("city")]
            public string City { get; set; }
            /// <summary>
            /// 省份
            /// </summary>
            [JsonProperty("province")]
            public string Province { get; set; }
            /// <summary>
            /// 区
            /// </summary>
            [JsonProperty("country")]
            public string Country { get; set; }
            /// <summary>
            /// 头像Url
            /// </summary>
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("session_key")]
            public string SessionKey { get; set; }
        }
        #endregion

    }
}