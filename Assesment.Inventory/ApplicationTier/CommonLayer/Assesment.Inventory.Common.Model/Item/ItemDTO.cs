using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Common.Model.Item
{
    /// <summary>
    /// ItemDTO class
    /// </summary>
    public class ItemDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [StringLength(150)]
        [Required(ErrorMessage = "Item name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the units avaialble.
        /// </summary>
        /// <value>
        /// The units avaialble.
        /// </value>
        [Required(ErrorMessage = "No of units available is required")]
        [Range(0.01, 999999999.99, ErrorMessage = "No of units available must be positive")]
        public decimal UnitsAvaialble { get; set; }

        /// <summary>
        /// Gets or sets the re order level.
        /// </summary>
        /// <value>
        /// The re order level.
        /// </value>
        [Required(ErrorMessage = "Re-order level is required")]
        [Range(0.01, 999999999.99, ErrorMessage = "Re-order level must be positive")]
        public decimal ReOrderLevel { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        [Required(ErrorMessage = "Unit price is required")]
        [Range(0.01, 999999999.99, ErrorMessage = "Unit price must be positive")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the record status identifier.
        /// </summary>
        /// <value>
        /// The record status identifier.
        /// </value>
        public int RecordStatusId { get; set; }
    }
}
