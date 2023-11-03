using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Application.Instruments.Commands.CreateInstrument;
using YourChordsAPIApp.Application.Instruments.Commands.UpdateInstrument;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Instruments.Queries.Dtos
{
    public class InstrumentDto : IMapFrom<Instrument>
    {
        public int Id { get; set; }
        public string InstrumentName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Instrument, InstrumentDto>();
            profile.CreateMap<InstrumentDto, Instrument>();
            profile.CreateMap<CreateInstrumentCommand, Instrument>();
            profile.CreateMap<UpdateInstrumentCommand, Instrument>();
        }
    }


}
