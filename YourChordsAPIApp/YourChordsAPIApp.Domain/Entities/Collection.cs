﻿using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class Collection
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string CollectionName { get; set; } = null!;

    public string? Image { get; set; }

    public DateTime DateCreated { get; set; }

    public bool IsPrivate { get; set; }

    public virtual ICollection<CollectionSong> CollectionSongs { get; set; } = new List<CollectionSong>();

    public virtual UserAccount User { get; set; } = null!;
}
