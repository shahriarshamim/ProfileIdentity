using Microsoft.AspNetCore.Identity;

namespace ProfileIdentity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

        public string ProfilePicPath { get; set; }
            = "/images/default-profile.svg";
    }
}