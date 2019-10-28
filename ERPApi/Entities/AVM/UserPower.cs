using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.AVM
{
    /// <summary>
    /// 用户权限
    /// </summary>
    [Table("AVM_UserPower")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class UserPower : BaseCacheEntity<UserPower>
    {
        #region Property
        /// <summary>
        /// 用户Id
        /// </summary>
        [Description("用户Id")]
        [JsonProperty("userId")]
        public int UserId { get; set; } = 0;
        /// <summary>
        /// 功能Id
        /// </summary>
        [Description("功能键")]
        [JsonProperty("registryId")]
        public int RegistryId { get; set; } = 0;
        /// <summary>
        /// 用户享有的权限Id
        /// </summary>
        [StringLength(int.MaxValue)]
        [Description("用户享有的权限Id")]
        [JsonProperty("powerIds")]
        public string PowerIds { get; set; }
        #endregion

        #region Not Mapped Property

        #endregion

    }
}
