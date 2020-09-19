using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using WebBoxOffice.Core.Filters;

namespace WebBoxOffice.Core.Services
{
    /// <summary>
    /// UriService
    /// </summary>
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseUri"></param>
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        /// <summary>
        /// GetPageUri
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var endPointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endPointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
