using System.Linq;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Services {
    public class CharacterService : ICharacterService {

        private readonly ApiDbContext context;

        public CharacterService(ApiDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Character> GetAll() {
            return context.Characters;
        }

        public bool TryGetById(int id, out Character character)
        {
            var x = context.Characters
                .Where(p => p.Id == id)
                .FirstOrDefault();
            if (x != null)
            {
                character = x;
                return true;
            }
            character = null;
            return false;
        }
    }
}