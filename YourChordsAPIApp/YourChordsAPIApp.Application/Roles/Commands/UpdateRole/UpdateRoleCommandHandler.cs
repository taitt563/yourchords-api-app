using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, int>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRolesRepository rolesRepository, IMapper mapper) 
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var updateRoleEntity = new UserRole () { Id = request.Id, RoleName = request.Name, Description = request.Description };
            return await _rolesRepository.UpdateAsync(request.Id, updateRoleEntity);
        }
    }
}
