using System.Collections;
using System.Text.Json;

namespace republic_exam_dotnet.Classes
{
    public class PlanetaryArchive : IEnumerable<Planet>
    {
        public PlanetaryArchive(string dataDirectory)
        {
            DataDirectory = Path.GetFullPath(dataDirectory);
            if (!Directory.Exists(DataDirectory))
            {
                throw new DirectoryNotFoundException("Invalid data directory.");
            }
        }

        public string DataDirectory { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Planet> GetEnumerator()
        {
            foreach (var file in Directory.EnumerateFiles(DataDirectory, "*.json"))
            {
                string json = File.ReadAllText(file);
                var deserialized = JsonSerializer.Deserialize<PlanetsData>(json);
                if (deserialized?.Results != null)
                {
                    foreach (var planet in deserialized.Results)
                    {
                        yield return planet;
                    }
                }

            }
        }
    }
}