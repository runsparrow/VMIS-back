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
    /// 展厅
    /// </summary>
    [Table("SRM_Venue")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Venue : BaseCacheEntity<Venue>
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
        /// 场地Id
        /// </summary>
        [Description("场地Id")]
        [JsonProperty("siteId")]
        public int SiteId { get; set; }
        /// <summary>
        /// 展厅名
        /// </summary>
        [StringLength(255)]
        [Description("展厅名")]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 展厅代码
        /// </summary>
        [StringLength(255)]
        [Description("展厅代码")]
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// 展厅别名
        /// </summary>
        [StringLength(255)]
        [Description("展厅别名")]
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
        /// 房号
        /// </summary>
        [StringLength(255)]
        [Description("房号")]
        [JsonProperty("roomNo")]
        public string RoomNo { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        [StringLength(255)]
        [Description("楼层")]
        [JsonProperty("floorNo")]
        public string FloorNo { get; set; }
        /// <summary>
        /// 层高
        /// </summary>
        [Description("层高")]
        [JsonProperty("height")]
        public decimal Height { get; set; } = 0;
        /// <summary>
        /// 面积
        /// </summary>
        [Description("面积")]
        [JsonProperty("area")]
        public decimal Area { get; set; } = 0;
        /// <summary>
        /// 容纳人数
        /// </summary>
        [Description("容纳人数")]
        [JsonProperty("holdQuantity")]
        public int HoldQuantity { get; set; }
        /// <summary>
        /// 展台尺寸限制
        /// </summary>
        [Description("展台尺寸限制")]
        [JsonProperty("sizeLimit")]
        public decimal SizeLimit { get; set; } = 0;
        /// <summary>
        /// 展台高度限制
        /// </summary>
        [Description("展台高度限制")]
        [JsonProperty("heightLimit")]
        public decimal HeightLimit { get; set; } = 0;
        /// <summary>
        /// 开口
        /// </summary>
        [StringLength(255)]
        [Description("开口")]
        [JsonProperty("opening")]
        public string Opening { get; set; }
        /// <summary>
        /// 吊点
        /// </summary>
        [StringLength(255)]
        [Description("吊点")]
        [JsonProperty("suspension")]
        public string Suspension { get; set; }
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
