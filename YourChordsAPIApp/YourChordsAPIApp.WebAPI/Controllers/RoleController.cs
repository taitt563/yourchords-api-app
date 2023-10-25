using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.Roles.Queries.GetRoles;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await Mediator.Send(new GetRolesQuery());
            return Ok(roles);
        }
    }
}
