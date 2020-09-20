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
    /// Hall
    /// </summary>
    public class HallController : GlController<Hall>
    {
        /// <summary>
        /// HallController
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public HallController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<Hall> logger, UserManager<WebBoxOfficeUser> userManager) : base(boxOfficeDbContext, uriService, logger, userManager)
        {
        }
    }
}
