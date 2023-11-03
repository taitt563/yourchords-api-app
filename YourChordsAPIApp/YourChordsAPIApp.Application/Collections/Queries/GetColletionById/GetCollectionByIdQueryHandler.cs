using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Collections.Queries.GetColletionById
{
    public class GetCollectionByIdQueryHandler : IRequestHandler<GetCollectionByIdQuery, CollectionDto>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public GetCollectionByIdQueryHandler(ICollectionRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }
        public async Task<CollectionDto> Handle(GetCollectionByIdQuery request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepository.GetByIdAsync(request.CollectionId);

            if (collection == null)
            {
            }

            return _mapper.Map<CollectionDto>(collection);
        }
    }
}
