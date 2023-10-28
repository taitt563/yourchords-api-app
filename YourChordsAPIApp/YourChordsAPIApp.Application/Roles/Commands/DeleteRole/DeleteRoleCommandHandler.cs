using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, int>
    {
        private readonly IRolesRepository _rolesRepository;

        public DeleteRoleCommandHandler(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<int> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _rolesRepository.DeleteAsync(request.Id);
        }
    }
}
