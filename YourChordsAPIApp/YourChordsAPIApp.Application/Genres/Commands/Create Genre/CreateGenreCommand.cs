using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Genres.Queries.GetAllGenres;

namespace YourChordsAPIApp.Application.Genres.Commands.Create_Genre
{
    public class CreateGenreCommand : IRequest<GenreVm>
    {
        public string GenreName { get; set; }
    }

}
