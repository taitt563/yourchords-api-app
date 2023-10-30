using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Genres.Queries.GetAllGenres;

namespace YourChordsAPIApp.Application.Genres.Commands.Update_Genre
{
    public class UpdateGenreCommand : IRequest<GenreVm>
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }

}
