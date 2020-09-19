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
    /// Schedule
    /// </summary>
    public class ScheduleController : GlController<Schedule>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        public ScheduleController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<Schedule> logger) : base(boxOfficeDbContext, uriService, logger)
        {
        }
    }
}
