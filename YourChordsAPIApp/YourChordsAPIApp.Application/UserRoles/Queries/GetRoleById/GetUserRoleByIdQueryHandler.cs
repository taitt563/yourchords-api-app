using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserRoles.Queries.GetRoles;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserRoles.Queries.GetRoleById
{
    public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, UserRoleVm>
    {
        private readonly IUserRoleRepository _rolesRepository;
        private readonly IMapper _mapper;

        public GetUserRoleByIdQueryHandler(IUserRoleRepository rolesRepository, IMapper mapper) 
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<UserRoleVm> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role =  await _rolesRepository.GetByIdAsync(request.RoleId);
            return _mapper.Map<UserRoleVm>(role);
        }
    }
}
