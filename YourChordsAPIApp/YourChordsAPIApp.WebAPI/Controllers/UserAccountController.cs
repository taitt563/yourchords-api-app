using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
using YourChordsAPIApp.WebAPI.Models;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user-accounts")]
    public class UserAccountController : ApiControllerBase
    {
        [Authorize]
        [HttpGet("current-profile")]
        public async Task<IActionResult> GetCurrentProfileAsync()
        {
            // Lấy thông tin người dùng từ claim
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest(new { message = "Invalid token. User not found." });
            }

            // Gọi phương thức để lấy thông tin hồ sơ từ repository (sử dụng Mediator)
            var userAccount = await Mediator.Send(new GetUserAccountByIdQuery { UserId = int.Parse(userId) });

            if (userAccount == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(userAccount);
        }

        [Authorize]
        [HttpPut("update-current-profile")]
        public async Task<IActionResult> UpdateCurrentUserProfile([FromBody] ProfileModel model)
        {
            // Lấy thông tin người dùng từ claim
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest(new { message = "Invalid token. User not found." });
            }

            // Cập nhật thông tin hồ sơ
            var result = await Mediator.Send(new UpdateProfileCommand
            {
                UserId = int.Parse(userId),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Bio = model.Bio,
                Dob = model.Dob,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Image = model.Image
            });

            if (result)
            {
                return Ok(new { message = "Profile updated successfully." });
            }
            else
            {
                return BadRequest(new { message = "Failed to update profile." });
            }
        }

        [CustomAuthorize("Customer", "Musician", "Admin","ChordValidator")]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfileAsync(UpdateProfileCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [CustomAuthorize("Customer", "Musician", "Admin", "ChordValidator")]
        [HttpPut("set-private-status")]
        public async Task<IActionResult> SetPrivateStatusAsync(SetPrivateStatusCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [CustomAuthorize("Admin")]
        [HttpPut("delete-account")]
        public async Task<IActionResult> DeleteAccountAsync(DeleteAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [CustomAuthorize("Admin")]
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

        [CustomAuthorize("Customer", "Musician", "Admin", "ChordValidator")]
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
