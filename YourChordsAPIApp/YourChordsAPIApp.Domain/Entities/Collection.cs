using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Collection
    {
        public Collection()
        {
            CollectionSongs = new HashSet<CollectionSong>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string CollectionName { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual UserAccount User { get; set; } = null!;
        public virtual ICollection<CollectionSong> CollectionSongs { get; set; }
    }
}
