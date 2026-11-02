namespace WebApplication1.Dtos
{
    public class BlogpostInputDto
    {
        public string Titel { get; set; } = string.Empty;
        public string Inhoud { get; set; } = string.Empty;
        public DateTime PublicatieDatum { get; set; }
    }
}
