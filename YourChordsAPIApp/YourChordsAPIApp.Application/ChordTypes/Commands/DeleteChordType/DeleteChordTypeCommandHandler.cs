using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.DeleteChordType
{
    public class DeleteChordTypeCommandHandler : IRequestHandler<DeleteChordTypeCommand, Unit>
    {
        private readonly IChordTypeRepository _chordTypeRepository;

        public DeleteChordTypeCommandHandler(IChordTypeRepository chordTypeRepository)
        {
            _chordTypeRepository = chordTypeRepository;
        }

        public async Task<Unit> Handle(DeleteChordTypeCommand request, CancellationToken cancellationToken)
        {
            await _chordTypeRepository.DeleteChordTypeAsync(request.ChordTypeId);
            return Unit.Value;
        }
    }
}
