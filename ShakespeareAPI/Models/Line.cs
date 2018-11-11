namespace ShakespeareAPI.Models
{
    public class Line
    {

        public int LineID { get; set; }
        public int PlayID { get; set; }
        public Play Play { get; set; }

        public int LineNumber { get; set; }
        public int ActNumber { get; set; }
        public int SceneNumber { get; set; }
        public string Text { get; set; }
    }
}