using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Core;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Domain;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Controllers.GL
{

    /// <summary>
    /// Schedule
    /// </summary>
    [AllowAnonymous]
    public class ScheduleController : GlController<Schedule>
    {
        /// <summary>
        /// ScheduleController
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        /// <param name="uriService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public ScheduleController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<Schedule> logger, UserManager<WebBoxOfficeUser> userManager) : base(boxOfficeDbContext, uriService, logger, userManager)
        {
        }
    }
}
