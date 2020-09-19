using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    /// <summary>
    /// class user token
    /// </summary>
    public class WebBoxOfficeUserToken : IdentityUserToken<string>
    {
        /// <summary>
        /// User
        /// </summary>
        public virtual WebBoxOfficeUser User { get; set; }
    }
}
