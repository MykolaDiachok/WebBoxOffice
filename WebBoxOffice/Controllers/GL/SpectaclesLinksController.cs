using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Controllers.GL
{

    /// <summary>
    /// SpectaclesLinks
    /// </summary>
    [AllowAnonymous]
    public class SpectaclesLinksController : GlController<SpectaclesLinks>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public SpectaclesLinksController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<SpectaclesLinks> logger, UserManager<WebBoxOfficeUser> userManager) : base(boxOfficeDbContext, uriService, logger, userManager)
        {
        }
    }
}
