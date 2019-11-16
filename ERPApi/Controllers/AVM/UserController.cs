using ERPApi.Entities.AVM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.AVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.AVM.UserController.HttpEntity;

namespace ERPApi.Controllers.AVM
{
    /// <summary>
    /// 用户
    /// </summary>
    [ControllerGroup("AVM", "User")]
    [Authorize("wzkj")]
    public class UserController : BaseController<User, UserService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Create", Name = "ERP_AVM_User_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                UserService.CreateService service = new UserService.CreateService();
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

        #region UpdateMode
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Update", Name = "ERP_AVM_User_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                UserService.UpdateService service = new UserService.UpdateService();
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
                    case "bindwechat":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.BindWeChat(request.Function.Args[0]??"", request.Function.Args[1]??"", request.Function.Args[2]??"", request.Function.Args[3]??"")
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
        /// 删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Delete", Name = "ERP_AVM_User_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                UserService.DeleteService service = new UserService.DeleteService();
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
        /// 查询用户的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Read/Columns", Name = "ERP_AVM_User_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                UserService.ColumnsService service = new UserService.ColumnsService();
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
        /// 查询用户（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Read/Row", Name = "ERP_AVM_User_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                UserService.RowService service = new UserService.RowService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "bywechatno":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByWeChatNo(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                )
                            );
                    case "bywechatopenid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByWeChatOpenId(request.Function.Args[0]??"", ToParams(request.Function.Args, 1))
                                )
                            );
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
        /// 查询用户（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Read/Rows", Name = "ERP_AVM_User_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                UserService.RowsService service = new UserService.RowsService();
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 指向具体执行的方法
                switch (request.Function.Name.ToLower())
                {
                    case "byroleid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByRoleId(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
                                )
                            );
                    case "byregistryid":
                        return base.ResponseOk(
                                request.ToResponse(
                                    service.ByRegistryId(ParseInt(request.Function.Args[0]??""), ToParams(request.Function.Args, 1))
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
        ///  查询用户（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Read/Single", Name = "ERP_AVM_User_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                UserService.SingleService service = new UserService.SingleService();
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
        /// 查询用户（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Read/Query", Name = "ERP_AVM_User_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                UserService.QueryService service = new UserService.QueryService();
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
        /// 查询用户（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/AVM/User/Read/Tree", Name = "ERP_AVM_User_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                UserService.TreeService service = new UserService.TreeService();
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
                public class Request : CreateMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="user"></param>
                    /// <returns></returns>
                    public override CreateMode<User>.Response ToResponse(User user)
                    {
                        return base.ToResponse(user);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userList"></param>
                    /// <returns></returns>
                    public override CreateMode<User>.Response ToResponse(List<User> userList)
                    {
                        return base.ToResponse(userList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<User>.Response
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
                public class Request : UpdateMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="user"></param>
                    /// <returns></returns>
                    public override UpdateMode<User>.Response ToResponse(User user)
                    {
                        return base.ToResponse(user);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userList"></param>
                    /// <returns></returns>
                    public override UpdateMode<User>.Response ToResponse(List<User> userList)
                    {
                        return base.ToResponse(userList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<User>.Response
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
                public class Request : DeleteMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="user"></param>
                    /// <returns></returns>
                    public override DeleteMode<User>.Response ToResponse(User user)
                    {
                        return base.ToResponse(user);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userList"></param>
                    /// <returns></returns>
                    public override DeleteMode<User>.Response ToResponse(List<User> userList)
                    {
                        return base.ToResponse(userList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<User>.Response
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
                public class Request : ColumnsMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="user"></param>
                    /// <returns></returns>
                    public override ColumnsMode<User>.Response ToResponse(User user)
                    {
                        return base.ToResponse(user);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<User>.Response
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
                public class Request : RowMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="user"></param>
                    /// <returns></returns>
                    public override RowMode<User>.Response ToResponse(User user)
                    {
                        return base.ToResponse(user);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<User>.Response
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
                public class Request : RowsMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userList"></param>
                    /// <returns></returns>
                    public override RowsMode<User>.Response ToResponse(List<User> userList)
                    {
                        return base.ToResponse(userList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<User>.Response
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
                public class Request : SingleMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="user"></param>
                    /// <returns></returns>
                    public override SingleMode<User>.Response ToResponse(User user)
                    {
                        return base.ToResponse(user);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<User>.Response
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
                public class Request : QueryMode<User>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userList"></param>
                    /// <returns></returns>
                    public override QueryMode<User>.Response ToResponse(List<User> userList)
                    {
                        return base.ToResponse(userList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<User>.Response
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
                public class Request : TreeMode<User>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="userList"></param>
                    /// <returns></returns>
                    public override TreeMode<User>.BootstrapTreeViewResponse ToResponse(List<User> userList)
                    {
                        return base.ToResponse(userList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<User>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}