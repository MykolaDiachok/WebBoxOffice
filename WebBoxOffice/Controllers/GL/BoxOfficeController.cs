using Microsoft.Extensions.Logging;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;

namespace WebBoxOffice.Controllers.GL
{
    /// <summary>
    /// BoxOfficeController
    /// </summary>
    public class BoxOfficeController : GlController<BoxOffice>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        public BoxOfficeController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<BoxOffice> logger) : base(boxOfficeDbContext, uriService, logger)
        {
        }
    }
}
