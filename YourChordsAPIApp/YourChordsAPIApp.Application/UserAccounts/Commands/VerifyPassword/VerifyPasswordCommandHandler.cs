using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.VerifyPassword
{
    public class VerifyPasswordCommandHandler : IRequestHandler<VerifyPasswordCommand, bool>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public VerifyPasswordCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<bool> Handle(VerifyPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userAccountRepository.VerifyPasswordAsync(request.Password, request.UserAccount);
        }
    }

}
