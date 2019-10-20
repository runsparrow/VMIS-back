using Newtonsoft.Json;

namespace ERPApi.HttpClients.HttpModes
{
    /// <summary>
    /// 
    /// </summary>
    public class ModeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public class Status
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "keys")]
            public virtual string[] Keys { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "values")]
            public virtual int[] Values { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "logics")]
            public virtual string [] Logics { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class Sort
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "name")]
            public virtual string Name { get; set; } = "";
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "mode")]
            public virtual string Mode { get; set; } = "asc";
        }
        /// <summary>
        /// 
        /// </summary>
        public class Function
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "name")]
            public virtual string Name { get; set; } = "";
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "args")]
            public virtual string[] Args { get; set; } = {""};
        }
    }
}