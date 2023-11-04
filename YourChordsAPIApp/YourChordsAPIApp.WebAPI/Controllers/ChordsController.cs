using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.Chords.Commands.AddChord;
using YourChordsAPIApp.Application.Chords.Dtos;
using YourChordsAPIApp.Application.Chords.Queries.GetChordById;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChordsController : ApiControllerBase
    {
        [HttpGet("{chordId}")]
        public async Task<ActionResult<ChordDto>> GetChord(int chordId)
        {
            try
            {
                var query = new GetChordByIdQuery { ChordId = chordId };
                var chordDto = await Mediator.Send(query);

                if (chordDto == null)
                {
                    return NotFound();
                }

                return Ok(chordDto);
            }
            catch (Exception ex)
            {
                // Log the exception details here if necessary
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ChordDto>> AddChord(AddChordCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var chordDto = await Mediator.Send(command);

                return CreatedAtAction(nameof(GetChord), new { id = chordDto.Id }, chordDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        
    }
}
