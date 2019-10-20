using ERPApi.Dal.EFHelper;
using ERPApi.Entities.AVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static ERPApi.Services.AVM.UserService;

namespace ERPApi.CacheServices.AVM
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCacheService : CacheServiceBase<User, VMISContext>
    {

        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : UserCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public override User Create(User user)
            {
                return User.Instance.Insert(user);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="users"></param>
            /// <returns></returns>
            public override List<User> Create(List<User> users)
            {
                users.ForEach(
                        user =>
                        {
                            User.Instance.Insert(user);
                        }
                    );
                return users;
            }
        }

        #endregion

        #region RPC UpdateMode
        /// <summary>
        /// UpdateMode Service
        /// </summary>
        public class UpdateService : UserCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public override User Update(User user)
            {
                return User.Instance.Update(user);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="users"></param>
            /// <returns></returns>
            public override List<User> Update(List<User> users)
            {
                users.ForEach(
                        user =>
                        {
                            User.Instance.Update(user);
                        }
                    );
                return users;
            }
        }
        #endregion

        #region RPC DeleteMode
        /// <summary>
        /// DeleteMode Service
        /// </summary>
        public class DeleteService : UserCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public override User Delete(User user)
            {
                return User.Instance.Delete(user);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="users"></param>
            /// <returns></returns>
            public override List<User> Delete(List<User> users)
            {
                users.ForEach(
                        user =>
                        {
                            User.Instance.Delete(user);
                        }
                    );
                return users;
            }
        }
        #endregion

        #region RPC Read ColumnsMode
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : UserCacheService
        {
            /// <summary>
            /// 返回字段集
            /// I.  只含本表字段
            /// </summary>
            /// <returns></returns>
            public User Sample()
            {
                try
                {
                    return new User();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// 返回字段集
            /// I.  含相关表字段
            /// </summary>
            /// <returns></returns>
            public User Full()
            {
                try
                {
                    return new User();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region RPC Read RowMode

        /// <summary>
        /// 
        /// </summary>
        public class RowService : UserCacheService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public User ById(int id, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLToList()
                                    .Where(row => row.Id == id)
                                    .SingleOrDefault()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 首记录
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="statusValues"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public User First(string keyWord, int[] statusValues, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var list = SQLToList();
                        // keyWord查询
                        list = KeyWordToList(list, keyWord);
                        // keyWordExt查询
                        list = KeyWordExtToList(list, keyWord);
                        // statusValues查询
                        list = StatusToList(list, statusValues);
                        // 返回结果
                        return SQLEntityToSingle(
                                list.FirstOrDefault()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 末记录
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="statusValues"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public User Last(string keyWord, int[] statusValues, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var list = SQLToList();
                        // keyWord查询
                        list = KeyWordToList(list, keyWord);
                        // keyWordExt查询
                        list = KeyWordExtToList(list, keyWord);
                        // statusValues查询
                        list = StatusToList(list, statusValues);
                        // 返回结果
                        return list.LastOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 下一条
            /// </summary>
            /// <param name="id"></param>
            /// <param name="keyWord"></param>
            /// <param name="statusValues"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public User Next(int id, string keyWord, int[] statusValues, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var list = SQLToList();
                        // keyWord查询
                        list = KeyWordToList(list, keyWord);
                        // keyWordExt查询
                        list = KeyWordExtToList(list, keyWord + "^Id>" + id);
                        // statusValues查询
                        list = StatusToList(list, statusValues);
                        // 返回结果
                        return list.FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 上一条
            /// </summary>
            /// <param name="id"></param>
            /// <param name="keyWord"></param>
            /// <param name="statusValues"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public User Prev(int id, string keyWord, int[] statusValues, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var list = SQLToList();
                        // keyWord查询
                        list = KeyWordToList(list, keyWord);
                        // keyWordExt查询
                        list = KeyWordExtToList(list, keyWord + "^Id<" + id);
                        // statusValues查询
                        list = StatusToList(list, statusValues);
                        // 返回结果
                        return list.FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        #endregion

        #region RPC Read RowsMode

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : UserCacheService
        {
            /// <summary>
            /// 返回全表数据
            /// I.  只在数据量可控是使用。
            /// </summary>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> All(params string[] entityAttrs)
            {
                try
                {
                    return SQLToList()
                        .OrderBy(row => row.Id)
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 模糊查询
            /// 1.  使用关键字进行模糊查询。
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ByKeyWord(string keyWord, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // 返回结果
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// 根据用户Id查询 返回角色集合
            /// </summary>
            /// <param name="roleId">用户Id</param>
            /// <returns></returns>
            public List<User> ByRoleId(int roleId)
            {
                try
                {
                    List<User> resultMaps = new List<User>();
                    //List<RERoleUser> reRoleUsers = new RERoleUserCacheService.RowsService().ByRoleId(roleId);
                    //reRoleUsers.ForEach(
                    //    reRoleUser =>
                    //    {
                    //        resultMaps.Add(reRoleUser.ToMap().User.ToMap());
                    //    }
                    //);
                    return resultMaps;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 根据 RoleId 查询数量
            /// </summary>
            /// <param name="roleId">状态Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public int CountByRoleId(int roleId, params string[] entityAttrs)
            {
                try
                {
                    //return new RERoleUserCacheService.RowsService().CountByRoleId(roleId);
                    return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 分页查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="pageIndex">页码</param>
            /// <param name="pageSize">每页显示数</param>
            /// <param name="statusValues">状态值</param>
            /// <param name="startDate">起始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="sort">排序</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> Page(string keyWord, int pageIndex, int pageSize, int[] statusValues, DateTime startDate, DateTime endDate, string sort, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // statusValues查询
                    list = StatusToList(list, statusValues);
                    // 时间范围查询
                    list = DateToList(list, startDate, endDate);
                    // 排序
                    list = SortToList(list, sort);
                    // 分页
                    list = PageToList(list, pageIndex, pageSize);
                    // 返回
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 分页计数
            /// I.  本方法用于配套分页查询。
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <param name="statusValues">可变参数</param>
            /// <param name="startDate">状态值</param>
            /// <param name="endDate">起始时间</param>
            /// <returns></returns>
            public int PageCount(string keyWord, int[] statusValues, DateTime startDate, DateTime endDate, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // statusValues查询
                    list = StatusToList(list, statusValues);
                    // 时间范围查询
                    list = DateToList(list, startDate, endDate);
                    // 返回
                    return list.Count();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 汇总信息
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="pageIndex"></param>
            /// <param name="pageSize"></param>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <param name="statusValues"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public SummaryEntity PageSummary(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, int[] statusValues, params string[] entityAttrs)
            {
                try
                {
                    // 返回
                    return new SummaryEntity();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region RPC Read SingleMode
        /// <summary>
        /// 
        /// </summary>
        public class SingleService : RowService
        {

        }

        #endregion

        #region RPC Read QueryMode

        /// <summary>
        /// 
        /// </summary>
        public class QueryService : RowsService
        {

        }

        #endregion

        #region RPC Read TreeMode

        /// <summary>
        /// 
        /// </summary>
        public class TreeService : UserCacheService
        {
            #region 调用RowService的方法
            /// <summary>
            ///  根据 id 查询
            ///  1. 本方法返回是单条记录
            /// </summary>
            /// <param name="id">id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ById(int id, params string[] entityAttrs)
            {
                List<User> users = new List<User>();
                users.Add(
                        new RowService().ById(id, entityAttrs)
                    );
                return users;
            }
            #endregion

            #region 调用RowsService的方法
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ByKeyWord(string keyWord, params string[] entityAttrs)
            {
                return new RowsService().ByKeyWord(keyWord, entityAttrs);
            }
            #endregion
        }
        #endregion

        #region Inner Method

        /// <summary>
        /// 
        /// </summary>
        public List<User> CacheAll()
        {
            try
            {
                return SQLToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="keyWord"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="statusValues"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private decimal Sum(Func<User, decimal> selector, string keyWord, DateTime startDate, DateTime endDate, int[] statusValues, params string[] entityAttrs)
        {
            try
            {
                // 定义
                var list = SQLToList();
                // keyWord查询
                list = KeyWordToList(list, keyWord);
                // keyWordExt查询
                list = KeyWordExtToList(list, keyWord);
                // statusValues查询
                list = StatusToList(list, statusValues);
                // 时间范围查询
                list = DateToList(list, startDate, endDate);
                // 返回
                return list.Sum(selector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="keyWord"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="statusValues"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private int Sum(Func<User, int> selector, string keyWord, DateTime startDate, DateTime endDate, int[] statusValues, params string[] entityAttrs)
        {
            try
            {
                // 定义
                var list = SQLToList();
                // keyWord查询
                list = KeyWordToList(list, keyWord);
                // keyWordExt查询
                list = KeyWordExtToList(list, keyWord);
                // statusValues查询
                list = StatusToList(list, statusValues);
                // 时间范围查询
                list = DateToList(list, startDate, endDate);
                // 返回
                return list.Sum(selector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private User SQLEntityToSingle(User entity)
        {
            if (entity == null)
                return null;
            else
            {
                // 主表
                User user = entity;
                // 返回
                return user;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        private List<User> KeyWordToList(List<User> list, string keyWord)
        {
            try
            {
                // 截取keyWord
                keyWord = keyWord.IndexOf("^") == -1 ? keyWord : keyWord.Substring(0, keyWord.IndexOf("^"));
                // #分割生成数组
                string[] ands = keyWord.Split('#');
                // 空格分割生成数组
                string[] ors = Regex.Split(keyWord, "\\s+", RegexOptions.IgnoreCase);
                // 多个条件精确查询，单个条件模糊查询
                if (ands.Length > 1)
                {
                    for (var i = 0; i < ands.Length; i++)
                    {
                        var andKeyWord = ands[i];
                        list = list.Where(row =>
                                row.Name.Contains(andKeyWord) ||
                                row.Mobile.Contains(andKeyWord) ||
                                row.Email.Contains(andKeyWord)
                            ).ToList();
                    }
                }
                else if (ors.Length > 1)
                {
                    list = list.Where(row =>
                            ors.Contains(row.Name) ||
                            ors.Contains(row.Mobile) ||
                            ors.Contains(row.Email)
                        ).ToList();
                }
                else
                {
                    list = list.Where(row =>
                            row.Name.Contains(keyWord) ||
                            row.Mobile.Contains(keyWord) ||
                            row.Email.Contains(keyWord)
                        ).ToList();
                }
                // 返回
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        private List<User> KeyWordExtToList(List<User> list, string keyWord)
        {
            try
            {
                if (keyWord.IndexOf("^") != -1)
                {
                    // 截取keyWordExt
                    var keyWordExt = keyWord.Substring(keyWord.IndexOf("^") + 1, keyWord.Length - keyWord.IndexOf("^") - 1);
                    // 拆分查询条件
                    var splits = keyWordExt.Split('^');
                    // 循环
                    for (var i = 0; i < splits.Length; i++)
                    {

                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private List<User> DateToList(List<User> list, DateTime startDate, DateTime endDate)
        {
            try
            {
                startDate = startDate == null ? DateTime.MinValue : startDate;
                endDate = endDate == null ? DateTime.MaxValue : endDate;
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="statusValues"></param>
        /// <returns></returns>
        private List<User> StatusToList(List<User> list, int[] statusValues)
        {
            try
            {
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private List<User> SortToList(List<User> list, string sort)
        {
            try
            {
                return list.OrderBy(row => row.Id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private List<User> PageToList(List<User> list, int pageIndex, int pageSize)
        {
            try
            {
                return list
                   .Take(pageIndex * pageSize)
                   .Skip(pageSize * (pageIndex - 1))
                   .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<User> SQLToList()
        {
            try
            {
                return User.Instance.CacheAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}