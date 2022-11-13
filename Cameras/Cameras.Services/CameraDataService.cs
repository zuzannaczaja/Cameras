using Cameras.Services.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Cameras.Services
{
    public class CameraDataService : ICameraDataService
    {
        public IEnumerable<CameraDto> GetCameraData()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = ";"
            };

            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

            using (var streamReader = File.OpenText(projectDirectory + "\\Cameras.API\\cameras-defb.csv"))
            using (var csv = new CsvReader(streamReader, csvConfig))
            {
                var records = new List<CameraDto>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    if (csv.GetField<string>("Camera").Contains("ERROR 1207"))
                    {
                        continue;
                    }

                    var record = new CameraDto
                    {
                        Camera = csv.GetField<string>("Camera"),
                        Number = Int32.Parse(Regex.Match(csv.GetField<string>("Camera"), @"\d+").Value),
                        Latitude = csv.GetField<decimal>("Latitude"),
                        Longitude = csv.GetField<decimal>("Longitude")
                    };

                    records.Add(record);
                }

                return records;
            }
        }

        public CameraDataTableDto GetDivideCameraList()
        {
            var cameras = GetCameraData();

            var camerasDivisibleBy3 = cameras.Where(x => x.Number % 3 == 0);
            var camerasDivisibleBy5 = cameras.Where(x => x.Number % 5 == 0);
            var camerasDivisibleBy3And5 = cameras.Where(x => x.Number % 3 == 0 && x.Number % 5 == 0);
            var camerasNotDivisibleBy3And5 = cameras.Where(x => x.Number % 3 != 0 && x.Number % 5 != 0);

            return new CameraDataTableDto()
            {
                CameraListDivisibleBy3 = camerasDivisibleBy3,
                CameraListDivisibleBy5 = camerasDivisibleBy5,
                CameraListDivisibleBy3And5 = camerasDivisibleBy3And5,
                CameraListNotDivisibleBy3And5 = camerasNotDivisibleBy3And5
            };
        }
    }
}
