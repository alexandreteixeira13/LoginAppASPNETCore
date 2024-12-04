using appLoginASPCORE.Libraries.Login;
using appLoginASPCORE.Repository;
using appLoginASPCORE.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add session manipulation

builder.Services.AddHttpContextAccessor();

// add interface as a service

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();

builder.Services.AddScoped<appLoginASPCORE.Libraries.Sessao.Sessao>();
builder.Services.AddScoped<LoginCliente>();

builder.Services.AddHttpContextAccessor();

// fix problems with TEMPDATA

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //set a time for the function

    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;

    //show to the browser that the cookie is essential

    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddSessionStateTempDataProvider(); 



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseCookiePolicy();
app.UseSession();





app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
