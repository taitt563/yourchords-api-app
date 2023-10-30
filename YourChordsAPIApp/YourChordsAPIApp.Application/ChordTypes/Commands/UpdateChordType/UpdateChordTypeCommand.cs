using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.UpdateChordType
{
    public class UpdateChordTypeCommand : IRequest<ChordTypeVm>
    {
        public int ChordTypeId { get; set; }
        public string TypeName { get; set; }
    }
}
