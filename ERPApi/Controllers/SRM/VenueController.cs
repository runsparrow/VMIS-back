using ERPApi.Entities.SRM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.SRM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.SRM.VenueController.HttpEntity;

namespace ERPApi.Controllers.SRM
{
    /// <summary>
    /// 展厅
    /// </summary>
    [ControllerGroup("SRM", "Venue")]
    [Authorize("wzkj")]
    public class VenueController : BaseController<Venue, VenueService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增展厅
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Create", Name = "ERP_SRM_Venue_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                VenueService.CreateService service = new VenueService.CreateService();
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
        /// 更新展厅
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Update", Name = "ERP_SRM_Venue_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                VenueService.UpdateService service = new VenueService.UpdateService();
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
        /// 删除展厅
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Delete", Name = "ERP_SRM_Venue_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                VenueService.DeleteService service = new VenueService.DeleteService();
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
        /// 查询展厅的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Read/Columns", Name = "ERP_SRM_Venue_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                VenueService.ColumnsService service = new VenueService.ColumnsService();
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
        /// 查询展厅（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Read/Row", Name = "ERP_SRM_Venue_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                VenueService.RowService service = new VenueService.RowService();
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
                                        service.ById(int.Parse(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
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
        /// 查询展厅（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Read/Rows", Name = "ERP_SRM_Venue_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                VenueService.RowsService service = new VenueService.RowsService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "bysiteid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.BySiteId(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
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
        ///  查询展厅（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Read/Single", Name = "ERP_SRM_Venue_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                VenueService.SingleService service = new VenueService.SingleService();
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
                                        service.ById(int.Parse(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
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
        /// 查询展厅（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Read/Query", Name = "ERP_SRM_Venue_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                VenueService.QueryService service = new VenueService.QueryService();
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
        /// 查询展厅（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Venue/Read/Tree", Name = "ERP_SRM_Venue_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                VenueService.TreeService service = new VenueService.TreeService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
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
                public class Request : CreateMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venue"></param>
                    /// <returns></returns>
                    public override CreateMode<Venue>.Response ToResponse(Venue venue)
                    {
                        return base.ToResponse(venue);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venueList"></param>
                    /// <returns></returns>
                    public override CreateMode<Venue>.Response ToResponse(List<Venue> venueList)
                    {
                        return base.ToResponse(venueList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Venue>.Response
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
                public class Request : UpdateMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venue"></param>
                    /// <returns></returns>
                    public override UpdateMode<Venue>.Response ToResponse(Venue venue)
                    {
                        return base.ToResponse(venue);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venueList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Venue>.Response ToResponse(List<Venue> venueList)
                    {
                        return base.ToResponse(venueList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Venue>.Response
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
                public class Request : DeleteMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venue"></param>
                    /// <returns></returns>
                    public override DeleteMode<Venue>.Response ToResponse(Venue venue)
                    {
                        return base.ToResponse(venue);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venueList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Venue>.Response ToResponse(List<Venue> venueList)
                    {
                        return base.ToResponse(venueList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Venue>.Response
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
                public class Request : ColumnsMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venue"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Venue>.Response ToResponse(Venue venue)
                    {
                        return base.ToResponse(venue);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Venue>.Response
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
                public class Request : RowMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venue"></param>
                    /// <returns></returns>
                    public override RowMode<Venue>.Response ToResponse(Venue venue)
                    {
                        return base.ToResponse(venue);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Venue>.Response
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
                public class Request : RowsMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venueList"></param>
                    /// <returns></returns>
                    public override RowsMode<Venue>.Response ToResponse(List<Venue> venueList)
                    {
                        return base.ToResponse(venueList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Venue>.Response
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
                public class Request : SingleMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venue"></param>
                    /// <returns></returns>
                    public override SingleMode<Venue>.Response ToResponse(Venue venue)
                    {
                        return base.ToResponse(venue);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Venue>.Response
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
                public class Request : QueryMode<Venue>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venueList"></param>
                    /// <returns></returns>
                    public override QueryMode<Venue>.Response ToResponse(List<Venue> venueList)
                    {
                        return base.ToResponse(venueList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Venue>.Response
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
                public class Request : TreeMode<Venue>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="venueList"></param>
                    /// <returns></returns>
                    public override TreeMode<Venue>.BootstrapTreeViewResponse ToResponse(List<Venue> venueList)
                    {
                        return base.ToResponse(venueList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Venue>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}