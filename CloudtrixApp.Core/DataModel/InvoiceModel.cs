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
    [Table("Invoice")]
    public class InvoiceModel : BaseModel
    {
        [Required]
        [DisplayName("Invoice Code")]
        public string InvoiceCode { get; set; }
        [Required]
        [DisplayName("Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        public string Notes { get; set; }
        [Required]
        public Double Total { get; set; }
        [Required]
        [DisplayName("Payment Method")]
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public double Discount { get; set; }
        public double IGST { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double GrandTotal { get; set; }

        [DisplayName("Project ")]
        [ForeignKey("ProjectModel")]
        public int ProjectId { get; set; }
        public ProjectModel ProjectModel { get; set; }


        public ICollection<InvoiceItemsModel> Items { get; set; }

        public InvoiceModel()
        {
            Items = new List<InvoiceItemsModel>();
        }
    }
}
