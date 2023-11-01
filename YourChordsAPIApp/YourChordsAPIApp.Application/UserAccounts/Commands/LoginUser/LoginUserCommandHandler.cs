using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserAccountVm>
    {
        private readonly IUserAccountRepository _repository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserAccountVm> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _repository.LoginAsync(request.Email, request.Password);
            return _mapper.Map<UserAccountVm>(userAccount);
        }
    }

}
