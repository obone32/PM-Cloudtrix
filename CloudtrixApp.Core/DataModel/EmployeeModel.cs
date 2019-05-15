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
    [Table("Employee")]
    public class EmployeeModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public decimal EmployeePhone { get; set; }
        public string EmployeeGender { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public DateTime EmployeeDOJ { get; set; }
        public string EmployeeAddress { get; set; }
        [Range(5000.00, 100000.00, ErrorMessage = "Salary Amount not valid")]
        public decimal EmployeeSalary { get; set; }
        public string Description { get; set; }
    }
}
