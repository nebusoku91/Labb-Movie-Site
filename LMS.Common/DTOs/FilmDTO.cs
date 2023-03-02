namespace LMS.Common.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Released { get; set; } = DateTime.Today;
        public bool Free { get; set; } = false;
        public string? Description { get; set; } = string.Empty;
        public string FilmUrl { get; set; } = string.Empty;
        public int? DirectorId { get; set; }
        public DirectorDTO? Director { get; set; }
        public List<GenreDTO>? Genres { get; set; } = new();
        public List<SimilarFilmsDTO>? SimilarFilms { get; set; } = new();
    }
    public class FilmCreateDTO
    {
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public bool Free { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }
        public int DirectorId { get; set; }
    }

    public class FilmEditDTO : FilmCreateDTO
    {
        public int Id { get; set; }
    }
}
