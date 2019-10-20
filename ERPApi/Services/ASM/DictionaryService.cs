using ERPApi.Dal.EFHelper;
using ERPApi.Entities.ASM;
using ERPApi.Entities.WFM;
using ERPApi.HttpClients.HttpModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ERPApi.Services.ASM
{
    /// <summary>
    /// 
    /// </summary>
    public class DictionaryService : ServiceBase<Dictionary, VMISContext>
    {
        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : DictionaryService
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary Commit(Dictionary dictionary)
            {
                try
                {
                    // 定义
                    Dictionary result = new Dictionary();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(
                                ReadyToCreate(dictionary)
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
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public List<Dictionary> Commit(List<Dictionary> dictionaryList)
            {
                try
                {
                    // 定义
                    List<Dictionary> resultList = new List<Dictionary>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        dictionaryList.ForEach(dictionary =>
                        {
                            resultList.Add(
                                    new CreateService().Commit(dictionary)
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary ToOpen(Dictionary dictionary)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(dictionary, "asm.dictionary.open")
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary ToClose(Dictionary dictionary)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(dictionary, "asm.dictionary.close")
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
        public class UpdateService : DictionaryService
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary Commit(Dictionary dictionary)
            {
                try
                {
                    // 定义
                    Dictionary result = new Dictionary();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(
                                ReadyToUpdate(dictionary)
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
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public List<Dictionary> Commit(List<Dictionary> dictionaryList)
            {
                try
                {
                    // 定义
                    List<Dictionary> resultList = new List<Dictionary>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        dictionaryList.ForEach(dictionary =>
                        {
                            resultList.Add(
                                    new UpdateService().Commit(dictionary)
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary ToOpen(Dictionary dictionary)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(dictionary, "asm.dictionary.open")
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary ToClose(Dictionary dictionary)
            {
                try
                {
                    return Commit(
                            ReadyToStatus(dictionary, "asm.dictionary.close")
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
        public class DeleteService : DictionaryService
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
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public Dictionary Commit(Dictionary dictionary)
            {
                try
                {
                    // 定义
                    Dictionary result = new Dictionary();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(dictionary);
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
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public List<Dictionary> Commit(List<Dictionary> dictionaryList)
            {
                try
                {
                    // 定义
                    List<Dictionary> resultList = new List<Dictionary>();
                    // 事务
                    transService.TransRegist(delegate {
                        dictionaryList.ForEach(dictionary =>
                        {
                            resultList.Add(
                                    new DeleteService().Commit(dictionary)
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
        public class ColumnsService : DictionaryService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Dictionary Default()
            {
                try
                {
                    return new Dictionary();
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
        public class RowService : DictionaryService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <returns></returns>
            public Dictionary ById(int id)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context)
                                    .Where(row => row.Dictionary.Id == id)
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
            public Dictionary ByKey(string key)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                                SQLQueryable(context)
                                    .Where(row => row.Dictionary.Key == key)
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
        public class RowsService : DictionaryService
        {
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <returns></returns>
            public List<Dictionary> ByKeyWord(string keyWord)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context)
                                    .Where(row => row.Dictionary.Name.Contains(keyWord))
                                    .OrderBy(row => row.Dictionary.Id)
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
            public List<Dictionary> ByPid(int pid)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context)
                                    .Where(row => row.Dictionary.Pid == pid)
                                    .OrderBy(row => row.Dictionary.Id)
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
            public List<Dictionary> ByPath(string path)
            {
                using (VMISContext context = new VMISContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context)
                                    .Where(row => row.Dictionary.Path.StartsWith(path))
                                    .OrderBy(row => row.Dictionary.Id)
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
            public List<Dictionary> Page(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
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
        public class TreeService : DictionaryService
        {
            /// <summary>
            /// 根据Id查询
            /// </summary>
            /// <param name="id">id</param>
            /// <returns></returns>
            public Dictionary ById(int id)
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
            public Dictionary ByKey(string key)
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
            public List<Dictionary> ByKeyWord(string keyWord)
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
            public List<Dictionary> ByPid(int pid)
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
            public List<Dictionary> ByPath(string path)
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
        /// <param name="dictionary"></param>
        /// <returns></returns>
        private Dictionary ReadyToCreate(Dictionary dictionary)
        {
            try
            {
                return dictionary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update预备方法
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        private Dictionary ReadyToUpdate(Dictionary dictionary)
        {
            try
            {
                return dictionary;
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
            var left = context.ASM_Dictionary.Select(Main => new
            {
                Dictionary = Main,
                Status = context.WFM_Status.FirstOrDefault(row => row.Id != row.Id)
            });

            foreach (string entityAttr in entityAttrs)
            {
                // SQLEntity.Status
                if (entityAttr.Equals("Status"))
                    left = left
                        // main: Dictionary | left : Status
                        .LeftOuterJoin(context.WFM_Status, Main => Main.Dictionary.StatusId, Left => Left.Id, (Main, Left) => new
                        {
                            Main.Dictionary,
                            Status = Left
                        });
            }
            var group = left.Select(Main => new SQLEntity
            {
                Dictionary = Main.Dictionary,
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
                                row.Dictionary.Name.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Dictionary.Name)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Dictionary.Name.Contains(keyWord)
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
                            queryable = queryable.Where(row => row.Dictionary.StatusId == statusId);
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
                            row.Dictionary.CreateDateTime >= startDate && row.Dictionary.CreateDateTime <= endDate
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
                        return queryable.OrderBy(row => row.Dictionary.Id);
                    }
                    else
                    {
                        return queryable.OrderByDescending(row => row.Dictionary.Id);
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
        private Dictionary SQLEntityToSingle(SQLEntity entity)
        {
            //判断搜索结果是否为空
            if (entity == null)
                return null;
            else
            {
                // 主表
                Dictionary dictionary = entity.Dictionary;
                // 状态
                dictionary.Status = entity.Status ?? null;
                // 返回
                return dictionary;
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<Dictionary> SQLEntityToList(List<SQLEntity> list)
        {
            // 为 Dictionary 赋值
            List<Dictionary> dictionaryList = new List<Dictionary>();
            list.ForEach(
                row =>
                {
                    dictionaryList.Add(
                            SQLEntityToSingle(row)
                        );
                }
            );
            return dictionaryList;
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        private class SQLEntity
        {
            public Dictionary Dictionary { get; set; }
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