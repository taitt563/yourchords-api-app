using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.UserAccounts.Commands.CreateUserAccount;
using YourChordsAPIApp.Application.UserAccounts.Commands.DeleteUserAccount;
using YourChordsAPIApp.Application.UserAccounts.Commands.SignIn;
using YourChordsAPIApp.Application.UserAccounts.Commands.SignUp;
using YourChordsAPIApp.Application.UserAccounts.Commands.UpdateUserAccount;
using YourChordsAPIApp.Application.UserAccounts.Queries.GenerateToken;
using YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountById;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [Route("api/user-accounts")]
    [ApiController]
    public class UserAccountController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAccountById(int id)
        {
            var userAccount = await Mediator.Send(new GetUserAccountByIdQuery { UserId = id });

            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAccount(CreateUserAccountCommand command)
        {
            var createdUserAccount = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetUserAccountById), new { id = createdUserAccount.Id }, createdUserAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAccount(int id, UpdateUserAccountCommand command)
        {
            command.UserAccount.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            await Mediator.Send(new DeleteUserAccountCommand { UserId = id });
            return NoContent();
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            var userAccount = await Mediator.Send(command);

            if (userAccount == null)
            {
                return Unauthorized();
            }

            var token = await Mediator.Send(new GenerateTokenQuery { UserAccount = userAccount });

            return Ok(new { Token = token });
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
        {
            try
            {
                var createdUserAccount = await Mediator.Send(command);
                var token = await Mediator.Send(new GenerateTokenQuery { UserAccount = createdUserAccount });

                return CreatedAtAction(nameof(GetUserAccountById), new { id = createdUserAccount.Id }, new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }

}
