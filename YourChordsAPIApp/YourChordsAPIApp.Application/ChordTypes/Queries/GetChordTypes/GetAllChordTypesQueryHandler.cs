using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes
{
    public class GetAllChordTypesQueryHandler : IRequestHandler<GetAllChordTypesQuery, IEnumerable<ChordTypeVm>>
    {
        private readonly IChordTypeRepository _chordTypeRepository;
        private readonly IMapper _mapper;

        public GetAllChordTypesQueryHandler(IChordTypeRepository chordTypeRepository, IMapper mapper)
        {
            _chordTypeRepository = chordTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChordTypeVm>> Handle(GetAllChordTypesQuery request, CancellationToken cancellationToken)
        {
            var chordTypes = await _chordTypeRepository.GetAllChordTypesAsync();

            return _mapper.Map<IEnumerable<ChordTypeVm>>(chordTypes);
        }
    }
}
