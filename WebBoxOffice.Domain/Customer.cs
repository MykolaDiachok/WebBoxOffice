using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// Customer
    /// </summary>
    [Table("Customers")]
    public class Customer: IDataBoxOffice
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string UserId { get; set; }

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

        /// <summary>
        /// user who changed last
        /// </summary>
        [Column(TypeName = "nvarchar(450)")]
        public string LastUserId { get; set; }
    }
}

