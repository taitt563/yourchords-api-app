using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.ChordTypes.Commands.CreateChordType;
using YourChordsAPIApp.Application.ChordTypes.Commands.DeleteChordType;
using YourChordsAPIApp.Application.ChordTypes.Commands.UpdateChordType;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypeById;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [Route("api/chord-types")]
    [ApiController]
    public class ChordTypesController : ApiControllerBase
    {
        [HttpGet("{chordTypeId}")]
        public async Task<IActionResult> GetChordTypeById(int chordTypeId)
        {
            var query = new GetChordTypeByIdQuery { ChordTypeId = chordTypeId };
            var result = await Mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChordTypes()
        {
            var query = new GetAllChordTypesQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChordType([FromBody] CreateChordTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetChordTypeById), new { chordTypeId = result.Id }, result);
        }

        [HttpPut("{chordTypeId}")]
        public async Task<IActionResult> UpdateChordType(int chordTypeId, [FromBody] UpdateChordTypeCommand command)
        {
            if (chordTypeId != command.ChordTypeId)
            {
                return BadRequest("ChordTypeId in the route does not match the one in the command.");
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{chordTypeId}")]
        public async Task<IActionResult> DeleteChordType(int chordTypeId)
        {
            var command = new DeleteChordTypeCommand { ChordTypeId = chordTypeId };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
