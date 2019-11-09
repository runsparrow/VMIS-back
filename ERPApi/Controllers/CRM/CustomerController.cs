using ERPApi.Entities.CRM;
using ERPApi.HttpClients.HttpModes;
using ERPApi.Services.CRM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ERPApi.Controllers.CRM.CustomerController.HttpEntity;

namespace ERPApi.Controllers.CRM
{
    /// <summary>
    /// 客户
    /// </summary>
    [ControllerGroup("CRM", "Customer")]
    [Authorize("wzkj")]
    public class CustomerController : BaseController<Customer, CustomerService>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Create", Name = "ERP_CRM_Customer_Create")]
        [HttpPost]
        public IActionResult Post(CreateMode.Request request)
        {
            try
            {
                CustomerService.CreateService service = new CustomerService.CreateService();
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
        /// 更新客户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Update", Name = "ERP_CRM_Customer_Update")]
        [HttpPost]
        public IActionResult Post(UpdateMode.Request request)
        {
            try
            {
                CustomerService.UpdateService service = new CustomerService.UpdateService();
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
        /// 删除客户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Delete", Name = "ERP_CRM_Customer_Delete")]
        [HttpPost]
        public IActionResult Post(DeleteMode.Request request)
        {
            try
            {
                CustomerService.DeleteService service = new CustomerService.DeleteService();
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
        /// 查询客户的字段
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Read/Columns", Name = "ERP_CRM_Customer_Read_Columns")]
        [HttpPost]
        public IActionResult Post(ColumnsMode.Request request)
        {
            try
            {
                CustomerService.ColumnsService service = new CustomerService.ColumnsService();
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
        /// 查询客户（单条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Read/Row", Name = "ERP_CRM_Customer_Read_Row")]
        [HttpPost]
        public IActionResult Post(RowMode.Request request)
        {
            try
            {
                CustomerService.RowService service = new CustomerService.RowService();
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
                                        service.ById(int.Parse(request.Function.Args[0]), ToParams(request.Function.Args, 1))
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
        /// 查询客户（多条记录）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Read/Rows", Name = "ERP_CRM_Customer_Read_Rows")]
        [HttpPost]
        public IActionResult Post(RowsMode.Request request)
        {
            try
            {
                CustomerService.RowsService service = new CustomerService.RowsService();
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
                                        service.ByKeyWord(request.Function.Args[0], ToParams(request.Function.Args, 1))
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
        ///  查询客户（单条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Read/Single", Name = "ERP_CRM_Customer_Read_Single")]
        [HttpPost]
        public IActionResult Post(SingleMode.Request request)
        {
            try
            {
                CustomerService.SingleService service = new CustomerService.SingleService();
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
                                        service.ById(int.Parse(request.Function.Args[0]), ToParams(request.Function.Args, 1))
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
        /// 查询客户（多条记录带JSON包装）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Read/Query", Name = "ERP_CRM_Customer_Read_Query")]
        [HttpPost]
        public IActionResult Post(QueryMode.Request request)
        {
            try
            {
                CustomerService.QueryService service = new CustomerService.QueryService();
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
        /// 查询客户（树形结构）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("ERP/CRM/Customer/Read/Tree", Name = "ERP_CRM_Customer_Read_Tree")]
        [HttpPost]
        public IActionResult Post(TreeMode.Request request)
        {
            try
            {
                CustomerService.TreeService service = new CustomerService.TreeService();
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
                                        service.ByKeyWord(request.Function.Args[0], ToParams(request.Function.Args, 1))
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
                public class Request : CreateMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customer"></param>
                    /// <returns></returns>
                    public override CreateMode<Customer>.Response ToResponse(Customer customer)
                    {
                        return base.ToResponse(customer);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customerList"></param>
                    /// <returns></returns>
                    public override CreateMode<Customer>.Response ToResponse(List<Customer> customerList)
                    {
                        return base.ToResponse(customerList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : CreateMode<Customer>.Response
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
                public class Request : UpdateMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customer"></param>
                    /// <returns></returns>
                    public override UpdateMode<Customer>.Response ToResponse(Customer customer)
                    {
                        return base.ToResponse(customer);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customerList"></param>
                    /// <returns></returns>
                    public override UpdateMode<Customer>.Response ToResponse(List<Customer> customerList)
                    {
                        return base.ToResponse(customerList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : UpdateMode<Customer>.Response
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
                public class Request : DeleteMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customer"></param>
                    /// <returns></returns>
                    public override DeleteMode<Customer>.Response ToResponse(Customer customer)
                    {
                        return base.ToResponse(customer);
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customerList"></param>
                    /// <returns></returns>
                    public override DeleteMode<Customer>.Response ToResponse(List<Customer> customerList)
                    {
                        return base.ToResponse(customerList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : DeleteMode<Customer>.Response
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
                public class Request : ColumnsMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customer"></param>
                    /// <returns></returns>
                    public override ColumnsMode<Customer>.Response ToResponse(Customer customer)
                    {
                        return base.ToResponse(customer);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : ColumnsMode<Customer>.Response
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
                public class Request : RowMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customer"></param>
                    /// <returns></returns>
                    public override RowMode<Customer>.Response ToResponse(Customer customer)
                    {
                        return base.ToResponse(customer);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowMode<Customer>.Response
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
                public class Request : RowsMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customerList"></param>
                    /// <returns></returns>
                    public override RowsMode<Customer>.Response ToResponse(List<Customer> customerList)
                    {
                        return base.ToResponse(customerList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : RowsMode<Customer>.Response
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
                public class Request : SingleMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customer"></param>
                    /// <returns></returns>
                    public override SingleMode<Customer>.Response ToResponse(Customer customer)
                    {
                        return base.ToResponse(customer);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : SingleMode<Customer>.Response
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
                public class Request : QueryMode<Customer>.Request
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customerList"></param>
                    /// <returns></returns>
                    public override QueryMode<Customer>.Response ToResponse(List<Customer> customerList)
                    {
                        return base.ToResponse(customerList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : QueryMode<Customer>.Response
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
                public class Request : TreeMode<Customer>.BootstrapTreeViewRequest
                {
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="customerList"></param>
                    /// <returns></returns>
                    public override TreeMode<Customer>.BootstrapTreeViewResponse ToResponse(List<Customer> customerList)
                    {
                        return base.ToResponse(customerList);
                    }
                }
                /// <summary>
                /// 
                /// </summary>
                public class Response : TreeMode<Customer>.BootstrapTreeViewRequest
                {

                }
            }
            #endregion
        }
        #endregion

    }
}