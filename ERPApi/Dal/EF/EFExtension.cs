﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ERPApi.Dal.EFHelper
{
    /// <summary>
    /// 
    /// </summary>
    public static class EFExtension
    {

        #region Left Outer Join 扩展方法

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOuter"></typeparam>
        /// <typeparam name="TInner"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="outer"></param>
        /// <param name="inner"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IQueryable<TResult> LeftOuterJoin<TOuter, TInner, TKey, TResult>(
          this IQueryable<TOuter> outer,
          IQueryable<TInner> inner,
          Expression<Func<TOuter, TKey>> outerKeySelector,
          Expression<Func<TInner, TKey>> innerKeySelector,
          Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {

            // generic methods
            var selectManies = typeof(Queryable).GetMethods()
                .Where(x => x.Name == "SelectMany" && x.GetParameters().Length == 3)
                .OrderBy(x => x.ToString().Length)
                .ToList();
            var selectMany = selectManies.First();
            var select = typeof(Queryable).GetMethods().First(x => x.Name == "Select" && x.GetParameters().Length == 2);
            var where = typeof(Queryable).GetMethods().First(x => x.Name == "Where" && x.GetParameters().Length == 2);
            var groupJoin = typeof(Queryable).GetMethods().First(x => x.Name == "GroupJoin" && x.GetParameters().Length == 5);
            var defaultIfEmpty = typeof(Queryable).GetMethods().First(x => x.Name == "DefaultIfEmpty" && x.GetParameters().Length == 1);

            // need anonymous type here or let's use Tuple
            // prepares for:
            // var q2 = Queryable.GroupJoin(db.A, db.B, a => a.Id, b => b.IdA, (a, b) => new { a, groupB = b.DefaultIfEmpty() });
            var tuple = typeof(Tuple<,>).MakeGenericType(
                typeof(TOuter),
                typeof(IQueryable<>).MakeGenericType(
                    typeof(TInner)
                    )
                );
            var paramOuter = Expression.Parameter(typeof(TOuter));
            var paramInner = Expression.Parameter(typeof(IEnumerable<TInner>));
            var groupJoinExpression = Expression.Call(
                null,
                groupJoin.MakeGenericMethod(typeof(TOuter), typeof(TInner), typeof(TKey), tuple),
                new Expression[]
                    {
                    Expression.Constant(outer),
                    Expression.Constant(inner),
                    outerKeySelector,
                    innerKeySelector,
                    Expression.Lambda(
                        Expression.New(
                            tuple.GetConstructor(tuple.GetGenericArguments()),
                            new Expression[]
                                {
                                    paramOuter,
                                    Expression.Call(
                                        null,
                                        defaultIfEmpty.MakeGenericMethod(typeof (TInner)),
                                        new Expression[]
                                            {
                                                Expression.Convert(paramInner, typeof (IQueryable<TInner>))
                                            }
                                )
                                },
                            tuple.GetProperties()
                            ),
                        new[] {paramOuter, paramInner}
                )
                    }
                );

            // prepares for:
            // var q3 = Queryable.SelectMany(q2, x => x.groupB, (a, b) => new { a.a, b });
            var tuple2 = typeof(Tuple<,>).MakeGenericType(typeof(TOuter), typeof(TInner));
            var paramTuple2 = Expression.Parameter(tuple);
            var paramInner2 = Expression.Parameter(typeof(TInner));
            var paramGroup = Expression.Parameter(tuple);
            var selectMany1Result = Expression.Call(
                null,
                selectMany.MakeGenericMethod(tuple, typeof(TInner), tuple2),
                new Expression[]
                    {
                    groupJoinExpression,
                    Expression.Lambda(
                        Expression.Convert(Expression.MakeMemberAccess(paramGroup, tuple.GetProperty("Item2")),
                                           typeof (IEnumerable<TInner>)),
                        paramGroup
                ),
                    Expression.Lambda(
                        Expression.New(
                            tuple2.GetConstructor(tuple2.GetGenericArguments()),
                            new Expression[]
                                {
                                    Expression.MakeMemberAccess(paramTuple2, paramTuple2.Type.GetProperty("Item1")),
                                    paramInner2
                                },
                            tuple2.GetProperties()
                            ),
                        new[]
                            {
                                paramTuple2,
                                paramInner2
                            }
                )
                    }
                );

            // prepares for final step, combine all expressinos together and invoke:
            // var q4 = Queryable.SelectMany(db.A, a => q3.Where(x => x.a == a).Select(x => x.b), (a, b) => new { a, b });
            var paramTuple3 = Expression.Parameter(tuple2);
            var paramTuple4 = Expression.Parameter(tuple2);
            var paramOuter3 = Expression.Parameter(typeof(TOuter));
            var selectManyResult2 = selectMany
                .MakeGenericMethod(
                    typeof(TOuter),
                    typeof(TInner),
                    typeof(TResult)
                )
                .Invoke(
                    null,
                    new object[]
                        {
                        outer,
                        Expression.Lambda(
                            Expression.Convert(
                                Expression.Call(
                                    null,
                                    select.MakeGenericMethod(tuple2, typeof(TInner)),
                                    new Expression[]
                                        {
                                            Expression.Call(
                                                null,
                                                where.MakeGenericMethod(tuple2),
                                                new Expression[]
                                                    {
                                                        selectMany1Result,
                                                        Expression.Lambda(
                                                            Expression.Equal(
                                                                paramOuter3,
                                                                Expression.MakeMemberAccess(paramTuple4, paramTuple4.Type.GetProperty("Item1"))
                                                            ),
                                                            paramTuple4
                                                        )
                                                    }
                                            ),
                                            Expression.Lambda(
                                                Expression.MakeMemberAccess(paramTuple3, paramTuple3.Type.GetProperty("Item2")),
                                                paramTuple3
                                            )
                                        }
                                ),
                                typeof(IEnumerable<TInner>)
                            ),
                            paramOuter3
                        ),
                        resultSelector
                        }
                );

            return (IQueryable<TResult>)selectManyResult2;
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
    }
}