using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;

namespace YourChordsAPIApp.Application.Collections.Commands.UpdateCollection
{
    public class UpdateCollectionCommand : IRequest<CollectionDto>
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public string? Image { get; set; }
        public bool IsPrivate { get; set; }
    }
}
