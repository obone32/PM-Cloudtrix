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
    [Table("Customer")]
    public class CustomerModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactPerson { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string GSTIN { get; set; }
        public string Notes { get; set; }

    }
}
