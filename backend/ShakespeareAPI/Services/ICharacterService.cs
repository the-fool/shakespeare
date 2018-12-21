using System.Linq;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Services {
    public interface ICharacterService {
        IQueryable<Character> GetAll();

        bool TryGetById(int id, out Character character);
    }
}