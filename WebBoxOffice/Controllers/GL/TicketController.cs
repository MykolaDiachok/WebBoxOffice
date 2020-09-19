using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;

namespace WebBoxOffice.Controllers.GL
{

    /// <summary>
    /// TicketController
    /// </summary>
    public class TicketController : GlController<Ticket>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        public TicketController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<Ticket> logger) : base(boxOfficeDbContext, uriService, logger)
        {
        }
    }
}
