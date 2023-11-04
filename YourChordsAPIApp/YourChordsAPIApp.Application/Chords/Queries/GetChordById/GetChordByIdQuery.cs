using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Dtos;

namespace YourChordsAPIApp.Application.Chords.Queries.GetChordById
{
    public class GetChordByIdQuery : IRequest<ChordDto>
    {
        public int ChordId { get; set; }
    }
}
