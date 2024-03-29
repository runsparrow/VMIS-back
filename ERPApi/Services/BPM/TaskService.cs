﻿using ERPApi.Dal.EF;
using ERPApi.Entities.AVM;
using ERPApi.Entities.BPM;
using ERPApi.Entities.CRM;
using ERPApi.Entities.SRM;
using ERPApi.Entities.WFM;
using ERPApi.HttpClients.HttpModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ERPApi.Services.BPM
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskService : BaseService.EF<Task, VMISContext>
    {
        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : TaskService
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task Commit(Task task)
            {
                try
                {
                    // 定义
                    Task result = new Task();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(
                                ReadyToCreate(task)
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
            /// <param name="taskList"></param>
            /// <returns></returns>
            public List<Task> Commit(List<Task> taskList)
            {
                try
                {
                    // 定义
                    List<Task> resultList = new List<Task>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        taskList.ForEach(task =>
                        {
                            resultList.Add(
                                    new CreateService().Commit(task)
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task ToOpen(Task task)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(task, "bpm.task.open")
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task ToClose(Task task)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(task, "bpm.task.close")
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
        public class UpdateService : TaskService
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task Commit(Task task)
            {
                try
                {
                    // 定义
                    Task result = new Task();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(
                                ReadyToUpdate(task)
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
            /// <param name="taskList"></param>
            /// <returns></returns>
            public List<Task> Commit(List<Task> taskList)
            {
                try
                {
                    // 定义
                    List<Task> resultList = new List<Task>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        taskList.ForEach(task =>
                        {
                            resultList.Add(
                                    new UpdateService().Commit(task)
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task ToOpen(Task task)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(task, "bpm.task.open")
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task ToClose(Task task)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(task, "bpm.task.close")
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
        public class DeleteService : TaskService
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
            /// <param name="task"></param>
            /// <returns></returns>
            public Task Commit(Task task)
            {
                try
                {
                    // 定义
                    Task result = new Task();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(task);
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
            /// <param name="taskList"></param>
            /// <returns></returns>
            public List<Task> Commit(List<Task> taskList)
            {
                try
                {
                    // 定义
                    List<Task> resultList = new List<Task>();
                    // 事务
                    transService.TransRegist(delegate {
                        taskList.ForEach(task =>
                        {
                            resultList.Add(
                                    new DeleteService().Commit(task)
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
        public class ColumnsService : TaskService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Task Default()
            {
                try
                {
                    return new Task();
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
        public class RowService : TaskService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">唯一标识</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public Task ById(int id, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                               SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.Id == id)
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
        public class RowsService : TaskService
        {
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> ByKeyWord(string keyWord, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.Name.Contains(keyWord))
                                    .OrderBy(row => row.Task.Id)
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
            /// 根据类型Id查询
            /// </summary>
            /// <param name="typeId">类型Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> ByTypeId(int typeId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.TypeId == typeId)
                                    .OrderBy(row => row.Task.Id)
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
            /// 根据接待人Id查询
            /// </summary>
            /// <param name="receptionId">接待人Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> ByReceptionId(int receptionId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.ReceptionId == receptionId)
                                    .OrderBy(row => row.Task.Id)
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
            /// 根据客户Id查询
            /// </summary>
            /// <param name="customerId">客户Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> ByCustomerId(int customerId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.CustomerId == customerId)
                                    .OrderBy(row => row.Task.Id)
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
            /// 根据场地Id查询
            /// </summary>
            /// <param name="siteId">场地Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> BySiteId(int siteId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.SiteId == siteId)
                                    .OrderBy(row => row.Task.Id)
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
            /// 根据场馆Id查询
            /// </summary>
            /// <param name="venueId">场馆Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> ByVenueId(int venueId, params string[] entityAttrs)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, entityAttrs)
                                    .Where(row => row.Task.VenueId == venueId)
                                    .OrderBy(row => row.Task.Id)
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
            public List<Task> Page(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
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
        public class TreeService : TaskService
        {
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Task> ByKeyWord(string keyWord, params string[] entityAttrs)
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
        /// <param name="task"></param>
        /// <returns></returns>
        private Task ReadyToCreate(Task task)
        {
            try
            {
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update预备方法
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private Task ReadyToUpdate(Task task)
        {
            try
            {
                return task;
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
            var left = context.BPM_Task.Select(Main => new
            {
                Task = Main,
                Reception = context.AVM_User.FirstOrDefault(row => row.Id != row.Id),
                Customer = context.CRM_Customer.FirstOrDefault(row => row.Id != row.Id),
                Site = context.SRM_Site.FirstOrDefault(row => row.Id != row.Id),
                Venue = context.SRM_Venue.FirstOrDefault(row => row.Id != row.Id),
                Status = context.WFM_Status.FirstOrDefault(row => row.Id != row.Id)
            });

            foreach (string entityAttr in entityAttrs)
            {
                // SQLEntity.Reception
                if (entityAttr.ToLower().Equals("reception"))
                {
                    left = left.LeftOuterJoin(context.AVM_User, Main => Main.Task.ReceptionId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.Task,
                        Reception = Left,
                        Main.Customer,
                        Main.Site,
                        Main.Venue,
                        Main.Status
                    });
                }
                // SQLEntity.Customer
                if (entityAttr.ToLower().Equals("customer"))
                {
                    left = left.LeftOuterJoin(context.CRM_Customer, Main => Main.Task.CustomerId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.Task,
                        Main.Reception,
                        Customer = Left,
                        Main.Site,
                        Main.Venue,
                        Main.Status
                    });
                }
                // SQLEntity.Site
                if (entityAttr.ToLower().Equals("site"))
                {
                    left = left.LeftOuterJoin(context.SRM_Site, Main => Main.Task.SiteId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.Task,
                        Main.Reception,
                        Main.Customer,
                        Site = Left,
                        Main.Venue,
                        Main.Status
                    });
                }
                // SQLEntity.Venue
                if (entityAttr.ToLower().Equals("venue"))
                {
                    left = left.LeftOuterJoin(context.SRM_Venue, Main => Main.Task.VenueId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.Task,
                        Main.Reception,
                        Main.Customer,
                        Main.Site,
                        Venue = Left,
                        Main.Status
                    });
                }
                // SQLEntity.Status
                if (entityAttr.ToLower().Equals("status"))
                {
                    left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Task.StatusId, Left => Left.Id, (Main, Left) => new
                    {
                        Main.Task,
                        Main.Reception,
                        Main.Customer,
                        Main.Site,
                        Main.Venue,
                        Status = Left
                    });
                }
            }
            var group = left.Select(Main => new SQLEntity
            {
                Task = Main.Task,
                Reception = Main.Reception,
                Customer = Main.Customer,
                Site = Main.Site,
                Venue = Main.Venue,
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
                                row.Task.Name.Contains(andKeyWord) ||
                                row.Task.Demand.Contains(andKeyWord) ||
                                row.Task.Desc.Contains(andKeyWord) ||
                                row.Task.DockingName.Contains(andKeyWord) ||
                                row.Task.DockingMobile.Contains(andKeyWord) ||
                                row.Task.DockingEmail.Contains(andKeyWord) ||
                                row.Task.DockingAddress.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Task.Name) ||
                            ors.Contains(row.Task.Demand) ||
                            ors.Contains(row.Task.Desc) ||
                            ors.Contains(row.Task.DockingName) ||
                            ors.Contains(row.Task.DockingMobile) ||
                            ors.Contains(row.Task.DockingEmail) ||
                            ors.Contains(row.Task.DockingAddress)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Task.Name.Contains(keyWord) ||
                            row.Task.Demand.Contains(keyWord) ||
                            row.Task.Desc.Contains(keyWord) ||
                            row.Task.DockingName.Contains(keyWord) ||
                            row.Task.DockingMobile.Contains(keyWord) ||
                            row.Task.DockingEmail.Contains(keyWord) ||
                            row.Task.DockingAddress.Contains(keyWord)
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
                        if (splits[i].ToLower().StartsWith("statusid"))
                        {
                            int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Task.StatusId == statusId);
                        }
                        else if (splits[i].ToLower().StartsWith("receptionid"))
                        {
                            int receptionId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Task.ReceptionId == receptionId);
                        }
                        else if (splits[i].ToLower().StartsWith("venueid"))
                        {
                            int venueId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Task.VenueId == venueId);
                        }
                        else if (splits[i].ToLower().StartsWith("siteid"))
                        {
                            int siteId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Task.SiteId == siteId);
                        }
                        else if (splits[i].ToLower().StartsWith("customerid"))
                        {
                            int customerId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Task.CustomerId == customerId);
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
                if (entityAttrs.ToLowers().Contains("createdatetime"))
                {
                    return queryable
                        .Where(row =>
                            row.Task.CreateDateTime >= startDate && row.Task.CreateDateTime <= endDate
                        );
                }
                if (entityAttrs.ToLowers().Contains("receptiondatetime"))
                {
                    return queryable
                        .Where(row =>
                            row.Task.ReceptionDateTime >= startDate && row.Task.ReceptionDateTime <= endDate
                        );
                }
                if (entityAttrs.ToLowers().Contains("indatetime"))
                {
                    return queryable
                        .Where(row =>
                            row.Task.InDateTime >= startDate && row.Task.InDateTime <= endDate
                        );
                }
                if (entityAttrs.ToLowers().Contains("outdatetime"))
                {
                    return queryable
                        .Where(row =>
                            row.Task.OutDateTime >= startDate && row.Task.OutDateTime <= endDate
                        );
                }
                if (entityAttrs.ToLowers().Contains("indatetime^outdatetime"))
                {
                    return queryable
                        .Where(row =>
                            row.Task.OutDateTime >= startDate && row.Task.InDateTime <= endDate
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
                        return queryable.OrderBy(row => row.Task.Id);
                    }
                    else
                    {
                        return queryable.OrderByDescending(row => row.Task.Id);
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
        private Task SQLEntityToSingle(SQLEntity entity)
        {
            //判断搜索结果是否为空
            if (entity == null)
                return null;
            else
            {
                // 主表
                Task task = entity.Task;
                // 接待人
                task.Reception = entity.Reception ?? null;
                // 客户
                task.Customer = entity.Customer ?? null;
                // 场地
                task.Site = entity.Site ?? null;
                // 场馆
                task.Venue = entity.Venue ?? null;
                // 状态
                task.Status = entity.Status ?? null;
                // 返回
                return task;
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<Task> SQLEntityToList(List<SQLEntity> list)
        {
            // 为 Task 赋值
            List<Task> taskList = new List<Task>();
            list.ForEach(
                row =>
                {
                    taskList.Add(
                            SQLEntityToSingle(row)
                        );
                }
            );
            return taskList;
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        private class SQLEntity
        {
            public Task Task { get; set; }
            public User Reception { get; set; }
            public Customer Customer { get; set; }
            public Site Site { get; set; }
            public Venue Venue { get; set; }
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