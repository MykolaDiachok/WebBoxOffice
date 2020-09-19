using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// Class Role
    /// </summary>
    public class WebBoxOfficeRole : IdentityRole
    {
        /// <summary>
        /// Users roles
        /// </summary>
        public virtual ICollection<WebBoxOfficeUserRole> UserRoles { get; set; }
        /// <summary>
        /// Role claims
        /// </summary>
        public virtual ICollection<WebBoxOfficeRoleClaim> RoleClaims { get; set; }
    }
}
