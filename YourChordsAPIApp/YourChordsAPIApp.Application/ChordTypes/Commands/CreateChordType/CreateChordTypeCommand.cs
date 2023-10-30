using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.CreateChordType
{
    public class CreateChordTypeCommand : IRequest<ChordTypeVm>
    {
        public string TypeName { get; set; }
    }
}
