using System.Collections;
using System.Text.Json;

namespace RepublicExerciseDotNET.Classes
{
    public class PlanetaryArchive : IEnumerable<Planet>
    {
        public PlanetaryArchive(string dataDirectory)
        {
            DataDirectory = Path.GetFullPath(dataDirectory);
            Utils.ThrowIfPathDoesNotExist(DataDirectory, "Invalid data directory.");
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
                if (deserialized?.results is not null)
                {
                    foreach (var planet in deserialized.results)
                    {
                        yield return planet;
                    }
                }

            }
        }
    }
}
