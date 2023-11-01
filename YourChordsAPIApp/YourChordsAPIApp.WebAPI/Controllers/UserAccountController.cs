using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.UserAccounts.Commands.ChangePassword;
using YourChordsAPIApp.Application.UserAccounts.Commands.DeleteAccount;
using YourChordsAPIApp.Application.UserAccounts.Commands.GenerateToken;
using YourChordsAPIApp.Application.UserAccounts.Commands.LoginUser;
using YourChordsAPIApp.Application.UserAccounts.Commands.RegisterUser;
using YourChordsAPIApp.Application.UserAccounts.Commands.SetPrivateStatus;
using YourChordsAPIApp.Application.UserAccounts.Commands.UpdateProfile;
using YourChordsAPIApp.Application.UserAccounts.Commands.UpdateUserRole;
using YourChordsAPIApp.Application.UserAccounts.Commands.VerifyEmail;
using YourChordsAPIApp.Application.UserAccounts.Commands.VerifyPassword;
using YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByEmail;
using YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountById;
using YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccounts;
using YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountsCount;
using YourChordsAPIApp.Application.UserAccounts.Queries.IsEmailUnique;
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Enums;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user-accounts")]
    public class UserAccountController : ApiControllerBase
    {
        [Authorize]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfileAsync(UpdateProfileCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("set-private-status")]
        public async Task<IActionResult> SetPrivateStatusAsync(SetPrivateStatusCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("delete-account")]
        public async Task<IActionResult> DeleteAccountAsync(DeleteAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserRole(int userId, UpdateUserRoleCommand command)
        {
            command.UserId = userId;
            var result = await Mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Update user role failed.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAccountByIdAsync(int userId)
        {
            var query = new GetUserAccountByIdQuery { UserId = userId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetUserAccountByEmailAsync(string email)
        {
            var query = new GetUserAccountByEmailQuery { Email = email };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAccountsAsync([FromQuery] GetUserAccountsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetUserAccountsCountAsync([FromQuery] GetUserAccountsCountQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }

}
