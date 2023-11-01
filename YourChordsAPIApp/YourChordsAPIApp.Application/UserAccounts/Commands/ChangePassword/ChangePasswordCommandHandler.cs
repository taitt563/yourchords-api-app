using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUserAccountRepository _repository;

        public ChangePasswordCommandHandler(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ChangePasswordAsync(request.UserId, request.CurrentPassword, request.NewPassword);
        }
    }

}
