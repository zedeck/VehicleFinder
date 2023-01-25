using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Interfaces
{
    public interface IFindVehicle
    {
        List<VehiclePosition> findClosestLsofVehicles(List<VehiclePosition> vehiclePositionList, List<VehicleCoordinates> coordinates);        
        VehiclePosition findClosestVehicle(List<VehiclePosition> vehiclePositions, float latitude, float longitude);
        VehiclePosition GetNearestVehiclePosition(List<VehiclePosition> vehiclePositions, float latitude, float longitude, out double nearestDistance);
       
    }
}
