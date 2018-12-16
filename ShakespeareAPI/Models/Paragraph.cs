namespace ShakespeareAPI.Models
{
    public class Paragraph
    {
        public int Id { get; set; }
        public int Cardinality { get; set; }
        public string Text { get; set; }
        public Character Character { get; set; }
        public Scene Scene {get; set;}
    }
}