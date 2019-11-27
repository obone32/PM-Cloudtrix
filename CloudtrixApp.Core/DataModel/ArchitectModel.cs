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
    [Table("Architect")]
    public class ArchitectModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        public string ArchitectName { get; set; }
        public string Description { get; set; }

        public ICollection<ArchitectItemModel> Items { get; set; }

        public ArchitectModel()
        {
            Items = new List<ArchitectItemModel>();
        }
    }
}
