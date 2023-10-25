using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.Roles.Commands.CreateRole;
using YourChordsAPIApp.Application.Roles.Commands.DeleteRole;
using YourChordsAPIApp.Application.Roles.Commands.UpdateRole;
using YourChordsAPIApp.Application.Roles.Queries.GetRoleById;
using YourChordsAPIApp.Application.Roles.Queries.GetRoles;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var roles = await Mediator.Send(new GetRolesQuery());
            return Ok(roles);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetRoleById))]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await Mediator.Send(new GetRoleByIdQuery() { RoleId = id });
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRole (CreateRoleCommand command)
        {
            var createdRole = await Mediator.Send(command);
            if (createdRole == null)
            {
                return BadRequest("Failed to create a new role.");
            }
            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, createdRole);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Invalid ID.");
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await Mediator.Send(new DeleteRoleCommand() { Id = id });
            if(result == 0)
            {
                return BadRequest("Invalid Id");
            }
            return NoContent();
        }
    }
}
