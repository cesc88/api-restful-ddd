using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto user, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await service.FindByLogin(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
