using ERPApi.Entities.ASM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.ASM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.ASM.RegionController.HttpEntity;

namespace ERPApi.Controllers.ASM
{
    /// <summary>
    /// 区域
    /// </summary>
    [ControllerGroup("ASM", "Region")]
    public class RegionController : ControllerBase<Region, RegionService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增区域
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Create", Name = "ERP_ASM_Region_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                RegionService.CreateService service = new RegionService.CreateService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
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
        /// 更新区域
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Update", Name = "ERP_ASM_Region_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                RegionService.UpdateService service = new RegionService.UpdateService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
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
        /// 删除区域
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Delete", Name = "ERP_ASM_Region_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                RegionService.DeleteService service = new RegionService.DeleteService();
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
        /// 查询区域的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Read/Columns", Name = "ERP_ASM_Region_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                RegionService.ColumnsService service = new RegionService.ColumnsService();
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
        /// 查询区域（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Read/Row", Name = "ERP_ASM_Region_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                RegionService.RowService service = new RegionService.RowService();
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
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("byid"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ById(ParseInt(request.Function.Args[0]))
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
        /// 查询区域（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Read/Rows", Name = "ERP_ASM_Region_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                RegionService.RowsService service = new RegionService.RowsService();
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
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("bykeyword"))
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
        ///  查询区域（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Read/Single", Name = "ERP_ASM_Region_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                RegionService.SingleService service = new RegionService.SingleService();
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
                                        service.ById(ParseInt(request.Function.Args[0]))
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
        /// 查询区域（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Read/Query", Name = "ERP_ASM_Region_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                RegionService.QueryService service = new RegionService.QueryService();
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
                                        service.Page(request.Function.Args[0], request.PageIndex, request.PageSize, request.StartDate, request.EndDate, request.Status, request.Sort, ToParams(request.Function.Args, 1)),
                                        service.PageCount(request.Function.Args[0], request.StartDate, request.EndDate, request.Status, ToParams(request.Function.Args, 1)),
                                        service.PageSummary(request.Function.Args[0], request.PageIndex, request.PageSize, request.StartDate, request.EndDate, request.Status, ToParams(request.Function.Args, 1))
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
        /// 查询区域（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/ASM/Region/Read/Tree", Name = "ERP_ASM_Region_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                RegionService.TreeService service = new RegionService.TreeService();
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
                                    new List<Region>()
                                    {
                                        service.ById(ParseInt(request.Function.Args[0]))
                                    }
                                )
                            );
                    case "bykey":
                        return base.ResponseOk(
                                request.ToResponse(
                                    new List<Region>()
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
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("bykeyword"))
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
                public class Request : CreateMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="region"></param>
                    /// <returns></returns>
                    public override CreateMode<Region>.Response ToResponse(Region region)
                    {
                        return base.ToResponse(region);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="regionList"></param>
                    /// <returns></returns>
                    public override CreateMode<Region>.Response ToResponse(List<Region> regionList)
                    {
                        return base.ToResponse(regionList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Region>.Response
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
                public class Request : UpdateMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="region"></param>
                    /// <returns></returns>
                    public override UpdateMode<Region>.Response ToResponse(Region region)
                    {
                        return base.ToResponse(region);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="regionList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Region>.Response ToResponse(List<Region> regionList)
                    {
                        return base.ToResponse(regionList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Region>.Response
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
                public class Request : DeleteMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="region"></param>
                    /// <returns></returns>
                    public override DeleteMode<Region>.Response ToResponse(Region region)
                    {
                        return base.ToResponse(region);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="regionList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Region>.Response ToResponse(List<Region> regionList)
                    {
                        return base.ToResponse(regionList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Region>.Response
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
                public class Request : ColumnsMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="region"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Region>.Response ToResponse(Region region)
                    {
                        return base.ToResponse(region);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Region>.Response
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
                public class Request : RowMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="region"></param>
                    /// <returns></returns>
                    public override RowMode<Region>.Response ToResponse(Region region)
                    {
                        return base.ToResponse(region);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Region>.Response
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
                public class Request : RowsMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="regionList"></param>
                    /// <returns></returns>
                    public override RowsMode<Region>.Response ToResponse(List<Region> regionList)
                    {
                        return base.ToResponse(regionList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Region>.Response
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
                public class Request : SingleMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="region"></param>
                    /// <returns></returns>
                    public override SingleMode<Region>.Response ToResponse(Region region)
                    {
                        return base.ToResponse(region);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Region>.Response
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
                public class Request : QueryMode<Region>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="regionList"></param>
                    /// <returns></returns>
                    public override QueryMode<Region>.Response ToResponse(List<Region> regionList)
                    {
                        return base.ToResponse(regionList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Region>.Response
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
                public class Request : TreeMode<Region>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="regionList"></param>
                    /// <returns></returns>
                    public override TreeMode<Region>.BootstrapTreeViewResponse ToResponse(List<Region> regionList)
                    {
                        return base.ToResponse(regionList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Region>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}