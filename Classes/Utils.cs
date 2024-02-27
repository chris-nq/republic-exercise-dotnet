using System.Text.RegularExpressions;

namespace RepublicExerciseDotNET.Classes
{
    public class Utils
    {
        public static void ThrowIfPathDoesNotExist(string path, string message = "Invalid path.")
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(message);
            }
        }

        public static string ReplaceBadChars(string input)
        {
            Regex regex = new("[\"|]");
            return regex.Replace(input, "_");
        }
    }
}