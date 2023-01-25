using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Interfaces
{
    public interface IVehicleFinder
    {
        VehiclePosition GetVehiclePositionByCoordinates(VehicleCoordinates vehicleCoordinates);
        List<VehiclePosition> GetVehiclePositionsByLsofCoordinates(List<VehicleCoordinates> vehicleCoordinates);
    }
}
