using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserAccountVm>
    {
        private readonly IUserAccountRepository _repository;
        private readonly IMapper _mapper; // Thêm IMapper

        public RegisterUserCommandHandler(IUserAccountRepository repository, IMapper mapper) // Thêm IMapper vào constructor
        {
            _repository = repository;
            _mapper = mapper; // Gán IMapper
        }

        public async Task<UserAccountVm> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _repository.RegisterAsync(request.Email, request.Password, request.ConfirmPassword);
            return _mapper.Map<UserAccountVm>(userAccount); // Chuyển đổi thành UserAccountVm
        }
    }

}
