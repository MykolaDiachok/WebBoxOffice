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
    /// CustomerTickets
    /// </summary>
    public class CustomerTicketsController : GlController<CustomerTickets>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public CustomerTicketsController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<CustomerTickets> logger, UserManager<WebBoxOfficeUser> userManager) : base(boxOfficeDbContext, uriService, logger, userManager)
        {
        }
    }
}
