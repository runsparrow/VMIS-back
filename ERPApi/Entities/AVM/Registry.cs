using ERPApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.AVM
{
    /// <summary>
    /// 功能
    /// </summary>
    [Table("AVM_Registry")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Registry : EntityCacheBase<Registry>
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
        /// 父Id
        /// </summary>
        [Description("父Id")]
        [JsonProperty("pid")]
        public int Pid { get; set; }
        /// <summary>
        /// 功能名
        /// </summary>
        [StringLength(255)]
        [Description("功能名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 功能路径
        /// </summary>
        [StringLength(4000)]
        [Description("功能路径")]
        [JsonProperty("path")]
        public string Path { get; set; }
        /// <summary>
        /// 功能键名
        /// </summary>
        [StringLength(255)]
        [Description("功能键名")]
        [JsonProperty("key")]
        public string Key { get; set; }
        /// <summary>
        /// 功能键值
        /// </summary>
        [StringLength(255)]
        [Description("功能键值")]
        [JsonProperty("value")]
        public string Value { get; set; }
        /// <summary>
        /// 功能路由
        /// </summary>
        [StringLength(500)]
        [Description("功能路由")]
        [JsonProperty("route")]
        public string Route { get; set; }
        /// <summary>
        /// 功能Url
        /// </summary>
        [StringLength(500)]
        [Description("功能Url")]
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(4000)]
        [Description("描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 功能等级
        /// </summary>
        [Description("功能等级")]
        [JsonProperty("level")]
        public int Level { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        public DateTime CreateDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 创建人Id
        /// </summary>
        [Description("创建人Id")]
        [JsonProperty("createUserId")]
        public int CreateUserId { get; set; } = 0;
        /// <summary>
        ///修改时间
        /// </summary>
        [Description("修改时间")]
        [JsonProperty("editDateTime")]
        public DateTime EditDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        ///修改人Id
        /// </summary>
        [Description("修改人Id")]
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
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        [NotMapped]
        public Status Status { get; set; }
        #endregion
    }
}
