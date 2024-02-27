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
                var archive = new PlanetaryArchive(o.DataDir ?? "data");
                var scanner = new PlanetaryScanner();
                scanner.Scan(o.Terrain?.ToArray() ?? Array.Empty<string>(), archive);
            });
}
}
