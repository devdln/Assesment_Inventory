using Assesment.Inventory.Data.Model.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Inventory.Data.Model.Item
{
    /// <summary>
    /// Item class
    /// </summary>
    [Table("Items", Schema = "item")]
    public class Item : BaseClass
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the units avaialble.
        /// </summary>
        /// <value>
        /// The units avaialble.
        /// </value>
        [Required]
        [Range(0.01, 999999999.99)]
        public decimal UnitsAvaialble { get; set; }

        /// <summary>
        /// Gets or sets the re order level.
        /// </summary>
        /// <value>
        /// The re order level.
        /// </value>
        [Required]
        [Range(0.01, 999999999.99)]
        public decimal ReOrderLevel { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        [Required]
        [Range(0.01, 999999999.99)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the record status identifier.
        /// </summary>
        /// <value>
        /// The record status identifier.
        /// </value>
        [Required]
        public int RecordStatusId { get; set; }

        /// <summary>
        /// Gets or sets the record status.
        /// </summary>
        /// <value>
        /// The record status.
        /// </value>
        [ForeignKey("RecordStatusId")]
        public RecordStatus RecordStatus { get; set; }
    }
}
