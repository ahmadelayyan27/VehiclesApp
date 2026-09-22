using System.Text.Json;
using VehiclesApp.DTOs;
using VehiclesApp.Entities;

namespace VehiclesApp.VehicleServices;

public class VehicleServices(HttpClient _httpClient): IVehicleServices.IVehicleServices
{
    private static readonly JsonSerializerOptions JsonOptions = new();
    public async Task<List<Make>> GetAllMakesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<Make>>(
            "getallmakes?format=json", JsonOptions);

        return response?.Results ?? new List<Make>();
    }

    public async Task<List<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId)
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<VehicleType>>(
            $"GetVehicleTypesForMakeId/{makeId}?format=json", JsonOptions);
        return response.Results ?? new List<VehicleType>();
    }

    public async Task<List<VehicleModel>> GetModelsForMakeIdAndYearAsync(int makeId, int year)
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<VehicleModel>>(
            $"GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json", JsonOptions);

        return response?.Results ?? new List<VehicleModel>();
    }
}