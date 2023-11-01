using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.DeleteUserAccount
{
    public class DeleteUserAccountCommandHandler : IRequestHandler<DeleteUserAccountCommand, bool>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public DeleteUserAccountCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<bool> Handle(DeleteUserAccountCommand request, CancellationToken cancellationToken)
        {
            await _userAccountRepository.DeleteUserAccountAsync(request.UserId);
            return true;
        }
    }

}
