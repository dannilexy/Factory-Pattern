using FactoryPattern.Sample;

namespace FactoryPattern.Factories;

public static class DifferentImplementationFactoryExtension
{
    public static void AddVehicleFactory(this IServiceCollection services)
    {
        services.AddTransient<IVehicle, Car>();
        services.AddTransient<IVehicle, Truck>();
        services.AddTransient<IVehicle, Van>();
        services.AddSingleton<Func<IEnumerable<IVehicle>>>(x=>()=>x.GetService<IEnumerable<IVehicle>>()!);
        services.AddSingleton<IVehicleFactory, VehicleFactory>();
    }
}

public interface IVehicleFactory
{
    IVehicle Create(string name);
}

public class VehicleFactory : IVehicleFactory
{
    private readonly Func<IEnumerable<IVehicle>> factory;

    public VehicleFactory(Func<IEnumerable<IVehicle>> factory)
    {
        this.factory = factory;
    }

    public IVehicle Create(string name)
    {
        var set = factory();
        IVehicle vehicle = set.FirstOrDefault(s => s.VehicleType == name);
        return vehicle;
    }
}
