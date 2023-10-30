using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserRoles.Queries.GetRoles;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserRoles.Commands.CreateRole
{
    internal class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, UserRoleVm>
    {
        private readonly IUserRoleRepository _rolesRepository;
        private readonly IMapper _mapper;

        public CreateUserRoleCommandHandler(IUserRoleRepository rolesRepository, IMapper mapper) 
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<UserRoleVm> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var roleEntity = new UserRole() { RoleName = request.Name, Description = request.Description };
            var result = await _rolesRepository.CreateAsync(roleEntity);
            return _mapper.Map<UserRoleVm>(result);
        }
    }
}
