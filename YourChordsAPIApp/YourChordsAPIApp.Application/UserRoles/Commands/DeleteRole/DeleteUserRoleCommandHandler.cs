using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserRoles.Commands.DeleteRole
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, int>
    {
        private readonly IUserRoleRepository _rolesRepository;

        public DeleteUserRoleCommandHandler(IUserRoleRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<int> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _rolesRepository.DeleteAsync(request.Id);
        }
    }
}
