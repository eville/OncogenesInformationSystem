using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Oncogenes.App;
using Oncogenes.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient("Oncogenes.Api", client => client.BaseAddress = new Uri("https://localhost:5223/"));

//builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
//builder.UseWebAssemblyDebugging();

builder.Services.AddHttpClient<IOncogenesDataService, OncogenesDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<IDiseasesDataService, DiseasesDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    //options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});


await builder.Build().RunAsync();
