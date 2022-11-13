namespace Cameras.Services.Models
{
    public class CameraDataTableDto
    {
        public IEnumerable<CameraDto> CameraListDivisibleBy3 { get; set; }

        public IEnumerable<CameraDto> CameraListDivisibleBy5 { get; set; }

        public IEnumerable<CameraDto> CameraListDivisibleBy3And5 { get; set; }

        public IEnumerable<CameraDto> CameraListNotDivisibleBy3And5 { get; set; }
    }
}
