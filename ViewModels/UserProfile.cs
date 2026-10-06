/*using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ProfileIdentity.ViewModels
{
    public class UserProfile
    {
        [StringLength(100)]
        public string? Name { get; set; }

        public string ProfilePicPath { get; set; } = "/images/default-profile.svg";

        public IFormFile? Pic { get; set; }
    }
}
*/


using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileIdentity.ViewModels
{
    public class UserProfile
    {
        public string? Name { get; set; }

        public string ProfilePicPath { get; set; }
            = "/images/default-profile.png";

        [NotMapped]
        public IFormFile? Pic { get; set; }
    }
}