using VehicleFinderBackend.Interfaces;
using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Services
{
    public class VehicleFinderSrv : IVehicleFinder
    {

        private readonly IFileManager _fman;
        private readonly IFindVehicle _fvan;

        public VehicleFinderSrv(IFileManager fman, IFindVehicle fvan) {

            _fman = fman;
            _fvan = fvan;
        }


        public VehiclePosition GetVehiclePositionByCoordinates(VehicleCoordinates vehicleCoordinates)
        {
            List<VehiclePosition> vehiclePositionList = new List<VehiclePosition>();
            vehiclePositionList =  _fman.DataFileWorker();
            return _fvan.findClosestVehicle(vehiclePositionList, vehicleCoordinates.Latitude, vehicleCoordinates.Longitude);
            
        }

        public List<VehiclePosition> GetVehiclePositionsByLsofCoordinates(List<VehicleCoordinates> vehicleCoordinates)
        {
            List<VehiclePosition> vehiclePositionList = new List<VehiclePosition>();
            vehiclePositionList = _fman.DataFileWorker();
            return _fvan.findClosestLsofVehicles(vehiclePositionList, vehicleCoordinates);
        }

     }
}
