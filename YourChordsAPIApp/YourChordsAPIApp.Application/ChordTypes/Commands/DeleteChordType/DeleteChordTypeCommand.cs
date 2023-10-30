using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.DeleteChordType
{
    public class DeleteChordTypeCommand : IRequest<Unit>
    {
        public int ChordTypeId { get; set; }
    }
}
