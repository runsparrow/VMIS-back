using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.HttpClients.HttpModes.TreeMode
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TreeViewBase<T>
    {
        #region TreeViewBase 的基础方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public virtual List<NodeBase> ToTree(List<NodeBase> nodes)
        {
            List<NodeBase> rootNodes = nodes.Where(
                        node => node.Pid == nodes.Min(m => m.Pid)
                    ).ToList();
            LoopToAppendChildren(rootNodes, nodes);
            return rootNodes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootNodes"></param>
        /// <param name="nodes"></param>
        protected void LoopToAppendChildren(List<NodeBase> rootNodes, List<NodeBase> nodes)
        {
            foreach (var rootNode in rootNodes)
            {
                List<NodeBase> subNodes = nodes.Where(node => node.Pid == rootNode.Id).ToList();
                rootNode.Nodes = subNodes;
                LoopToAppendChildren(subNodes, nodes);
            }
        }
        #endregion

        #region NodeBase
        /// <summary>
        /// 
        /// </summary>
        public abstract class NodeBase
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "id")]
            public virtual int Id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "pid")]
            public virtual int Pid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "levelIndex")]
            public virtual int LevelIndex { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "key")]
            public virtual string Key { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "row")]
            public virtual object Row { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "nodes")]
            public virtual List<NodeBase> Nodes { get; set; }
        }

        #endregion

        #region ConfigBase
        /// <summary>
        /// 
        /// </summary>
        public abstract class ConfigBase
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "propertyBind")]
            public virtual InnerClassBase.PropertyBindBase PropertyBind { get; set; }
        }
        #endregion

        #region InnerClassBase

        /// <summary>
        /// 
        /// </summary>
        public abstract class InnerClassBase
        {
            #region IdSetBase
            /// <summary>
            /// 
            /// </summary>
            public abstract class IdSetBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "id")]
                public virtual int Id { get; set; }
            }
            #endregion

            #region LevelSetBase
            /// <summary>
            /// 
            /// </summary>
            public abstract class LevelSetBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "levelIndex")]
                public virtual int LevelIndex { get; set; }
            }
            #endregion

            #region KeySetBase
            /// <summary>
            /// 
            /// </summary>
            public abstract class KeySetBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "key")]
                public virtual string Key { get; set; }
            }
            #endregion

            #region PropertyBindBase
            /// <summary>
            /// 
            /// </summary>
            public abstract class PropertyBindBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "id")]
                public virtual string Id { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "pid")]
                public virtual string Pid { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "key")]
                public virtual string Key { get; set; }
            }
            #endregion
        }
        #endregion
    }
}
