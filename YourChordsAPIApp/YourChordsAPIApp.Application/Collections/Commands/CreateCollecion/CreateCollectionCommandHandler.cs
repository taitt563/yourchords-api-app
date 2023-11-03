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
            // Extract user id from JWT token
            var collection = new Collection();
            collection.CollectionName = request.CollectionName;
            collection.UserId = request.UserId;
            collection.Image = request.Image;
            collection.IsPrivate = request.IsPrivate;
            collection.DateCreated = DateTime.UtcNow; // Or your preferred time zone

            collection = await _collectionRepository.AddAsync(collection);

            return _mapper.Map<CollectionDto>(collection);
        }
    }
}
