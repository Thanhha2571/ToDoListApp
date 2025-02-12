using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Blazored.LocalStorage;
using TodoListApp.Client.service;

namespace TodoListApp.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddScoped<ToDoItemDataService>();
        builder.Services.AddScoped<PersonDataService>();

        builder.Services.AddRadzenComponents();
        builder.Services.AddBlazoredLocalStorage();
        await builder.Build().RunAsync();
    }
}
