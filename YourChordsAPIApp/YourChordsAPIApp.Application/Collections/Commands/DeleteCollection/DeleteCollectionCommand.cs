using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Collections.Commands.DeleteCollection
{
    public class DeleteCollectionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
