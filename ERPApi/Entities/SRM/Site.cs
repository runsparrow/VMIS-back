using ERPApi.CacheServices.WFM;
using ERPApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApi.Entities.SRM
{
    /// <summary>
    /// 场地
    /// </summary>
    [Table("SRM_Site")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Site : EntityCacheBase<Site>
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
        /// 场地名
        /// </summary>
        [StringLength(255)]
        [Description("场地名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 场地代码
        /// </summary>
        [StringLength(255)]
        [Description("场地代码")]
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// 场地别名
        /// </summary>
        [StringLength(255)]
        [Description("场地别名")]
        [JsonProperty("alias")]
        public string Alias { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(4000)]
        [Description("描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 场地地址
        /// </summary>
        [StringLength(255)]
        [Description("场地地址")]
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// 场地电话
        /// </summary>
        [StringLength(255)]
        [Description("场地电话")]
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        [StringLength(255)]
        [Description("负责人姓名")]
        [JsonProperty("leaderName")]
        public string LeaderName { get; set; }
        /// <summary>
        /// 负责人手机
        /// </summary>
        [StringLength(255)]
        [Description("负责人手机")]
        [JsonProperty("leaderMobile")]
        public string LeaderMobile { get; set; }
        /// <summary>
        /// 负责人邮箱
        /// </summary>
        [StringLength(255)]
        [Description("负责人邮箱")]
        [JsonProperty("leaderEmail")]
        public string LeaderEmail { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("建造日期")]
        [JsonProperty("buildDate")]
        public DateTime BuildDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 属地Id
        /// </summary>
        [Description("属地Id")]
        [JsonProperty("regionId")]
        public int RegionId { get; set; }
        /// <summary>
        /// 停车位
        /// </summary>
        [Description("停车位")]
        [JsonProperty("parkingQuantity")]
        public int ParkingQuantity { get; set; }
        /// <summary>
        /// 展厅数量
        /// </summary>
        [Description("展厅数量")]
        [JsonProperty("venueQuantity")]
        public int VenueQuantity { get; set; }
        /// <summary>
        /// 客房数量
        /// </summary>
        [Description("客房数量")]
        [JsonProperty("roomQuantity")]
        public int RoomQuantity { get; set; }
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
