using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.ChordTypes.Queries.GetChordTypes
{
    public class ChordTypeVm : IMapFrom<ChordType>
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
