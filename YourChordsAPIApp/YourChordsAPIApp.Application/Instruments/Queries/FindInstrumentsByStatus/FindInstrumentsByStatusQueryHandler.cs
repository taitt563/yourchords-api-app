using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Instruments.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Instruments.Queries.FindInstrumentsByStatus
{
    public class FindInstrumentsByStatusQueryHandler : IRequestHandler<FindInstrumentsByStatusQuery, IEnumerable<InstrumentDto>>
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;

        public FindInstrumentsByStatusQueryHandler(IInstrumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstrumentDto>> Handle(FindInstrumentsByStatusQuery request, CancellationToken cancellationToken)
        {
            var instruments = await _repository.FindAsync(x => x.Status == request.Status);
            return _mapper.Map<IEnumerable<InstrumentDto>>(instruments);
        }
    }

}
