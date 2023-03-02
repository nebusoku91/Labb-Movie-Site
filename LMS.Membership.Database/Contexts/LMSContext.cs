namespace LMS.Membership.Database.Contexts
{
    public class LMSContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<SimilarFilms> SimilarFilms { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<FilmGenre> FilmGenres { get; set; } = null!;

        public LMSContext(DbContextOptions<LMSContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SimilarFilms>().HasKey(ci => new { ci.FilmId, ci.SimilarFilmId });
            builder.Entity<FilmGenre>().HasKey(ci => new { ci.FilmId, ci.GenreId });

            base.OnModelCreating(builder);

            builder.Entity<Film>(entity =>
            {
                entity
                    .HasMany(d => d.SimilarFilms)
                    .WithOne(p => p.Film)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Genres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                      .ToTable("FilmGenres");
            });

            //TheSeedIsStrong(builder);
        }

        private void TheSeedIsStrong(ModelBuilder builder)
        {
            builder.Entity<Director>().HasData(
                new { Id = 1, Name = "The Wachowskis" },
                new { Id = 2, Name = "Ridley Scott" },
                new { Id = 3, Name = "Guillermo del Toro" },
                new { Id = 4, Name = "Damien Chazelle" },
                new { Id = 5, Name = "Christopher Nolan" },
                new { Id = 6, Name = "Quentin Tarantino" },
                new { Id = 7, Name = "Robert Eggers" },
                new { Id = 8, Name = "Tommy Wiseau" },
                new { Id = 9, Name = "Chris Williams" }
                );

            builder.Entity<Film>().HasData(
                 new { Id = 1, Title = "The Matrix", DirectorId = 1, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=vKQi3bBA1y8", Released = new DateTime(1999, 01, 01), Free = true },
                 new { Id = 2, Title = "Gladiator", DirectorId = 2, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=P5ieIbInFpg", Released = new DateTime(2000, 01, 01), Free = false },
                 new { Id = 3, Title = "Guillermo del Toro's Pinocchio", DirectorId = 3, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=Od2NW1sfRdA", Released = new DateTime(2022, 01, 01), Free = false },
                 new { Id = 4, Title = "Whiplash", DirectorId = 4, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=7d_jQycdQGo", Released = new DateTime(2014, 01, 01), Free = true },
                 new { Id = 5, Title = "Alien", DirectorId = 2, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=LjLamj-b0I8", Released = new DateTime(1979, 01, 01), Free = false },
                 new { Id = 6, Title = "Memento", DirectorId = 5, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=4CV41hoyS8A", Released = new DateTime(2000, 01, 01), Free = false },
                 new { Id = 7, Title = "Django Unchained", DirectorId = 6, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=0fUCuvNlOCg", Released = new DateTime(2012, 01, 01), Free = false },
                 new { Id = 8, Title = "Pulp Fiction", DirectorId = 6, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=s7EdQ4FqbhY", Released = new DateTime(1994, 01, 01), Free = true },
                 new { Id = 9, Title = "The Witch", DirectorId = 7, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=iQXmlf3Sefg", Released = new DateTime(2015, 01, 01), Free = false },
                 new { Id = 10, Title = "The Room", DirectorId = 8, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=tfMTHIwTUXA", Released = new DateTime(2015, 01, 01), Free = false },
                 new { Id = 11, Title = "The Sea Beast", DirectorId = 9, Description = "Lorem ipsum", FilmUrl = "https://www.youtube.com/watch?v=tfMTHIwTUXA", Released = new DateTime(2015, 01, 01), Free = false });

            builder.Entity<SimilarFilms>().HasData(
                new SimilarFilms { FilmId = 1, SimilarFilmId = 5 },
                new SimilarFilms { FilmId = 2, SimilarFilmId = 5 },
                new SimilarFilms { FilmId = 2, SimilarFilmId = 7 },
                new SimilarFilms { FilmId = 3, SimilarFilmId = 11 },
                new SimilarFilms { FilmId = 4, SimilarFilmId = 6 },
                new SimilarFilms { FilmId = 4, SimilarFilmId = 8 },
                new SimilarFilms { FilmId = 5, SimilarFilmId = 1 },
                new SimilarFilms { FilmId = 5, SimilarFilmId = 2 },
                new SimilarFilms { FilmId = 5, SimilarFilmId = 9 },
                new SimilarFilms { FilmId = 6, SimilarFilmId = 4 },
                new SimilarFilms { FilmId = 7, SimilarFilmId = 8 },
                new SimilarFilms { FilmId = 7, SimilarFilmId = 2 },
                new SimilarFilms { FilmId = 8, SimilarFilmId = 7 },
                new SimilarFilms { FilmId = 8, SimilarFilmId = 4 },
                new SimilarFilms { FilmId = 9, SimilarFilmId = 5 },
                new SimilarFilms { FilmId = 11, SimilarFilmId = 3 });

            builder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Science Fiction" },
                new { Id = 3, Name = "Drama" },
                new { Id = 4, Name = "Adventure" },
                new { Id = 5, Name = "Horror" },
                new { Id = 6, Name = "Thriller" });

            builder.Entity<FilmGenre>().HasData(
                new FilmGenre { FilmId = 1, GenreId = 1 },
                new FilmGenre { FilmId = 1, GenreId = 2 },
                new FilmGenre { FilmId = 2, GenreId = 1 },
                new FilmGenre { FilmId = 2, GenreId = 3 },
                new FilmGenre { FilmId = 3, GenreId = 4 },
                new FilmGenre { FilmId = 3, GenreId = 3 },
                new FilmGenre { FilmId = 4, GenreId = 3 },
                new FilmGenre { FilmId = 5, GenreId = 5 },
                new FilmGenre { FilmId = 5, GenreId = 2 },
                new FilmGenre { FilmId = 6, GenreId = 3 },
                new FilmGenre { FilmId = 6, GenreId = 6 },
                new FilmGenre { FilmId = 7, GenreId = 1 },
                new FilmGenre { FilmId = 7, GenreId = 3 },
                new FilmGenre { FilmId = 7, GenreId = 5 },
                new FilmGenre { FilmId = 8, GenreId = 3 },
                new FilmGenre { FilmId = 8, GenreId = 1 },
                new FilmGenre { FilmId = 9, GenreId = 5 },
                new FilmGenre { FilmId = 10, GenreId = 3 },
                new FilmGenre { FilmId = 10, GenreId = 6 },
                new FilmGenre { FilmId = 10, GenreId = 4 },
                new FilmGenre { FilmId = 11, GenreId = 4 });
        }
    }
}
