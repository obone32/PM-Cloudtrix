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
        [Required]
        [StringLength(10)]
        public string ReceiptNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ReceiptDate { get; set; }

        [Required]
        [DisplayName("Client Name")]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        [Required]
        [DisplayName("Project Name")]
        [ForeignKey("ProjectModel")]
        public int ProjectId { get; set; }
        public ProjectModel ProjectModel { get; set; }

        [Required]
        [Range(1.00, 1000000.00, ErrorMessage = "Amount not valid")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Status")]
        [ForeignKey("PaymentStatusModel")]
        public int PaymentStatusId { get; set; }
        public PaymentStatusModel PaymentStatusModel { get; set; }

        [Required]
        public string ReceivedBy { get; set; }

        public string Description { get; set; }
    }
}
