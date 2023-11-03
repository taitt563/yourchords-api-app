using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourChordsAPIApp.Application.Instruments.Commands.CreateInstrument;
using YourChordsAPIApp.Application.Instruments.Commands.DeleteInstrument;
using YourChordsAPIApp.Application.Instruments.Commands.UpdateInstrument;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;
using YourChordsAPIApp.Application.Instruments.Queries.FindInstrumentsByStatus;
using YourChordsAPIApp.Application.Instruments.Queries.GetAllInstruments;
using YourChordsAPIApp.Application.Instruments.Queries.GetInstrumentById;
using YourChordsAPIApp.Application.Instruments.Queries.SearchInstrumentsByName;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ApiControllerBase
    {
        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstrumentDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllInstrumentsQuery()));
        }

        // GET: api/Instruments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentDto>> Get(int id)
        {
            var instrument = await Mediator.Send(new GetInstrumentByIdQuery { Id = id });
            if (instrument == null)
            {
                return NotFound();
            }
            return Ok(instrument);
        }

        // POST: api/Instruments
        [HttpPost]
        [Authorize(Roles = "Admin")] // Adjust the role as necessary for your use case
        public async Task<ActionResult<InstrumentDto>> Create(CreateInstrumentCommand command)
        {
            var instrumentDto = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = instrumentDto.Id }, instrumentDto);
        }

        // PUT: api/Instruments/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Adjust the role as necessary for your use case
        public async Task<IActionResult> Update(int id, UpdateInstrumentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Instruments/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Adjust the role as necessary for your use case
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteInstrumentCommand { Id = id });
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<InstrumentDto>>> SearchByName(string name)
        {
            var instruments = await Mediator.Send(new SearchInstrumentsByNameQuery { Name = name });
            if (instruments == null || !instruments.Any())
            {
                return NotFound(new { Message = $"No instruments found with the name '{name}'." });
            }
            return Ok(instruments);
        }

        // GET: api/Instruments/status?isActive={isActive}
        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<InstrumentDto>>> GetByStatus(bool isActive)
        {
            var instruments = await Mediator.Send(new FindInstrumentsByStatusQuery { Status = isActive });
            return Ok(instruments);
        }
    }
}
