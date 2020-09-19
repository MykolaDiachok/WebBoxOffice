using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// class user claim
    /// </summary>
    public class WebBoxOfficeUserClaim : IdentityUserClaim<string>
    {
        /// <summary>
        /// User
        /// </summary>
        public virtual WebBoxOfficeUser User { get; set; }
    }
}
