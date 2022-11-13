namespace Cameras.API.Controllers.Models
{
    public class CameraDataTableModel
    {
        public IEnumerable<CameraModel> CameraListDivisibleBy3 { get; set; }

        public IEnumerable<CameraModel> CameraListDivisibleBy5 { get; set; }

        public IEnumerable<CameraModel> CameraListDivisibleBy3And5 { get; set; }

        public IEnumerable<CameraModel> CameraListNotDivisibleBy3And5 { get; set; }
    }
}
