using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Collections.Queries.Dtos
{
    public class CollectionDto : IMapFrom<Collection>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CollectionName { get; set; }
        public string? Image { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPrivate { get; set; }
    }
}
