using System.Diagnostics;
using Rotativa.AspNetCore;
using StudentExportApp.Repositories;
using StudentExportApp.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddControllersWithViews();

// Setup Rotativa (taruh wkhtmltopdf.exe di wwwroot/Rotativa)
RotativaConfiguration.Setup(builder.Environment.WebRootPath, "Rotativa");

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();