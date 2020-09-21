using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Core.Filters;
using WebBoxOffice.Core.Helpers;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Core.Wrappers;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Core
{
    /// <summary>
    /// GLController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //TODO: add API version
    [Route("api/GL/[controller]")]
    [ApiController]
    
    public abstract class GlController<T>: ControllerBase where T : class, IDataBoxOffice
    {
        private readonly WebBoxOfficeDbContext _boxOfficeDbContext;
        private readonly IUriService _uriService;
        private readonly ILogger<T> _logger;
        private readonly UserManager<WebBoxOfficeUser> _userManager;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        protected GlController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService,ILogger<T> logger, UserManager<WebBoxOfficeUser> userManager)
        {
            _boxOfficeDbContext = boxOfficeDbContext;
            _uriService = uriService;
            _logger = logger;
            _userManager = userManager;
        }


        /// <summary>
        /// Get one
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> GetById(Guid id, CancellationToken ct)
        {
            var entity = await _boxOfficeDbContext.Set<T>().Where(x=>x.Id==id).FirstOrDefaultAsync(ct);
            if (entity == null)
                return NotFound();
            return Ok(new Response<T>(entity));
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter, CancellationToken ct)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _boxOfficeDbContext.Set<T>()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync(ct);
            var totalRecords = await _boxOfficeDbContext.Set<T>().CountAsync(ct);
            var pagedResponse = PaginationHelper.CreatePagedReponse<T>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedResponse);
        }

        /// <summary>
        /// Delete one
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> DeleteById(Guid id, CancellationToken ct)
        {
            var entity = await _boxOfficeDbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync(ct);
            if (entity == null)
            {
                return NotFound();
            }
            _boxOfficeDbContext.Set<T>().Remove(entity);
            await _boxOfficeDbContext.SaveChangesAsync(ct);
            return Ok();
        }

        /// <summary>
        /// Create one
        /// </summary>
        /// <param name="dataBoxOffice"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> CreateNew([FromBody]T dataBoxOffice, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            dataBoxOffice.LastUserId = user!=null ? user.Id : "Anonymous";
            await _boxOfficeDbContext.AddAsync(dataBoxOffice, ct);
            await _boxOfficeDbContext.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new {id = dataBoxOffice.Id}, dataBoxOffice);
        }

        /// <summary>
        /// Update one
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataBoxOffice"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> UpdateOne([FromRoute]Guid id, [FromBody] T dataBoxOffice, CancellationToken ct)
        {
            if (dataBoxOffice.Id != id)
            {
                return BadRequest("Id doesn't match");
            }
            var entity = await _boxOfficeDbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync(ct);
            if (entity == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var interfaceProps = typeof(IDataBoxOffice).GetProperties().Select(x=>x.Name).ToArray();

            foreach (var propertyInfo in typeof(T).GetProperties().Where(x=>!interfaceProps.Contains(x.Name) && x.GetValue(dataBoxOffice)!=null))
            {
                var value = propertyInfo.GetValue(dataBoxOffice);
                propertyInfo.SetValue(entity, value);
            }
            entity.LastUpdated = DateTime.UtcNow;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            dataBoxOffice.LastUserId = user != null ? user.Id : "Anonymous";
            _boxOfficeDbContext.Update(entity);
            await _boxOfficeDbContext.SaveChangesAsync(ct);
            return CreatedAtRoute(nameof(GetById), new { id = dataBoxOffice.Id }, dataBoxOffice);
        }

    }
}
