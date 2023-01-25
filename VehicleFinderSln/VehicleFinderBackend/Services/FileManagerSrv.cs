using Microsoft.AspNetCore.Mvc;
using VehicleFinderBackend.Interfaces;
using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Services
{
    public class FileManagerSrv : IFileManager
    {
        private readonly IConfiguration _configuration;
        public FileManagerSrv(IConfiguration configuration) {

            _configuration = configuration;
        }


        public List<VehiclePosition> DataFileWorker()
        {

            byte[] datax;

            var _file = _configuration.GetValue<string>("FileName");
            try
            {
                datax = File.ReadAllBytes(_file);
                List<VehiclePosition> vehiclePositionList = new List<VehiclePosition>();
                int offset = 0;
                while (offset < datax.Length)
                {
                    vehiclePositionList.Add(ReadVehiclePosition(datax, ref offset));
                }
                return vehiclePositionList;
            }
            catch (FileNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
            }
      

        }

        private static VehiclePosition ReadVehiclePosition(byte[] data, ref int offset) => VehiclePosition.FromBytes(data, ref offset);

    }
}
