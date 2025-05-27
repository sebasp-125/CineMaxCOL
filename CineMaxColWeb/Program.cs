using CineMaxColBLL.Services;
using CineMaxColDal.DBContext;
using CineMaxColDal.Implementación;
using CineMaxColDal.Interfaces;
using CineMaxColIOC;
using CineMaxColWeb.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.InyectarDependencias(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPeliculas, Peliculas>();
builder.Services.AddScoped<ICineComidas, CineComidas>();
builder.Services.AddScoped<IComidas, Comidas>();
builder.Services.AddScoped<ICloudinaryR, CloudinaryR>();
builder.Services.AddScoped<IMunicipios, Municipios>();
builder.Services.AddScoped<IPromociones, Promociones>();
builder.Services.AddScoped<PeliculasService>();
builder.Services.AddScoped<CineComidaService>();
builder.Services.AddScoped<MunicipioService>();
builder.Services.AddScoped<CloudinaryService>();

builder.Services.AddDbContext<CineMaxColContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
