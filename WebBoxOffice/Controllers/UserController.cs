using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebBoxOffice.Identity.Data;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private readonly WebBoxOfficeIdentityDbContext _identityDbContext;


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="identityDbContext"></param>
        public UserController(ILogger<UserController> logger, WebBoxOfficeIdentityDbContext identityDbContext)
        {
            _logger = logger;
            _identityDbContext = identityDbContext;
        }

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WebBoxOfficeUser> GetBoxOfficeUsers()
        {
            return _identityDbContext.Users;
        }
    }
}
