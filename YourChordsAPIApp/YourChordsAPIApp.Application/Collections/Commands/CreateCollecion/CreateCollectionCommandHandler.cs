using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace YourChordsAPIApp.Application.Collections.Commands.CreateCollecion
{
    public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, CollectionDto>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public CreateCollectionCommandHandler(ICollectionRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        public async Task<CollectionDto> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = new Collection
            {
                UserId = request.UserId,
                CollectionName = request.CollectionName,
                Image = request.Image,
                IsPrivate = request.IsPrivate,
                DateCreated = request.DateCreated
            };

            // The UserId should be set just before adding the collection to the repository, like so:
            // collection.UserId = userId; (this will be passed into the handler)

            await _collectionRepository.AddAsync(collection);

            return _mapper.Map<CollectionDto>(collection);
        }
    }
}
