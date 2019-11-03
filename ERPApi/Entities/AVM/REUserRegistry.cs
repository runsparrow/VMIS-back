using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.AVM
{
    /// <summary>
    /// 用户功能关系
    /// </summary>
    [Table("AVM_RE_UserRegistry")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class REUserRegistry : BaseCacheEntity<REUserRegistry>
    {
        #region Property
        /// <summary>
        /// 用户Id
        /// </summary>
        [Description("用户Id")]
        [JsonProperty("userId")]
        public int UserId { get; set; } = -1;
        /// <summary>
        /// 功能Id
        /// </summary>
        [Description("功能Id")]
        [JsonProperty("registryId")]
        public int RegistryId { get; set; } = -1;
        #endregion

        #region Not Mapped Property

        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        [JsonProperty("user")]
        [NotMapped]
        public User User { get; set; }
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
