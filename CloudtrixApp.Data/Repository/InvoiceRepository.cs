using eLearningHub.Data.Repository.BaseRepository;
using CloudtrixApp.Core.DataModel;
using CloudtrixApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudtrixApp.Core.ViewModel;

namespace CloudtrixApp.Data.Repository
{
    public class InvoiceRepository : BaseRepository<InvoiceModel>, IInvoiceRepository
    {

        public InvoiceViewModel GetInvoiceById(int InvoiceId)
        {
            var model = All().SingleOrDefault(x => x.Id == InvoiceId);
            if (model != null)
            {

            }

            throw new NotImplementedException();
        }
    }
}
