using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// class user role
    /// </summary>
    public class WebBoxOfficeUserRole : IdentityUserRole<string>
    {
        /// <summary>
        /// user
        /// </summary>
        public virtual WebBoxOfficeUser User { get; set; }
        /// <summary>
        /// role
        /// </summary>
        public virtual WebBoxOfficeRole Role { get; set; }
    }
}
