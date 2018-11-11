using System;
using System.Linq;

namespace ShakespeareAPI.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.Plays.Any())
            {
                return; // DB already seeded
            }

            var plays = new Play[]
            {
                new Play{Name="Hamlet", Genre=Genre.Tragedy},
                new Play{Name="Macbeth", Genre=Genre.Tragedy},
                new Play{Name="All's Well that Ends Well", Genre=Genre.Comedy}

            };

            foreach (Play p in plays)
            {
                context.Plays.Add(p);
            }

            context.SaveChanges();
        }
        
    }
}