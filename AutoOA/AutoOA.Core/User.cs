using Microsoft.AspNetCore.Identity;

namespace AutoOA.Core
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
