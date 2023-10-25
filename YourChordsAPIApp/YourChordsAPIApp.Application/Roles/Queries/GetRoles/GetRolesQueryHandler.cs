using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Roles.Queries.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RolesVm>>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(IRolesRepository rolesRepository, IMapper mapper) {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<List<RolesVm>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _rolesRepository.GetAllBlogAsync();
            //var roleList = roles.Select(x => new RolesVm { Id = x.Id , Name = x.Name, Description = x.Description}).ToList();
            var roleList = _mapper.Map<List<RolesVm>>(roles);
            return roleList;
        }
    }
}
