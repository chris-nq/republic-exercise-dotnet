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
    }
}