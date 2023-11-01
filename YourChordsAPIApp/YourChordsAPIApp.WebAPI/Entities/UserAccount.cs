using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class UserAccount
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Token { get; set; }

    public string? Bio { get; set; }

    public DateTime? Dob { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? Gender { get; set; }

    public string? Image { get; set; }

    public DateTime? DateJoined { get; set; }

    public bool? IsVerified { get; set; }

    public bool? IsPrivate { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Beat> Beats { get; set; } = new List<Beat>();

    public virtual ICollection<Chord> Chords { get; set; } = new List<Chord>();

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    public virtual ICollection<UserLikedSong> UserLikedSongs { get; set; } = new List<UserLikedSong>();
}
