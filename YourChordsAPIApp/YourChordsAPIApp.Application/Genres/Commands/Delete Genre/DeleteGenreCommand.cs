using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Genres.Commands.Delete_Genre
{
    public class DeleteGenreCommand : IRequest<Unit>
    {
        public int GenreId { get; set; }
    }

}
