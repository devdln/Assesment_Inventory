using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Common.Model.Item
{
    public class ItemDTO
    {
        public long Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Item name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "No of units available is required")]
        [Range(0.01, 999999999.99, ErrorMessage = "No of units available must be positive")]
        public decimal UnitsAvaialble { get; set; }

        [Required(ErrorMessage = "Re-order level is required")]
        [Range(0.01, 999999999.99, ErrorMessage = "Re-order level must be positive")]
        public decimal ReOrderLevel { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        [Range(0.01, 999999999.99, ErrorMessage = "Unit price must be positive")]
        public decimal UnitPrice { get; set; }

        public int RecordStatusId { get; set; }
    }
}
