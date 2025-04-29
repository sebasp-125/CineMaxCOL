using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.Repository.Implimentation;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_DAL.UnitOfWork.Implementation;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// This is register the UnitOfWork
// builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//This is register  Application Services
builder.Services.AddScoped<DiferentsServices>();
builder.Services.AddScoped<AuthService>();


builder.Services.AddDbContext<CineMaxColContext>(opc =>
{
    opc.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

    //CLAIMS
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/CredentialUser/Index";
        options.LogoutPath = "/CredentialUser/LogOut";
        options.AccessDeniedPath = "/Home/Privacy";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
        options.SlidingExpiration = true;
    });

    //COOKIES - SESIONS
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
