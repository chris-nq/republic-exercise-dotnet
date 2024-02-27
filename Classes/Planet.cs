namespace republic_exam_dotnet.Classes
{
    public class Planet
    {
        public Planet(string name, string[] terrains, string population)
        {
            Name = name;
            Terrains = terrains;
            Population = population;
        }
        public string Name { get; set; }
        public string[] Terrains { get; set; }
        public string Population { get; set; }
    }
}