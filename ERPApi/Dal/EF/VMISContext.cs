
using Microsoft.EntityFrameworkCore;

namespace ERPApi.Dal.EFHelper
{
    /// <summary>
    /// 
    /// </summary>
    public partial class VMISContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString("VMISContext"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.AVM.UserPower>().HasKey(key => new { key.UserId, key.RegistryId });
            modelBuilder.Entity<Entities.AVM.RERoleUser>().HasKey(key => new { key.UserId, key.RoleId });
            modelBuilder.Entity<Entities.AVM.RERoleRegistry>().HasKey(key => new { key.RoleId, key.RegistryId });
            modelBuilder.Entity<Entities.AVM.REUserRegistry>().HasKey(key => new { key.UserId, key.RegistryId });
            base.OnModelCreating(modelBuilder);
        }

        #region AVM
        /// <summary>
        /// 用户
        /// </summary>
        public virtual DbSet<Entities.AVM.User> AVM_User { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public virtual DbSet<Entities.AVM.UserPower> AVM_UserPower { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual DbSet<Entities.AVM.Role> AVM_Role{ get; set; }
        /// <summary>
        /// 功能
        /// </summary>
        public virtual DbSet<Entities.AVM.Registry> AVM_Registry{ get; set; }
        /// <summary>
        /// 角色用户关系
        /// </summary>
        public virtual DbSet<Entities.AVM.RERoleUser> AVM_RE_RoleUser{ get; set; }
        /// <summary>
        /// 角色功能关系
        /// </summary>
        public virtual DbSet<Entities.AVM.RERoleRegistry> AVM_RE_RoleRegistry { get; set; }
        /// <summary>
        /// 用户功能关系
        /// </summary>
        public virtual DbSet<Entities.AVM.REUserRegistry> AVM_RE_UserRegistry { get; set; }
        #endregion

        #region ASM
        /// <summary>
        /// 字典
        /// </summary>
        public virtual DbSet<Entities.ASM.Dictionary> ASM_Dictionary { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public virtual DbSet<Entities.ASM.Region> ASM_Region { get; set; }
        #endregion

        #region WFM
        /// <summary>
        /// 状态
        /// </summary>
        public virtual DbSet<Entities.WFM.Status> WFM_Status { get; set; }
        #endregion

        #region CRM
        /// <summary>
        /// 客户
        /// </summary>
        public virtual DbSet<Entities.CRM.Customer> CRM_Customer { get; set; }
        #endregion

        #region SRM
        /// <summary>
        /// 场地
        /// </summary>
        public virtual DbSet<Entities.SRM.Site> SRM_Site { get; set; }
        /// <summary>
        /// 展厅
        /// </summary>
        public virtual DbSet<Entities.SRM.Venue> SRM_Venue { get; set; }
        #endregion

        #region BPM
        /// <summary>
        /// 任务
        /// </summary>
        public virtual DbSet<Entities.BPM.Task> BPM_Task { get; set; }
        #endregion
    }

}
