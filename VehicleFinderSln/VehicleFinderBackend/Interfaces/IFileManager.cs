using VehicleFinderBackend.Models;

namespace VehicleFinderBackend.Interfaces
{
    public interface IFileManager
    {
        List<VehiclePosition> DataFileWorker();
    }
}
