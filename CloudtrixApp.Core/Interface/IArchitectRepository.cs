using eLearningHub.Core.Interface.Base;
using CloudtrixApp.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudtrixApp.Core.Interface
{
    public interface IArchitectRepository : IBaseRepository<ArchitectModel>
    {
        IEnumerable<SelectListItem> ArchitectForDropdown();
    }
}

