using Microsoft.AspNetCore.Identity;

namespace Catalog.Infrastructure.Identity.Models
{
    public class User : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }

        public void SetCreatedDate()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void SetUpdatedDate()
        {
            UpdatedAt = DateTime.Now;
        }

        public void UpdateUser(string name)
        {
            Name = name;    
        }
    }
}
