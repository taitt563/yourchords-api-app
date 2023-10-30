using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserRoles.Queries.GetRoles
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<UserRoleVm>>
    {
        private readonly IUserRoleRepository _rolesRepository;
        private readonly IMapper _mapper;

        public GetUserRolesQueryHandler(IUserRoleRepository rolesRepository, IMapper mapper) {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<List<UserRoleVm>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _rolesRepository.GetAllBlogAsync();
            //var roleList = roles.Select(x => new RolesVm { Id = x.Id , Name = x.Name, Description = x.Description}).ToList();
            var roleList = _mapper.Map<List<UserRoleVm>>(roles);
            return roleList;
        }
    }
}
