using ERPApi.Dal.EF;
using ERPApi.Entities.AVM;
using ERPApi.HttpClients.HttpModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ERPApi.Services.AVM
{
    /// <summary>
    /// 
    /// </summary>
    public class RERoleRegistryService : BaseService.EF<RERoleRegistry, VMISContext>
    {
        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : RERoleRegistryService
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
            /// <param name="reRoleRegistry"></param>
            /// <returns></returns>
            public RERoleRegistry Commit(RERoleRegistry reRoleRegistry)
            {
                try
                {
                    // 定义
                    RERoleRegistry result = new RERoleRegistry();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(
                                ReadyToCreate(reRoleRegistry)
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
            /// <param name="reRoleRegistryList"></param>
            /// <returns></returns>
            public List<RERoleRegistry> Commit(List<RERoleRegistry> reRoleRegistryList)
            {
                try
                {
                    // 定义
                    List<RERoleRegistry> resultList = new List<RERoleRegistry>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        reRoleRegistryList.ForEach(reRoleRegistry =>
                        {
                            resultList.Add(
                                    new CreateService().Commit(reRoleRegistry)
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

        #region RPC UpdateMode
        /// <summary>
        /// UpdateMode Service
        /// </summary>
        public class UpdateService : RERoleRegistryService
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
            /// <param name="reRoleRegistry"></param>
            /// <returns></returns>
            public RERoleRegistry Commit(RERoleRegistry reRoleRegistry)
            {
                try
                {
                    // 定义
                    RERoleRegistry result = new RERoleRegistry();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(
                                ReadyToUpdate(reRoleRegistry)
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
            /// <param name="reRoleRegistryList"></param>
            /// <returns></returns>
            public List<RERoleRegistry> Commit(List<RERoleRegistry> reRoleRegistryList)
            {
                try
                {
                    // 定义
                    List<RERoleRegistry> resultList = new List<RERoleRegistry>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        reRoleRegistryList.ForEach(reRoleRegistry =>
                        {
                            resultList.Add(
                                    new UpdateService().Commit(reRoleRegistry)
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

        #region RPC DeleteMode
        /// <summary>
        /// DeleteMode Service
        /// </summary>
        public class DeleteService : RERoleRegistryService
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
            /// <param name="reRoleRegistry"></param>
            /// <returns></returns>
            public RERoleRegistry Commit(RERoleRegistry reRoleRegistry)
            {
                try
                {
                    // 定义
                    RERoleRegistry result = new RERoleRegistry();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(reRoleRegistry);
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
            /// <param name="reRoleRegistryList"></param>
            /// <returns></returns>
            public List<RERoleRegistry> Commit(List<RERoleRegistry> reRoleRegistryList)
            {
                try
                {
                    // 定义
                    List<RERoleRegistry> resultList = new List<RERoleRegistry>();
                    // 事务
                    transService.TransRegist(delegate {
                        reRoleRegistryList.ForEach(reRoleRegistry =>
                        {
                            resultList.Add(
                                    new DeleteService().Commit(reRoleRegistry)
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
        public class ColumnsService : RERoleRegistryService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public RERoleRegistry Default()
            {
                try
                {
                    return new RERoleRegistry();
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
        public class RowService : RERoleRegistryService
        {
            /// <summary>
            /// 查询唯一值
            /// </summary>
            /// <param name="registryId"></param>
            /// <param name="roleId"></param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public RERoleRegistry Only(int registryId, int roleId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.RERoleRegistry.RegistryId == registryId && row.RERoleRegistry.RoleId == roleId)
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
        public class RowsService : RERoleRegistryService
        {
            /// <summary>
            /// 根据功能Id查询
            /// </summary>
            /// <param name="registryId">功能Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<RERoleRegistry> ByRegistryId(int registryId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        entityAttrs[entityAttrs.Length] = "Role";
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.RERoleRegistry.RegistryId == registryId)
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
            /// <param name="roleId">角色Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<RERoleRegistry> ByRoleId(int roleId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        entityAttrs[entityAttrs.Length] = "Registry";
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.RERoleRegistry.RoleId == roleId)
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
            public List<RERoleRegistry> Page(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
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
            /// <param name="sort">排序</param>
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
            /// <param name="status">状态</param>
            /// <param name="sort">排序</param>
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
        public class TreeService : RERoleRegistryService
        {
            /// <summary>
            /// 查询唯一值
            /// </summary>
            /// <param name="registryId">功能Id</param>
            /// <param name="roleId">角色Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public RERoleRegistry Only(int registryId, int roleId, params string[] entityAttrs)
            {
                try
                {
                    return new RowService().Only(registryId, roleId, entityAttrs);
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
        /// <param name="reRoleRegistry"></param>
        /// <returns></returns>
        private RERoleRegistry ReadyToCreate(RERoleRegistry reRoleRegistry)
        {
            try
            {
                return reRoleRegistry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update预备方法
        /// </summary>
        /// <param name="reRoleRegistry"></param>
        /// <returns></returns>
        private RERoleRegistry ReadyToUpdate(RERoleRegistry reRoleRegistry)
        {
            try
            {
                return reRoleRegistry;
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
            var left = context.AVM_RE_RoleRegistry.Select(Main => new
            {
                RERoleRegistry = Main,
                Registry = context.AVM_Registry.FirstOrDefault(row => row.Id != row.Id),
                Role = context.AVM_Role.FirstOrDefault(row => row.Id != row.Id)
            });

            foreach (string entityAttr in entityAttrs)
            {
                // SQLEntity.Registry
                if (entityAttr.ToLower().Equals("registry"))
                {
                    left = left.LeftOuterJoin(context.AVM_Registry, Main => Main.RERoleRegistry.RegistryId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.RERoleRegistry,
                        Registry = Left,
                        Main.Role
                    });
                }
                // SQLEntity.Role
                if (entityAttr.ToLower().Equals("role"))
                {
                    left = left.LeftOuterJoin(context.AVM_Role, Main => Main.RERoleRegistry.RoleId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.RERoleRegistry,
                        Main.Registry,
                        Role = Left
                    });
                }
            }
            var group = left.Select(Main => new SQLEntity
            {
                RERoleRegistry = Main.RERoleRegistry,
                Registry = Main.Registry,
                Role = Main.Role
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
                    }
                }
                else if (ors.Length > 1)
                {

                }
                else
                {

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
                        if (splits[i].ToLower().StartsWith("registryid"))
                        {
                            int registryId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.RERoleRegistry.RegistryId == registryId);
                        }
                        else if (splits[i].ToLower().StartsWith("roleid"))
                        {
                            int roleId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.RERoleRegistry.RoleId == roleId);
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
                if (sort.Name.ToLower().Equals("registryid"))
                {
                    if (sort.Mode.ToLower().Equals("asc"))
                    {
                        return queryable.OrderBy(row => row.RERoleRegistry.RegistryId);
                    }
                    else
                    {
                        return queryable.OrderByDescending(row => row.RERoleRegistry.RegistryId);
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
        private RERoleRegistry SQLEntityToSingle(SQLEntity entity)
        {
            //判断搜索结果是否为空
            if (entity == null)
                return null;
            else
            {
                // 主表
                RERoleRegistry reRoleRegistry = entity.RERoleRegistry;
                // 功能
                reRoleRegistry.Registry = entity.Registry ?? null;
                // 角色
                reRoleRegistry.Role = entity.Role ?? null;
                // 返回
                return reRoleRegistry;
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<RERoleRegistry> SQLEntityToList(List<SQLEntity> list)
        {
            // 为 RERoleRegistry 赋值
            List<RERoleRegistry> reRoleRegistryList = new List<RERoleRegistry>();
            list.ForEach(
                row =>
                {
                    reRoleRegistryList.Add(
                            SQLEntityToSingle(row)
                        );
                }
            );
            return reRoleRegistryList;
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        private class SQLEntity
        {
            public RERoleRegistry RERoleRegistry { get; set; }
            public Registry Registry { get; set; }
            public Role Role { get; set; }
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