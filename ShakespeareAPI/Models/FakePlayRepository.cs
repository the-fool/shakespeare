using System.Collections.Generic;
using System.Linq;

namespace ShakespeareAPI.Models
{
    public class FakePlayRepository : IProductRepository
    {
        public IQueryable<Play> Plays => new List {
            new Play { Name = "Hamlet" },
            new Play { Name = "Macbeth" },
            new Play { Name = "As You Like It" }
        }.AsQueryable();
    }
}