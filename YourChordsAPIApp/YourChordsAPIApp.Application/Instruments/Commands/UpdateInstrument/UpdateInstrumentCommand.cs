using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Instruments.Commands.UpdateInstrument
{
    public class UpdateInstrumentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string InstrumentName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
