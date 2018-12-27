using System;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = ShakespeareAPI.Program.CreateWebHostBuilder(args);

            using(var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApiDbContext>; 

                if (args.Length == 0) {
                    return 0;
                }

                var arg = args[0];

                switch (arg) {
                    case "csv": {
                        CsvIngester.Ingest(context);
                        return 0;
                    }

                }
            }
        }
    }
}
