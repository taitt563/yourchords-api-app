using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Instruments.Queries.GetAllInstruments
{
    public class GetAllInstrumentsQueryHandler : IRequestHandler<GetAllInstrumentsQuery, IEnumerable<InstrumentDto>>
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllInstrumentsQueryHandler(IInstrumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstrumentDto>> Handle(GetAllInstrumentsQuery request, CancellationToken cancellationToken)
        {
            var instruments = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InstrumentDto>>(instruments);
        }
    }

}
