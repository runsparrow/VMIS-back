using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ERPApi.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class EntityCacheBase<T> : EntityBase
        where T : class, new()
    {
        private static T entity = null;
        private static ICacheManager<object> manager = null;
        private static List<T> list = new List<T>();

        private static string cacheName = null;

        /// <summary>
        /// 单件实例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (entity == null)
                {
                    entity = new T();
                    cacheName = ((TableAttribute)entity.GetType().GetCustomAttributes(false)[0]).Name;
                }
                if (manager == null)
                {
                    manager = CacheFactory.Build("getStartedCache", settings =>
                    {
                        settings.WithMicrosoftMemoryCacheHandle("handleName");
                    });
                }
                return entity;
            }
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> CacheAll()
        {
            var value = manager.Get(cacheName) as List<T>;
            if (value == null)
            {
                var type = Type.GetType("ERPApi.Services." + entity.GetType().Namespace.Substring(entity.GetType().Namespace.LastIndexOf('.') + 1) + "." + entity.GetType().Name + "Service+RowsService");
                list = (List<T>)type.GetMethod("Read", new Type[] { }).Invoke(Activator.CreateInstance(type), null);
                value = list;
                manager.Add(cacheName, value);
            }
            else
            {

            }
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        public void Set(List<T> ts)
        {
            manager.Add(cacheName, ts);
        }
        /// <summary>
        /// 插入新的记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Insert(T t)
        {
            // 赋值
            entity = t;
            list = CacheAll();
            //先获取全部记录，然后加入记录
            if (!list.Contains(t))
            {
                list.Add(t);
            }
            //重新设置缓存
            manager.Update(cacheName, v => list);
            return t;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Update(T t)
        {
            // 赋值
            list = CacheAll();
            int index = list.FindIndex(row => (int)row.GetType().GetProperty("Id").GetValue(row) == (int)t.GetType().GetProperty("Id").GetValue(t));
            if (index == -1)
            {
                list.Add(t);
            }
            else
            {
                list[index] = t;
            }
            //重新设置缓存
            manager.Update(cacheName, v => list);
            return t;
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Delete(T t)
        {
            // 赋值
            entity = t;
            list = CacheAll();
            // 删除记录
            if (list.Contains(t, PopupComparer.Default))
            {
                list.RemoveAll(EqualPredicate);
            }
            manager.Update(cacheName, v => list);
            return t;
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            // 赋值
            list = CacheAll();
            list.Clear();
            manager.Update(cacheName, v => list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool EqualPredicate(T x)
        {
            return x.GetType().GetProperty("Id").GetValue(x).ToString().Equals(entity.GetType().GetProperty("Id").GetValue(entity).ToString());
        }

        #region PopupComparer Class

        /// <summary>
        /// 描述：弹出模型对象列表比较器(根据ID比较)
        /// </summary>
        public class PopupComparer : IEqualityComparer<T>
        {
            /// <summary>
            /// 
            /// </summary>
            public static PopupComparer Default = new PopupComparer();

            #region IEqualityComparer<T> 成员

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public bool Equals(T x, T y)
            {
                return x.GetType().GetProperty("Id").GetValue(x).ToString().Equals(y.GetType().GetProperty("Id").GetValue(y).ToString());
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public int GetHashCode(T t)
            {
                return t.GetHashCode();
            }

            #endregion
        }

        #endregion
    }
}