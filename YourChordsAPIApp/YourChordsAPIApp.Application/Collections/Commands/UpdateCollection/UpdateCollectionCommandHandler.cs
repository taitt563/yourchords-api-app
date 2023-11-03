using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Collections.Commands.UpdateCollection
{
    public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand, CollectionDto>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public UpdateCollectionCommandHandler(ICollectionRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        public async Task<CollectionDto> Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
        {
            var existingCollection = await _collectionRepository.GetByIdAsync(request.Id);

            if (existingCollection == null)
            {
                
            }
            existingCollection.CollectionName = request.CollectionName;
            existingCollection.Image = request.Image;
            existingCollection.IsPrivate = request.IsPrivate;

            await _collectionRepository.UpdateAsync(existingCollection);

            return _mapper.Map<CollectionDto>(existingCollection);
        }
    }
}
