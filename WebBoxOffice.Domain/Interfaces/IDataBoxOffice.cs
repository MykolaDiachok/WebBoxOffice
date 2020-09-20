using System;

namespace WebBoxOffice.Domain
{
    /// <summary>
    /// base interface for data classes
    /// </summary>
    public interface IDataBoxOffice
    {
        /// <summary>
        /// 
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// LastUpdated - last create or change date
        /// </summary>
        DateTime LastUpdated { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        byte[] Timestamp { get; set; }

        /// <summary>
        /// LastChangedUserId
        /// </summary>
        string LastUserId { get; set; }
    }
}