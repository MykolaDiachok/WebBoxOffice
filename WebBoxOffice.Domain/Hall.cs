﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Halls")]
    public class Hall:IDataBoxOffice
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
        public int FreePlaces { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DataBoxOffice DataBoxOffice { get; set; }
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
