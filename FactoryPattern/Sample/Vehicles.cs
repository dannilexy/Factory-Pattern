namespace FactoryPattern.Sample;

public interface IVehicle
{
    string Start { get; }
    string VehicleType { get; set; }
}

public class Car : IVehicle
{
    public string VehicleType { get; set; } = "Car";
    public string Start => "The car has been started.";
}

public class Truck : IVehicle
{
    public string VehicleType { get; set; } = "Truck";
    public string Start => "The Truck has been started.";
}

public class Van : IVehicle
{
    public string VehicleType { get; set; } = "Van";
    public string Start => "The Van has been started";
}
