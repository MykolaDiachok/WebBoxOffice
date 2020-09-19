using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    public class WebBoxOfficeUserClaim : IdentityUserClaim<string>
    {
        public virtual WebBoxOfficeUser User { get; set; }
    }
}
