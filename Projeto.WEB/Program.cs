using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Projeto.WEB;
using Projeto.WEB.Service;
using Projeto.WEB.Service.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrlApi = "https://localhost:7006";
builder.Services.AddHttpClient("ConexaoApi", con =>
{
    con.BaseAddress = new Uri(baseUrlApi);
});

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrlApi) });
builder.Services.AddScoped<ITipoArquivoService, TipoArquivoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IControleCaixaService, ControleCaixaService>();
builder.Services.AddScoped<IArquivoService, ArquivoService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ITipoAquivoLocalStorageService, TipoAquivoLocalStorageService>();

await builder.Build().RunAsync();
