using ERPApi.CacheServices.WFM;
using ERPApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.CRM
{
    /// <summary>
    /// 客户
    /// </summary>
    [Table("CRM_Customer")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Customer : EntityCacheBase<Customer>
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
        /// 客户名
        /// </summary>
        [StringLength(255)]
        [Description("客户名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(4000)]
        [Description("描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 默认联系人姓名
        /// </summary>
        [StringLength(255)]
        [Description("默认联系人姓名")]
        [JsonProperty("defaultName")]
        public string DefaultName { get; set; }
        /// <summary>
        /// 默认联系人手机
        /// </summary>
        [StringLength(255)]
        [Description("默认联系人手机")]
        [JsonProperty("defaultMobile")]
        public string DefaultMobile { get; set; }
        /// <summary>
        /// 默认联系人邮箱
        /// </summary>
        [StringLength(255)]
        [Description("默认联系人邮箱")]
        [JsonProperty("defaultEmail")]
        public string DefaultEmail { get; set; }
        /// <summary>
        /// 默认联系人地址
        /// </summary>
        [StringLength(255)]
        [Description("默认联系人地址")]
        [JsonProperty("defaultAdress")]
        public string DefaultAdress { get; set; }
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
        /// <summary>
        /// 状态Id
        /// </summary>
        [Description("状态Id")]
        [JsonProperty("statusId")]
        public int StatusId { get; set; } = 0;
        #endregion

        #region Not Mapped Property
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
        #endregion
    }
}
