using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Data.Model.Metadata
{
    /// <summary>
    /// RecordStatus class
    /// </summary>
    [Table("RecordStatus", Schema = "metadata")]
    public class RecordStatus
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [StringLength(100)]
        public string Description { get; set; }
    }
}
