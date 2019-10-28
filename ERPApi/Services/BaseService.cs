using ERPApi.CacheServices.WFM;
using Microsoft.EntityFrameworkCore;
using System;

namespace ERPApi.Services
{
    public class BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        public abstract class EF<T, TContext> : Dal.EF.BaseDal<T, TContext>
            where T : class
            where TContext : DbContext, new()
        {
            #region Ready To

            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            protected T ReadyToStatus(T entity, string statusKey)
            {
                try
                {
                    // 从缓存中获取
                    var status = new StatusCacheService.RowService().ByKey(statusKey);
                    // 使用反射赋值
                    if (entity.GetType().GetProperty("StatusId") != null)
                    {
                        entity.GetType().GetProperty("StatusId").SetValue(
                                entity,
                                status.Id
                            );
                    }
                    if (entity.GetType().GetProperty("StatusValue") != null)
                    {
                        entity.GetType().GetProperty("StatusValue").SetValue(
                            entity,
                            status.Value
                        );
                    }
                    if (entity.GetType().GetProperty("StatusName") != null)
                    {
                        entity.GetType().GetProperty("StatusName").SetValue(
                            entity,
                            status.Name
                        );
                    }
                    if (entity.GetType().GetProperty("Status") != null)
                    {
                        entity.GetType().GetProperty("Status").SetValue(
                            entity,
                            status
                        );
                    }
                    return entity;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion
        }
    }
}
