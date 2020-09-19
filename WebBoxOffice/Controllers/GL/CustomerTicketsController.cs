using Microsoft.Extensions.Logging;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;

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
        public CustomerTicketsController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<CustomerTickets> logger) : base(boxOfficeDbContext, uriService, logger)
        {
        }
    }
}
