using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Collections.Commands.DeleteCollection
{
    public class DeleteCollectionCommandHandler : IRequestHandler<DeleteCollectionCommand, Unit>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public DeleteCollectionCommandHandler(ICollectionRepository collectionRepository, IMapper mapper) 
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepository.GetByIdAsync(request.Id);

            if (collection == null)
            {
                
            }

            await _collectionRepository.DeleteAsync(collection);

            return Unit.Value;
        }
    }
}
