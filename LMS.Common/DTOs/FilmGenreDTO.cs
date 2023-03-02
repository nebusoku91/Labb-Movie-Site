namespace LMS.Common.DTOs
{
    public class FilmGenreDTO
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public FilmDTO Film { get; set; } = null!;
        public GenreDTO Genre { get; set; } = null!;
    }

    public class FilmGenreCreateDTO
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }
    }
}
