using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShakespeareAPI.Models {
    public class Scene {
        public int Id { get; set; }

        [JsonIgnore]
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public int Act { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }

        public IEnumerable<Paragraph> Paragraphs { get; set; }
    }
}