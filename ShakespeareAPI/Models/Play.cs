namespace ShakespeareAPI.Models {

  public enum Genre
  {
    Tragedy, History, Comedy, Unusual
  }

  public class Play {
    public int PlayID { get; set; }
    public string Name { get; set; }

    public Genre Genre { get; set; }
  }
}