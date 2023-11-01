using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.UpdateUserAccount
{
    public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, bool>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UpdateUserAccountCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<bool> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userAccount = new UserAccount
            {
                Id = request.UserAccount.Id,
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

            await _userAccountRepository.UpdateUserAccountAsync(userAccount);
            return true; 
        }
    }


}
