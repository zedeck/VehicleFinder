using VehicleFinderBackend.Interfaces;
using GeoCoordinatePortable;

namespace VehicleFinderBackend.Services
{
    public class HelperSrv : IHelpers
    {

        public double GetDistanceBetween(float firstLatitude, float firstLongitude, float secondLatitude, float secondLongitude)
        {
            var sCoord = new GeoCoordinate(firstLatitude, firstLongitude);
            var eCoord = new GeoCoordinate(secondLatitude, secondLongitude);
            return sCoord.GetDistanceTo(eCoord);
        }
            
    }
}
