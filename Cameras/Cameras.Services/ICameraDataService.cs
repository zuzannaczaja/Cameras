using Cameras.Services.Models;

namespace Cameras.Services
{
    public interface ICameraDataService
    {
        IEnumerable<CameraDto> GetCameraData();

        CameraDataTableDto GetDivideCameraList();
    }
}
