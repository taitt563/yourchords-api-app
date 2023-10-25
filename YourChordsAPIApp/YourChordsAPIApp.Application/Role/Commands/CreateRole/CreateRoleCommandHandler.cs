using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Roles.Queries.GetRoles;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Roles.Commands.CreateRole
{
    internal class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RolesVm>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRolesRepository rolesRepository, IMapper mapper) 
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<RolesVm> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleEntity = new Role() { Name = request.Name, Description = request.Description };
            var result = await _rolesRepository.CreateAsync(roleEntity);
            return _mapper.Map<RolesVm>(result);
        }
    }
}
