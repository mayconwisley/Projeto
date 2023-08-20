using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Projeto.WEB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrlApi = "https://localhost:7006";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrlApi) });

await builder.Build().RunAsync();
