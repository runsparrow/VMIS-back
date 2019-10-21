using ERPApi.HttpClients.HttpModes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace ERPApi.Controllers
{
    /// <summary>
    /// Api Controller 基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TService"></typeparam>
    public abstract class ControllerBase<T, TService> : Controller
        where T : class
        where TService : class, new()
    {
        private TService service = new TService();

        #region Protected 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool Exists(int id)
        {
            return DbSetEntity().Count(e => (int)EntityPropertyValue(e, "Id") == id) > 0;
        }

        /// <summary>
        /// 从 TService 中获取 T 数据集合
        /// </summary>
        /// <returns>TService.T</returns>
        protected DbSet<T> DbSetEntity()
        {
            PropertyInfo p = service.GetType().GetProperty(typeof(T).Name);
            if (p == null)
            {
                throw new Exception("Not found this property");
            }
            return (DbSet<T>)p.GetValue(service);
        }

        /// <summary>
        /// 从 Model 中获取 属性值
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns>T.Property.Value</returns>
        protected object EntityPropertyValue(T entity, string propertyName)
        {
            PropertyInfo p = entity.GetType().GetProperty(propertyName);
            if (p == null)
            {
                throw new Exception("Not found this property");
            }
            return p.GetValue(entity);
        }

        /// <summary>
        /// 使用反射方法调用Service类中对应的方法。
        /// </summary>
        /// <param name="name">方法名</param>
        /// <param name="objs">参数</param>
        /// <returns></returns>
        protected virtual object ServiceInvokeValue(string name, params object[] objs)
        {
            MethodInfo[] mis = service.GetType().GetMethods();
            for (int index = 0; index < mis.Length; index++)
            {
                if (mis[index].Name.Equals(name))
                {
                    //判断参数是否完全匹配
                    ParameterInfo[] paramsInfo = mis[index].GetParameters();
                    //如果参数个数不匹配直接跳出本次循环
                    if (paramsInfo.Length != objs.Length)
                    {
                        continue;
                    }
                    //判断每一个参数类型是否完全匹配
                    bool flag = true;
                    for (int i = 0; i < paramsInfo.Length; i++)
                    {
                        if (paramsInfo[i].ParameterType.FullName != objs[i].GetType().FullName)
                        {
                            flag = false;
                        }
                    }
                    if (!flag)
                        continue;
                    //将 params object [] 参数转换成 invoke需要的 object [] 
                    object[] o = new object[objs.Length];
                    for (int i = 0; i < objs.Length; i++)
                    {
                        o[i] = objs[i];
                    }
                    //返回结果
                    return mis[index].Invoke(service, o);
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual object HttpEntityToResponse<TRequest>(TRequest request) where TRequest : class, new()
        {
            TRequest requestClass = new TRequest();
            MethodInfo m = requestClass.GetType().GetMethod("ToResponse");
            return m.Invoke(requestClass, new object[] { request });
        }

        #endregion
        
        #region RPC 方式

        #region CreateMode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(CreateMode<T>.Response response)
        {
            return Ok(response.Row);
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(UpdateMode<T>.Response response)
        {
            return Ok(response.Rows);
        }
        #endregion

        #region DeleteMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(DeleteMode<T>.Response response)
        {
            return Ok(response);
        }

        #endregion

        #region ColumnsMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(ColumnsMode<T>.Response response)
        {
            return Ok(response.Columns);
        }

        #endregion

        #region RowMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(RowMode<T>.Response response)
        {
            return Ok(response.Row);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(object result)
        {
            return Ok(result);
        }

        #endregion

        #region RowsMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(RowsMode<T>.Response response)
        {
            return Ok(response.Rows);
        }

        #endregion

        #region SingleMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(SingleMode<T>.Response response)
        {
            return Ok(response);
        }

        #endregion

        #region QueryMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(QueryMode<T>.Response response)
        {
            return Ok(response);
        }

        #endregion

        #region TreeMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(TreeMode<T>.Response response)
        {
            return Ok(response);
        }
        #endregion

        #endregion

        #region Common 方式
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual IActionResult ResponseOk(Response response)
        {
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual Response ToResponse(object obj)
        {
            return new Response()
            {
                Result = obj,
                Success = obj != null
            };
        }
        /// <summary>
        /// 
        /// </summary>
        public new class Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "result")]
            public object Result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "success")]
            public bool Success { get; set; }
        }

        #endregion

        #region ControllerHelper

        #region Convert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int ParseInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int[] ParseInts(string[] strs)
        {
            try
            {
                int[] results = new int[strs.Length];
                for (var i = 0; i < strs.Length; i++)
                {
                    results[i] = ParseInt(strs[i]);
                }
                return results;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public string[] ToParams(string[] args, int startIndex)
        {
            string[] paramsArgs = new string[args.Length - startIndex];
            Array.ConstrainedCopy(args, startIndex, paramsArgs, 0, args.Length - startIndex);
            return paramsArgs;
        }

        #endregion

        #region Application

        /// <summary>
        /// 
        /// </summary>
        public void AppReset()
        {
            try
            {
                //HttpContext.Current.Application.Remove("StatusApplication");
                //HttpContext.Current.Application.Add("StatusApplication", new Services.AVM.StatusService.RowsService().ToApplication());

                //HttpContext.Current.Application.Remove("DictionaryApplication");
                //HttpContext.Current.Application.Add("DictionaryApplication", new Services.AVM.DictionaryService.RowsService().ToApplication());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public Dictionary<string, StatusMap> StatusApplication
        //{
        //    get
        //    {
        //        return ((Dictionary<string, StatusMap>)HttpContext.Current.Application["StatusApplication"]);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public Dictionary<string, DictionaryMap> DictionaryApplication
        //{
        //    get
        //    {
        //        return ((Dictionary<string, DictionaryMap>)HttpContext.Current.Application["DictionaryApplication"]);
        //    }
        //}
        #endregion

        #region Auth
        /// <summary>
        /// 从Claim获取UserId
        /// </summary>
        /// <returns></returns>
        public int GetUserIdFromClaim()
        {
            return ParseInt(HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value);
        }
        #endregion

        #endregion
    }
}