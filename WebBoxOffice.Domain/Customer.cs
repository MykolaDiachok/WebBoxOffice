using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// Customer
    /// </summary>
    [Table("Customers")]
    public class Customer
    {
        /// <summary>
        /// Id
        /// </summary>
        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Column(TypeName = "nvarchar(256)")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        [Column(TypeName = "nvarchar(256)")]
        [Required]
        public string Surname { get; set; }


        
        /// <summary>
        /// LastUpdated - last create or change date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}

