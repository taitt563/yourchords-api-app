using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.VerifyEmail
{
    public class VerifyEmailCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
