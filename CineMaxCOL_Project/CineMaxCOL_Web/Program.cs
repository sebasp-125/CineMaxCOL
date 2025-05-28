using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.Repository.Implimentation;
using CineMaxCOL_DAL.UnitOfWork.Implementation;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using CineMaxCol_DAL.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// This is register the UnitOfWork
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

//This is register  Application Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<SendEmails>();
builder.Services.AddScoped<DetailsMovieService>();
builder.Services.AddScoped<SelectingPositionsServices>();
builder.Services.AddScoped<PaymentBuyTickets>();
builder.Services.AddScoped<MarketTemporalService>();

//mio
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

builder.Services.AddDbContext<CineMaxColContext>(opc =>
{
    opc.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//AutoMapperProfile
builder.Services.AddAutoMapper(typeof(ContractProfile));

//CLAIMS
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/LogIn";
        options.LogoutPath = "/Home/Index";
        options.AccessDeniedPath = "/Account/LogIn";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
        options.SlidingExpiration = true;
    });

// COOKIES - SESIONS
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Este permite acceder al HttpContext desde cualquier servicio
builder.Services.AddHttpContextAccessor();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseSession();
app.UseHttpsRedirection(); 
app.UseAuthentication();  

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
