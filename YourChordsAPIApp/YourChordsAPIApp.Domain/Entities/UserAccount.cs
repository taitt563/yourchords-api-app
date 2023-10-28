﻿using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Beats = new HashSet<Beat>();
            Chords = new HashSet<Chord>();
            Collections = new HashSet<Collection>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            Requests = new HashSet<Request>();
            Songs = new HashSet<Song>();
            UserLikedSongs = new HashSet<UserLikedSong>();
            UserLoginData = new HashSet<UserLoginDatum>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public string? Image { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }

        public virtual UserRole Role { get; set; } = null!;
        public virtual ICollection<Beat> Beats { get; set; }
        public virtual ICollection<Chord> Chords { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<UserLikedSong> UserLikedSongs { get; set; }
        public virtual ICollection<UserLoginDatum> UserLoginData { get; set; }
    }
}
