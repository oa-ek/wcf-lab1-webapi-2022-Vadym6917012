using Microsoft.AspNetCore.Identity;

namespace AutoOA.WebAPI
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
