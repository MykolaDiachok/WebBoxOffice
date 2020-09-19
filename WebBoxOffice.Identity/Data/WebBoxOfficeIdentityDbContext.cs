using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice.Identity.Data
{
    /// <summary>
    /// class WebBoxOfficeIdentityDbContext
    /// </summary>
    public class WebBoxOfficeIdentityDbContext : ApiAuthorizationDbContext<WebBoxOfficeUser>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="operationalStoreOptions"></param>
        public WebBoxOfficeIdentityDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
