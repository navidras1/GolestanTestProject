using DataAccess;
using GolestanTestProject.Models;
using Microsoft.EntityFrameworkCore;
//using newtonsoft

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.ConfigGolestanDB(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(WebApiResponse));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataAccess.Models.GolestanTestDbContext>();
    context.Database.Migrate();

    
}


app.Run();
