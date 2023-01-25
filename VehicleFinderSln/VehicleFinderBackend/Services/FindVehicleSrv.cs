using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.Xml;
using VehicleFinderBackend.Interfaces;
using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Services
{
    public class FindVehicleSrv : IFindVehicle
    {
        private readonly IHelpers _hlp;
        public FindVehicleSrv( IHelpers hlp)
        {
            _hlp = hlp;
        }


        public List<VehiclePosition> findClosestLsofVehicles(List<VehiclePosition> vehiclePositions,List<VehicleCoordinates> coordinates)
        {
            List<VehiclePosition> vehiclePositionList = new List<VehiclePosition>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (VehicleCoordinates coord in coordinates)
                vehiclePositionList.Add(GetNearestVehiclePosition(vehiclePositions, coord.Latitude, coord.Longitude, out double nearestDistance));
            stopwatch.Stop();
            Console.WriteLine(string.Format("Find list of vehicles per coordinates execution time : {0} ms", (object)stopwatch.ElapsedMilliseconds));
            Console.WriteLine();
            return vehiclePositionList;
        }

        public VehiclePosition findClosestVehicle(List<VehiclePosition> vehiclePositions, float latitude, float longitude)
        {
           
            Stopwatch stopwatch = Stopwatch.StartNew();
            double nearestDistance;
            VehiclePosition nearestVehicle = GetNearestVehiclePosition(vehiclePositions, latitude, longitude, out nearestDistance);
            stopwatch.Stop();
            Console.WriteLine(string.Format("Find closest vehicle by coordinate execution time : {0} ms", (object)stopwatch.ElapsedMilliseconds));
            return nearestVehicle;
        }

        public VehiclePosition GetNearestVehiclePosition(List<VehiclePosition> vehiclePositions, float latitude, float longitude, out double nearestDistance)
        {
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            VehiclePosition nearestVehicle = (VehiclePosition)null;
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            nearestDistance = double.MaxValue;
            foreach (VehiclePosition vehiclePosition in vehiclePositions)
            {
                double num = _hlp.GetDistanceBetween(latitude, longitude, vehiclePosition.Latitude, vehiclePosition.Longitude);
                if(num < nearestDistance)
                {
                    nearestVehicle = vehiclePosition;
                    nearestDistance = num;
                }

            }

            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            nearestVehicle.RecordedTimeUTC = DateTime.Now;
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
            #pragma warning disable CS8603 // Possible null reference return.
            return nearestVehicle;
            #pragma warning restore CS8603 // Possible null reference return.

        }
    }
}
