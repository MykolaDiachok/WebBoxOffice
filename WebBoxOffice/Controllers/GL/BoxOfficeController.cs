using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Controllers.GL.Abstract;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Controllers.GL
{
    /// <summary>
    /// BoxOfficeController
    /// </summary>
    public class BoxOfficeController : GlController<DataBoxOffice>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public BoxOfficeController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<DataBoxOffice> logger, UserManager<WebBoxOfficeUser> userManager) : base(boxOfficeDbContext, uriService, logger, userManager)
        {
        }
    }
}
