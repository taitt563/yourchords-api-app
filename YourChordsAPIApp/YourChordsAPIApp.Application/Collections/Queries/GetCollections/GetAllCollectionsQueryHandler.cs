using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Collections.Queries.GetCollections
{
    public class GetAllCollectionsQueryHandler : IRequestHandler<GetAllCollectionsQuery, IEnumerable<CollectionDto>>
    {
        private readonly ICollectionRepository _collectionRepostiory;
        private readonly IMapper _mapper;

        public GetAllCollectionsQueryHandler(ICollectionRepository collectionRepository, IMapper mapper) 
        {
            _collectionRepostiory = collectionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CollectionDto>> Handle(GetAllCollectionsQuery request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepostiory.GetAllAsync();
            return _mapper.Map<IEnumerable<CollectionDto>>(collection);
        }
    }
}
