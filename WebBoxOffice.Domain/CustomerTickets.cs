using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// Customer Tickets
    /// </summary>
    [Table("CustomerTickets")]
    public class CustomerTickets
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Tickets
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; }

        /// <summary>
        /// Date of sale ticket
        /// </summary>
        public DateTime? DateOfSale { get; set; }

        /// <summary>
        /// Sold price
        /// </summary>
        public decimal SoldPrice { get; set; }
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
