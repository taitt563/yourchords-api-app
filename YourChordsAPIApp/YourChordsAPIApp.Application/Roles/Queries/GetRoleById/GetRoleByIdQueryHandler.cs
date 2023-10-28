using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Roles.Queries.GetRoles;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RolesVm>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public GetRoleByIdQueryHandler(IRolesRepository rolesRepository, IMapper mapper) 
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<RolesVm> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role =  await _rolesRepository.GetByIdAsync(request.RoleId);
            return _mapper.Map<RolesVm>(role);
        }
    }
}
