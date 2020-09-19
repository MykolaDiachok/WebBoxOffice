using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBoxOffice.Core.Filters
{
    /// <summary>
    /// PaginationFilter
    /// </summary>
    public class PaginationFilter
    {
        /// <summary>
        /// PageNumber
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// ctor
        /// </summary>
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        /// <summary>
        /// PaginationFilter
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
