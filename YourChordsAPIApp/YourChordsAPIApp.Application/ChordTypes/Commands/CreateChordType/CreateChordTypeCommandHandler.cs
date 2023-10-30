using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.CreateChordType
{
    public class CreateChordTypeCommandHandler : IRequestHandler<CreateChordTypeCommand, ChordTypeVm>
    {
        private readonly IChordTypeRepository _chordTypeRepository;
        private readonly IMapper _mapper;

        public CreateChordTypeCommandHandler(IChordTypeRepository chordTypeRepository, IMapper mapper)
        {
            _chordTypeRepository = chordTypeRepository;
            _mapper = mapper;
        }

        public async Task<ChordTypeVm> Handle(CreateChordTypeCommand request, CancellationToken cancellationToken)
        {
            var chordType = new ChordType
            {
                TypeName = request.TypeName
            };

            await _chordTypeRepository.AddChordTypeAsync(chordType);

            return _mapper.Map<ChordTypeVm>(chordType);
        }
    }

}
