using Assesment.Inventory.Data.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Data.Model.Item
{
    [Table("Items", Schema = "item")]
    public class Item
    {        
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 999999999.99)]
        public decimal UnitsAvaialble { get; set; }

        [Required]
        [Range(0.01, 999999999.99)]
        public decimal ReOrderLevel { get; set; }

        [Required]
        [Range(0.01, 999999999.99)]
        public decimal UnitPrice { get; set; }

        [Required]
        public int RecordStatusId { get; set; }

        [ForeignKey("RecordStatusId")]
        public RecordStatus RecordStatus { get; set; }
    }
}
