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
    [Table("Associate")]
    public class ArchitectItemModel : BaseModel
    {
        [DisplayName("Architect")]
        [ForeignKey("ArchitectModel")]
        public int ArchitectId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public ArchitectModel ArchitectModel { get; set; }
    }
}
