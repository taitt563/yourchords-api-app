using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Genres.Queries.GetAllGenres
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GenreVm>>
    {
    }

}
