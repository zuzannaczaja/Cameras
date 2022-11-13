using AutoMapper;
using Cameras.API.Controllers.Models;
using Cameras.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cameras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamerasController : ControllerBase
    {
        private readonly ICameraDataService _cameraDataService;
        private readonly IMapper _mapper;
        private readonly ILogger<CamerasController> _logger;

        public CamerasController(ICameraDataService cameraDataService,
            IMapper mapper,
            ILogger<CamerasController> logger)
        {
            _cameraDataService = cameraDataService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var cameras = _cameraDataService.GetDivideCameraList();

                return Ok(_mapper.Map<CameraDataTableModel>(cameras));
            }
            catch (Exception e)
            {
                _logger.LogError("Message:" + e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}