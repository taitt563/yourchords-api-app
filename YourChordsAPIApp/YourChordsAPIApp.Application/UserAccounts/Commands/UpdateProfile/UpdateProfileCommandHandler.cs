using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, bool>
    {
        private readonly IUserAccountRepository _repository;

        public UpdateProfileCommandHandler(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateProfileAsync(request.UserId, request.FirstName, request.LastName, request.Bio, request.Dob, request.PhoneNumber, request.Gender, request.Image);
        }
    }

}
