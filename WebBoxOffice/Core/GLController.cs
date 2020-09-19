using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Core.Filters;
using WebBoxOffice.Core.Helpers;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Core.Wrappers;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;

namespace WebBoxOffice.Core
{
    /// <summary>
    /// GLController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Route("api/GL/[controller]")]
    [ApiController]
    public abstract class GlController<T>: ControllerBase where T : class
    {
        private readonly WebBoxOfficeDbContext _boxOfficeDbContext;
        private readonly IUriService _uriService;
        private readonly ILogger<T> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        protected GlController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService,ILogger<T> logger)
        {
            _boxOfficeDbContext = boxOfficeDbContext;
            _uriService = uriService;
            _logger = logger;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _boxOfficeDbContext.Set<T>()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _boxOfficeDbContext.Set<T>().CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<T>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
        }
    }
}
