namespace ShakespeareAPI.Models {

    public enum Genre {
        Tragedy,
        History,
        Comedy,
        Poem,
        Sonnet,
        Unusual
    }

    public class Work {

        public int Id { get; set; }
        public string Title { get; set; }

        public string LongTitle { get; set; }

        public string Date { get; set; }

        public Genre Genre { get; set; }
    }
}