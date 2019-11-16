using ERPApi.Entities.ASM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.ASM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.ASM.DictionaryController.HttpEntity;

namespace ERPApi.Controllers.ASM
{
    /// <summary>
    /// 字典
    /// </summary>
    [ControllerGroup("ASM", "Dictionary")]
    [Authorize("wzkj")]
    public class DictionaryController : BaseController<Dictionary, DictionaryService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Create", Name = "ERP_ASM_Dictionary_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                DictionaryService.CreateService service = new DictionaryService.CreateService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // Entity
                if (request.Entity != null)
                {
                    request.Entity.CreateUserId = GetUserIdFromClaim();
                    request.Entity.CreateDateTime = DateTime.Now;
                }
                // Entities
                if (request.Entities != null)
                {
                    request.Entities.ForEach(entity =>
                    {
                        entity.CreateUserId = GetUserIdFromClaim();
                        entity.CreateDateTime = DateTime.Now;
                    });
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "toopen":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ToOpen(request.Entity)
                                )
                            );
                    case "toclose":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ToClose(request.Entity)
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("commit"))
                        {
                            if (request.Entity != null)
                            {
                                return base.ResponseOk(
                                        request.ToResponse(
                                            service.Commit(request.Entity)
                                        )
                                    );
                            }
                            else
                            {
                                return base.ResponseOk(
                                        request.ToResponse(
                                            service.Commit(request.Entities)
                                        )
                                    );
                            }
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 更新字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Update", Name = "ERP_ASM_Dictionary_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                DictionaryService.UpdateService service = new DictionaryService.UpdateService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // Entity
                if (request.Entity != null)
                {
                    request.Entity.EditUserId = GetUserIdFromClaim();
                    request.Entity.EditDateTime = DateTime.Now;
                }
                // Entities
                if (request.Entities != null)
                {
                    request.Entities.ForEach(entity =>
                    {
                        entity.EditUserId = GetUserIdFromClaim();
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "toopen":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ToOpen(request.Entity)
                                )
                            );
                    case "toclose":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ToClose(request.Entity)
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("commit"))
                        {
                            if (request.Entity != null)
                            {
                                return base.ResponseOk(
                                        request.ToResponse(
                                            service.Commit(request.Entity)
                                        )
                                    );
                            }
                            else
                            {
                                return base.ResponseOk(
                                        request.ToResponse(
                                            service.Commit(request.Entities)
                                        )
                                    );
                            }
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DeleteMode
        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Delete", Name = "ERP_ASM_Dictionary_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                DictionaryService.DeleteService service = new DictionaryService.DeleteService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("commit"))
                        {
                            if (request.Entity != null)
                            {
                                return base.ResponseOk(
                                        request.ToResponse(
                                            service.Commit(request.Entity)
                                        )
                                    );
                            }
                            else
                            {
                                return base.ResponseOk(
                                        request.ToResponse(
                                            service.Commit(request.Entities)
                                        )
                                    );
                            }
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read ColumnsMode
        /// <summary>
        /// 查询字典的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Read/Columns", Name = "ERP_ASM_Dictionary_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                DictionaryService.ColumnsService service = new DictionaryService.ColumnsService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("default"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.Default()
                                    )
                                );
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read RowMode
        /// <summary>
        /// 查询字典（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Read/Row", Name = "ERP_ASM_Dictionary_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                DictionaryService.RowService service = new DictionaryService.RowService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "bykey":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByKey(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("byid"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ById(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
                                    )
                                );
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read RowsMode
        /// <summary>
        /// 查询字典（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Read/Rows", Name = "ERP_ASM_Dictionary_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                DictionaryService.RowsService service = new DictionaryService.RowsService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "bypid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPid(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
                                )
                            );
                    case "bypath":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPath(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("bykeyword"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ByKeyWord(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                    )
                                );
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read SingleMode
        /// <summary>
        ///  查询字典（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Read/Single", Name = "ERP_ASM_Dictionary_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                DictionaryService.SingleService service = new DictionaryService.SingleService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("byid"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ById(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
                                    )
                                );
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read QueryMode
        /// <summary>
        /// 查询字典（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Read/Query", Name = "ERP_ASM_Dictionary_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                DictionaryService.QueryService service = new DictionaryService.QueryService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("page"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.Page(request.Function.Args[0]??"", request.PageIndex, request.PageSize, request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1)),
                                        service.PageCount(request.Function.Args[0]??"", request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1)),
                                        service.PageSummary(request.Function.Args[0]??"", request.PageIndex, request.PageSize, request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1))
                                    )
                                );
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read TreeMode
        /// <summary>
        /// 查询字典（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Dictionary/Read/Tree", Name = "ERP_ASM_Dictionary_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                DictionaryService.TreeService service = new DictionaryService.TreeService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "byid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    new List<Dictionary>()
                                    {
                                        service.ById(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
                                    }
                                )
                            );
                    case "bykey":
                        return base.ResponseOk(
                                request.ToResponse(
                                    new List<Dictionary>()
                                    {
                                        service.ByKey(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                    }
                                )
                            );
                    case "bypid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPid(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
                                )
                            );
                    case "bypath":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPath(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("bykeyword"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ByKeyWord(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                    )
                                );
                        }
                        else
                        {
                            throw new Exception("未发现对应函数方法！");
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region HttpEntity

        /// <summary>
        /// 
        /// </summary>
        public class HttpEntity
        {
            #region Create
            /// <summary>
            /// 
            /// </summary>
            public class CreateMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : CreateMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionary"></param>
                    /// <returns></returns>
                    public override CreateMode<Dictionary>.Response ToResponse(Dictionary dictionary)
                    {
                        return base.ToResponse(dictionary);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionaryList"></param>
                    /// <returns></returns>
                    public override CreateMode<Dictionary>.Response ToResponse(List<Dictionary> dictionaryList)
                    {
                        return base.ToResponse(dictionaryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Dictionary>.Response
                {

                }
            }
            #endregion

            #region Update
            /// <summary>
            /// 
            /// </summary>
            public class UpdateMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : UpdateMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionary"></param>
                    /// <returns></returns>
                    public override UpdateMode<Dictionary>.Response ToResponse(Dictionary dictionary)
                    {
                        return base.ToResponse(dictionary);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionaryList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Dictionary>.Response ToResponse(List<Dictionary> dictionaryList)
                    {
                        return base.ToResponse(dictionaryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Dictionary>.Response
                {

                }
            }
            #endregion

            #region Delete
            /// <summary>
            /// 
            /// </summary>
            public class DeleteMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : DeleteMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionary"></param>
                    /// <returns></returns>
                    public override DeleteMode<Dictionary>.Response ToResponse(Dictionary dictionary)
                    {
                        return base.ToResponse(dictionary);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionaryList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Dictionary>.Response ToResponse(List<Dictionary> dictionaryList)
                    {
                        return base.ToResponse(dictionaryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Dictionary>.Response
                {

                }
            }
            #endregion

            #region Read
            /// <summary>
            /// 
            /// </summary>
            public class ColumnsMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : ColumnsMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionary"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Dictionary>.Response ToResponse(Dictionary dictionary)
                    {
                        return base.ToResponse(dictionary);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Dictionary>.Response
                {

                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class RowMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : RowMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionary"></param>
                    /// <returns></returns>
                    public override RowMode<Dictionary>.Response ToResponse(Dictionary dictionary)
                    {
                        return base.ToResponse(dictionary);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Dictionary>.Response
                {

                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class RowsMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : RowsMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionaryList"></param>
                    /// <returns></returns>
                    public override RowsMode<Dictionary>.Response ToResponse(List<Dictionary> dictionaryList)
                    {
                        return base.ToResponse(dictionaryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Dictionary>.Response
                {

                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class SingleMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : SingleMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionary"></param>
                    /// <returns></returns>
                    public override SingleMode<Dictionary>.Response ToResponse(Dictionary dictionary)
                    {
                        return base.ToResponse(dictionary);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Dictionary>.Response
                {

                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class QueryMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : QueryMode<Dictionary>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionaryList"></param>
                    /// <returns></returns>
                    public override QueryMode<Dictionary>.Response ToResponse(List<Dictionary> dictionaryList)
                    {
                        return base.ToResponse(dictionaryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Dictionary>.Response
                {

                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class TreeMode
            {
                /// <summary>
                /// 
                /// </summary>
                public class Request : TreeMode<Dictionary>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="dictionaryList"></param>
                    /// <returns></returns>
                    public override TreeMode<Dictionary>.BootstrapTreeViewResponse ToResponse(List<Dictionary> dictionaryList)
                    {
                        return base.ToResponse(dictionaryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Dictionary>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}