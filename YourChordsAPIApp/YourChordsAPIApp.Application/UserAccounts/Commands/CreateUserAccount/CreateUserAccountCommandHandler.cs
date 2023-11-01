using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Queries;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, UserAccountVm>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public CreateUserAccountCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccountVm> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
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

            var createdUserAccount = await _userAccountRepository.CreateUserAccountAsync(userAccount);

            return new UserAccountVm
            {
                Id = createdUserAccount.Id,
                UserName = createdUserAccount.UserName,
                Email = createdUserAccount.Email,
                PasswordHash = createdUserAccount.PasswordHash,
                Token = createdUserAccount.Token,
                Bio = createdUserAccount.Bio,
                Dob = (DateTime)createdUserAccount.Dob,
                PhoneNumber = createdUserAccount.PhoneNumber,
                Gender = (bool)createdUserAccount.Gender,
                Image = createdUserAccount.Image,
                DateJoined = (DateTime)createdUserAccount.DateJoined,
                IsVerified = (bool)createdUserAccount.IsVerified,
                IsPrivate = (bool)createdUserAccount.IsPrivate,
                IsDeleted = (bool)createdUserAccount.IsDeleted,
                Role = createdUserAccount.Role
            };
        }
    }

}
