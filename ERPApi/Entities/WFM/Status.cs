using ERPApi.CacheServices.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.WFM
{
    /// <summary>
    /// 状态
    /// </summary>
    [Table("WFM_Status")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Status : BaseCacheEntity<Status>
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
        /// 父节点Id
        /// </summary>
        [Description("#")]
        [JsonProperty("pid")]
        public int Pid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(255)]
        [Description("用户名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 状态路径
        /// </summary>
        [StringLength(4000)]
        [Description("状态路径")]
        [JsonProperty("path")]
        public string Path { get; set; }
        /// <summary>
        /// 状态键名
        /// </summary>
        [StringLength(255)]
        [Description("状态键名")]
        [JsonProperty("key")]
        public string Key { get; set; }
        /// <summary>
        /// 状态键值
        /// </summary>
        [Description("状态键值")]
        [JsonProperty("value")]
        public int Value { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        [StringLength(4000)]
        [Description("状态描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; }
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
        /// 修改时间
        /// </summary>
        [Description("修改时间")]
        [JsonProperty("editDateTime")]
        public DateTime EditDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 修改人Id
        /// </summary>
        [Description("修改人Id")]
        [JsonProperty("editUserId")]
        public int EditUserId { get; set; } = 0;
        #endregion

        #region Not Mapped Property

        private Status _parentStatus;
        /// <summary>
        /// 父状态
        /// </summary>
        [Description("父状态")]
        [JsonProperty("parentStatus")]
        [NotMapped]
        public Status ParentStatus
        {
            get
            {
                return new StatusCacheService.RowService().ById(Pid);
            }
            set
            {
                _parentStatus = value;
            }
        }
        #endregion
    }
}
