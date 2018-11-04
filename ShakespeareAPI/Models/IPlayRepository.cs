using System.Linq;
using System.Collections.Generic;

namespace ShakespeareAPI.Models
{
    public interface IPlayRepository {
        IQueryable<Play> Plays { get; }

        IQueryable<Play> GetAll();

        bool TryGetPlay(int id, out Play play);
    }
    
}