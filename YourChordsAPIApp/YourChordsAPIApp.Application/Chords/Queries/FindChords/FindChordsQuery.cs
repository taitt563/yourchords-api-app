using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Dtos;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Chords.Queries.FindChords
{
    public class FindChordsQuery : IRequest<IEnumerable<ChordDto>>
    {
        public Expression<Func<Chord, bool>> Predicate { get; set; }
    }
}
