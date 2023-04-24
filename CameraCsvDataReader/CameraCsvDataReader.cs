using CameraCsvDataReader.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CameraCsvDataReader
{
    public class CameraCsvDataReader
    {
        
        public List<CameraDto> ReadCsv(string cameraName = null)
        {
            List<CameraDto> cameras = new List<CameraDto>();

            var settings = new SystemSettings.SystemSettings();
            string fullPath = settings.GetCsvFilePath();

            using (var reader = new StreamReader(fullPath))
            {
                CultureInfo culture = new CultureInfo("nl-NL");
                var configuration = new CsvConfiguration(culture);

                configuration.HasHeaderRecord = false;
                configuration.MissingFieldFound = null;
                int rowCount = 0;

                using (var csv = new CsvReader(reader, configuration))
                {
                    while (csv.Read())
                    {
                        try
                        {
                            rowCount++;
                            var name = csv.GetField<string>((int)Cameras.Name);
                            var latitude = csv.GetField<string>((int)Cameras.Latitude);
                            var longitude = csv.GetField<string>((int)Cameras.Longitude);

                            if (string.IsNullOrEmpty(cameraName) || name.Contains(cameraName))
                            {
                                var newName = RemoveNonNumeric(name);
                                var camera = new CameraDto
                                {
                                    Number = newName,
                                    Name = name,
                                    Latitude = latitude,
                                    Longitude = longitude
                                };
                                cameras.Add(camera);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }

            return cameras;
        }
        public static string RemoveNonNumeric(string value) => Regex.Replace(value, "[^0-9]", "");
        
    }
    enum Cameras
    {
        Name = 0,
        Latitude = 1,
        Longitude = 2
    }
}