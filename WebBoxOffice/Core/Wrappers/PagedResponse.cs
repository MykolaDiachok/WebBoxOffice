using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBoxOffice.Core.Wrappers
{
    /// <summary>
    /// PagedResponse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResponse<T> : Response<T>
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
        /// FirstPage
        /// </summary>
        public Uri FirstPage { get; set; }
        /// <summary>
        /// LastPage
        /// </summary>
        public Uri LastPage { get; set; }
        /// <summary>
        /// TotalPages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// TotalRecords
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// NextPage
        /// </summary>
        public Uri NextPage { get; set; }
        /// <summary>
        /// PreviousPage
        /// </summary>
        public Uri PreviousPage { get; set; }
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}
