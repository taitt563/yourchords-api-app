using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Instruments.Commands.DeleteInstrument
{
    public class DeleteInstrumentCommandHandler : IRequestHandler<DeleteInstrumentCommand, Unit>
    {
        private readonly IInstrumentRepository _repository;

        public DeleteInstrumentCommandHandler(IInstrumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteInstrumentCommand request, CancellationToken cancellationToken)
        {
            var instrument = await _repository.GetByIdAsync(request.Id);
            if (instrument == null)
            {
                
            }

            await _repository.DeleteAsync(instrument);

            return Unit.Value;
        }
    }

}
