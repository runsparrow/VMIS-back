using ERPApi.Entities.AVM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.AVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.AVM.UserPowerController.HttpEntity;

namespace ERPApi.Controllers.AVM
{
    /// <summary>
    /// 用户权限
    /// </summary>
    [ControllerGroup("AVM", "UserPower")]
    public class UserPowerController : ControllerBase<UserPower, UserPowerService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增用户权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Create", Name = "ERP_AVM_UserPower_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                UserPowerService.CreateService service = new UserPowerService.CreateService();
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
        /// 更新用户权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Update", Name = "ERP_AVM_UserPower_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                UserPowerService.UpdateService service = new UserPowerService.UpdateService();
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
        /// 删除用户权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Delete", Name = "ERP_AVM_UserPower_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                UserPowerService.DeleteService service = new UserPowerService.DeleteService();
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
                            if(request.Entity != null)
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
        /// 查询用户权限的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Read/Columns", Name = "ERP_AVM_UserPower_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                UserPowerService.ColumnsService service = new UserPowerService.ColumnsService();
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
        /// 查询用户权限（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Read/Row", Name = "ERP_AVM_UserPower_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                UserPowerService.RowService service = new UserPowerService.RowService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("only"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.Only(ParseInt(request.Function.Args[0]), ParseInt(request.Function.Args[1]))
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
        /// 查询用户权限（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Read/Rows", Name = "ERP_AVM_UserPower_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                UserPowerService.RowsService service = new UserPowerService.RowsService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "byregistryid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByRegistryId(ParseInt(request.Function.Args[0]))
                                )
                            );
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("byuserid"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.ByUserId(ParseInt(request.Function.Args[0]))
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
        ///  查询用户权限（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Read/Single", Name = "ERP_AVM_UserPower_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                UserPowerService.SingleService service = new UserPowerService.SingleService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("only"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        service.Only(ParseInt(request.Function.Args[0]), ParseInt(request.Function.Args[1]))
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
        /// 查询用户权限（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Read/Query", Name = "ERP_AVM_UserPower_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                UserPowerService.QueryService service = new UserPowerService.QueryService();
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
        /// 查询用户权限（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/UserPower/Read/Tree", Name = "ERP_AVM_UserPower_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                UserPowerService.TreeService service = new UserPowerService.TreeService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    default:
                        if (string.IsNullOrEmpty(request.Function.Name) || request.Function.Name.ToLower().Equals("only"))
                        {
                            return base.ResponseOk(
                                    request.ToResponse(
                                        new List<UserPower>()
                                        {
                                            service.Only(ParseInt(request.Function.Args[0]), ParseInt(request.Function.Args[1]))
                                        }
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
                public class Request : CreateMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPower"></param>
                    /// <returns></returns>
                    public override CreateMode<UserPower>.Response ToResponse(UserPower userPower)
                    {
                        return base.ToResponse(userPower);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPowerLIst"></param>
                    /// <returns></returns>
                    public override CreateMode<UserPower>.Response ToResponse(List<UserPower> userPowerLIst)
                    {
                        return base.ToResponse(userPowerLIst);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<UserPower>.Response
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
                public class Request : UpdateMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPower"></param>
                    /// <returns></returns>
                    public override UpdateMode<UserPower>.Response ToResponse(UserPower userPower)
                    {
                        return base.ToResponse(userPower);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPowerLIst"></param>
                    /// <returns></returns>
                    public override UpdateMode<UserPower>.Response ToResponse(List<UserPower> userPowerLIst)
                    {
                        return base.ToResponse(userPowerLIst);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<UserPower>.Response
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
                public class Request : DeleteMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPower"></param>
                    /// <returns></returns>
                    public override DeleteMode<UserPower>.Response ToResponse(UserPower userPower)
                    {
                        return base.ToResponse(userPower);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPowerLIst"></param>
                    /// <returns></returns>
                    public override DeleteMode<UserPower>.Response ToResponse(List<UserPower> userPowerLIst)
                    {
                        return base.ToResponse(userPowerLIst);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<UserPower>.Response
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
                public class Request : ColumnsMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPower"></param>
                    /// <returns></returns>
                    public override ColumnsMode<UserPower>.Response ToResponse(UserPower userPower)
                    {
                        return base.ToResponse(userPower);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<UserPower>.Response
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
                public class Request : RowMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPower"></param>
                    /// <returns></returns>
                    public override RowMode<UserPower>.Response ToResponse(UserPower userPower)
                    {
                        return base.ToResponse(userPower);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<UserPower>.Response
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
                public class Request : RowsMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPowerLIst"></param>
                    /// <returns></returns>
                    public override RowsMode<UserPower>.Response ToResponse(List<UserPower> userPowerLIst)
                    {
                        return base.ToResponse(userPowerLIst);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<UserPower>.Response
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
                public class Request : SingleMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPower"></param>
                    /// <returns></returns>
                    public override SingleMode<UserPower>.Response ToResponse(UserPower userPower)
                    {
                        return base.ToResponse(userPower);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<UserPower>.Response
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
                public class Request : QueryMode<UserPower>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPowerLIst"></param>
                    /// <returns></returns>
                    public override QueryMode<UserPower>.Response ToResponse(List<UserPower> userPowerLIst)
                    {
                        return base.ToResponse(userPowerLIst);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<UserPower>.Response
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
                public class Request : TreeMode<UserPower>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userPowerLIst"></param>
                    /// <returns></returns>
                    public override TreeMode<UserPower>.BootstrapTreeViewResponse ToResponse(List<UserPower> userPowerLIst)
                    {
                        return base.ToResponse(userPowerLIst);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<UserPower>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}