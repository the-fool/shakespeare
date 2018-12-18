using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
namespace ShakespeareAPI.Models {
    public class CsvIngester {
        private class WorksRow {
            public int id { get; set; }
            public string title { get; set; }
            public string long_title { get; set; }
            public string date { get; set; }
            public string genre { get; set; }
        }
        private class ShakespeareRow {
            public int paragraph_num { get; set; }
            public string text { get; set; }
            public string character_name { get; set; }
            public string character_abbrev { get; set; }
            public string character_description { get; set; }
            public int scene_act { get; set; }
            public int scene_scene { get; set; }
            public string scene_description { get; set; }
            public string work_title { get; set; }
            public string work_long_title { get; set; }
            public string work_date { get; set; }
            public string work_genre { get; set; }

            public override string ToString() {
                return base.ToString() + ": " + work_title + ": " + text.Substring(0, 16);
            }
        }

        public static void Ingest(ApiDbContext context) {
            var rootFixtureDir = "models/shakespeare_data/csv";
            using(TextReader masterReader = File.OpenText($"{rootFixtureDir}/works.csv")) {
                var csv = new CsvReader(masterReader);
                var rows = csv.GetRecords<WorksRow>();

                var oldWorks = context.Set<Work>();

                context.Works.RemoveRange(oldWorks);
                context.SaveChanges();

                foreach (var r in rows) {
                    if (!Enum.TryParse<Genre>(r.genre, true, out var genre)) {
                        genre = Genre.Unusual;
                    };
                    var work = new Work() {
                        Id = r.id,
                        Title = r.title,
                        LongTitle = r.long_title,
                        Date = r.date,
                        Genre = genre,
                    };
                    context.Works.Add(work);
                }
                context.SaveChanges();
            }
        }

    }
}