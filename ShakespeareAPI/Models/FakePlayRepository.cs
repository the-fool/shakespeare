using System.Collections.Generic;
using System.Linq;

namespace ShakespeareAPI.Models {
    public class FakePlayRepository : IPlayRepository {
        public IQueryable<Play> Plays => new List<Play> {
            new Play { PlayID = 1, Name = "Hamlet" },
            new Play { PlayID = 2, Name = "Macbeth" },
            new Play { PlayID = 3, Name = "As You Like It" }
        }.AsQueryable ();

        public bool TryGetPlay (int id, out Play play) {
            var x = Plays.FirstOrDefault (p => p.PlayID == id);
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