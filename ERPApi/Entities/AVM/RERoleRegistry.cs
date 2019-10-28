using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.AVM
{
    /// <summary>
    /// 角色功能关系
    /// </summary>
    [Table("AVM_RE_RoleRegistry")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class RERoleRegistry : BaseCacheEntity<RERoleRegistry>
    {
        #region Property
        /// <summary>
        /// 角色Id
        /// </summary>
        [Description("角色Id")]
        [JsonProperty("roleId")]
        public int RoleId { get; set; } = 0;
        /// <summary>
        /// 功能Id
        /// </summary>
        [Description("功能Id")]
        [JsonProperty("registryId")]
        public int RegistryId { get; set; } = 0;
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
        /// 功能
        /// </summary>
        [Description("功能")]
        [JsonProperty("registry")]
        [NotMapped]
        public Registry Registry { get; set; }

        #endregion

    }
}
