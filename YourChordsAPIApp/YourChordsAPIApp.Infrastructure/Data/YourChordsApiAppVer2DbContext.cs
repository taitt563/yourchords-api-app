using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class YourChordsApiAppVer2DbContext : DbContext
    {
        public YourChordsApiAppVer2DbContext()
        {
        }

        public YourChordsApiAppVer2DbContext(DbContextOptions<YourChordsApiAppVer2DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<ArtistGenre> ArtistGenres { get; set; } = null!;
        public virtual DbSet<Beat> Beats { get; set; } = null!;
        public virtual DbSet<BeatGenre> BeatGenres { get; set; } = null!;
        public virtual DbSet<BeatInstrument> BeatInstruments { get; set; } = null!;
        public virtual DbSet<Chord> Chords { get; set; } = null!;
        public virtual DbSet<ChordType> ChordTypes { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<CollectionSong> CollectionSongs { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Instrument> Instruments { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestBeat> RequestBeats { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<SongArtist> SongArtists { get; set; } = null!;
        public virtual DbSet<SongBeat> SongBeats { get; set; } = null!;
        public virtual DbSet<SongChord> SongChords { get; set; } = null!;
        public virtual DbSet<SongGenre> SongGenres { get; set; } = null!;
        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;
        public virtual DbSet<UserLikedSong> UserLikedSongs { get; set; } = null!;
        public virtual DbSet<UserLoginDatum> UserLoginData { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SE140283; Database= YourChordsApiAppVer2Db; User ID=sa; Password=admin123; trustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Bio).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.ExternalLink).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ProfilePic).HasMaxLength(255);
            });

            modelBuilder.Entity<ArtistGenre>(entity =>
            {
                entity.ToTable("ArtistGenre");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistGenres)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_artist_genre_artist");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.ArtistGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_artist_genre_genre");
            });

            modelBuilder.Entity<Beat>(entity =>
            {
                entity.ToTable("Beat");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tone).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Beats)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_beat_user_account");
            });

            modelBuilder.Entity<BeatGenre>(entity =>
            {
                entity.ToTable("BeatGenre");

                entity.HasOne(d => d.Beat)
                    .WithMany(p => p.BeatGenres)
                    .HasForeignKey(d => d.BeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_beat_genres_beat");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BeatGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_beat_genres_genre");
            });

            modelBuilder.Entity<BeatInstrument>(entity =>
            {
                entity.ToTable("BeatInstrument");

                entity.HasOne(d => d.Beat)
                    .WithMany(p => p.BeatInstruments)
                    .HasForeignKey(d => d.BeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_beat_instrument_beat");

                entity.HasOne(d => d.Instrument)
                    .WithMany(p => p.BeatInstruments)
                    .HasForeignKey(d => d.InstrumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_beat_instrument_instrument");
            });

            modelBuilder.Entity<Chord>(entity =>
            {
                entity.ToTable("Chord");

                entity.Property(e => e.ChordDiagram).HasMaxLength(255);

                entity.Property(e => e.ChordName).HasMaxLength(100);

                entity.Property(e => e.ChordSound).HasMaxLength(255);

                entity.Property(e => e.Components).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ExternalLink).HasMaxLength(255);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Notation).HasMaxLength(50);

                entity.Property(e => e.Tone).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Chords)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chord_user_account");

                entity.HasOne(d => d.Instrument)
                    .WithMany(p => p.Chords)
                    .HasForeignKey(d => d.InstrumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chord_instrument");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Chords)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chord_chord_type");
            });

            modelBuilder.Entity<ChordType>(entity =>
            {
                entity.ToTable("ChordType");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collection");

                entity.Property(e => e.CollectionName).HasMaxLength(255);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_collection_user_account");
            });

            modelBuilder.Entity<CollectionSong>(entity =>
            {
                entity.ToTable("CollectionSong");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.CollectionSongs)
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_collection_songs_collection");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.CollectionSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_collection_songs_song");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreName).HasMaxLength(255);
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.ToTable("Instrument");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.InstrumentName).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateOrder).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.VoiceRecord).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_UserAccount");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Method).HasMaxLength(255);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_request");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_user_account");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.TransactionIdCustomer).HasMaxLength(255);

                entity.Property(e => e.TransactionIdMusician).HasMaxLength(255);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_user_account");
            });

            modelBuilder.Entity<RequestBeat>(entity =>
            {
                entity.ToTable("RequestBeat");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.Beat)
                    .WithMany(p => p.RequestBeats)
                    .HasForeignKey(d => d.BeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_beat_beat");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestBeats)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_beat_request");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExternalLink).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Lyrics).HasColumnType("text");

                entity.Property(e => e.SongTitle).HasMaxLength(255);

                entity.Property(e => e.SongWriter).HasMaxLength(255);

                entity.Property(e => e.Tone).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_user_account");
            });

            modelBuilder.Entity<SongArtist>(entity =>
            {
                entity.ToTable("SongArtist");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_artist_artist");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_artist_song");
            });

            modelBuilder.Entity<SongBeat>(entity =>
            {
                entity.ToTable("SongBeat");

                entity.HasOne(d => d.Beat)
                    .WithMany(p => p.SongBeats)
                    .HasForeignKey(d => d.BeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_beat_beat");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongBeats)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_beat_song");
            });

            modelBuilder.Entity<SongChord>(entity =>
            {
                entity.ToTable("SongChord");

                entity.HasOne(d => d.Chord)
                    .WithMany(p => p.SongChords)
                    .HasForeignKey(d => d.ChordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chord_song_chord");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongChords)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chord_song_song");
            });

            modelBuilder.Entity<SongGenre>(entity =>
            {
                entity.ToTable("SongGenre");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SongGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_genres_genre");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongGenres)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_song_genres_song");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.Property(e => e.DateJoined).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_account_user_role");
            });

            modelBuilder.Entity<UserLikedSong>(entity =>
            {
                entity.ToTable("UserLikedSong");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.UserLikedSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_liked_songs_song");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLikedSongs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_liked_songs_user_account");
            });

            modelBuilder.Entity<UserLoginDatum>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(250);

                entity.Property(e => e.PasswordSalt).HasMaxLength(100);

                entity.Property(e => e.Token).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLoginData)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_login_data_user_account");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
