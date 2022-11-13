using Cameras.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private readonly ISearchCameraService _searchCameraService;

    public Program(ISearchCameraService searchCameraService)
    {
        _searchCameraService = searchCameraService;
    }

    private static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Services.GetRequiredService<Program>().Run();
    }

    public void Run()
    {
        Console.WriteLine("Search camera:");
        var search = Console.ReadLine();
        _searchCameraService.SearchCameras(search);
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<Program>();
                services.AddScoped<ISearchCameraService, SearchCameraService>();
                services.AddScoped<ICameraDataService, CameraDataService>();
            });
    }
}