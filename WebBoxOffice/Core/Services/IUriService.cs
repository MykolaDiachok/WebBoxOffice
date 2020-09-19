using System;
using WebBoxOffice.Core.Filters;

namespace WebBoxOffice.Core.Services
{
    /// <summary>
    /// IUriService
    /// </summary>
    public interface IUriService
    {
        /// <summary>
        /// GetPageUri
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
