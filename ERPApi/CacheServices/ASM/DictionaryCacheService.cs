using ERPApi.Dal.EFHelper;
using ERPApi.Entities.ASM;
using ERPApi.HttpClients.HttpModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static ERPApi.Services.ASM.DictionaryService;

namespace ERPApi.CacheServices.ASM
{
    /// <summary>
    /// 
    /// </summary>
    public class DictionaryCacheService : CacheServiceBase<Dictionary, VMISContext>
    {

        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : DictionaryCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="status"></param>
            /// <returns></returns>
            public override Dictionary Create(Dictionary dictionary)
            {
                return Dictionary.Instance.Insert(dictionary);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public override List<Dictionary> Create(List<Dictionary> dictionaryList)
            {
                dictionaryList.ForEach(
                        dictionary =>
                        {
                            Dictionary.Instance.Insert(dictionary);
                        }
                    );
                return dictionaryList;
            }
        }

        #endregion

        #region RPC UpdateMode
        /// <summary>
        /// UpdateMode Service
        /// </summary>
        public class UpdateService : DictionaryCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="status"></param>
            /// <returns></returns>
            public override Dictionary Update(Dictionary dictionary)
            {
                return Dictionary.Instance.Update(dictionary);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public override List<Dictionary> Update(List<Dictionary> dictionaryList)
            {
                dictionaryList.ForEach(
                        dictionary =>
                        {
                            Dictionary.Instance.Update(dictionary);
                        }
                    );
                return dictionaryList;
            }
        }
        #endregion

        #region RPC DeleteMode
        /// <summary>
        /// DeleteMode Service
        /// </summary>
        public class DeleteService : DictionaryCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="status"></param>
            /// <returns></returns>
            public override Dictionary Delete(Dictionary dictionary)
            {
                return Dictionary.Instance.Delete(dictionary);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public override List<Dictionary> Delete(List<Dictionary> dictionaryList)
            {
                dictionaryList.ForEach(
                        dictionary =>
                        {
                            Dictionary.Instance.Delete(dictionary);
                        }
                    );
                return dictionaryList;
            }
        }
        #endregion

        #region RPC Read ColumnsMode
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : DictionaryCacheService
        {
            /// <summary>
            /// 返回字段集
            /// I.  只含本表字段
            /// </summary>
            /// <returns></returns>
            public Dictionary Sample()
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

            /// <summary>
            /// 返回字段集
            /// I.  含相关表字段
            /// </summary>
            /// <returns></returns>
            public Dictionary Full()
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
        public class RowService : DictionaryCacheService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public Dictionary ById(int id, params string[] entityAttrs)
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
            /// <summary>
            /// 根据 key 查询
            /// </summary>
            /// <param name="key">key</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public Dictionary ByKey(string key, params string[] entityAttrs)
            {
                try
                {
                    return SQLEntityToSingle(
                            SQLToList()
                                .Where(row => row.Key == key)
                                .SingleOrDefault()
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 首记录
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public Dictionary First(string keyWord, ModeBase.Status status, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // status查询
                    list = StatusToList(list, status);
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
            /// <summary>
            /// 末记录
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public Dictionary Last(string keyWord, ModeBase.Status status, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return list.LastOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 下一条
            /// </summary>
            /// <param name="id"></param>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public Dictionary Next(int id, string keyWord, ModeBase.Status status, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord + "^Id>" + id);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return list.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 上一条
            /// </summary>
            /// <param name="id"></param>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public Dictionary Prev(int id, string keyWord, ModeBase.Status status, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord + "^Id<" + id);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return list.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region RPC Read RowsMode

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : DictionaryCacheService
        {
            /// <summary>
            /// 返回全表数据
            /// </summary>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Dictionary> All(params string[] entityAttrs)
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
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Dictionary> ByKeyWord(string keyWord, params string[] entityAttrs)
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
            /// 分页查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="pageIndex">页码</param>
            /// <param name="pageSize">每页显示数</param>
            /// <param name="startDate">起始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="dictionary">状态</param>
            /// <param name="sort">排序</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Dictionary> Page(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // status查询
                    list = StatusToList(list, status);
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
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="startDate">起始时间</param>
            /// <param name="endDate">结束时间</param>
            /// <param name="dictionary">状态</param>
            /// <param name="sort">排序</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public int PageCount(string keyWord, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // status查询
                    list = StatusToList(list, status);
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
            /// <param name="status"></param>
            /// <param name="sort"></param>
            /// <param name="entityAttrs"></param>
            /// <returns></returns>
            public SummaryEntity PageSummary(string keyWord, int pageIndex, int pageSize, DateTime startDate, DateTime endDate, ModeBase.Status status, ModeBase.Sort sort, params string[] entityAttrs)
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
        public class TreeService : DictionaryCacheService
        {
            #region 调用RowService的方法
            /// <summary>
            ///  根据 id 查询
            ///  1. 本方法返回是单条记录
            /// </summary>
            /// <param name="id">id</param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Dictionary> ById(int id, params string[] entityAttrs)
            {
                List<Dictionary> resultList = new List<Dictionary>();
                resultList.Add(
                        new RowService().ById(id, entityAttrs)
                    );
                return resultList;
            }
            #endregion

            #region 调用RowsService的方法
            /// <summary>
            /// 模糊查询
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="entityAttrs">可变参数</param>
            /// <returns></returns>
            public List<Dictionary> ByKeyWord(string keyWord, params string[] entityAttrs)
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
        public List<Dictionary> CacheAll()
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
        /// <param name="entityList"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private decimal Sum(Func<Dictionary, decimal> selector, List<Dictionary> entityList, params string[] entityAttrs)
        {
            try
            {
                return entityList.Sum(selector);
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
        /// <param name="entityList"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private int Sum(Func<Dictionary, int> selector, List<Dictionary> entityList, params string[] entityAttrs)
        {
            try
            {
                return entityList.Sum(selector);
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
        private Dictionary SQLEntityToSingle(Dictionary entity)
        {
            if (entity == null)
                return null;
            else
            {
                // 主表
                Dictionary dictionary = entity;
                // 返回
                return dictionary;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyWord"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private List<Dictionary> KeyWordToList(List<Dictionary> list, string keyWord, params string[] entityAttrs)
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
                                row.Key.Contains(andKeyWord)
                            ).ToList();
                    }
                }
                else if (ors.Length > 1)
                {
                    list = list.Where(row =>
                            ors.Contains(row.Name) ||
                            ors.Contains(row.Key)
                        ).ToList();
                }
                else
                {
                    list = list.Where(row =>
                            row.Name.Contains(keyWord) ||
                            row.Key.Contains(keyWord)
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
        /// <param name="keyWord"></param
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private List<Dictionary> KeyWordExtToList(List<Dictionary> list, string keyWord, params string[] entityAttrs)
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
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private List<Dictionary> DateToList(List<Dictionary> list, DateTime startDate, DateTime endDate, params string[] entityAttrs)
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
        /// <param name="status"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private List<Dictionary> StatusToList(List<Dictionary> list, ModeBase.Status status, params string[] entityAttrs)
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
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private List<Dictionary> SortToList(List<Dictionary> list, ModeBase.Sort sort, params string[] entityAttrs)
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
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        private List<Dictionary> PageToList(List<Dictionary> list, int pageIndex, int pageSize, params string[] entityAttrs)
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
        private List<Dictionary> SQLToList()
        {
            try
            {
                return Dictionary.Instance.CacheAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}