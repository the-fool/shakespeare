using System.Collections.Generic;

namespace ShakespeareAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public List<Paragraph> Paragraphs { get; set; }
    }
}