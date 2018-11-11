using System;
using System.Collections.Generic;
using System.IO;
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
                csv.Read ();
                var record = csv.GetRecord<ShakespeareRow> ();
                Console.WriteLine (record.ToString());
            }
        }

    }
}