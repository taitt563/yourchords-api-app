using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Dtos;

namespace YourChordsAPIApp.Application.Chords.Commands.AddChord
{
    public class AddChordCommand : IRequest<ChordDto>
    {
        public string ChordName { get; set; }
        public string Notation { get; set; }
        public string Components { get; set; }
        public int TypeId { get; set; }
        public int InstrumentId { get; set; }
        public string Tone { get; set; }
        public string ChordDiagram { get; set; }
        public string? ExternalLink { get; set; }
        public string? ChordSound { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
