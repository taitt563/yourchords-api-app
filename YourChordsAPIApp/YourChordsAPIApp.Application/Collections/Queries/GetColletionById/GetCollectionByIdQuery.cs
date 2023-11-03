using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;

namespace YourChordsAPIApp.Application.Collections.Queries.GetColletionById
{
    public class GetCollectionByIdQuery : IRequest<CollectionDto>
    {
        public int CollectionId { get; set; }
    }
}
