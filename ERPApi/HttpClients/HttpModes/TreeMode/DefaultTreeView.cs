using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.HttpClients.HttpModes.TreeMode
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultTreeView<T> : TreeViewBase<T>
    {
        #region 定义 DefaultTreeView 的 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public List<Node> ToTree(List<T> rows, Config config)
        {
            return ToTree(
                    ConvertTo(rows, config)
                );
        }
        /// <summary>
        /// 将Entity集合转换成尚未建立树形关系的Node集合
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private List<Node> ConvertTo(List<T> rows, Config config)
        {
            List<Node> nodes = new List<Node>();
            foreach (T row in rows)
            {
                Node node = new Node();
                node.Id = (int)row.GetType().GetProperty(config.PropertyBind.Id).GetValue(row);
                node.Pid = (int)row.GetType().GetProperty(config.PropertyBind.Pid).GetValue(row);
                node.Row = row;
                nodes.Add(node);
            }
            return nodes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private List<Node> ToTree(List<Node> nodes)
        {
            List<Node> rootNodes = nodes.Where(
                        node => node.Pid == nodes.Min(m => m.Pid)
                    ).ToList();
            LoopToAppendChildren(rootNodes, nodes);
            return rootNodes;
        }
        /// <summary>
        /// 节点递归方法
        /// </summary>
        /// <param name="rootNodes"></param>
        /// <param name="nodes"></param>
        private void LoopToAppendChildren(List<Node> rootNodes, List<Node> nodes)
        {
            foreach (var rootNode in rootNodes)
            {
                List<Node> subNodes = nodes.Where(node => node.Pid == rootNode.Id).ToList();
                rootNode.Nodes = subNodes;
                LoopToAppendChildren(subNodes, nodes);
            }
        }
        #endregion

        #region 定义 DefaultTreeView 的 Node 属性
        /// <summary>
        /// 
        /// </summary>
        public class Node : NodeBase
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "nodes")]
            public new List<Node> Nodes { get; set; } = new List<Node>();
        }
        #endregion

        #region 定义 DefaultTreeView 的相关配置
        /// <summary>
        /// 
        /// </summary>
        public class Config : ConfigBase
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "propertyBind")]
            public new InnerClass.PropertyBind PropertyBind { get; set; }
        }
        #endregion

        #region DefaultTreeView 内部类
        /// <summary>
        /// 
        /// </summary>
        public class InnerClass : InnerClassBase
        {
            /// <summary>
            /// 
            /// </summary>
            public class PropertyBind : PropertyBindBase
            {
                /// <summary>
                /// 树形结构对应的 Text 的字段
                /// </summary>
                [JsonProperty(PropertyName = "text")]
                public string Text { get; set; }
            }
        }
        #endregion

    }
}