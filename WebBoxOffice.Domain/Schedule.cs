﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// Spectacles schedules
    /// </summary>
    [Table("Schedules")]
    public class Schedule:IDataBoxOffice
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        /// <summary>
        /// status
        /// </summary>
        
        public bool Enabled { get; set; }

        /// <summary>
        /// place
        /// </summary>
        public Hall Hall { get; set; }
        /// <summary>
        /// fkey Hall
        /// </summary>
        public Guid HallId { get; set; }

        /// <summary>
        /// Spectacle
        /// </summary>
        public Spectacle Spectacle { get; set; }
        /// <summary>
        /// fkey
        /// </summary>
        public Guid SpectacleId { get; set; }

        /// <summary>
        /// Start date and time
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }


        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }


        /// <summary>
        /// Tickets
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; }

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
