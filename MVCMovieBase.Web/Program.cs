using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCMovieBase.AuthDb;
using MVCMovieBase.Infrasctructure;
using MVCMovieBase.Services.Interfaces;
using MVCMovieBase.Services.Services;

var builder = WebApplication.CreateBuilder(args);

var movieDbConnectionString = builder.Configuration.GetConnectionString("MovieDb") ?? throw new InvalidOperationException("Connection string 'MovieDb' not found.");
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(movieDbConnectionString));

var authDbConnectionString = builder.Configuration.GetConnectionString("AuthDb") ?? throw new InvalidOperationException("Connection string 'AuthDb' not found.");
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(authDbConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddTransient<AuthDataSeed>();

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var movieDbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
    var authDbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

    authDbContext.Database.Migrate();
    movieDbContext.Database.Migrate();

    var authDataSeed = scope.ServiceProvider.GetRequiredService<AuthDataSeed>();
    await authDataSeed.SeedAdminUser();
}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
