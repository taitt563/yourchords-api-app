using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;

namespace YourChordsAPIApp.Application.Instruments.Queries.SearchInstrumentsByName
{
    public class SearchInstrumentsByNameQuery : IRequest<IEnumerable<InstrumentDto>>
    {
        public string Name { get; set; }
    }
}
