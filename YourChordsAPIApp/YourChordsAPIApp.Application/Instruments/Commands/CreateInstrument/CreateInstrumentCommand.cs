using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;

namespace YourChordsAPIApp.Application.Instruments.Commands.CreateInstrument
{
    public class CreateInstrumentCommand : IRequest<InstrumentDto>
    {
        public string InstrumentName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
