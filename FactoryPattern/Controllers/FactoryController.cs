using FactoryPattern.Factories;
using FactoryPattern.Sample;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPattern.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FactoryController : ControllerBase
{
    private readonly IAbstractFactory<ISample1> _factory;
    private readonly IAbstractFactory<ISample2> _factory2;
    private readonly IUserDataFactory _userDataFactory;
    private readonly IVehicleFactory _vehicleFactory;
    public FactoryController(IAbstractFactory<ISample1> _factory, IAbstractFactory<ISample2> _factory2,
        IUserDataFactory userDataFactory, IVehicleFactory _vehicleFactory)
    {
        this._factory = _factory;
        this._factory2 = _factory2;
        _userDataFactory = userDataFactory;
        this._vehicleFactory = _vehicleFactory;

    }

    [HttpGet("GetCurrentDate")]
    public async Task<IActionResult> GetCurrentDate()
    {
        var sampleTime = _factory.Create().CurrentDateTime;
        var randomValue = _factory2.Create().RandomValue;
        var userData = _userDataFactory.Create("El Dorado");
        var vehicle = _vehicleFactory.Create("Car");
        return Ok(new {name = userData.Name, currentDateTime = sampleTime, RandomValue = randomValue, started = vehicle.Start });
    }
}
