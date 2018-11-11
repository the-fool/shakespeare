using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
namespace ShakespeareAPI.Models {
    public class CsvIngester {
        private class ShakespeareRow {
            public string Dataline { get; set; }
            public string Play { get; set; }
            public string PlayerLine { get; set; }
            public string ActSceneLine { get; set; }
            public string Player { get; set; }
            public string Text { get; set; }
            public override string ToString () {
                return base.ToString () + ": " + Play + ": " + Dataline;
            }
        }

        public static void Ingest (ApplicationDbContext context) {

            List<string> result = new List<string> ();

            using (TextReader fileReader = File.OpenText ("models/Shakespeare_data.csv")) {
                var csv = new CsvReader (fileReader);
                var records = csv.GetRecords<ShakespeareRow> ();
                var plays = records.Select (r => r.Play).Distinct ();

                var oldPlays = context.Set<Play> ();
                context.Plays.RemoveRange (oldPlays);
                context.SaveChanges();
                foreach (var p in plays) {
                    context.Plays.Add (new Play () {
                        Name = p,
                        Genre=Genre.Unusual
                    });

                }
                context.SaveChanges();
            }
        }

    }
}