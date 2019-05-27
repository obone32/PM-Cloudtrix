using CloudtrixApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Core.DataModel
{
    [Table("InvoiceItems")]
    public class InvoiceItemsModel : BaseModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Amount { get; set; }

        [DisplayName("Invoice")]
        [ForeignKey("InvoiceModel")]
        public int InvoiceId { get; set; }

        [Range(0.1, 100)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Percentage")]
        public Double IGST { get; set; }
        [Required]
        public Double IGSTAmt { get; set; }

        [Range(0.1, 100)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Percentage")]
        public Double CGST { get; set; }
        [Required]
        public Double CGSTAmt { get; set; }

        [Range(0.1, 100)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Percentage")]
        public Double SGST { get; set; }
        [Required]
        public Double SGSTAmt { get; set; }
        [Required]
        public Double TotAmt { get; set; }

        public InvoiceModel InvoiceModel { get; set; }


    }
}
