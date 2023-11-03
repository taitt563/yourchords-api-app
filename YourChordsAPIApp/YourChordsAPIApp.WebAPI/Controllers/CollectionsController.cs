using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourChordsAPIApp.Application.Collections.Commands.CreateCollecion;
using YourChordsAPIApp.Application.Collections.Commands.DeleteCollection;
using YourChordsAPIApp.Application.Collections.Commands.UpdateCollection;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Application.Collections.Queries.GetAllCollectionsByUser;
using YourChordsAPIApp.Application.Collections.Queries.GetColletionById;
using YourChordsAPIApp.Domain.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requires a valid JWT token for access
    public class CollectionsController : ApiControllerBase
    {
        // POST api/collections
        [HttpPost]
        public async Task<ActionResult<CollectionDto>> Create(CreateCollectionCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest(new { message = "Invalid token. User not found." });
            }
            command.UserId = int.Parse(userId);
            // DateCreated will be set in the handler, not here
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/collections/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCollectionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            // UserId can also be validated here against the JWT token if needed
            await Mediator.Send(command);
            return NoContent();
        }

        // GET api/collections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionDto>> GetById(int id)
        {
            var query = new GetCollectionByIdQuery { Id = id };
            var result = await Mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/collections/user
        [HttpGet("me")]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetAllByUser()
        {
            // Extract user id from JWT token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest(new { message = "Invalid token. User not found." });
            }
            var query = new GetAllCollectionsByUserQuery { UserId = int.Parse(userId) };
            var results = await Mediator.Send(query);
            return Ok(results);
        }

        // DELETE api/collections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // You can check here if the collection belongs to the user from the JWT token if needed
            var command = new DeleteCollectionCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
