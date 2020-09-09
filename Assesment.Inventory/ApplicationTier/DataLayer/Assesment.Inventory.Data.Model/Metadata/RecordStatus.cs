using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Data.Model.Metadata
{
    [Table("RecordStatus", Schema = "metadata")]
    public class RecordStatus
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
