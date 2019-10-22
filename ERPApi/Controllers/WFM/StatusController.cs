using ERPApi.CacheServices.WFM;
using ERPApi.Entities.WFM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.WFM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.WFM.StatusController.HttpEntity;

namespace ERPApi.Controllers.WFM
{
    /// <summary>
    /// 用户
    /// </summary>
    [ControllerGroup("WFM", "Status")]
    [Authorize("wzkj")]
    public class StatusController : ControllerBase<Status, StatusService>
    {

        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Create", Name = "ERP_WFM_Status_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                StatusService.CreateService service = new StatusService.CreateService();
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
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
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
        /// 更新用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Update", Name = "ERP_WFM_Status_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                StatusService.UpdateService service = new StatusService.UpdateService();
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
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
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
        /// 删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Delete", Name = "ERP_WFM_Status_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                StatusService.DeleteService service = new StatusService.DeleteService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name)) {
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
        /// 查询用户的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Read/Columns", Name = "ERP_WFM_Status_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                StatusService.ColumnsService service = new StatusService.ColumnsService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
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
        /// 查询用户（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Read/Row", Name = "ERP_WFM_Status_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                StatusService.RowService service = new StatusService.RowService();
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
                                    service.ByKey(request.Function.Args[0])
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ById(int.Parse(request.Function.Args[0]))
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
        /// 查询用户（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Read/Rows", Name = "ERP_WFM_Status_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                StatusService.RowsService service = new StatusService.RowsService();
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
                                    service.ByPid(ParseInt(request.Function.Args[0]))
                                )
                            );
                    case "bypath":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPath(request.Function.Args[0])
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ByKeyWord(request.Function.Args[0])
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
        ///  查询用户（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Read/Single", Name = "ERP_WFM_Status_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                StatusService.SingleService service = new StatusService.SingleService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ById(int.Parse(request.Function.Args[0]))
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
        /// 查询用户（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Read/Query", Name = "ERP_WFM_Status_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                StatusService.QueryService service = new StatusService.QueryService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.Page(request.Function.Args[0], request.PageIndex, request.PageSize, request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1)),
                                        service.PageCount(request.Function.Args[0], request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1)),
                                        service.PageSummary(request.Function.Args[0], request.PageIndex, request.PageSize, request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1))
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
        /// 查询用户（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/WFM/Status/Read/Tree", Name = "ERP_WFM_Status_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                StatusService.TreeService service = new StatusService.TreeService();
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
                                    new List<Status>()
                                    {
                                        service.ById(ParseInt(request.Function.Args[0]))
                                    }
                                )
                            );
                    case "bykey":
                        return base.ResponseOk(
                                request.ToResponse(
                                    new List<Status>()
                                    {
                                        service.ByKey(request.Function.Args[0])
                                    }
                                )
                            );
                    case "bypid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPid(ParseInt(request.Function.Args[0]))
                                )
                            );
                    case "bypath":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByPath(request.Function.Args[0])
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ByKeyWord(request.Function.Args[0])
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
                public class Request : CreateMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="status"></param>
                    /// <returns></returns>
                    public override CreateMode<Status>.Response ToResponse(Status status)
                    {
                        return base.ToResponse(status);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="statusList"></param>
                    /// <returns></returns>
                    public override CreateMode<Status>.Response ToResponse(List<Status> statusList)
                    {
                        return base.ToResponse(statusList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Status>.Response
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
                public class Request : UpdateMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="status"></param>
                    /// <returns></returns>
                    public override UpdateMode<Status>.Response ToResponse(Status status)
                    {
                        return base.ToResponse(status);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="statusList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Status>.Response ToResponse(List<Status> statusList)
                    {
                        return base.ToResponse(statusList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Status>.Response
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
                public class Request : DeleteMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="status"></param>
                    /// <returns></returns>
                    public override DeleteMode<Status>.Response ToResponse(Status status)
                    {
                        return base.ToResponse(status);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="statusList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Status>.Response ToResponse(List<Status> statusList)
                    {
                        return base.ToResponse(statusList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Status>.Response
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
                public class Request : ColumnsMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="status"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Status>.Response ToResponse(Status status)
                    {
                        return base.ToResponse(status);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Status>.Response
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
                public class Request : RowMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="status"></param>
                    /// <returns></returns>
                    public override RowMode<Status>.Response ToResponse(Status status)
                    {
                        return base.ToResponse(status);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Status>.Response
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
                public class Request : RowsMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="statusList"></param>
                    /// <returns></returns>
                    public override RowsMode<Status>.Response ToResponse(List<Status> statusList)
                    {
                        return base.ToResponse(statusList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Status>.Response
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
                public class Request : SingleMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="status"></param>
                    /// <returns></returns>
                    public override SingleMode<Status>.Response ToResponse(Status status)
                    {
                        return base.ToResponse(status);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Status>.Response
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
                public class Request : QueryMode<Status>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="statusList"></param>
                    /// <returns></returns>
                    public override QueryMode<Status>.Response ToResponse(List<Status> statusList)
                    {
                        return base.ToResponse(statusList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Status>.Response
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
                public class Request : TreeMode<Status>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="statusList"></param>
                    /// <returns></returns>
                    public override TreeMode<Status>.BootstrapTreeViewResponse ToResponse(List<Status> statusList)
                    {
                        return base.ToResponse(statusList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Status>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}