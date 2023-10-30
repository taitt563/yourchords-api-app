using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Genres.Queries.GetAllGenres;

namespace YourChordsAPIApp.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQuery : IRequest<GenreVm>
    {
        public int GenreId { get; set; }
    }

}
