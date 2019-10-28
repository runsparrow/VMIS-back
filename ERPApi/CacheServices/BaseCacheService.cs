using ERPApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ERPApi.CacheServices
{
    public class BaseCacheService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        public abstract class EF<T, TContext> : BaseService.EF<T, TContext>
            where T : class, new()
            where TContext : DbContext, new()
        {

        }
    }

}