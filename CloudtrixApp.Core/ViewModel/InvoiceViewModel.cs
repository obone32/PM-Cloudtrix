using CloudtrixApp.Core.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudtrixApp.Core.ViewModel
{
    public class InvoiceViewModel
    {
        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }
        [DisplayName("Project Name")]
        [ForeignKey("ProjectModel")]
        public int ProjectId { get; set; }
        public ProjectModel ProjectModel { get; set; }
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

        public ICollection<InvoiceItemsViewModel> InvoiceItems { get; set; }

        public InvoiceViewModel()
        {
            InvoiceItems = new List<InvoiceItemsViewModel>();
        }
    }

    public class InvoiceItemsViewModel
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public double Total { get; set; }

    }
}
