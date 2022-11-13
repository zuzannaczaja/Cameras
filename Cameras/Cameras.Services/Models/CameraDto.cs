using System.Text.RegularExpressions;

namespace Cameras.Services.Models
{
    public class CameraDto
    {
        public string Camera { get; set; }

        public int Number { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return @$"{Number} | {Camera} | {Latitude} | {Longitude}";
        }
    }
}
