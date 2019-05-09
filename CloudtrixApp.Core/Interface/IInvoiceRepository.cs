using eLearningHub.Core.Interface.Base;
using CloudtrixApp.Core.DataModel;
using CloudtrixApp.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Core.Interface
{
    public interface IInvoiceRepository : IBaseRepository<InvoiceModel>
    {
        InvoiceViewModel GetInvoiceById(int InvoiceId);
    }
}
