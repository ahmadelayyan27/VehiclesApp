using VehiclesApp.Entities;

namespace VehiclesApp.VehicleServices.IVehicleServices;

public interface IVehicleServices
{
    Task<List<Make>> GetAllMakesAsync();
    Task<List<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId);
    Task<List<VehicleModel>> GetModelsForMakeIdAndYearAsync(int makeId, int year);
}