using VehicleFinderBackend.Services;
using VehicleFinderBackend.Interfaces;
using System.Text;

namespace VehicleFinderBackend.Models
{
    public class VehiclePosition
    {
        public int ID { get; set; }
        public string Registration { get; set; } = string.Empty;
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime RecordedTimeUTC { get; set; }

        internal static VehiclePosition FromBytes(byte[] buffer, ref int offset)
        {
            VehiclePosition vehiclePosition = new VehiclePosition();
            vehiclePosition.ID = BitConverter.ToInt32(buffer, offset);
            offset += 4;
            StringBuilder stringBuilder = new StringBuilder();
            while (buffer[offset] != (byte)0)
            {
                stringBuilder.Append((char)buffer[offset]);
                ++offset;
            }
            vehiclePosition.Registration = stringBuilder.ToString();
            ++offset;
            vehiclePosition.Latitude = BitConverter.ToSingle(buffer, offset);
            offset += 4;
            vehiclePosition.Longitude = BitConverter.ToSingle(buffer, offset);
            offset += 4;
            ulong uint64 = BitConverter.ToUInt64(buffer, offset);
            vehiclePosition.RecordedTimeUTC = IHelpers.GetDateTimeFormat();
            offset += 8;
            return vehiclePosition;
        }

    }
}
