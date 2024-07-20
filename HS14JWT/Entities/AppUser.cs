using Microsoft.AspNetCore.Identity;

namespace HS14JWT.Entities
{
    public class AppUser : IdentityUser //IdentityUser tablosuna sütun ekleme işlemi yapıyoruz
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
