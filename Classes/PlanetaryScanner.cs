using System;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;

namespace RepublicExerciseDotNET.Classes
{
    public class PlanetaryScanner
    {
        public PlanetaryScanner(string outputDir)
        {
            OutputDir = Path.GetFullPath(outputDir);
            Utils.ThrowIfPathDoesNotExist(OutputDir, "Invalid output directory.");
        }
        public string OutputDir { get; set; }
        public string? Filename { get; set; }
        public string[] Headers = new string[] { "Name", "Terrain", "Population" };
        public string[] Terrains = Array.Empty<string>();
        public void Scan(string[] terrains, PlanetaryArchive archive)
        {
            // DataTable table = new();
            Terrains = terrains;
            var suffix = terrains.Length > 0 ? string.Join("_", terrains) : "all";
            var filename = $"planets_{suffix}.csv";
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = "|",
                ShouldQuote = (a) => a.Row.HeaderRecord is not null,
                NewLine = Environment.NewLine,
            };
            Filename = Path.Combine(OutputDir, filename);
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, config);
            csv.WriteHeader<Planet>();
            csv.NextRecord();
            foreach (var planet in archive)
            {
                // Console.WriteLine(planet.Name);
                Regex regex = new(@"\s*,\s*");
                string[] planetTerrains = regex.Split(planet.terrain);
                if (terrains.Length == 0 || planetTerrains.Intersect(terrains).Any())
                {
                    // Console.WriteLine(planet.name);
                    planet.name = Utils.ReplaceBadChars(planet.name);
                    planet.terrain = Utils.ReplaceBadChars(planet.terrain);
                    planet.population = Utils.ReplaceBadChars(planet.population);
                    csv.WriteRecord(planet);
                    csv.NextRecord();
                }
            }

        }
    }
}
