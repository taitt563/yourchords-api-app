using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.Artists.Commands.CreateArtist;
using YourChordsAPIApp.Application.Artists.Commands.DeleteArtist;
using YourChordsAPIApp.Application.Artists.Commands.UpdateArtist;
using YourChordsAPIApp.Application.Artists.Queries.GetArtistById;
using YourChordsAPIApp.Application.Artists.Queries.GetArtistByName;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ApiControllerBase
    {
        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtistById(int artistId)
        {
            var artist = await Mediator.Send(new GetArtistByIdQuery { ArtistId = artistId });

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet("name/{artistName}")]
        public async Task<IActionResult> GetArtistByName(string artistName)
        {
            var artist = await Mediator.Send(new GetArtistByNameQuery { ArtistName = artistName });

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await Mediator.Send(new GetAllArtistsQuery());

            return Ok(artists);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArtist(CreateArtistCommand command)
        {
            var createdArtist = await Mediator.Send(command);

            if (createdArtist == null)
            {
                return BadRequest("Failed to create a new artist.");
            }

            return CreatedAtAction(nameof(GetArtistById), new { artistId = createdArtist.Id }, createdArtist);
        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> UpdateArtist(int artistId, UpdateArtistCommand command)
        {
            if (artistId != command.ArtistId)
            {
                return BadRequest("Invalid request.");
            }

            var updatedArtist = await Mediator.Send(command);

            if (updatedArtist == null)
            {
                return BadRequest("Failed to update artist.");
            }

            return Ok(updatedArtist);
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> DeleteArtist(int artistId)
        {
            var existingArtist = await Mediator.Send(new GetArtistByIdQuery { ArtistId = artistId });

            if (existingArtist == null)
            {
                return NotFound();
            }

            await Mediator.Send(new DeleteArtistCommand { ArtistId = artistId });
            return Ok("Artist deleted successfully.");
        }
    }
}
