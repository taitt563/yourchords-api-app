using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypeById
{
    public class GetChordTypeByIdQueryHandler : IRequestHandler<GetChordTypeByIdQuery, ChordTypeVm>
    {
        private readonly IChordTypeRepository _chordTypeRepository;
        private readonly IMapper _mapper;

        public GetChordTypeByIdQueryHandler(IChordTypeRepository chordTypeRepository, IMapper mapper)
        {
            _chordTypeRepository = chordTypeRepository;
            _mapper = mapper;
        }

        public async Task<ChordTypeVm> Handle(GetChordTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var chordType = await _chordTypeRepository.GetChordTypeByIdAsync(request.ChordTypeId);

            return _mapper.Map<ChordTypeVm>(chordType);
        }
    }
}
