using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Queries;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, UserAccountVm>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public SignInCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccountVm> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.SignInAsync(request.Email, request.Password);

            if (userAccount == null)
            {
                return null; // Trả về null nếu không tìm thấy tài khoản
            }

            return new UserAccountVm
            {
                Id = userAccount.Id,
                UserName = userAccount.UserName,
                Email = userAccount.Email,
                Token = userAccount.Token,
                Role = userAccount.Role
            };
        }
    }

}
