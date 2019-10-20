using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using ERPApi.HttpClients.HttpModes.ColumnsMode;

namespace ERPApi.HttpClients.HttpModes
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnsMode<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public class Request
        {
            /// <summary>
            /// JWT的Token
            /// </summary>
            [JsonProperty(PropertyName = "token")]
            public virtual string Token { get; set; } = "";
            /// <summary>
            /// Service中的方法
            /// </summary>
            [JsonProperty(PropertyName = "function")]
            public virtual ModeBase.Function Function { get; set; } = new ModeBase.Function();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "pluginConfig")]
            public Config PluginConfig { get; set; } = new Config();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Response ToResponse(T entity)
            {
                // JwtOptions.Validate(Token);
                Response response = new Response();
                response.Request = this;
                response.Entity = entity;
                return response;
            }

            #region Config 内部类
            /// <summary>
            /// 
            /// </summary>
            public class Config
            {
                /// <summary>
                /// 
                /// </summary>
                [JsonIgnore]
                public string Plugin { get; } = "DefaultTable";
                /// <summary>
                /// 
                /// </summary>
                [JsonProperty(PropertyName = "firstCheckbox")]
                public bool FirstCheckbox { get; set; } = true;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public class Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "request")]
            public virtual Request Request { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "entity")]
            public virtual T Entity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "columns")]
            public virtual List<IColumnBase> Columns
            {
                get
                {
                    return ToColumns(Activator.CreateInstance<T>() , Request.PluginConfig);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="requestConfig"></param>
            /// <returns></returns>
            public virtual List<IColumnBase> ToColumns(T entity, Request.Config requestConfig)
            {
                List<IColumnBase> columnList = new List<IColumnBase>();
                PropertyInfo[] properties = entity.GetType().GetProperties();
                if (requestConfig.FirstCheckbox)
                {
                    IColumnBase column = (IColumnBase)Activator.CreateInstance(Type.GetType("ERPApi.HttpClients.HttpModes.ColumnsMode." + requestConfig.Plugin), true);
                    column.Checkbox = true;
                    columnList.Add(column);
                }
                foreach (PropertyInfo p in properties)
                {
                    IColumnBase column = (IColumnBase)Activator.CreateInstance(Type.GetType("ERPApi.HttpClients.HttpModes.ColumnsMode." + requestConfig.Plugin), true);
                    column.Field = p.Name;

                    DescriptionAttribute[] desc = (DescriptionAttribute[])p.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if(desc.Length > 0)
                        column.Title = desc[0].Description;
                    else
                        column.Title = p.Name;
                    columnList.Add(column);
                }
                return columnList;
            }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "error")]
            public virtual string Error { get; set; }

        }
    }
}