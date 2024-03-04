
using EcomApp.DataAccessLayer;
using EcomApp.DataAccessLayer.InfraStructure.IRepository;
using EcomApp.DataAccessLayer.InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
builder.Services.AddDbContext<EshopDataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
