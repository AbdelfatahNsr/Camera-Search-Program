
namespace SystemSettings
{
    public class SystemSettings
    {
        public string GetCsvFilePath()
        {
            string fullPath = Environment.ProcessPath;

            string fileName = "cameras-defb.csv";
            string filePath = SearchFileInPathAndParents(fullPath, fileName);

            if (!string.IsNullOrEmpty(filePath))
            {
                //Console.WriteLine($"The file '{fileName}' was found at: '{filePath}'.");
                return filePath;
            }
            else
            {
                //Console.WriteLine($"The file '{fileName}' was not found in the specified path or its parent directories.");
                throw new FileNotFoundException($"CSV file not found at path: {fullPath}");
            }
        }

        string SearchFileInPathAndParents(string basePath, string fileName)
        {
            string fullPath = Path.Combine(basePath, fileName);

            if (File.Exists(fullPath))
            {
                return fullPath;
            }
            else
            {
                string parentDirectory = Directory.GetParent(basePath)?.FullName;
                if (!string.IsNullOrEmpty(parentDirectory))
                {
                    return SearchFileInPathAndParents(parentDirectory, fileName);
                }
            }

            return null;
        }
    }
}