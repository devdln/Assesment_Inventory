using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Data.Model
{
    /// <summary>
    /// BaseClass class
    /// </summary>
    public class BaseClass
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [StringLength(150)]
        [Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        [StringLength(150)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
    }
}
