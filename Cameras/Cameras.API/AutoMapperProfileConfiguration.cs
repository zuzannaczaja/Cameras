using AutoMapper;
using Cameras.API.Controllers.Models;
using Cameras.Services.Models;

namespace Camera.API
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName)
            : base(profileName)
        {
            CreateMap<CameraDto, CameraModel>();

            CreateMap<CameraDataTableDto, CameraDataTableModel>();
        }
    }
}
