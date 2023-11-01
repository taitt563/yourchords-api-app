using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GenerateToken
{
    public class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, string>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GenerateTokenQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<string> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
        {
            var userAccount = new UserAccount
            {
                UserName = request.UserAccount.UserName,
                Email = request.UserAccount.Email,
                PasswordHash = request.UserAccount.PasswordHash,
                Token = request.UserAccount.Token,
                Bio = request.UserAccount.Bio,
                Dob = request.UserAccount.Dob,
                PhoneNumber = request.UserAccount.PhoneNumber,
                Gender = request.UserAccount.Gender,
                Image = request.UserAccount.Image,
                DateJoined = request.UserAccount.DateJoined,
                IsVerified = request.UserAccount.IsVerified,
                IsPrivate = request.UserAccount.IsPrivate,
                IsDeleted = request.UserAccount.IsDeleted,
                Role = request.UserAccount.Role
            };

            return await _userAccountRepository.GenerateTokenAsync(userAccount);
        }
    }

}
