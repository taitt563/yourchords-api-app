using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;

namespace YourChordsAPIApp.Application.Collections.Queries.GetAllCollectionsByUser
{
    public class GetAllCollectionsByUserQuery : IRequest<IEnumerable<CollectionDto>>
    {
        public int UserId { get; set; }
    }
}
