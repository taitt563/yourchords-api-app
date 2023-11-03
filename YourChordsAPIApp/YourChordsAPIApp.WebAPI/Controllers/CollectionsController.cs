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
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;
using YourChordsAPIApp.WebAPI.Models.CollectionModel;
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
        public async Task<ActionResult<CollectionDto>> Create([FromBody] CollectionModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized("User ID claim is missing from the token.");
            }  // Set UserId in command from the token
            var result = await Mediator.Send(new CreateCollectionCommand
            {
                UserId = int.Parse(userId.Value),
                CollectionName = model.CollectionName,
                Image = model.Image,
                IsPrivate = model.IsPrivate,
                DateCreated = DateTime.UtcNow
            });

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/collections/5
        [HttpPut("{collectionId}")]
        public async Task<ActionResult> Update(int collectionId, UpdateCollectionCommand command)
        {
            if (collectionId != command.CollectionId)
            {
                return BadRequest();
            }

            // UserId can also be validated here against the JWT token if needed
            await Mediator.Send(command);
            return NoContent();
        }

        // GET api/collections/5
        [HttpGet("{collectionId}")]
        public async Task<ActionResult<CollectionDto>> GetById(int collectionId)
        {
            var query = new GetCollectionByIdQuery { CollectionId = collectionId };
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
        [HttpDelete("{collectionId}")]
        public async Task<ActionResult> Delete(int collectionId)
        {
            // You can check here if the collection belongs to the user from the JWT token if needed
            var command = new DeleteCollectionCommand { CollectionId = collectionId };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
