using Microsoft.AspNetCore.Identity;
namespace FutbolcuKimApi.Models

{
    public class ApplicationUser:IdentityUser
    {
        public string DisplayName { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
