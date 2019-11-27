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
    [Table("Project")]
    public class ProjectModel  :   BaseModel
    {
        [Required]
        public string ProjectName { get; set; }
        [DisplayName("Billing Name")]
        public string BillingName { get; set; }

        [DisplayName("Project Head")]
        [ForeignKey("ArchitectModel")]
        public int ArchitectId { get; set; }
        public ArchitectModel ArchitectModel { get; set; }

        [DisplayName("Client Name")]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Employee List")]
        public string EmployeeIds { get; set; }

        public string[] EmployeeIds_List { get; set; }


    }
}
