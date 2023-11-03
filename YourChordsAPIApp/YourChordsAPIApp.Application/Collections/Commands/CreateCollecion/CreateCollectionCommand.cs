using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Collections.Queries.Dtos;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Collections.Commands.CreateCollecion
{
    public class CreateCollectionCommand : IRequest<CollectionDto>
    {
        public int UserId { get; set; }
        public string CollectionName { get; set; }
        public string? Image { get; set; }
        public bool IsPrivate { get; set; }
    }
}
