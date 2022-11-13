namespace Cameras.Services
{
    public class SearchCameraService : ISearchCameraService
    {
        private readonly ICameraDataService _cameraDataService;

        public SearchCameraService(ICameraDataService cameraDataService)
        {
            _cameraDataService = cameraDataService;
        }

        public void SearchCameras(string search)
        {
            var allCameras = _cameraDataService.GetCameraData();

            var searchCameras = allCameras.Where(c => c.Camera.ToLower().Contains(search.ToLower()));

            if (searchCameras.Any())
            {
                foreach (var camera in searchCameras)
                {
                    Console.WriteLine(camera);
                }
            }
            else
            {
                Console.WriteLine("There are no such cameras");
            }
        }
    }
}
