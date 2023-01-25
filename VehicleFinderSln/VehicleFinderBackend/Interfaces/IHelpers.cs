namespace VehicleFinderBackend.Interfaces
{
    public interface IHelpers
    {
       
        static DateTime GetDateTimeFormat() {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }
        Double GetDistanceBetween(float firstLatitude, float firstLongitude, float secondLatitude, float secondLongitude);
    }
}
