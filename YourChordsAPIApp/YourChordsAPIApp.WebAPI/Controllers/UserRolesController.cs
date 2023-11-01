using Microsoft.AspNetCore.Mvc;
//using YourChordsAPIApp.Application.UserRoles.Commands.CreateRole;
//using YourChordsAPIApp.Application.UserRoles.Commands.DeleteRole;
//using YourChordsAPIApp.Application.UserRoles.Commands.UpdateRole;
//using YourChordsAPIApp.Application.UserRoles.Queries.GetRoleById;
//using YourChordsAPIApp.Application.UserRoles.Queries.GetRoles;
using YourChordsAPIApp.Domain.Endpoints;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    //[Route("api/user-roles")]
    //[ApiController]
    //public class UserRolesController : ApiControllerBase
    //{
    //    [HttpGet]
    //    public async Task<IActionResult> GetAllRoleAsync()
    //    {
    //        var roles = await Mediator.Send(new GetUserRolesQuery());
    //        return Ok(roles);
    //    }

    //    [HttpGet("{roleId}")]
    //    public async Task<IActionResult> GetRoleById(int roleId)
    //    {
    //        var role = await Mediator.Send(new GetUserRoleByIdQuery() { RoleId = roleId });
    //        if (role == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(role);
    //    }

    //    [HttpPost("create")]
    //    [ProducesResponseType(StatusCodes.Status201Created)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> AddNewRole (CreateUserRoleCommand command)
    //    {
    //        var createdRole = await Mediator.Send(command);
    //        if (createdRole == null)
    //        {
    //            return BadRequest("Failed to create a new role.");
    //        }
    //        return Ok(createdRole);
    //    }

    //    [HttpPut("{roleId}")]
    //    public async Task<IActionResult> UpdateRole(int roleId, UpdateRoleCommand command)
    //    {
    //        if (roleId != command.Id)
    //        {
    //            return BadRequest("Invalid ID.");
    //        }

    //        await Mediator.Send(command);

    //        return Ok("Update Successfully"); 
    //    }

    //    [HttpDelete("{roleId}")]
    //    public async Task<IActionResult> DeleteRole(int roleId)
    //    {
    //        var result = await Mediator.Send(new DeleteUserRoleCommand() { Id = roleId });
    //        if(result == 0)
    //        {
    //            return BadRequest("Invalid Id");
    //        }
    //        return Ok("Delete Successfully");
    //    }
    //}
}
