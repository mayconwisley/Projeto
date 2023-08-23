using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Projeto.WEB;
using Projeto.WEB.Service;
using Projeto.WEB.Service.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrlApi = "https://localhost:7006";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrlApi) });
builder.Services.AddScoped<ITipoArquivoServices, TipoArquivoServices>();

await builder.Build().RunAsync();
