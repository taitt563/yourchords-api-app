using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Genres.Queries.GetAllGenres
{
    public class GenreVm : IMapFrom<Genre>
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
    }

}
