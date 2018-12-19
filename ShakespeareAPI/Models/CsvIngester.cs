using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

namespace ShakespeareAPI.Models {
    public class CsvIngester {
        private class WorksRow {
            public int id { get; set; }
            public string title { get; set; }
            public string long_title { get; set; }
            public string date { get; set; }
            public string genre { get; set; }
        }

        private class SceneRow {
            public int id { get; set; }
            public int act { get; set; }
            public int scene { get; set; }
            public string description { get; set; }
            public int work_id { get; set; }
        }

        private class ParagraphRow {
            public int id { get; set; }
            public int paragraph_num { get; set; }
            public string text { get; set; }
            public int character_id { get; set; }
            public int scene_id { get; set; }
        }

        private class CharacterRow {
            public int id { get; set; }
            public string name { get; set; }
            public string abbrev { get; set; }
            public string description { get; set; }
        }

        public static void Ingest(ApiDbContext context) {

            var rootFixtureDir = "models/shakespeare_data/csv";
            using(TextReader masterReader = File.OpenText($"{rootFixtureDir}/works.csv")) {
                var csv = new CsvReader(masterReader);
                var rows = csv.GetRecords<WorksRow>();

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

            using(TextReader reader = File.OpenText($"{rootFixtureDir}/scenes.csv")) {
                var csv = new CsvReader(reader);
                var rows = csv.GetRecords<SceneRow>();

                foreach (var r in rows) {
                    var scene = new Scene() {
                        Id = r.id,
                        Order = r.scene,
                        Act = r.act,
                        Description = r.description,
                        WorkId = r.work_id
                    };

                    context.Scenes.Add(scene);
                }
                context.SaveChanges();
            }

            using(TextReader reader = File.OpenText($"{rootFixtureDir}/characters.csv")) {
                var csv = new CsvReader(reader);
                var rows = csv.GetRecords<CharacterRow>();

                foreach (var r in rows) {
                    var character = new Character() {
                        Id = r.id,
                        Name = r.name,
                        Abbreviation = r.abbrev,
                        Description = r.description,
                    };

                    context.Characters.Add(character);
                }
                context.SaveChanges();
            }
            
            using(TextReader reader = File.OpenText($"{rootFixtureDir}/characters.csv")) {
                var csv = new CsvReader(reader);
                var rows = csv.GetRecords<CharacterRow>();

                foreach (var r in rows) {
                    var character = new Character() {
                        Id = r.id,
                        Name = r.name,
                        Abbreviation = r.abbrev,
                        Description = r.description,
                    };

                    context.Characters.Add(character);
                }
                context.SaveChanges();
            }

            using(TextReader reader = File.OpenText($"{rootFixtureDir}/paragraphs.csv")) {
                var csv = new CsvReader(reader);
                var rows = csv.GetRecords<ParagraphRow>();
                var count = 1;
                foreach (var r in rows) {
                    var x = new Paragraph() {
                        Id = r.id,
                        Text = r.text,
                        Cardinality = r.paragraph_num,
                        CharacterId = r.character_id,
                        SceneId = r.scene_id,
                    };

                    context.Paragraphs.Add(x);
                    // batch the inserts
                    if (count % 1000 == 0)
                        context.SaveChanges();
                    count++;
                }
                context.SaveChanges();
            }
        }

    }
}