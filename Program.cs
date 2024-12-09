using DocPatient.Context;
using DocPatient.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var con = builder.Configuration.GetConnectionString("DefaultConnectionString");

if (con != null)
{
    builder.Services.AddDbContext<EFDbContext>(options => options.UseMySql(
        con,
        serverVersion: ServerVersion.AutoDetect(con)));
}
builder.Services
    .AddScoped<IDocService, DocService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
