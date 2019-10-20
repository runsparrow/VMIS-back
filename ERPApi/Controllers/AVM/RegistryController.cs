using ERPApi.Entities.AVM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.AVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.AVM.RegistryController.HttpEntity;

namespace ERPApi.Controllers.AVM
{
    /// <summary>
    /// 功能
    /// </summary>
    [ControllerGroup("AVM", "Registry")]
    public class RegistryController : ControllerBase<Registry, RegistryService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增功能
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Create", Name = "ERP_AVM_Registry_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                RegistryService.CreateService service = new RegistryService.CreateService();
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
        /// 更新功能
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Update", Name = "ERP_AVM_Registry_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                RegistryService.UpdateService service = new RegistryService.UpdateService();
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
        /// 删除功能
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Delete", Name = "ERP_AVM_Registry_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                RegistryService.DeleteService service = new RegistryService.DeleteService();
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
        /// 查询功能的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Read/Columns", Name = "ERP_AVM_Registry_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                RegistryService.ColumnsService service = new RegistryService.ColumnsService();
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
        /// 查询功能（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Read/Row", Name = "ERP_AVM_Registry_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                RegistryService.RowService service = new RegistryService.RowService();
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
        /// 查询功能（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Read/Rows", Name = "ERP_AVM_Registry_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                RegistryService.RowsService service = new RegistryService.RowsService();
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
                    case "byuserid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByUserId(ParseInt(request.Function.Args[0]))
                                )
                            );
                    case "byroleid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByRoleId(ParseInt(request.Function.Args[0]))
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
        ///  查询功能（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Read/Single", Name = "ERP_AVM_Registry_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                RegistryService.SingleService service = new RegistryService.SingleService();
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
        /// 查询功能（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Read/Query", Name = "ERP_AVM_Registry_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                RegistryService.QueryService service = new RegistryService.QueryService();
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
        /// 查询功能（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/Registry/Read/Tree", Name = "ERP_AVM_Registry_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                RegistryService.TreeService service = new RegistryService.TreeService();
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
                                    new List<Registry>()
                                    {
                                        service.ById(ParseInt(request.Function.Args[0]))
                                    }
                                )
                            );
                    case "bykey":
                        return base.ResponseOk(
                                request.ToResponse(
                                    new List<Registry>()
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
                public class Request : CreateMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registry"></param>
                    /// <returns></returns>
                    public override CreateMode<Registry>.Response ToResponse(Registry registry)
                    {
                        return base.ToResponse(registry);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registryList"></param>
                    /// <returns></returns>
                    public override CreateMode<Registry>.Response ToResponse(List<Registry> registryList)
                    {
                        return base.ToResponse(registryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Registry>.Response
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
                public class Request : UpdateMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registry"></param>
                    /// <returns></returns>
                    public override UpdateMode<Registry>.Response ToResponse(Registry registry)
                    {
                        return base.ToResponse(registry);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registryList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Registry>.Response ToResponse(List<Registry> registryList)
                    {
                        return base.ToResponse(registryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Registry>.Response
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
                public class Request : DeleteMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registry"></param>
                    /// <returns></returns>
                    public override DeleteMode<Registry>.Response ToResponse(Registry registry)
                    {
                        return base.ToResponse(registry);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registryList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Registry>.Response ToResponse(List<Registry> registryList)
                    {
                        return base.ToResponse(registryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Registry>.Response
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
                public class Request : ColumnsMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registry"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Registry>.Response ToResponse(Registry registry)
                    {
                        return base.ToResponse(registry);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Registry>.Response
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
                public class Request : RowMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registry"></param>
                    /// <returns></returns>
                    public override RowMode<Registry>.Response ToResponse(Registry registry)
                    {
                        return base.ToResponse(registry);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Registry>.Response
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
                public class Request : RowsMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registryList"></param>
                    /// <returns></returns>
                    public override RowsMode<Registry>.Response ToResponse(List<Registry> registryList)
                    {
                        return base.ToResponse(registryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Registry>.Response
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
                public class Request : SingleMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registry"></param>
                    /// <returns></returns>
                    public override SingleMode<Registry>.Response ToResponse(Registry registry)
                    {
                        return base.ToResponse(registry);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Registry>.Response
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
                public class Request : QueryMode<Registry>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registryList"></param>
                    /// <returns></returns>
                    public override QueryMode<Registry>.Response ToResponse(List<Registry> registryList)
                    {
                        return base.ToResponse(registryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Registry>.Response
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
                public class Request : TreeMode<Registry>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="registryList"></param>
                    /// <returns></returns>
                    public override TreeMode<Registry>.BootstrapTreeViewResponse ToResponse(List<Registry> registryList)
                    {
                        return base.ToResponse(registryList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Registry>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}