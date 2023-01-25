using Microsoft.AspNetCore.Mvc;
using VehicleFinderBackend.Interfaces;
using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleFinderController : ControllerBase
    {
        private readonly ILogger<VehicleFinderController> _logger;
        private readonly IVehicleFinder _vserve;
        

        public VehicleFinderController(ILogger<VehicleFinderController> logger, IVehicleFinder vserve)
        {
            _logger = logger;
            _vserve = vserve;
            
        }
        
        [Route("GetVehiclePositionByCoordinates")]
        [HttpPost]
        public VehiclePosition GetVehiclePositionByCoordinates(VehicleCoordinates vehicleCoordinates)
        {
           return _vserve.GetVehiclePositionByCoordinates(vehicleCoordinates);
        }
        
        
        [Route("GetVehiclePositionsByLsofCoordinates")]
        [HttpPost]
        public List<VehiclePosition> GetVehiclePositionsByLsofCoordinates(List<VehicleCoordinates> vehicleCoordinates)
        {
            return _vserve.GetVehiclePositionsByLsofCoordinates(vehicleCoordinates);
        }
   
    }
}
