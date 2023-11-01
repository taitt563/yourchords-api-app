using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.SetPrivateStatus
{
    public class SetPrivateStatusCommandHandler : IRequestHandler<SetPrivateStatusCommand, bool>
    {
        private readonly IUserAccountRepository _repository;

        public SetPrivateStatusCommandHandler(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SetPrivateStatusCommand request, CancellationToken cancellationToken)
        {
            return await _repository.SetPrivateStatusAsync(request.UserId, request.IsPrivate);
        }
    }

}
