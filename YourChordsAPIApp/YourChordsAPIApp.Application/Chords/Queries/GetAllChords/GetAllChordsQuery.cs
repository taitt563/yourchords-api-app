using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Dtos;
using YourChordsAPIApp.Domain.Common;

namespace YourChordsAPIApp.Application.Chords.Queries.GetAllChords
{
    public class GetAllChordsQuery : IRequest<IEnumerable<ChordDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public ChordFilter Filter { get; set; }
    }
}
