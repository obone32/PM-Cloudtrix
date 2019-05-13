using Ninject;
using CloudtrixApp.Core.Interface;
using CloudtrixApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Dependency
{
    public class DependenyResolver
    {
        public static IKernel Kernel { get; set; }
        public void Resolve()
        {
            Kernel = new StandardKernel();
            var serviceRegister = new DependencyServiceRegister();
            serviceRegister.Register(Kernel);
        }
    }

    public class DependencyServiceRegister
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IArchitectRepository>().To<ArchitectRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IReceiptRepository>().To<ReceiptRepository>();
            kernel.Bind<IPaymentStatusRepository>().To<PaymentStatusRepository>();
            kernel.Bind<IProjectRepository>().To<ProjectRepository>();
            kernel.Bind<ITimeSheetRepository>().To<TimeSheetRepository>();
            kernel.Bind<IInvoiceRepository>().To<InvoiceRepository>();
            kernel.Bind<IInvoiceItemRepository>().To<InvoiceItemRepository>();
            kernel.Bind<IStoreSettingRepository>().To<StoreSettingRepository>();
        }
    }
}
