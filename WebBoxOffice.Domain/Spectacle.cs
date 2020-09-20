using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// Spectacle
    /// </summary>
    [Table("Spectacles")]
    public class Spectacle:IDataBoxOffice
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Column(TypeName = "nvarchar(1024)")]
        public string Name { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        [Column(TypeName = "nvarchar(1024)")]
        public string ShortDescription { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        /// <summary>
        /// Spectacle - Duration in minutes
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// SpectacleLinks
        /// </summary>
        public ICollection<SpectaclesLinks> SpectacleLinks { get; set; }
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
