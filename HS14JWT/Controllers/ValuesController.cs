using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS14JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)] // bunu zorunlu kıldıktan sonra extentions'a neye göre kontrol edileceğini yazıyoruz
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetNumbers()
        {
            return Ok(Enumerable.Range(1, 100));
        }
    }
}
