using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    public class WebBoxOfficeUserLogin : IdentityUserLogin<string>
    {
        public virtual WebBoxOfficeUser User { get; set; }
    }
}
