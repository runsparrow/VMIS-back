using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.Collections;

namespace ERPApi.HttpClients.HttpModes.TreeMode
{
    /// <summary>
    /// 
    /// </summary>
    public class BootstrapTreeView<T> : TreeViewBase<T>
    {
        #region 定义 BootstrapTreeView 的 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public List<Node> ToTree(List<T> rows, Config config)
        {
            List<Node> treeNodes = ToTree(
                    ConvertTo(rows, config)
                );
            FillTo(treeNodes, config);
            return treeNodes;
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
            try
            {
                foreach (T row in rows)
                {
                    Node node = new Node();
                    if (config.PropertyBind.Id != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Id) == null)
                            node.Id = int.Parse(config.PropertyBind.Id);
                        else
                            node.Id = (int)row.GetType().GetProperty(config.PropertyBind.Id).GetValue(row);
                    }
                    if (config.PropertyBind.Pid != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Pid) == null)
                            node.Pid = int.Parse(config.PropertyBind.Pid);
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Pid).GetValue(row) != null)
                                node.Pid = (int)row.GetType().GetProperty(config.PropertyBind.Pid).GetValue(row);
                        }
                    }
                    if (config.PropertyBind.Key != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Key) == null)
                            node.Key = config.PropertyBind.Key;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Key).GetValue(row) != null)
                                node.Key = row.GetType().GetProperty(config.PropertyBind.Key).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Text != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Text) == null)
                            node.Text = config.PropertyBind.Text;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Text).GetValue(row) != null)
                                node.Text = row.GetType().GetProperty(config.PropertyBind.Text).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Tooltip != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Tooltip) == null)
                            node.Tooltip = config.PropertyBind.Tooltip;
                        else
                        {
                            if(row.GetType().GetProperty(config.PropertyBind.Tooltip).GetValue(row)!=null)
                                node.Tooltip = row.GetType().GetProperty(config.PropertyBind.Tooltip).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Icon != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Icon) == null)
                            node.Icon = config.PropertyBind.Icon;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Icon).GetValue(row) != null)
                                node.Icon = row.GetType().GetProperty(config.PropertyBind.Icon).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.SelectedIcon != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.SelectedIcon) == null)
                            node.SelectedIcon = config.PropertyBind.SelectedIcon;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.SelectedIcon).GetValue(row) != null)
                                node.SelectedIcon = row.GetType().GetProperty(config.PropertyBind.SelectedIcon).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Color != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Color) == null)
                            node.Color = config.PropertyBind.Color;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Color).GetValue(row) != null)
                                node.Color = row.GetType().GetProperty(config.PropertyBind.Color).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.BackColor != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.BackColor) == null)
                            node.BackColor = config.PropertyBind.BackColor;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.BackColor).GetValue(row) != null)
                                node.BackColor = row.GetType().GetProperty(config.PropertyBind.BackColor).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Href != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Href) == null)
                            node.Href = config.PropertyBind.Href;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Href).GetValue(row) != null)
                                node.Href = row.GetType().GetProperty(config.PropertyBind.Href).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Selectable != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Selectable) == null)
                            node.Selectable = bool.Parse(config.PropertyBind.Selectable);
                        else
                            node.Selectable = (bool)row.GetType().GetProperty(config.PropertyBind.Selectable).GetValue(row);
                    }
                    if (config.PropertyBind.Levels != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Levels) == null)
                            node.Levels = int.Parse(config.PropertyBind.Levels);
                        else
                            node.Levels = (int)row.GetType().GetProperty(config.PropertyBind.Levels).GetValue(row);
                    }
                    if (config.PropertyBind.PreventUnselect != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.PreventUnselect) == null)
                            node.PreventUnselect = bool.Parse(config.PropertyBind.PreventUnselect);
                        else
                            node.PreventUnselect = (bool)row.GetType().GetProperty(config.PropertyBind.PreventUnselect).GetValue(row);
                    }
                    if (config.PropertyBind.AllowReselect != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.AllowReselect) == null)
                            node.AllowReselect = bool.Parse(config.PropertyBind.AllowReselect);
                        else
                            node.AllowReselect = (bool)row.GetType().GetProperty(config.PropertyBind.AllowReselect).GetValue(row);
                    }
                    if (config.PropertyBind.HideCheckbox != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.HideCheckbox) == null)
                            node.HideCheckbox = bool.Parse(config.PropertyBind.HideCheckbox);
                        else
                            node.HideCheckbox = (bool)row.GetType().GetProperty(config.PropertyBind.HideCheckbox).GetValue(row);
                    }
                    if (config.PropertyBind.State != null)
                    {
                        node.State.Checked = config.PropertyBind.State.Checked;
                        node.State.Expanded = config.PropertyBind.State.Expanded;
                        node.State.Selected = config.PropertyBind.State.Selected;
                        node.State.Disabled = config.PropertyBind.State.Disabled;
                    }
                    if (config.CheckedRows != null)
                    {
                        config.CheckedRows.ForEach(
                                checkedRow =>
                                {
                                    if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                                    {
                                        node.State.Checked = true;
                                    }
                                }
                            );
                    }
                    if (config.ExpandedRows != null)
                    {
                        config.ExpandedRows.ForEach(
                                checkedRow =>
                                {
                                    if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                                    {
                                        node.State.Expanded = true;
                                    }
                                }
                            );
                    }
                    if (config.SelectedRows != null)
                    {
                        config.SelectedRows.ForEach(
                                checkedRow =>
                                {
                                    if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                                    {
                                        node.State.Selected = true;
                                    }
                                }
                            );
                    }
                    if (config.DisabledRows != null)
                    {
                        config.DisabledRows.ForEach(
                                checkedRow =>
                                {
                                    if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                                    {
                                        node.State.Disabled = true;
                                    }
                                }
                            );
                    }
                    node.Row = row;

                    nodes.Add(node);

                    foreach (InnerClass.NodePropertyBind nodePropertyBind in config.NodePropertyBinds)
                    {
                        //反射创建List
                        IList nodesT = MakeListOfType(Assembly.GetExecutingAssembly().GetType(nodePropertyBind.NodePropertyClass));
                        //为List赋值
                        nodesT = (IList)row.GetType().GetProperty(nodePropertyBind.NodePropertyName).GetValue(row);
                        //循环进行配置
                        for (int i = 0; i < nodesT.Count; i++)
                        {
                            Node nodeT = new Node();
                            if (nodePropertyBind.Id != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Id) == null)
                                    nodeT.Id = int.Parse(nodePropertyBind.Id);
                                else
                                    nodeT.Id = (int)nodesT[i].GetType().GetProperty(nodePropertyBind.Id).GetValue(nodesT[i]);
                            }
                            if (nodePropertyBind.Pid != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Pid) == null)
                                    nodeT.Pid = int.Parse(nodePropertyBind.Pid);
                                else
                                    nodeT.Pid = (int)nodesT[i].GetType().GetProperty(nodePropertyBind.Pid).GetValue(nodesT[i]);
                            }
                            if (nodePropertyBind.Key != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Key) == null)
                                    nodeT.Key = nodePropertyBind.Key;
                                else
                                {
                                    if(nodesT[i].GetType().GetProperty(nodePropertyBind.Key).GetValue(nodesT[i])!=null)
                                        nodeT.Key = nodesT[i].GetType().GetProperty(nodePropertyBind.Key).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.Text != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Text) == null)
                                    nodeT.Text = nodePropertyBind.Text;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.Text).GetValue(nodesT[i]) != null)
                                        nodeT.Text = nodesT[i].GetType().GetProperty(nodePropertyBind.Text).GetValue(nodesT[i]).ToString();
                                }

                            }
                            if (nodePropertyBind.Tooltip != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Tooltip) == null)
                                    nodeT.Tooltip = nodePropertyBind.Tooltip;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.Tooltip).GetValue(nodesT[i]) != null)
                                        nodeT.Tooltip = nodesT[i].GetType().GetProperty(nodePropertyBind.Tooltip).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.Icon != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Icon) == null)
                                    nodeT.Icon = nodePropertyBind.Icon;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.Icon).GetValue(nodesT[i]) != null)
                                        nodeT.Icon = nodesT[i].GetType().GetProperty(nodePropertyBind.Icon).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.SelectedIcon != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.SelectedIcon) == null)
                                    nodeT.SelectedIcon = nodePropertyBind.SelectedIcon;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.SelectedIcon).GetValue(nodesT[i]) != null)
                                        nodeT.SelectedIcon = nodesT[i].GetType().GetProperty(nodePropertyBind.SelectedIcon).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.Color != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Color) == null)
                                    nodeT.Color = nodePropertyBind.Color;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.Color).GetValue(nodesT[i]) != null)
                                        nodeT.Color = nodesT[i].GetType().GetProperty(nodePropertyBind.Color).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.BackColor != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.BackColor) == null)
                                    nodeT.BackColor = nodePropertyBind.BackColor;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.BackColor).GetValue(nodesT[i]) != null)
                                        nodeT.BackColor = nodesT[i].GetType().GetProperty(nodePropertyBind.BackColor).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.Href != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Href) == null)
                                    nodeT.Href = nodePropertyBind.Href;
                                else
                                {
                                    if (nodesT[i].GetType().GetProperty(nodePropertyBind.Href).GetValue(nodesT[i]) != null)
                                        nodeT.Href = nodesT[i].GetType().GetProperty(nodePropertyBind.Href).GetValue(nodesT[i]).ToString();
                                }
                            }
                            if (nodePropertyBind.Selectable != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.Selectable) == null)
                                    nodeT.Selectable = bool.Parse(nodePropertyBind.Selectable);
                                else
                                    nodeT.Selectable = (bool)nodesT[i].GetType().GetProperty(nodePropertyBind.Selectable).GetValue(nodesT[i]);
                            }
                            if (nodePropertyBind.PreventUnselect != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.PreventUnselect) == null)
                                    nodeT.PreventUnselect = bool.Parse(nodePropertyBind.PreventUnselect);
                                else
                                    nodeT.PreventUnselect = (bool)nodesT[i].GetType().GetProperty(nodePropertyBind.PreventUnselect).GetValue(nodesT[i]);
                            }
                            if (nodePropertyBind.AllowReselect != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.AllowReselect) == null)
                                    nodeT.AllowReselect = bool.Parse(nodePropertyBind.AllowReselect);
                                else
                                    nodeT.AllowReselect = (bool)nodesT[i].GetType().GetProperty(nodePropertyBind.AllowReselect).GetValue(nodesT[i]);
                            }
                            if (nodePropertyBind.HideCheckbox != null)
                            {
                                if (nodesT[i].GetType().GetProperty(nodePropertyBind.HideCheckbox) == null)
                                    nodeT.HideCheckbox = bool.Parse(nodePropertyBind.HideCheckbox);
                                else
                                    nodeT.HideCheckbox = (bool)nodesT[i].GetType().GetProperty(nodePropertyBind.HideCheckbox).GetValue(nodesT[i]);
                            }
                            if (nodePropertyBind.State != null)
                            {
                                nodeT.State.Selected = nodePropertyBind.State.Selected;
                                nodeT.State.Checked = nodePropertyBind.State.Checked;
                                nodeT.State.Disabled = nodePropertyBind.State.Disabled;
                                nodeT.State.Expanded = nodePropertyBind.State.Expanded;
                            }
                            nodeT.Row = nodesT[i];

                            // 判断传入的是否是Map类型，如果Map进行类型转换
                            if (nodeT.Row.GetType().ToString() != nodePropertyBind.NodePropertyClass)
                            {
                                MethodInfo method = nodeT.Row.GetType().GetMethod("ToMap", new Type[] { });
                                if (method != null)
                                {
                                    nodeT.Row = method.Invoke(nodeT.Row, new object[] { });
                                }
                            }

                            nodes.Add(nodeT);
                        }
                    }

                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(string.Format("实体类中未找到匹配属性。错误信息：{0}", ex.ToString()));
            }
            return nodes;
        }

        /// <summary>
        /// 对泛型进行List实例化
        /// </summary>
        /// <param name="listType"></param>
        /// <returns></returns>
        private IList MakeListOfType(Type listType)
        {
            Type type = typeof(List<>);
            Type specificListType = type.MakeGenericType(listType);
            return (IList)Activator.CreateInstance(specificListType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private void FillTo(List<Node> nodes, Config config)
        {
            foreach (Node node in nodes)
            {
                //根据 IdSet 配置
                foreach (InnerClass.IdSet idSet in config.IdSets)
                {
                    if (node.Id == idSet.Id)
                    {
                        if (!string.IsNullOrEmpty(idSet.Text))
                            node.Text = idSet.Text;
                        if (!string.IsNullOrEmpty(idSet.Icon))
                            node.Icon = idSet.Icon;
                        if (idSet.SelectedIcon != null)
                            node.SelectedIcon = idSet.SelectedIcon;
                        if (!string.IsNullOrEmpty(idSet.Color))
                            node.Color = idSet.Color;
                        if (!string.IsNullOrEmpty(idSet.BackColor))
                            node.BackColor = idSet.BackColor;
                        if (!string.IsNullOrEmpty(idSet.Href))
                            node.Href = idSet.Href;
                        if (idSet.State != null)
                            node.State = idSet.State;
                        if (idSet.Tags != null)
                            node.Tags = idSet.Tags;
                    }
                    FillTo(node.Nodes, config);
                }
                //根据 LevelSet 配置
                foreach (InnerClass.LevelSet levelSet in config.LevelSets)
                {
                    if (node.LevelIndex == levelSet.LevelIndex)
                    {
                        if (!string.IsNullOrEmpty(levelSet.Text))
                            node.Text = levelSet.Text;
                        if (!string.IsNullOrEmpty(levelSet.Icon))
                            node.Icon = levelSet.Icon;
                        if (levelSet.SelectedIcon != null)
                            node.SelectedIcon = levelSet.SelectedIcon;
                        if (!string.IsNullOrEmpty(levelSet.Color))
                            node.Color = levelSet.Color;
                        if (!string.IsNullOrEmpty(levelSet.BackColor))
                            node.BackColor = levelSet.BackColor;
                        if (!string.IsNullOrEmpty(levelSet.Href))
                            node.Href = levelSet.Href;
                        if (levelSet.State != null)
                            node.State = levelSet.State;
                        if (levelSet.Tags != null)
                            node.Tags = levelSet.Tags;
                    }
                    FillTo(node.Nodes, config);
                }

                //根据 KeySet 配置
                foreach (InnerClass.KeySet keySet in config.KeySets)
                {
                    if (node.Key == keySet.Key)
                    {
                        if (!string.IsNullOrEmpty(keySet.Text))
                            node.Text = keySet.Text;
                        if (!string.IsNullOrEmpty(keySet.Icon))
                            node.Icon = keySet.Icon;
                        if (keySet.SelectedIcon != null)
                            node.SelectedIcon = keySet.SelectedIcon;
                        if (!string.IsNullOrEmpty(keySet.Color))
                            node.Color = keySet.Color;
                        if (!string.IsNullOrEmpty(keySet.BackColor))
                            node.BackColor = keySet.BackColor;
                        if (!string.IsNullOrEmpty(keySet.Href))
                            node.Href = keySet.Href;
                        if (keySet.State != null)
                            node.State = keySet.State;
                        if (keySet.Tags != null)
                            node.Tags = keySet.Tags;
                    }
                    FillTo(node.Nodes, config);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes">尚未排列成树形结构的Node集合</param>
        /// <returns></returns>
        protected List<Node> ToTree(List<Node> nodes)
        {
            List<Node> rootNodes = nodes.Where(
                        node => node.Pid == nodes.Min(m => m.Pid)
                    ).ToList();
            LoopToAppendChildren(rootNodes, nodes, 0);
            return rootNodes;
        }
        /// <summary>
        /// 节点递归方法
        /// </summary>
        /// <param name="rootNodes">已排列成树形结构的根节点</param>
        /// <param name="nodes">尚未排列成树形结构的Node集合</param>
        /// <param name="levelIndex">已排列成树形结构的根节点LevelIndex</param>
        protected void LoopToAppendChildren(List<Node> rootNodes, List<Node> nodes, int levelIndex)
        {
            foreach (var rootNode in rootNodes)
            {
                List<Node> subNodes = nodes.Where(node => node.Pid == rootNode.Id).ToList();
                rootNode.Nodes = subNodes;
                rootNode.LevelIndex = levelIndex;
                LoopToAppendChildren(subNodes, nodes, rootNode.LevelIndex + 1);
            }
        }

        #endregion

        #region 定义 BootstrapTreeView 的 Node 属性

        /// <summary>
        /// 
        /// </summary>
        public class Node : NodeBase
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "tooltip")]
            public string Tooltip { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "icon")]
            public string Icon { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "image")]
            //public string Image { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "selectedIcon")]
            public string SelectedIcon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "color")]
            public string Color { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "backColor")]
            public string BackColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "lazyLoad")]
            //public bool LazyLoad { get; set; } = false;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "selectable")]
            public bool Selectable { get; set; } = true;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "checkable")]
            public bool Checkable { get; set; } = true;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "state")]
            public InnerClass.State State { get; set; } = new InnerClass.State();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "tags")]
            public List<string> Tags { get; set; } = new List<string>();
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "tagsClass")]
            //public List<string> TagsClass { get; set; } = new List<string>();
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "dataAttr")]
            //public List<object> DataAttr { get; set; } = new List<object>();
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "class")]
            //public string Class { get; set; }



            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "borderColor")]
            //public string BorderColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "changedNodeColor")]
            //public string ChangedNodeColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "checkboxFirst")]
            //public bool CheckboxFirst { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "checkedIcon")]
            //public string CheckedIcon { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "collapseIcon")]
            //public string CollapseIcon { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "emptyIcon")]
            //public string EmptyIcon { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "expandIcon")]
            //public string ExpandIcon { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "loadingIcon")]
            //public string LoadingIcon { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "hierarchicalCheck")]
            //public bool HierarchicalCheck { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "propagateCheckEvent")]
            //public bool PropagateCheckEvent { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "highlightChanges")]
            //public bool HighlightChanges { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "highlightSearchResults")]
            //public bool HighlightSearchResults { get; set; } = true;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "highlightSelected")]
            //public bool HighlightSelected { get; set; } = true;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "levels")]
            public int Levels { get; set; } = 1;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "multiSelect")]
            //public bool MultiSelect { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "nodeIcon")]
            //public string NodeIcon { get; set; }
            /////// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "onhoverColor")]
            //public string OnhoverColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "partiallyCheckedIcon")]
            //public string PartiallyCheckedIcon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "preventUnselect")]
            public bool PreventUnselect { get; set; } = false;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "allowReselect")]
            public bool AllowReselect { get; set; } = true;
            /// <summary>
            /// 
            /// </summary>
            //[JsonProperty(PropertyName = "searchResultBackColor")]
            //public string SearchResultBackColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "searchResultColor")]
            //public string SearchResultColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "selectedBackColor")]
            //public string SelectedBackColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "selectedColor")]
            //public string SelectedColor { get; set; }
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "showBorder")]
            //public bool ShowBorder { get; set; } = true;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "hideCheckbox")]
            public bool HideCheckbox { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "showIcon")]
            //public bool ShowIcon { get; set; } = true;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "showImage")]
            //public bool ShowImage { get; set; } = false;
            ///// <summary>
            ///// 
            ///// </summary>
            //[JsonProperty(PropertyName = "showTags")]
            //public bool ShowTags { get; set; } = false;
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "href")]
            public string Href { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "nodes")]
            public new List<Node> Nodes { get; set; } = new List<Node>();
        }

        #endregion

        #region 定义 BootstrapTreeView 的相关配置 Config
        /// <summary>
        /// 
        /// </summary>
        public class Config : ConfigBase
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "checkedRows")]
            public virtual List<T> CheckedRows { get; set; } = new List<T>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "expandedRows")]
            public virtual List<T> ExpandedRows { get; set; } = new List<T>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "selectedRows")]
            public virtual List<T> SelectedRows { get; set; } = new List<T>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "disabledRows")]
            public virtual List<T> DisabledRows { get; set; } = new List<T>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "idSets")]
            public List<InnerClass.IdSet> IdSets { get; set; } = new List<InnerClass.IdSet>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "levelSets")]
            public List<InnerClass.LevelSet> LevelSets { get; set; } = new List<InnerClass.LevelSet>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "keySets")]
            public List<InnerClass.KeySet> KeySets { get; set; } = new List<InnerClass.KeySet>();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "propertyBind")]
            public new InnerClass.PropertyBind PropertyBind { get; set; } = new InnerClass.PropertyBind();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "nodePropertyBinds")]
            public List<InnerClass.NodePropertyBind> NodePropertyBinds = new List<InnerClass.NodePropertyBind>();
        }
        #endregion

        #region BootstrapTreeView 内部类 InnerClass
        /// <summary>
        /// 
        /// </summary>
        public class InnerClass : InnerClassBase
        {
            #region IdSet
            /// <summary>
            /// 树节点设置，用以替换Json中的对应内容。
            /// </summary>
            public class IdSet : IdSetBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "text")]
                public string Text { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "icon")]
                public string Icon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectedIcon")]
                public string SelectedIcon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "color")]
                public string Color { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "backColor")]
                public string BackColor { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "href")]
                public string Href { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectable")]
                public bool Selectable { get; set; } = true;
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "state")]
                public State State { get; set; } = new State();
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "tags")]
                public List<string> Tags { get; set; } = new List<string>();
            }
            #endregion

            #region LevelSet
            /// <summary>
            /// 
            /// </summary>
            public class LevelSet : LevelSetBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "text")]
                public string Text { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "icon")]
                public string Icon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectedIcon")]
                public string SelectedIcon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "color")]
                public string Color { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "backColor")]
                public string BackColor { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "href")]
                public string Href { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectable")]
                public bool Selectable { get; set; } = true;
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "state")]
                public State State { get; set; } = new State();
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "tags")]
                public List<string> Tags { get; set; } = new List<string>();
            }
            #endregion

            #region KeySet
            /// <summary>
            /// 
            /// </summary>
            public class KeySet : KeySetBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "text")]
                public string Text { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "icon")]
                public string Icon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectedIcon")]
                public string SelectedIcon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "color")]
                public string Color { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "backColor")]
                public string BackColor { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "href")]
                public string Href { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectable")]
                public bool Selectable { get; set; } = true;
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "state")]
                public State State { get; set; } = new State();
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "tags")]
                public List<string> Tags { get; set; } = new List<string>();
            }
            #endregion

            #region PropertyBind
            /// <summary>
            /// 用于指定树控件的属性分别对应的是实体类中的哪些字段
            ///     即：绑定树控件属性与实体类属性
            /// </summary>
            public class PropertyBind : PropertyBindBase
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "text")]
                public string Text { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "tooltip")]
                public string Tooltip { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "icon")]
                public string Icon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "image")]
                //public string Image { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectedIcon")]
                public string SelectedIcon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "color")]
                public string Color { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "backColor")]
                public string BackColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "lazyLoad")]
                //public string LazyLoad { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selectable")]
                public string Selectable { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "checkable")]
                public string Checkable { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "state")]
                public State State { get; set; } = new State();
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "class")]
                //public string Class { get; set; }



                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "borderColor")]
                //public string BorderColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "changedNodeColor")]
                //public string ChangedNodeColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "checkboxFirst")]
                //public string CheckboxFirst { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "checkedIcon")]
                //public string CheckedIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "collapseIcon")]
                //public string CollapseIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "emptyIcon")]
                //public string EmptyIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "expandIcon")]
                //public string ExpandIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "loadingIcon")]
                //public string LoadingIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "hierarchicalCheck")]
                //public string HierarchicalCheck { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "propagateCheckEvent")]
                //public string PropagateCheckEvent { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "highlightChanges")]
                //public string HighlightChanges { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "highlightSearchResults")]
                //public string HighlightSearchResults { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "highlightSelected")]
                //public string HighlightSelected { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "levels")]
                public string Levels { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                ////[JsonProperty(PropertyName = "multiSelect")]
                ////public string MultiSelect { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "nodeIcon")]
                //public string NodeIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "onhoverColor")]
                //public string OnhoverColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "partiallyCheckedIcon")]
                //public string PartiallyCheckedIcon { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "preventUnselect")]
                public string PreventUnselect { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "allowReselect")]
                public string AllowReselect { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "searchResultBackColor")]
                //public string SearchResultBackColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "searchResultColor")]
                //public string SearchResultColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "selectedBackColor")]
                //public string SelectedBackColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "selectedColor")]
                //public string SelectedColor { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "showBorder")]
                //public string ShowBorder { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "hideCheckbox")]
                public string HideCheckbox { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "showIcon")]
                //public string ShowIcon { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "showImage")]
                //public string ShowImage { get; set; }
                ///// <summary>
                ///// 
                ///// </summary>
                //[JsonProperty(PropertyName = "showTags")]
                //public string ShowTags { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "href")]
                public string Href { get; set; }
            }
            #endregion

            #region NodesPropertyBind

            /// <summary>
            /// 
            /// </summary>
            public class NodePropertyBind : PropertyBind
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "nodePropertyName")]
                public string NodePropertyName { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "nodePropertyClass")]
                public string NodePropertyClass { get; set; }
            }
            #endregion

            #region State
            /// <summary>
            /// bootstrapTreeView节点的State属性
            /// </summary>
            public class State
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "checked")]
                public bool Checked { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "disabled")]
                public bool Disabled { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "expanded")]
                public bool Expanded { get; set; }
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "selected")]
                public bool Selected { get; set; }
            }
            #endregion
        }
        #endregion

    }
}