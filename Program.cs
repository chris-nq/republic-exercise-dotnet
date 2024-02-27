using CommandLine;
using RepublicExerciseDotNET.Classes;

namespace RepublicExerciseDotNET;
class Program
{
    public class Options
    {
        [Value(0, MetaName = "terrain", Required = false, HelpText = "Terrain values")]
        public IEnumerable<string>? Terrain { get; set; }
        [Option('o', "output-dir", Required = false, HelpText = "Set output directory.")]
        public string? OutputDir { get; set; }
        [Option('d', "data-dir", Required = false, HelpText = "Set data directory.")]
        public string? DataDir { get; set; }

    }
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                if (o.Terrain is null || o.Terrain.ToArray().Length == 0)
                {
                    Console.WriteLine("No terrain specified, generating for all terrains");
                }
                var terrainsOutput = o.Terrain is not null && o.Terrain.Any() ? string.Join(", ", o.Terrain.ToArray()) : "all";
                Console.WriteLine($"Generating CSV for terrains: {terrainsOutput}");
                var archive = new PlanetaryArchive(o.DataDir ?? "data");
                var scanner = new PlanetaryScanner(o.OutputDir ?? ".");
                scanner.Scan(o.Terrain?.ToArray() ?? Array.Empty<string>(), archive);
                Console.WriteLine($"Generated CSV at {scanner.Filename}");
            });
}
}
