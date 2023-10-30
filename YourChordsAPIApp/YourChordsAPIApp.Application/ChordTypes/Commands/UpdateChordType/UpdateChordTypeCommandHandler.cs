using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.UpdateChordType
{
    public class UpdateChordTypeCommandHandler : IRequestHandler<UpdateChordTypeCommand, ChordTypeVm>
    {
        private readonly IChordTypeRepository _chordTypeRepository;
        private readonly IMapper _mapper;

        public UpdateChordTypeCommandHandler(IChordTypeRepository chordTypeRepository, IMapper mapper)
        {
            _chordTypeRepository = chordTypeRepository;
            _mapper = mapper;
        }

        public async Task<ChordTypeVm> Handle(UpdateChordTypeCommand request, CancellationToken cancellationToken)
        {
            var existingChordType = await _chordTypeRepository.GetChordTypeByIdAsync(request.ChordTypeId);

            if (existingChordType == null)
            {
                // Handle the case where the chord type with the provided ID is not found
                // You can throw an exception or return an appropriate response
            }

            existingChordType.TypeName = request.TypeName;
            await _chordTypeRepository.UpdateChordTypeAsync(existingChordType);

            return _mapper.Map<ChordTypeVm>(existingChordType);
        }
    }
}
