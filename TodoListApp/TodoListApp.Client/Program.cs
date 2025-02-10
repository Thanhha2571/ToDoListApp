using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
namespace TodoListApp.Client;
using Blazored.LocalStorage;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        // builder.Services.AddScoped<ToDoItemDataService>();
        builder.Services.AddRadzenComponents();
        builder.Services.AddBlazoredLocalStorage();
        await builder.Build().RunAsync();
    }
}
