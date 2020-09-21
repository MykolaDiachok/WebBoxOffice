using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// class Ticket
    /// </summary>
    [Table("Tickets")]
    public class Ticket:IDataBoxOffice
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Schedule
        /// </summary>
        public virtual Schedule Schedule { get; set; }
        /// <summary>
        /// fkey ScheduleId
        /// </summary>
        public virtual Guid ScheduleId { get; set; }

        /// <summary>
        /// Paid
        /// </summary>
        public bool Paid { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        
        
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
