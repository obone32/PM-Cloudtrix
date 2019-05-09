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
    [Table("TimeSheet")]
    public class TimeSheetModel : BaseModel
    {
        [Required]
        [DisplayName("Employee Name")]
        [ForeignKey("EmployeeModel")]
        public int EmployeeId { get; set; }
        public EmployeeModel EmployeeModel { get; set; }

        [Required]
        [DisplayName("Project Name")]
        [ForeignKey("ProjectModel")]
        public int ProjectId { get; set; }
        public ProjectModel ProjectModel { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string WorkDetails { get; set; }

    }
}
