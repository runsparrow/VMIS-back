using ERPApi.Dal.EF;
using ERPApi.Entities.AVM;
using ERPApi.Entities.WFM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ERPApi.Services.AVM
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : BaseService.EF<User, VMISContext>
    {

        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : UserService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private readonly TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public CreateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User Commit(User user)
            {
                try
                {
                    // 定义
                    User result = new User();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(
                                ReadyToCreate(user)
                            );
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="userList"></param>
            /// <returns></returns>
            public List<User> Commit(List<User> userList)
            {
                try
                {
                    // 定义
                    List<User> resultList = new List<User>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        userList.ForEach(user =>
                        {
                            resultList.Add(
                                    new CreateService().Commit(user)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User ToOpen(User user)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(user, "avm.user.open")
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User ToClose(User user)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(user, "avm.user.close")
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region RPC UpdateMode
        /// <summary>
        /// UpdateMode Service
        /// </summary>
        public class UpdateService : UserService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public UpdateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User Commit(User user)
            {
                try
                {
                    // 定义
                    User result = new User();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(
                                ReadyToUpdate(user)
                            );
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="userList"></param>
            /// <returns></returns>
            public List<User> Commit(List<User> userList)
            {
                try
                {
                    // 定义
                    List<User> resultList = new List<User>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        userList.ForEach(user =>
                        {
                            resultList.Add(
                                    new UpdateService().Commit(user)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User ToOpen(User user)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(user, "avm.user.open")
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User ToClose(User user)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(user, "avm.user.close")
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="key">用户名</param>
            /// <param name="password">密码</param>
            /// <param name="weChatNo">微信号</param>
            /// <param name="weChatOpenId">微信OpenId</param>
            /// <returns></returns>
            public User BindWeChat(string key, string password, string weChatNo, string weChatOpenId)
            {
                try
                {
                    var user = new RowService().Verify(key, password);
                    if (user != null)
                    {
                        user.WeChatNo = weChatNo;
                        user.WeChatOpenId = weChatOpenId;
                    }
                    return new UpdateService().Update(user);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region RPC DeleteMode
        /// <summary>
        /// DeleteMode Service
        /// </summary>
        public class DeleteService : UserService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public DeleteService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public User Commit(User user)
            {
                try
                {
                    // 定义
                    User result = new User();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(user);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="userList"></param>
            /// <returns></returns>
            public List<User> Commit(List<User> userList)
            {
                try
                {
                    // 定义
                    List<User> resultList = new List<User>();
                    // 事务
                    transService.TransRegist(delegate {
                        userList.ForEach(user =>
                        {
                            resultList.Add(
                                    new DeleteService().Commit(user)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region RPC Read ColumnsMode
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : UserService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public User Default()
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
        public class RowService : UserService
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
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.User.Id == id)
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
            /// 根据微信号查询
            /// </summary>
            /// <param name="weChatNo">Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public User ByWeChatNo(string weChatNo, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.User.WeChatNo == weChatNo)
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
            /// 根据微信OpenId查询
            /// </summary>
            /// <param name="weChatOpenId">Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public User ByWeChatOpenId(string weChatOpenId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.User.WeChatOpenId == weChatOpenId)
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
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            public User Verify(string key, string password)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 加密
                        password = EncryptHelper.GetBase64String(password);
                        return context.AVM_User.FirstOrDefault(row => (
                                (row.Name == key && row.Password == password) ||
                                (row.Mobile == key && row.Password == password) ||
                                (row.Email == key && row.Password == password)
                            ) && row.StatusId == 1
                        );
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
        public class RowsService : UserService
        {
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ByKeyWord(string keyWord, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.User.Name.Contains(keyWord))
                                    .OrderBy(row => row.User.Id)
                                    .ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 根据角色Id查询
            /// </summary>
            /// <param name="roleId"></param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ByRoleId(int roleId, params string[] entityAttrs)
            {
                try
                {
                    List<User> resultList = new List<User>();
                    new RERoleUserService.RowsService().ByRoleId(roleId, entityAttrs).ForEach(reRoleUser =>
                    {
                        resultList.Add(reRoleUser.User);
                    });
                    return resultList;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 根据功能Id查询
            /// </summary>
            /// <param name="registryId"></param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ByRegistryId(int registryId, params string[] entityAttrs)
            {
                try
                {
                    List<User> resultList = new List<User>();
                    new REUserRegistryService.RowsService().ByRegistryId(registryId, entityAttrs).ForEach(reUserRegistry =>
                    {
                        resultList.Add(reUserRegistry.User);
                    });
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            ///  分页
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="pageIndex">页码</param>
            /// <param name="pageSize">单页数据量</param>
            /// <param name="startDate">开始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="status">状态</param>
            /// <param name="sort">排序</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> Page(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, entityAttrs);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord, entityAttrs);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord, entityAttrs);
                        // 日期查询
                        queryable = DateQueryable(queryable, startDate, endDate, entityAttrs);
                        // status查询
                        queryable = StatusQueryable(queryable, status, entityAttrs);
                        // 排序
                        queryable = SortQueryable(queryable, sort, entityAttrs);
                        // 分页
                        queryable = PageQueryable(queryable, pageIndex, pageSize, entityAttrs);
                        // 返回
                        return SQLEntityToList(
                                queryable.ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 分页计数
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="startDate">开始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="status">状态</param
            /// <param name="sort">分页</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public int PageCount(string keyWord, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, entityAttrs);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord, entityAttrs);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord, entityAttrs);
                        // 日期查询
                        queryable = DateQueryable(queryable, startDate, endDate, entityAttrs);
                        // status查询
                        queryable = StatusQueryable(queryable, status, entityAttrs);
                        // 排序
                        queryable = SortQueryable(queryable, sort, entityAttrs);
                        // 返回
                        return queryable.Count();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            /// <summary>
            /// 汇总信息
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="pageIndex">页码</param>
            /// <param name="pageSize">单页数据量</param>
            /// <param name="startDate">开始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="status">状态</param
            /// <param name="sort">分页</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public SummaryEntity PageSummary(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, entityAttrs);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord, entityAttrs);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord, entityAttrs);
                        // 日期查询
                        queryable = DateQueryable(queryable, startDate, endDate, entityAttrs);
                        // status查询
                        queryable = StatusQueryable(queryable, status, entityAttrs);
                        // 排序
                        queryable = SortQueryable(queryable, sort, entityAttrs);
                        // 分页
                        queryable = PageQueryable(queryable, pageIndex, pageSize, entityAttrs);
                        // 返回
                        return new SummaryEntity();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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
        public class TreeService : UserService
        {
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<User> ByKeyWord(string keyWord, params string[] entityAttrs)
            {
                try
                {
                    return new RowsService().ByKeyWord(keyWord, entityAttrs);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region Inner Methods

        /// <summary>
        /// Create预备方法
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private User ReadyToCreate(User user)
        {
            try
            {
                // 加密
                user.Password = EncryptHelper.GetBase64String(user.Password);
                // 创建时间
                user.CreateDateTime = DateTime.Now;
                // 返回
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update预备方法
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private User ReadyToUpdate(User user)
        {
            try
            {
                // 修改时间
                user.EditDateTime = DateTime.Now;
                // 返回
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 默认查询
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> SQLQueryable(VMISContext context, params string[] entityAttrs)
        {
            var left = context.AVM_User.Select(Main => new
            {
                User = Main,
                Status = context.WFM_Status.FirstOrDefault(row => row.Id != row.Id)
            });

            foreach (string entityAttr in entityAttrs)
            {
                // SQLEntity.Status
                if (entityAttr.Equals("Status"))
                    left = left
                        // main: User | left : Status
                        .LeftOuterJoin(context.WFM_Status, Main => Main.User.StatusId, Left => Left.Id, (Main, Left) => new
                        {
                            Main.User,
                            Status = Left
                        });
            }
            var group = left.Select(Main => new SQLEntity
            {
                User = Main.User,
                Status = Main.Status
            });

            foreach (string entityAttr in entityAttrs)
            {

            }
            return group;
        }
        /// <summary>
        /// 关键字
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="keyWord"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> KeyWordQueryable(IQueryable<SQLEntity> queryable, string keyWord, params string[] entityAttrs)
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
                        queryable = queryable.Where(row =>
                                row.User.Name.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.User.Name)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.User.Name.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 关键字扩展
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="keyWord"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> KeyWordExtQueryable(IQueryable<SQLEntity> queryable, string keyWord, params string[] entityAttrs)
        {
            try
            {
                if (keyWord.IndexOf("^") != -1)
                {
                    // 截取keyWordExt
                    var keyWordExt = keyWord.Substring(keyWord.IndexOf("^") + 1, keyWord.Length - keyWord.IndexOf("^") - 1);
                    // 拆分查询条件
                    var splits = keyWordExt.Split('^');
                    // 遍历
                    for (var i = 0; i < splits.Length; i++)
                    {
                        if (splits[i].ToLower().Contains("statusid"))
                        {
                            int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.User.StatusId == statusId);
                        }
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> DateQueryable(IQueryable<SQLEntity> queryable, DateTime startDate, DateTime endDate, params string[] entityAttrs)
        {
            try
            {
                startDate = startDate == null ? DateTime.MinValue : startDate;
                endDate = endDate == null ? DateTime.MaxValue : endDate.TimeOfDay.TotalSeconds == 0 ? endDate.Date.AddDays(1).AddSeconds(-1) : endDate;
                if (entityAttrs.Contains("CreateDateTime"))
                {
                    return queryable
                        .Where(row =>
                            row.User.CreateDateTime >= startDate && row.User.CreateDateTime <= endDate
                        );
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="status"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> StatusQueryable(IQueryable<SQLEntity> queryable, ModeBase.Status status, params string[] entityAttrs)
        {
            try
            {
                return queryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="sort"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> SortQueryable(IQueryable<SQLEntity> queryable, ModeBase.Sort sort, params string[] entityAttrs)
        {
            try
            {
                if (sort.Name.ToLower().Equals("id"))
                {
                    if (sort.Mode.ToLower().Equals("asc"))
                    {
                        return queryable.OrderBy(row => row.User.Id);
                    }
                    else
                    {
                        return queryable.OrderByDescending(row => row.User.Id);
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private IQueryable<SQLEntity> PageQueryable(IQueryable<SQLEntity> queryable, int pageIndex, int pageSize, params string[] entityAttrs)
        {
            try
            {
                return queryable
                   .Take(pageIndex * pageSize)
                   .Skip(pageSize * (pageIndex - 1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private User SQLEntityToSingle(SQLEntity entity)
        {
            //判断搜索结果是否为空
            if (entity == null)
                return null;
            else
            {
                // 主表
                User user = entity.User;
                // 状态
                user.Status = entity.Status ?? null;
                // 返回
                return user;
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<User> SQLEntityToList(List<SQLEntity> list)
        {
            // 为 User 赋值
            List<User> userList = new List<User>();
            list.ForEach(
                row =>
                {
                    userList.Add(
                            SQLEntityToSingle(row)
                        );
                }
            );
            return userList;
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        private class SQLEntity
        {
            public User User { get; set; }
            //public HRMEmployee Employee { get; set; }
            public Status Status { get; set; }
            //public IEnumerable<Role> Roles { get; set; }
            //public IEnumerable<Registry> Registries { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class SummaryEntity
        {

        }
        #endregion
    }
}