using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;

namespace YourChordsAPIApp.Application.Instruments.Queries.GetInstrumentById
{
    public class GetInstrumentByIdQuery : IRequest<InstrumentDto>
    {
        public int Id { get; set; }
    }
}
