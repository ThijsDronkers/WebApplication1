namespace WebApplication1.Dtos
{
    public class BlogpostDto
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Inhoud { get; set; } = string.Empty;
        public DateTime PublicatieDatum { get; set; }
    }
}
