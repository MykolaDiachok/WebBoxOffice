using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// class user login
    /// </summary>
    public class WebBoxOfficeUserLogin : IdentityUserLogin<string>
    {
        /// <summary>
        /// User
        /// </summary>
        public virtual WebBoxOfficeUser User { get; set; }
    }
}
