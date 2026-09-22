using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiclesApp.Entities;
using VehiclesApp.VehicleServices.IVehicleServices;

namespace VehiclesApp.Pages;

public class IndexModel : PageModel
{
    private readonly IVehicleServices _vehicleServices;
    private readonly ILogger<IndexModel> _logger;

    public List<Make> Makes { get; set; } = new();
    public IndexModel(ILogger<IndexModel> logger, IVehicleServices vehicleServices)
    {
        _vehicleServices=vehicleServices;
        _logger = logger;
    }
    public async Task OnGetAsync()
    {
        Makes = await _vehicleServices.GetAllMakesAsync();
    }
    public async Task<JsonResult> OnGetVehicleTypesForMakeIdAsync(int makeId)
    {
        var types = await _vehicleServices.GetVehicleTypesForMakeIdAsync(makeId);
        return new JsonResult(types);
    }
    public async Task<JsonResult> OnGetModelsForMakeIdAndYearAsync(int makeId, int year)
    {
        var models = await _vehicleServices.GetModelsForMakeIdAndYearAsync(makeId, year);
        return new JsonResult(models);
    }
}