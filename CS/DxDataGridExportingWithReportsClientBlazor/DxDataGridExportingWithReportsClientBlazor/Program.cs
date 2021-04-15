using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DxDataGridExportingWithReportsClientBlazor
{
    public class Program
    {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddDevExpressBlazor();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.RootComponents.Add<App>("#app");
            var host = builder.Build();
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            await host.RunAsync();
        }
    }
}
