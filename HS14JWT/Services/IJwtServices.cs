using HS14JWT.Entities;
using Microsoft.AspNetCore.Identity;

namespace HS14JWT.Services
{
    public interface IJwtServices
    {
        string GenerateJwtToken(AppUser user);
    }
}
