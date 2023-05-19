using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Oncogenes.App;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddHttpClient("Oncogenes.Api", client => client.BaseAddress = new Uri("https://localhost:5223/"));

//builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
//builder.UseWebAssemblyDebugging();


await builder.Build().RunAsync();
