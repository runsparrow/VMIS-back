using ERPApi.Dal.EFHelper;
using ERPApi.Entities.AVM;
using ERPApi.Entities.WFM;
using ERPApi.HttpClients.HttpModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ERPApi.Services.AVM
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistryService : ServiceBase<Registry, VMISContext>
    {
        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : RegistryService
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry Commit(Registry registry)
            {
                try
                {
                    // 定义
                    Registry result = new Registry();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(
                                ReadyToCreate(registry)
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
            /// <param name="registryList"></param>
            /// <returns></returns>
            public List<Registry> Commit(List<Registry> registryList)
            {
                try
                {
                    // 定义
                    List<Registry> resultList = new List<Registry>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        registryList.ForEach(registry =>
                        {
                            resultList.Add(
                                    new CreateService().Commit(registry)
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry ToOpen(Registry registry)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(registry, "avm.registry.open")
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry ToClose(Registry registry)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(registry, "avm.registry.close")
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
        public class UpdateService : RegistryService
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry Commit(Registry registry)
            {
                try
                {
                    // 定义
                    Registry result = new Registry();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(
                                ReadyToUpdate(registry)
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
            /// <param name="registryList"></param>
            /// <returns></returns>
            public List<Registry> Commit(List<Registry> registryList)
            {
                try
                {
                    // 定义
                    List<Registry> resultList = new List<Registry>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        registryList.ForEach(registry =>
                        {
                            resultList.Add(
                                    new UpdateService().Commit(registry)
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry ToOpen(Registry registry)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(registry, "avm.registry.open")
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry ToClose(Registry registry)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(registry, "avm.registry.close")
                        );
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
        public class DeleteService : RegistryService
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
            /// <param name="registry"></param>
            /// <returns></returns>
            public Registry Commit(Registry registry)
            {
                try
                {
                    // 定义
                    Registry result = new Registry();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(registry);
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
            /// <param name="registryList"></param>
            /// <returns></returns>
            public List<Registry> Commit(List<Registry> registryList)
            {
                try
                {
                    // 定义
                    List<Registry> resultList = new List<Registry>();
                    // 事务
                    transService.TransRegist(delegate {
                        registryList.ForEach(registry =>
                        {
                            resultList.Add(
                                    new DeleteService().Commit(registry)
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
        public class ColumnsService : RegistryService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Registry Default()
            {
                try
                {
                    return new Registry();
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
        public class RowService : RegistryService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <returns></returns>
            public Registry ById(int id)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context)
                                    .Where(row => row.Registry.Id == id)
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
            /// 根据功能键名查询
            /// </summary>
            /// <param name="key">功能键名</param>
            /// <returns></returns>
            public Registry ByKey(string key)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context)
                                    .Where(row => row.Registry.Key == key)
                                    .SingleOrDefault()
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
        public class RowsService : RegistryService
        {
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <returns></returns>
            public List<Registry> ByKeyWord(string keyWord)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context)
                                    .Where(row => row.Registry.Name.Contains(keyWord))
                                    .OrderBy(row => row.Registry.Id)
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
            /// 根据父Id查询
            /// </summary>
            /// <param name="pid">父Id</param>
            /// <returns></returns>
            public List<Registry> ByPid(int pid)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context)
                                    .Where(row => row.Registry.Pid == pid)
                                    .OrderBy(row => row.Registry.Id)
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
            /// 根据功能路径查询
            /// </summary>
            /// <param name="path">功能路径</param>
            /// <returns></returns>
            public List<Registry> ByPath(string path)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context)
                                    .Where(row => row.Registry.Path.StartsWith(path))
                                    .OrderBy(row => row.Registry.Id)
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
            public List<Registry> Page(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
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
            /// 1.  本方法用于配套分页查询。
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="startDate">开始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="status">状态</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public int PageCount(string keyWord, DateTime startDate, DateTime endDate, ModeBase.Status status, params string[] entityAttrs)
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
            /// <param name="keyWord"></param>
            /// <param name="pageIndex"></param>
            /// <param name="pageSize"></param>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <param name="status"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public SummaryEntity PageSummary(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, params string[] entityAttrs)
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
        public class TreeService : RegistryService
        {
            /// <summary>
            /// 根据Id查询
            /// </summary>
            /// <param name="id">id</param>
            /// <returns></returns>
            public Registry ById(int id)
            {
                try
                {
                    return new RowService().ById(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 根据功能键名查询
            /// </summary>
            /// <param name="key">功能键名</param>
            /// <returns></returns>
            public Registry ByKey(string key)
            {
                try
                {
                    return new RowService().ByKey(key);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <returns></returns>
            public List<Registry> ByKeyWord(string keyWord)
            {
                try
                {
                    return new RowsService().ByKeyWord(keyWord);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 根据父Id查询
            /// </summary>
            /// <param name="pid">父Id</param>
            /// <returns></returns>
            public List<Registry> ByPid(int pid)
            {
                try
                {
                    return new RowsService().ByPid(pid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 根据功能路径查询
            /// </summary>
            /// <param name="path">功能路径</param>
            /// <returns></returns>
            public List<Registry> ByPath(string path)
            {
                try
                {
                    return new RowsService().ByPath(path);
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
        /// <param name="registry"></param>
        /// <returns></returns>
        private Registry ReadyToCreate(Registry registry)
        {
            try
            {
                return registry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update预备方法
        /// </summary>
        /// <param name="registry"></param>
        /// <returns></returns>
        private Registry ReadyToUpdate(Registry registry)
        {
            try
            {
                return registry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 字段类型decimal的合计方法
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="keyWord"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private decimal Sum(Expression<Func<SQLEntity, decimal>> selector, string keyWord, DateTime startDate, DateTime endDate, ModeBase.Status status, params string[] entityAttrs)
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
                    // 返回
                    return queryable.Sum(selector);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 字段类型int的合计方法
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="keyWord"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private int Sum(Expression<Func<SQLEntity, int>> selector, string keyWord, DateTime startDate, DateTime endDate, ModeBase.Status status, params string[] entityAttrs)
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
                    // 返回
                    return queryable.Sum(selector);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
            var left = context.AVM_Registry.Select(Main => new
            {
                Registry = Main,
                Status = context.WFM_Status.FirstOrDefault(row => row.Id != row.Id)
            });

            foreach (string entityAttr in entityAttrs)
            {
                // SQLEntity.Status
                if (entityAttr.Equals("Status"))
                    left = left
                        // main: Registry | left : Status
                        .LeftOuterJoin(context.WFM_Status, Main => Main.Registry.StatusId, Left => Left.Id, (Main, Left) => new
                        {
                            Main.Registry,
                            Status = Left
                        });
            }
            var group = left.Select(Main => new SQLEntity
            {
                Registry = Main.Registry,
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
                                row.Registry.Name.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Registry.Name)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Registry.Name.Contains(keyWord)
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
                            queryable = queryable.Where(row => row.Registry.StatusId == statusId);
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
                            row.Registry.CreateDateTime >= startDate && row.Registry.CreateDateTime <= endDate
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
                        return queryable.OrderBy(row => row.Registry.Id);
                    }
                    else
                    {
                        return queryable.OrderByDescending(row => row.Registry.Id);
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
        private Registry SQLEntityToSingle(SQLEntity entity)
        {
            //判断搜索结果是否为空
            if (entity == null)
                return null;
            else
            {
                // 主表
                Registry registry = entity.Registry;
                // 状态
                registry.Status = entity.Status ?? null;
                // 返回
                return registry;
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<Registry> SQLEntityToList(List<SQLEntity> list)
        {
            // 为 Registry 赋值
            List<Registry> registryList = new List<Registry>();
            list.ForEach(
                row =>
                {
                    registryList.Add(
                            SQLEntityToSingle(row)
                        );
                }
            );
            return registryList;
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        private class SQLEntity
        {
            public Registry Registry { get; set; }
            public Status Status { get; set; }
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