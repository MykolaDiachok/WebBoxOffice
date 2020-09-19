using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// class role claim
    /// </summary>
    public class WebBoxOfficeRoleClaim : IdentityRoleClaim<string>
    {
        /// <summary>
        /// role
        /// </summary>
        public virtual WebBoxOfficeRole Role { get; set; }
    }
}
