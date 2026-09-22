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
    
}