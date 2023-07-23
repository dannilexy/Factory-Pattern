using FactoryPattern.Sample;

namespace FactoryPattern.Factories;

public static class GenerateClassWithDataFactory
{
    public static void AddGenericClassWithDataFactory(this IServiceCollection services)
    {
        services.AddTransient<IUserData, UserData>();
        services.AddSingleton<Func<IUserData>>(x => () => x.GetService<IUserData>()!);
        services.AddSingleton<IUserDataFactory,UserDataFactory>();
    }
}

public interface IUserDataFactory
{
    IUserData Create(string name);
}

public class UserDataFactory : IUserDataFactory
{
    private readonly Func<IUserData> factory;

    public UserDataFactory(Func<IUserData> factory)
    {
        this.factory = factory;
    }

    public IUserData Create(string name)
    {
        var output = factory();
        output.Name = name;
        return output;
    }
}
