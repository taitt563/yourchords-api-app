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

namespace YourChordsAPIApp.Application.Chords.Queries.GetChordById
{
    public class GetChordByIdQueryHandler : IRequestHandler<GetChordByIdQuery, ChordDto>
    {
        private readonly IChordRepository _chordRepository;
        private readonly IMapper _mapper;

        public GetChordByIdQueryHandler(IChordRepository chordRepository, IMapper mapper)
        {
            _chordRepository = chordRepository ?? throw new ArgumentNullException(nameof(chordRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ChordDto> Handle(GetChordByIdQuery request, CancellationToken cancellationToken)
        {
            var chord = await _chordRepository.GetChordByIdAsync(request.ChordId);
            if (chord == null)
            {
                // You could throw a not found exception here or return null depending on your flow
                throw new ApplicationException(nameof(Chord));
            }

            // Assuming you have a mapping profile set up to map Chord to ChordDto
            var chordDto = _mapper.Map<ChordDto>(chord);

            return chordDto;
        }
    }

}
