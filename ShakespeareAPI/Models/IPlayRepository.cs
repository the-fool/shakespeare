using System.Linq;

namespace ShakespeareAPI.Models
{
    public interface IPlayRepository {
        IQueryable<Play> Plays { get; }
    }
    
}