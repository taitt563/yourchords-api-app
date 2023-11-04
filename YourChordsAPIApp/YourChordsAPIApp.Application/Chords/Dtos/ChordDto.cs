using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Commands.AddChord;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Chords.Dtos
{
    public class ChordDto : IMapFrom<Chord>
    {
        public int Id { get; set; }
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
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<ChordProgression> ChordProgressions { get; set; } = new List<ChordProgression>();
        public virtual UserAccount CreatedByNavigation { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual ChordType Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chord, ChordDto>();
            profile.CreateMap<ChordDto, Chord>();
            profile.CreateMap<AddChordCommand, Chord>();
        }
    }
}
