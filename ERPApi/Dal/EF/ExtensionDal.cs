using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ERPApi.Dal.EF
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionDal
    {

        #region Left Outer Join 扩展方法

        ///<summary>
        /// Implement Left Outer join implemented by calling GroupJoin and
        /// SelectMany within this extension method
        ///</summary>
        ///<typeparam name="TOuter">Outer Type</typeparam>
        ///<typeparam name="TInner">Inner Type</typeparam>
        ///<typeparam name="TKey">Key Type</typeparam>
        ///<typeparam name="TResult">Result Type</typeparam>
        ///<param name="outer">Outer set</param>
        ///<param name="inner">Inner set</param>
        ///<param name="outerKeySelector">Outer Key Selector</param>
        ///<param name="innerKeySelector">Inner Key Selector</param>
        ///<param name="resultSelector">Result Selector</param>
        ///<returns>IQueryable Result set</returns>
        public static IQueryable<TResult> LeftOuterJoin<TOuter, TInner, TKey, TResult>(
            this IQueryable<TOuter> outer,
            IQueryable<TInner> inner,
            Expression<Func<TOuter, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            //LinqKit allows easy runtime evaluation of inline invoked expressions
            //without manually writing expression trees.
            //Tell LinqKit to convert everything into an expression tree.
            return outer.AsExpandable().GroupJoin(
                inner,
                outerKeySelector,
                innerKeySelector,
                (outerItem, innerItems) => new { outerItem, innerItems }
            ).SelectMany(
                joinResult => joinResult.innerItems.DefaultIfEmpty(),
                (joinResult, innerItem) =>resultSelector.Invoke(joinResult.outerItem, innerItem)
            );
        }
        #endregion

        #region And Or
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        /// <summary>
        /// false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                    (Expression.Or(expr1.Body, invokedExpr), expr1.Parameters);
        }
        /// <summary>
        /// true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                                Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                    (Expression.And(expr1.Body, invokedExpr), expr1.Parameters);
        }
        #endregion

        #region Mergin

        /// <summary>
        ///  将Request传入的Entity与原始Entity进行比较并合并
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbEntity">原始Entity</param>
        /// <param name="reqEntity">由Request传入的Entity</param>
        /// <returns></returns>
        public static TEntity MergeFrom<TEntity>(this TEntity dbEntity, TEntity reqEntity)
        {
            if (reqEntity.GetType() == dbEntity.GetType())
            {
                PropertyInfo[] properties = dbEntity.GetType().GetProperties();

                foreach (var p in properties)
                {
                    var reqEntityValue = p.GetValue(reqEntity, null);
                    if (reqEntityValue != null)
                    {
                        if (p.IsMapped())
                        {
                            if (reqEntityValue != GetDefault(p.GetType()))
                            {
                                p.SetValue(dbEntity, reqEntityValue, null);
                            }
                        }
                    }
                }
            }
            return dbEntity;
        }
        /// <summary>
        /// 判断属性是否有效，即能否存入数据库
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsMapped(this PropertyInfo p)
        {
            return p.CustomAttributes.Where(x => x.AttributeType.Name == "NotMappedAttribute").ToList().Count == 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
        #endregion
    }
}