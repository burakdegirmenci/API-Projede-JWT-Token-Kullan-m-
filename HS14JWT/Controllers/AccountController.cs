using HS14JWT.DTOs;
using HS14JWT.Entities;
using HS14JWT.Services;
using HS14JWT.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace HS14JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtServices _jwtServices;

        public AccountController(IJwtServices jwtServices)
        {
            _jwtServices = jwtServices;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromServices] UserManager<AppUser> userManager, RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser()
            {
                FirstName=model.FirstName, 
                LastName=model.LastName,
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true
            };
            var identityCreateResult = await userManager.CreateAsync(user, model.Password);
            if(!identityCreateResult.Succeeded)
            {
                return BadRequest(new AccountResult
                {
                    IsSucces = false,
                    Message = identityCreateResult.ToString()
                });
            }
            return Ok(new AccountResult
            {
                IsSucces = true,
                Message = "Kullanıcı oluşturma başarılı."
            });

        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromServices] SignInManager<AppUser>_signInManager, LoginDTO loginDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _signInManager.UserManager.FindByEmailAsync(loginDTO.Email);
            if(user is null)
            {
                return BadRequest(new AccountResult
                {
                    IsSucces=false,
                    Message="Kullanıcı veya şifre yanlış."
                });
            }
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user,loginDTO.Password,false);
            if(!singInResult.Succeeded)
            {
                return BadRequest(new AccountResult
                {
                    IsSucces = false,
                    Message = "Kullanıcı veya şifre yanlış."
                });
            }
            return Ok(new AccountResult
            {
                IsSucces = true,
                Message = "Giriş Başarılı",
                Token=_jwtServices.GenerateJwtToken(user)
            });

        }












    }
}
