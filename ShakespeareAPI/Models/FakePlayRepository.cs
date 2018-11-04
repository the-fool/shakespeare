using System.Collections.Generic;
using System.Linq;

namespace ShakespeareAPI.Models {
    public class FakePlayRepository : IPlayRepository {
        public IQueryable<Play> Plays => new List<Play> {
            new Play { ID = 1, Name = "Hamlet" },
            new Play { ID = 2, Name = "Macbeth" },
            new Play { ID = 3, Name = "As You Like It" }
        }.AsQueryable ();

        public bool TryGetPlay (int id, out Play play) {
            var x = Plays.FirstOrDefault (p => p.ID == id);
            if (x != null)
            {
                play = x;
                return true;
            }

            play = null;
            return false;
        }

        public IQueryable<Play> GetAll () {
            return Plays;
        }
    }
}