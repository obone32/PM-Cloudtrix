using CloudtrixApp.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Core.ViewModel
{
    public class InvoiceReportViewModel
    {
        public StoreSettingModel company { get; set; }
        public InvoiceModel Invoice { get; set; }
    }
}
