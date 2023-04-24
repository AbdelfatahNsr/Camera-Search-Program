using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    public class CamerasController : Controller
    {
        [HttpGet("api/cameras/search")]
        public ActionResult<IEnumerable<CameraModel>> Get([FromQuery] string searchTerm)
        {
            var cameras = new List<CameraModel>();

            var cameraCsvDataReader = new CameraCsvDataReader.CameraCsvDataReader();
            var readResults = cameraCsvDataReader.ReadCsv(searchTerm);

            foreach (var items in readResults)
            {
                cameras.Add(new CameraModel
                {
                    Number = items.Number, 
                    Name = items.Name,
                    Latitude = items.Latitude,
                    Longitude = items.Longitude
                });
              
            }

            return Ok(cameras);
        }

        [HttpGet("api/cameras")]
        public ActionResult<IEnumerable<CameraModel>> GetAllCameras()
        {
            var cameras = new List<CameraModel>();

            var cameraCsvDataReader = new CameraCsvDataReader.CameraCsvDataReader();
            var readResults = cameraCsvDataReader.ReadCsv();

            foreach (var items in readResults)
            {
                cameras.Add(new CameraModel
                {
                    Number = items.Number,
                    Name = items.Name,
                    Latitude = items.Latitude,
                    Longitude = items.Longitude
                });

            }

            return Ok(cameras);
        }
    }

}
