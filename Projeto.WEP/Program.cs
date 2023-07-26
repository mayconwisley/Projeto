using Projeto.WEP.Services;
using Projeto.WEP.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var urlBuilder = builder.Configuration["ServicoUrl:DadosConexaoApi"];

if (urlBuilder != null)
{
    builder.Services.AddHttpClient("DadosConexaoApi", con =>
    {
        con.BaseAddress = new Uri(urlBuilder);
    });
}

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ISessaoService, SessaoService>();

builder.Services.AddSession(s =>
{
    s.Cookie.HttpOnly = true;
    s.Cookie.IsEssential = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
