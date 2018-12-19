using System.Collections.Generic;

namespace ShakespeareAPI.Models {
    public class Scene {
        public int Id { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public int Act { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }

        public List<Paragraph> Paragraphs { get; set; }
    }
}