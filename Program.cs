using republic_exam_dotnet.Classes;

namespace republic_exam_dotnet;
class Program
{
    static void Main(string[] args)
    {
        var archive = new PlanetaryArchive("./data");
        var scanner = new PlanetaryScanner();
        scanner.WriteToCsv(new string[] { "mountains" }, archive);
    }
}
