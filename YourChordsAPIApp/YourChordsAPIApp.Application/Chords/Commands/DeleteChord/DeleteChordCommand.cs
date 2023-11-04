using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Dtos;

namespace YourChordsAPIApp.Application.Chords.Commands.DeleteChord
{
    public class DeleteChordCommand : IRequest<ChordDto>
    {
        public ChordDto Chord { get; set; }
    }
}
