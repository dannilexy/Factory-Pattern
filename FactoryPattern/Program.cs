
using FactoryPattern.Factories;
using FactoryPattern.Sample;

namespace FactoryPattern;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddTransient<ISample1, Sample1>();
        //builder.Services.AddSingleton<Func<ISample1>>(x => () => x.GetService<ISample1>()!);
        builder.Services.AddAbstractFactory<ISample1, Sample1>();
        builder.Services.AddAbstractFactory<ISample2, Sample2>();

        builder.Services.AddGenericClassWithDataFactory();
        builder.Services.AddVehicleFactory();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}