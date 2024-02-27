using System.Text.RegularExpressions;

namespace RepublicExerciseDotNET.Classes
{
    public class Planet
    {
        public Planet(string name, string terrain, string population)
        {
            this.name = name;
            this.terrain = terrain;
            this.population = population;
        }
        public string name { get; set; }
        public string terrain { get; set; }
        public string population { get; set; }
    }
}