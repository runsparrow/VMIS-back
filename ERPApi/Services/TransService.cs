using System.Transactions;

namespace ERPApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TransService
    {
        /// <summary>
        /// 定义事务函数的委托
        /// </summary>
        public delegate void TransDelegate();

        private TransDelegate transDelegate;

        /// <summary>
        /// 使用WIN系统 MSDTC 服务，分布式事务
        /// </summary>
        /// <param name="transDelegate"></param>
        private void TransScope(TransDelegate transDelegate)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                transDelegate();
                //提交
                transaction.Complete();
            }
        }

        /// <summary>
        /// 注册需要参与事务的委托
        /// </summary>
        /// <param name="transDelegate"></param>
        public void TransRegist(TransDelegate transDelegate)
        {
            if (this.transDelegate == null)
                this.transDelegate = transDelegate;
            else
                this.transDelegate += transDelegate;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void TransCommit()
        {
            TransScope(transDelegate);
        }
    }
}