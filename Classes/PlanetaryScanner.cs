using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace republic_exam_dotnet.Classes
{
    public class PlanetaryScanner
    {
        public string[] Headers = new string[] { "Name", "Terrain", "Population" };
        public string[] Terrains = Array.Empty<string>();
        public void WriteToCsv(string[] terrains, PlanetaryArchive archive)
        {
            // DataTable table = new();
            Terrains = terrains;
            foreach (var planet in archive)
            {
                if (planet.Terrains.Intersect(terrains).Any())
                {
                    Console.WriteLine(planet.Name);
                }
            }
            
        }
    }
}
