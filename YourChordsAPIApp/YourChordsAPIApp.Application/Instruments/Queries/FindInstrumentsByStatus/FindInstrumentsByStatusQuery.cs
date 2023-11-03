using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;

namespace YourChordsAPIApp.Application.Instruments.Queries.FindInstrumentsByStatus
{
    public class FindInstrumentsByStatusQuery : IRequest<IEnumerable<InstrumentDto>>
    {
        public bool Status { get; set; }
    }
}
