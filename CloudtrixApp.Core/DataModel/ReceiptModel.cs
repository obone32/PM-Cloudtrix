using CloudtrixApp.Core.DataModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CloudtrixApp.Core.DataModel
{
    [Table("Receipt")]
    public class ReceiptModel : BaseModel
    {
        public string ReceiptNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ReceiptDate { get; set; }

        [DisplayName("Client Name")]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        [DisplayName("Project Name")]
        [ForeignKey("ProjectModel")]
        public int ProjectId { get; set; }
        public ArchitectModel ProjectModel { get; set; }

        public decimal Amount { get; set; }

        public int Status { get; set; }

        public string ReceivedBy { get; set; }

        
    }
}
