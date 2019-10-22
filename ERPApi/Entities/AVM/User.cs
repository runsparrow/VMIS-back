using ERPApi.CacheServices.WFM;
using ERPApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.AVM
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("AVM_User")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class User : EntityCacheBase<User>
    {
        #region Property
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Description("#")]
        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(255)]
        [Description("用户名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 实名
        /// </summary>
        [StringLength(255)]
        [Description("实名")]
        [JsonProperty("realName")]
        public string RealName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(255)]
        [Description("密码")]
        [JsonProperty("password")]
        public string Password { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [StringLength(255)]
        [Description("电子邮箱")]
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// 电子邮箱密码
        /// </summary>
        [StringLength(255)]
        [Description("电子邮箱密码")]
        [JsonProperty("emailPassword")]
        public string EmailPassword { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(20)]
        [Description("手机")]
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(4000)]
        [Description("描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Description("最后登录时间")]
        [JsonProperty("loginDateTime")]
        public DateTime LoginDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Description("最后登录IP")]
        [JsonProperty("loginIPAddress")]
        public string LoginIPAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        public DateTime CreateDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Description("创建用户Id")]
        [JsonProperty("createUserId")]
        public int CreateUserId { get; set; } = 0;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Description("最后修改时间")]
        [JsonProperty("editDateTime")]
        public DateTime EditDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 最后修改用户Id
        /// </summary>
        [Description("最后修改用户Id")]
        [JsonProperty("editUserId")]
        public int EditUserId { get; set; } = 0;
        /// <summary>
        /// 状态Id
        /// </summary>
        [Description("状态Id")]
        [JsonProperty("statusId")]
        public int StatusId { get; set; } = 0;
        #endregion

        #region Not Mapped Property
        ///// <summary>
        ///// 角色
        ///// </summary>
        //[Description("角色")]
        //[JsonProperty("roles")]
        //[NotMapped]
        //public List<> Roles { get; set; }

        private Status _status;
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        [NotMapped]
        public Status Status
        {
            get
            {
                return new StatusCacheService.RowService().ById(StatusId);
            }
            set
            {
                _status = value;
            }
        }
        /// <summary>
        /// 新密码
        /// </summary>
        [Description("新密码")]
        [JsonProperty("newPassword")]
        [NotMapped]
        public string NewPassword { get; set; }
        #endregion
    }
}
