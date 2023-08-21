using System.Diagnostics.Eventing.Reader;
using System.IO;
using BpTool.DataLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor;
using MudBlazor.Services;

namespace BpTool;

public static class Startup
{
    public static IServiceProvider? Services { get; private set; }

    public static void Init()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(WireupServices)
            .Build();
        Services = host.Services;

        if (!File.Exists(FilePath.GetDataFilePath()))
        {
            File.Create(FilePath.GetDataFilePath());
        }
    }

    private static void WireupServices(IServiceCollection services)
    {
        services.AddWpfBlazorWebView();
        services.AddMudServices();
        services.AddSingleton<BloodPressureRecordRepository>();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif
        
    }
}