using System;
using System.Collections.Generic;
using WebBoxOffice.Core.Filters;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Core.Wrappers;

namespace WebBoxOffice.Core.Helpers
{
    /// <summary>
    /// PaginationHelper
    /// </summary>
    public static class PaginationHelper
    {
        /// <summary>
        /// CreatePagedReponse
        /// </summary>
        /// <param name="pagedData"></param>
        /// <param name="validFilter"></param>
        /// <param name="totalRecords"></param>
        /// <param name="uriService"></param>
        /// <param name="route"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PagedResponse<ICollection<T>> CreatePagedReponse<T>(ICollection<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
        {
            var reponse = new PagedResponse<ICollection<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            reponse.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                    ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                    : null;
            reponse.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                    ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                    : null;
            reponse.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            reponse.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            reponse.TotalPages = roundedTotalPages;
            reponse.TotalRecords = totalRecords;
            return reponse;
        }
    }
}
