using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.ArtistGenres.Commands.CreateArtistGenre;
using YourChordsAPIApp.Application.ArtistGenres.Commands.DeleteArtistGenre;
using YourChordsAPIApp.Application.ArtistGenres.Commands.UpdateArtistGenre;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreByArtistId;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreByGenreId;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreById;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetIdByArtistId;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/artist-genres")]
    public class ArtistGenresController : ApiControllerBase
    {
        [HttpGet("{artistGenreId}")]
        public async Task<IActionResult> GetArtistGenreById(int artistGenreId)
        {
            var artistGenre = await Mediator.Send(new GetArtistGenreByIdQuery { ArtistGenreId = artistGenreId });

            if (artistGenre == null)
            {
                return NotFound();
            }

            return Ok(artistGenre);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtistGenres()
        {
            var artistGenres = await Mediator.Send(new GetAllArtistGenresQuery());

            return Ok(artistGenres);
        }

        [HttpGet("by-artist/{artistId}")]
        public async Task<IActionResult> GetArtistGenresByArtistId(int artistId)
        {
            var artistGenres = await Mediator.Send(new GetArtistGenresByArtistIdQuery { ArtistId = artistId });

            return Ok(artistGenres);
        }

        [HttpGet("by-genre/{genreId}")]
        public async Task<IActionResult> GetArtistGenresByGenreId(int genreId)
        {
            var artistGenres = await Mediator.Send(new GetArtistGenresByGenreIdQuery { GenreId = genreId });

            return Ok(artistGenres);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArtistGenre(CreateArtistGenreCommand command)
        {
            var createdArtistGenre = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetArtistGenreById), new { artistGenreId = createdArtistGenre.Id }, createdArtistGenre);
        }

        [HttpPut("{artistGenreId}")]
        public async Task<IActionResult> UpdateArtistGenre(int artistGenreId, UpdateArtistGenreCommand command)
        {
            if (artistGenreId != command.ArtistGenreId)
            {
                return BadRequest("Invalid request.");
            }

            var updatedArtistGenre = await Mediator.Send(command);

            if (updatedArtistGenre == null)
            {
                return BadRequest("Failed to update artist genre.");
            }

            return Ok(updatedArtistGenre);
        }

        [HttpDelete("{artistGenreId}")]
        public async Task<IActionResult> DeleteArtistGenre(int artistGenreId)
        {
            var existingArtistGenre = await Mediator.Send(new GetArtistGenreByIdQuery { ArtistGenreId = artistGenreId });

            if (existingArtistGenre == null)
            {
                return NotFound();
            }

            await Mediator.Send(new DeleteArtistGenreCommand { ArtistGenreId = artistGenreId });
            return NoContent();
        }

        [HttpGet("get-ids-by-artist/{artistId}")]
        public async Task<IActionResult> GetArtistGenreIdsByArtistId(int artistId)
        {
            var artistGenreIds = await Mediator.Send(new GetArtistGenreIdsByArtistIdQuery { ArtistId = artistId });

            return Ok(artistGenreIds);
        }
    }

}
