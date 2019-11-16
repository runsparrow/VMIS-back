using ERPApi.Entities.SRM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.SRM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.SRM.SiteController.HttpEntity;

namespace ERPApi.Controllers.SRM
{
    /// <summary>
    /// 场地
    /// </summary>
    [ControllerGroup("SRM", "Site")]
    [Authorize("wzkj")]
    public class SiteController : BaseController<Site, SiteService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增场地
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Create", Name = "ERP_SRM_Site_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                SiteService.CreateService service = new SiteService.CreateService();
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
        /// 更新场地
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Update", Name = "ERP_SRM_Site_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                SiteService.UpdateService service = new SiteService.UpdateService();
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
        /// 删除场地
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Delete", Name = "ERP_SRM_Site_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                SiteService.DeleteService service = new SiteService.DeleteService();
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
        /// 查询场地的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Read/Columns", Name = "ERP_SRM_Site_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                SiteService.ColumnsService service = new SiteService.ColumnsService();
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
        /// 查询场地（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Read/Row", Name = "ERP_SRM_Site_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                SiteService.RowService service = new SiteService.RowService();
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
        /// 查询场地（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Read/Rows", Name = "ERP_SRM_Site_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                SiteService.RowsService service = new SiteService.RowsService();
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

        #region Read SingleMode
        /// <summary>
        ///  查询场地（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Read/Single", Name = "ERP_SRM_Site_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                SiteService.SingleService service = new SiteService.SingleService();
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
        /// 查询场地（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Read/Query", Name = "ERP_SRM_Site_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                SiteService.QueryService service = new SiteService.QueryService();
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
        /// 查询场地（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/SRM/Site/Read/Tree", Name = "ERP_SRM_Site_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                SiteService.TreeService service = new SiteService.TreeService();
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
                public class Request : CreateMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="site"></param>
                    /// <returns></returns>
                    public override CreateMode<Site>.Response ToResponse(Site site)
                    {
                        return base.ToResponse(site);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="siteList"></param>
                    /// <returns></returns>
                    public override CreateMode<Site>.Response ToResponse(List<Site> siteList)
                    {
                        return base.ToResponse(siteList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Site>.Response
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
                public class Request : UpdateMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="site"></param>
                    /// <returns></returns>
                    public override UpdateMode<Site>.Response ToResponse(Site site)
                    {
                        return base.ToResponse(site);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="siteList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Site>.Response ToResponse(List<Site> siteList)
                    {
                        return base.ToResponse(siteList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Site>.Response
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
                public class Request : DeleteMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="site"></param>
                    /// <returns></returns>
                    public override DeleteMode<Site>.Response ToResponse(Site site)
                    {
                        return base.ToResponse(site);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="siteList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Site>.Response ToResponse(List<Site> siteList)
                    {
                        return base.ToResponse(siteList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Site>.Response
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
                public class Request : ColumnsMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="site"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Site>.Response ToResponse(Site site)
                    {
                        return base.ToResponse(site);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Site>.Response
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
                public class Request : RowMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="site"></param>
                    /// <returns></returns>
                    public override RowMode<Site>.Response ToResponse(Site site)
                    {
                        return base.ToResponse(site);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Site>.Response
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
                public class Request : RowsMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="siteList"></param>
                    /// <returns></returns>
                    public override RowsMode<Site>.Response ToResponse(List<Site> siteList)
                    {
                        return base.ToResponse(siteList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Site>.Response
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
                public class Request : SingleMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="site"></param>
                    /// <returns></returns>
                    public override SingleMode<Site>.Response ToResponse(Site site)
                    {
                        return base.ToResponse(site);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Site>.Response
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
                public class Request : QueryMode<Site>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="siteList"></param>
                    /// <returns></returns>
                    public override QueryMode<Site>.Response ToResponse(List<Site> siteList)
                    {
                        return base.ToResponse(siteList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Site>.Response
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
                public class Request : TreeMode<Site>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="siteList"></param>
                    /// <returns></returns>
                    public override TreeMode<Site>.BootstrapTreeViewResponse ToResponse(List<Site> siteList)
                    {
                        return base.ToResponse(siteList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Site>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}