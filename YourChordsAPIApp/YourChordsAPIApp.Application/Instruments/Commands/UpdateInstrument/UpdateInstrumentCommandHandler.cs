using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Instruments.Commands.UpdateInstrument
{
    public class UpdateInstrumentCommandHandler : IRequestHandler<UpdateInstrumentCommand, Unit>
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateInstrumentCommandHandler(IInstrumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInstrumentCommand request, CancellationToken cancellationToken)
        {
            var instrument = await _repository.GetByIdAsync(request.Id);
            if (instrument == null)
            {
                
            }

            _mapper.Map(request, instrument);

            await _repository.UpdateAsync(instrument);

            return Unit.Value; // MediatR uses Unit.Value to represent a void response
        }
    }

}
