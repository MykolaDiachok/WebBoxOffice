using Microsoft.Extensions.Logging;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;

namespace WebBoxOffice.Controllers.GL
{
    
    /// <summary>
    /// Hall
    /// </summary>
    public class HallController : GlController<Hall>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        public HallController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<Hall> logger) : base(boxOfficeDbContext, uriService, logger)
        {
        }
    }
}
