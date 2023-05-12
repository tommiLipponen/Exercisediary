using Exercisediary.Client;
using Exercisediary.Client.ClientDataInterfaces.ClientExerciseDataInterfaces;
using Exercisediary.Client.ClientDataInterfaces.ClientExerciseTypeDataInterfaces;
using Exercisediary.Client.ClientDataInterfaces.ClientLocationDataInterfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClientExerciseData, ClientExerciseData>();
builder.Services.AddScoped<IClientExerciseTypeData, ClientExerciseTypeData>();
builder.Services.AddScoped<IClientLocationData, ClientLocationData>();

await builder.Build().RunAsync();
