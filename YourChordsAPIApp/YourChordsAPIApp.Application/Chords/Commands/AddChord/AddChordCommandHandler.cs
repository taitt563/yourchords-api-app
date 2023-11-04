using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Chords.Dtos;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Chords.Commands.AddChord
{
    public class AddChordCommandHandler : IRequestHandler<AddChordCommand, ChordDto>
    {
        private readonly IChordRepository _chordRepository;
        private readonly IMapper _mapper;

        public AddChordCommandHandler(IChordRepository chordRepository, IMapper mapper)
        {
            _chordRepository = chordRepository ?? throw new ArgumentNullException(nameof(chordRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ChordDto> Handle(AddChordCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentException("Chord data must be provided", nameof(request));
            }

            var chordEntity = _mapper.Map<Chord>(request);

            // Implement any additional logic or checks before adding the chord

            var addedChord = await _chordRepository.AddChordAsync(chordEntity);

            // After saving to the database, the entity will have the ID set by the database
            var chordDto = _mapper.Map<ChordDto>(addedChord);

            return chordDto;
        }
    }

}
