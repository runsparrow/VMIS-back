using ERPApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ERPApi.CacheServices
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public abstract class CacheBaseService<T, TContext> : BaseService<T, TContext>
        where T : class, new()
        where TContext : DbContext, new()
    {

    }

}