using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// Users
    /// </summary>
    public class WebBoxOfficeUser : IdentityUser
    {
        /// <summary>
        /// Claims
        /// </summary>
        public virtual ICollection<WebBoxOfficeUserClaim> Claims { get; set; }

        /// <summary>
        /// user logins
        /// </summary>
        public virtual ICollection<WebBoxOfficeUserLogin> Logins { get; set; }

        /// <summary>
        /// tokens
        /// </summary>
        public virtual ICollection<WebBoxOfficeUserToken> Tokens { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        public virtual ICollection<WebBoxOfficeUserRole> UserRoles { get; set; }

        /// <summary>
        /// user Last Login Time
        /// </summary>
        public virtual DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// user registration date
        /// </summary>
        public virtual DateTime? RegistrationDate { get; set; }

        
    }
}
