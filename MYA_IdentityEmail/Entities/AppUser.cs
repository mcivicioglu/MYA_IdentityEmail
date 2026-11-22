using Microsoft.AspNetCore.Identity;

namespace MYA_IdentityEmail.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AboutMe { get; set; }
        public string? ProfilePictureUrl { get; set; }

    }
}