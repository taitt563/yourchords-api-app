using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Instruments.Queries.GetInstrumentById
{
    public class GetInstrumentByIdQueryHandler : IRequestHandler<GetInstrumentByIdQuery, InstrumentDto>
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;

        public GetInstrumentByIdQueryHandler(IInstrumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InstrumentDto> Handle(GetInstrumentByIdQuery request, CancellationToken cancellationToken)
        {
            var instrument = await _repository.GetByIdAsync(request.Id);
            if (instrument == null)
            {
                
            }

            return _mapper.Map<InstrumentDto>(instrument);
        }
    }

}
