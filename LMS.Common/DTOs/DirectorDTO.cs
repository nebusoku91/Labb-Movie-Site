namespace LMS.Common.DTOs
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FilmDTO> Films { get; set; } = new();
    }

    public class DirectorCreateDTO
    {
        public string Name { get; set; }
    }

    public class DirectorEditDTO : DirectorCreateDTO
    {
        public int Id { get; set; }
    }
}
