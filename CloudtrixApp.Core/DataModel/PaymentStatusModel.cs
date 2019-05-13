using CloudtrixApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Core.DataModel
{
    [Table("PaymentStatus")]
    public class PaymentStatusModel : BaseModel
    {
        [StringLength(30)]
        public string PaymentStatus { get; set; }
    }
}
