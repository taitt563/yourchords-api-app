using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.Genres.Commands.Create_Genre;
using YourChordsAPIApp.Application.Genres.Commands.Delete_Genre;
using YourChordsAPIApp.Application.Genres.Commands.Update_Genre;
using YourChordsAPIApp.Application.Genres.Queries.GetAllGenres;
using YourChordsAPIApp.Application.Genres.Queries.GetGenreById;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ApiControllerBase
    {
        [HttpGet("{genreId}")]
        public async Task<IActionResult> GetGenreById(int genreId)
        {
            var genre = await Mediator.Send(new GetGenreByIdQuery { GenreId = genreId });

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await Mediator.Send(new GetAllGenresQuery());

            return Ok(genres);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGenre(CreateGenreCommand command)
        {
            var createdGenre = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetGenreById), new { genreId = createdGenre.Id }, createdGenre);
        }

        [HttpPut("{genreId}")]
        public async Task<IActionResult> UpdateGenre(int genreId, UpdateGenreCommand command)
        {
            if (genreId != command.GenreId)
            {
                return BadRequest("Invalid request.");
            }

            var updatedGenre = await Mediator.Send(command);

            if (updatedGenre == null)
            {
                return BadRequest("Failed to update genre.");
            }

            return Ok(updatedGenre);
        }

        [HttpDelete("{genreId}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            var existingGenre = await Mediator.Send(new GetGenreByIdQuery { GenreId = genreId });

            if (existingGenre == null)
            {
                return NotFound();
            }

            await Mediator.Send(new DeleteGenreCommand { GenreId = genreId });
            return NoContent();
        }
    }
}
