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
            public override string ToString() {
                return base.ToString() + ": " + Play + ": " + Dataline;
            }
        }

        private class WorkGenreRow {
            public string Title { get; set; }
            public Genre Genre { get; set; }
        }

        public static void Ingest(ApiDbContext context) {

            var result = new List<string>();
            var rootFixtureDir = "models/shakespeare_data/csv";
            using(TextReader worksReader = File.OpenText($"{rootFixtureDir}/works.csv"))
            using(TextReader linesReader = File.OpenText($"{rootFixtureDir}/paragraphs.csv")) {
                var worksCsv = new CsvReader(worksReader);
                var csv = new CsvReader(linesReader);
                var works = worksCsv.GetRecords<WorkGenreRow>();

                var oldPlays = context.Set<Work>();
                context.Works.RemoveRange(oldPlays);
                context.SaveChanges();
                foreach (var w in works) {
                    var play = new Work() {
                        Title = w.Title,
                        Genre = w.Genre,
                    };
                    context.Works.Add(play);

                }
                context.SaveChanges();
            }
        }

    }
}