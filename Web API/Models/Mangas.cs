namespace Web_API.Models
{
    public class Mangas // and Manhwas
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
    }
}
