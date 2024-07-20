using HS14JWT.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HS14JWT.Contexts
{
    public class JwtContext : IdentityDbContext<AppUser> //appuser'da eklediğimiz propları AspUser tablosuna eklediğimiz için artık AppUser class'ını baz alacak.
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
