namespace WebApplication1.Entities
{
    public class Blogpost
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Inhoud { get; set; } = string.Empty;
        public DateTime PublicatieDatum { get; set; }
      
    }
}
