using CloudtrixApp.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Data.AppDbContext
{
    public class CloudtrixDbContext  : DbContext
    {
        public DbSet<ArchitectModel> Architects { get; set; }
        public DbSet<ArchitectItemModel> ArchitectItemModel { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<CustomerModel> Customers{ get; set; }
        public DbSet<StoreSettingModel> StoreSetting { get; set; }
        public DbSet<InvoiceModel> InvoiceModel { get; set; }
        public DbSet<InvoiceItemsModel> InvoiceItemsModel { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<TimeSheetModel> TimeSheet { get; set; }
        public DbSet<UserAccountModel> Users { get; set; }

        public CloudtrixDbContext() : base("CloudtrixContext")
        {

        }
    }
}
