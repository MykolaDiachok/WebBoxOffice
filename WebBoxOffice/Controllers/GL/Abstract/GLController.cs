using System;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
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

namespace WebBoxOffice.Controllers.GL.Abstract
{
    /// <summary>
    /// GLController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //TODO: add API version
    //TODO: add Include nested classes
    //TODO: Auth and permissions

    [Route("api/GL/[controller]")]
    [ApiController]
    
    public abstract class GlController<T>: ControllerBase where T : class, IDataBoxOffice
    {
        /// <summary>
        /// BoxOfficeDbContext
        /// </summary>
        protected readonly WebBoxOfficeDbContext BoxOfficeDbContext;
        /// <summary>
        /// UriService
        /// </summary>
        protected readonly IUriService UriService;
        /// <summary>
        /// Logger
        /// </summary>
        protected readonly ILogger<T> Logger;
        /// <summary>
        /// UserManager
        /// </summary>
        protected readonly UserManager<WebBoxOfficeUser> UserManager;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        protected GlController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService,ILogger<T> logger, UserManager<WebBoxOfficeUser> userManager)
        {
            BoxOfficeDbContext = boxOfficeDbContext;
            UriService = uriService;
            Logger = logger;
            UserManager = userManager;
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
            var entity = await BoxOfficeDbContext.Set<T>().Where(x=>x.Id==id).FirstOrDefaultAsync(ct);
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
            var pagedData = await BoxOfficeDbContext.Set<T>()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync(ct);
            var totalRecords = await BoxOfficeDbContext.Set<T>().CountAsync(ct);
            var pagedResponse = PaginationHelper.CreatePagedReponse<T>(pagedData, validFilter, totalRecords, UriService, route);
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
            var entity = await BoxOfficeDbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync(ct);
            if (entity == null)
            {
                return NotFound();
            }
            BoxOfficeDbContext.Set<T>().Remove(entity);
            await BoxOfficeDbContext.SaveChangesAsync(ct);
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
            var user = await UserManager.GetUserAsync(HttpContext.User);
            dataBoxOffice.LastUserId = user!=null ? user.Id : "Anonymous";
            await BoxOfficeDbContext.AddAsync(dataBoxOffice, ct);
            await BoxOfficeDbContext.SaveChangesAsync(ct);
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
            var entity = await BoxOfficeDbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync(ct);
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
            var user = await UserManager.GetUserAsync(HttpContext.User);
            dataBoxOffice.LastUserId = user != null ? user.Id : "Anonymous";
            BoxOfficeDbContext.Update(entity);
            await BoxOfficeDbContext.SaveChangesAsync(ct);
            return CreatedAtRoute(nameof(GetById), new { id = dataBoxOffice.Id }, dataBoxOffice);
        }

    }
}
