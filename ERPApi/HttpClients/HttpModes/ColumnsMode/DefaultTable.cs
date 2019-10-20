using Newtonsoft.Json;

namespace ERPApi.HttpClients.HttpModes.ColumnsMode
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultTable : IColumnBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "checkbox")]
        public bool Checkbox { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}