using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes;

namespace YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypeById
{
    public class GetChordTypeByIdQuery : IRequest<ChordTypeVm>
    {
        public int ChordTypeId { get; set; }
    }
}
