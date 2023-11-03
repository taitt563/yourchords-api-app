using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Instruments.Commands.CreateInstrument
{
    public class CreateInstrumentCommandHandler : IRequestHandler<CreateInstrumentCommand, InstrumentDto>
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;

        public CreateInstrumentCommandHandler(IInstrumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InstrumentDto> Handle(CreateInstrumentCommand request, CancellationToken cancellationToken)
        {
            var instrument = _mapper.Map<Instrument>(request);
            var result = await _repository.AddAsync(instrument);
            return _mapper.Map<InstrumentDto>(result);
        }
    }

}
