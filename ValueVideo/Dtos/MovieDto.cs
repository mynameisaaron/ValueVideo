namespace ValueVideo.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte NumberAvailable { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
    }

    public class GenreDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}