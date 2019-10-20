using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.AVM
{
    /// <summary>
    /// 角色用户关系
    /// </summary>
    [Table("AVM_RE_RoleUser")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class RERoleUser : EntityCacheBase<RERoleUser>
    {
        #region Property
        /// <summary>
        /// 用户Id
        /// </summary>
        [Description("用户Id")]
        [JsonProperty("userId")]
        public int UserId { get; set; } = 0;
        /// <summary>
        /// 角色Id
        /// </summary>
        [Description("角色Id")]
        [JsonProperty("roleId")]
        public int RoleId { get; set; } = 0;
        #endregion

        #region Not Mapped Property

        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        [JsonProperty("role")]
        [NotMapped]
        public Role Role { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        [JsonProperty("user")]
        [NotMapped]
        public User User { get; set; }
        #endregion

    }
}
