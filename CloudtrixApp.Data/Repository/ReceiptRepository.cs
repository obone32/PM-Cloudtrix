using eLearningHub.Data.Repository.BaseRepository;
using CloudtrixApp.Core.DataModel;
using CloudtrixApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudtrixApp.Data.Repository
{
    public class ReceiptRepository : BaseRepository<ReceiptModel>, IReceiptRepository
    {
        public IEnumerable<SelectListItem> ReceiptForDropdown()
        {
            return All().ToList().Select(x => new SelectListItem
            {
                Text = x.ReceiptNumber,
                Value = x.Id.ToString()
            });

        }
    }
}
