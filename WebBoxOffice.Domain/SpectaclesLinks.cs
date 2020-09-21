using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// SpectaclesLinks
    /// </summary>
    [Table("SpectaclesLinks")]
    public class SpectaclesLinks:IDataBoxOffice
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Spectacle
        /// </summary>
        public Spectacle Spectacle { get; set; }
        /// <summary>
        /// fkey
        /// </summary>
        public Guid SpectacleId { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Column(TypeName = "nvarchar(1024)")]
        public string Description { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [Column(TypeName = "nvarchar(2048)")]
        public string Url { get; set; }

        /// <summary>
        /// ContentUrl
        /// </summary>
        [Column(TypeName = "nvarchar(2048)")]
        public string ContentUrl { get; set; }
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
