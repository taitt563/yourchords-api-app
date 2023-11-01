using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Queries;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, UserAccountVm>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public SignUpCommandHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccountVm> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var userAccount = new UserAccount
            {
                Email = request.Email,
                PasswordHash = request.Password,
            };

            var createdUser = await _userAccountRepository.SignUpAsync(request.Email, request.Password);

            return new UserAccountVm
            {
                Id = createdUser.Id,
                UserName = createdUser.UserName,
                Email = createdUser.Email,
                Token = createdUser.Token,
                Bio = createdUser.Bio,
                Dob = (DateTime)createdUser.Dob,
                PhoneNumber = createdUser.PhoneNumber,
                Gender = (bool)createdUser.Gender,
                Image = createdUser.Image,
                DateJoined = (DateTime)createdUser.DateJoined,
                Role = createdUser.Role
                // Thêm các thông tin tài khoản người dùng khác tùy theo yêu cầu
            };
        }
    }

}
