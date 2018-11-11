using System.Collections.Generic;
using System.Linq;
namespace ShakespeareAPI.Models
{
    public class PlayRepository : IPlayRepository
    {
        private ApplicationDbContext context;

        public PlayRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Play> GetAll()
        {
            return context.Plays;
        }

        public bool TryGetPlay(int id, out Play play)
        {
            var x = context.Plays
                .Where(p => p.ID == id)
                .FirstOrDefault();
            if (x != null)
            {
                play = x;
                return true;
            }
            play = null;
            return false;
        }
    }
}