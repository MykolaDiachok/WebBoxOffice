﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Table("BoxOffices")]
    public class BoxOffice
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Hall> Halls { get; set; }
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

