using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes
{
    public class GetAllChordTypesQuery : IRequest<IEnumerable<ChordTypeVm>>
    {
    }
}
