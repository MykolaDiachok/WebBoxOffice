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

    public class SpectaclesLinksController : GlController<SpectaclesLinks>
    {
        public SpectaclesLinksController(WebBoxOfficeDbContext boxOfficeDbContext, IUriService uriService, ILogger<SpectaclesLinks> logger) : base(boxOfficeDbContext, uriService, logger)
        {
        }
    }
}
