using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    public class WebBoxOfficeUserToken : IdentityUserToken<string>
    {
        public virtual WebBoxOfficeUser User { get; set; }
    }
}
