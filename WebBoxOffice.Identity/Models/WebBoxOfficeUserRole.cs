using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    public class WebBoxOfficeUserRole : IdentityUserRole<string>
    {
        public virtual WebBoxOfficeUser User { get; set; }
        public virtual WebBoxOfficeRole Role { get; set; }
    }
}
