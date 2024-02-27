using System.Text.RegularExpressions;

namespace republic_exam_dotnet.Classes
{
    public class Planet
    {
        public Planet(string name, string terrain, string population)
        {
            this.name = name;
            // Regex regex = new Regex(@"\s*,\s*");
            // this.terrain = regex.Split(terrain);
            this.terrain = terrain;
            this.population = population;
        }
        public string name { get; set; }
        public string terrain { get; set; }
        public string population { get; set; }
    }
}