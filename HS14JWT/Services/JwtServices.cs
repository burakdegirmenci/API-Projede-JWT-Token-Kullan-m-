using HS14JWT.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HS14JWT.Services
{
    public class JwtServices : IJwtServices
    {
        private readonly AppJsonSettings _settings; // <<<<<<<OPTİON PATTERN>>>>>>> AppJsonSettings class'ını oluşturduk, appsettings.json dosyasındaki verileri Service'de kullanmamıza yardımcı oldu.

        public JwtServices(IOptions<AppJsonSettings> options)
        {
            _settings = options.Value;
        }

        public string GenerateJwtToken(AppUser user)
        {
            Claim[] claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier,user.Id), // claimtypes barındırmak zorunda, biz burda id verdik fakat istediğimizi verebiliriz.
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email),
                new(JwtRegisteredClaimNames.GivenName,user.Email),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var encodedKey = Encoding.UTF8.GetBytes(_settings.Secret); // secret key alanı
            var signingCredentials= new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer:_settings.Issuer,audience:_settings.Audience, claims: claims, expires:DateTime.Now.Add(_settings.ExperiedTime),signingCredentials:signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
