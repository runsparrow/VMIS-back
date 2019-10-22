using ERPApi.CacheServices.WFM;
using ERPApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.BPM
{
    /// <summary>
    /// 任务
    /// </summary>
    [Table("BPM_Task")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Task : EntityCacheBase<Task>
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
        /// 任务名
        /// </summary>
        [StringLength(255)]
        [Description("任务名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        [Description("任务类型")]
        [JsonProperty("typeId")]
        public int TypeId { get; set; } = 0;
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(4000)]
        [Description("描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 接待人Id
        /// </summary>
        [Description("接待人Id")]
        [JsonProperty("receptionId")]
        public int ReceptionId { get; set; } = 0;
        /// <summary>
        /// 接待时间
        /// </summary>
        [Description("接待时间")]
        [JsonProperty("receptionDateTime")]
        public DateTime ReceptionDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        [JsonProperty("customerId")]
        public int CustomerId { get; set; } = 0;
        /// <summary>
        /// 对接人姓名
        /// </summary>
        [StringLength(255)]
        [Description("对接人姓名")]
        [JsonProperty("dockingName")]
        public string DockingName { get; set; }
        /// <summary>
        /// 对接人手机
        /// </summary>
        [StringLength(255)]
        [Description("对接人手机")]
        [JsonProperty("dockingMobile")]
        public string DockingMobile { get; set; }
        /// <summary>
        /// 对接人邮箱
        /// </summary>
        [StringLength(255)]
        [Description("对接人邮箱")]
        [JsonProperty("dockingEmail")]
        public string DockingEmail { get; set; }
        /// <summary>
        /// 对接人地址
        /// </summary>
        [StringLength(255)]
        [Description("对接人地址")]
        [JsonProperty("dockingAddress")]
        public string DockingAddress { get; set; }
        /// <summary>
        /// 场地Id
        /// </summary>
        [Description("场地Id")]
        [JsonProperty("siteId")]
        public int SiteId { get; set; } = 0;
        /// <summary>
        /// 展厅Id
        /// </summary>
        [Description("展厅Id")]
        [JsonProperty("venueId")]
        public int VenueId { get; set; } = 0;
        /// <summary>
        /// 访客人数
        /// </summary>
        [Description("访客人数")]
        [JsonProperty("visitorQuantity")]
        public int VisitorQuantity { get; set; } = 0;
        /// <summary>
        /// 泊车数量
        /// </summary>
        [Description("泊车数量")]
        [JsonProperty("parkingQuantity")]
        public int ParkingQuantity { get; set; }
        /// <summary>
        /// 是否搭建
        /// </summary>
        [Description("是否搭建")]
        [JsonProperty("isBuild")]
        public bool IsBuild { get; set; } = false;
        /// <summary>
        /// 是否茶歇
        /// </summary>
        [Description("是否茶歇")]
        [JsonProperty("isBreak")]
        public bool IsBreak { get; set; } = false;
        /// <summary>
        /// 是否需要设备支持
        /// </summary>
        [Description("是否需要设备支持")]
        [JsonProperty("isEquipment")]
        public bool IsEquipment { get; set; } = false;
        /// <summary>
        /// 任务要求
        /// </summary>
        [StringLength(4000)]
        [Description("任务要求")]
        [JsonProperty("demand")]
        public string Demand { get; set; }
        /// <summary>
        /// 入场时间
        /// </summary>
        [Description("入场时间")]
        [JsonProperty("inDateTime")]
        public DateTime InDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 离场时间
        /// </summary>
        [Description("离场时间")]
        [JsonProperty("outDateTime")]
        public DateTime OutDateTime { get; set; } = DateTime.MinValue;
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
