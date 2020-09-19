using Microsoft.AspNetCore.Identity;

namespace WebBoxOffice.Identity.Models
{
    public class WebBoxOfficeRoleClaim : IdentityRoleClaim<string>
    {
        public virtual WebBoxOfficeRole Role { get; set; }
    }
}
