﻿using eLearningHub.Data.Repository.BaseRepository;
using CloudtrixApp.Core.DataModel;
using CloudtrixApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Data.Repository
{
    public class InvoiceItemRepository : BaseRepository<InvoiceItemsModel>, IInvoiceItemRepository
    {
    }
}
