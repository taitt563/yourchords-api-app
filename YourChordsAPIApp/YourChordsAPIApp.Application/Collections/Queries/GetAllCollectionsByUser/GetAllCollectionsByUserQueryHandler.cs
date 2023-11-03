using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Collections.Queries.GetAllCollectionsByUser
{
    public class GetAllCollectionsByUserQueryHandler : IRequestHandler<GetAllCollectionsByUserQuery, IEnumerable<CollectionDto>>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public GetAllCollectionsByUserQueryHandler(ICollectionRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CollectionDto>> Handle(GetAllCollectionsByUserQuery request, CancellationToken cancellationToken)
        {
            var collections = await _collectionRepository.GetByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<CollectionDto>>(collections);
        }
    }
}
