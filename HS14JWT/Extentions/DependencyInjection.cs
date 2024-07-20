using HS14JWT.Contexts;
using HS14JWT.Entities;
using HS14JWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HS14JWT.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JwtContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<JwtContext>().AddDefaultTokenProviders(); //Projede rol kullanılmasa bile parametre olarak IdentityRole yazılmalı.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt=> opt.TokenValidationParameters= new(){
                    ValidIssuer = configuration["JWT:Issure"],
                ValidAudience= configuration["JWT:Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                ValidateIssuer=false,
                ValidateAudience=false,
                ValidateLifetime=true,
                ValidateIssuerSigningKey=true,

            });
            services.AddScoped<IJwtServices, JwtServices>();
            services.Configure<AppJsonSettings>(configuration.GetSection("JWT"));
            return services;

        }
    }
}
