using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Controllers.GL.Abstract;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Filters;
using WebBoxOffice.Core.Helpers;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Controllers.GL
{
    //TODO: add pagination with data filters
    /// <summary>
    /// Schedule
    /// </summary>
    [AllowAnonymous]
    public class ScheduleController : GlController<Schedule>
    {
        /// <summary>
        /// ScheduleController
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public ScheduleController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<Schedule> logger, UserManager<WebBoxOfficeUser> userManager) : base(boxOfficeDbContext, uriService, logger, userManager)
        {
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        public override async Task<IActionResult> GetAll(PaginationFilter filter, CancellationToken ct)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await BoxOfficeDbContext.Schedules
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync(ct);
            var totalRecords = await BoxOfficeDbContext.Set<Schedule>().CountAsync(ct);
            var pagedResponse = PaginationHelper.CreatePagedReponse<Schedule>(pagedData, validFilter, totalRecords, UriService, route);
            return Ok(pagedResponse);
        }
    }
}
