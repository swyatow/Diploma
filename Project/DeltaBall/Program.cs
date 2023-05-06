using DeltaBall.Data;
using DeltaBall.Data.Repositories;
using DeltaBall.Data.Repositories.Interfaces;
using DeltaBall.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Add transient for DataManager
builder.Services.AddTransient<IClientRepo, ClientRepo>();
builder.Services.AddTransient<IGameScenarioRepo, GameScenarioRepo>();
builder.Services.AddTransient<IGameStatusRepo, GameStatusRepo>();
builder.Services.AddTransient<IGameTypeRepo, GameTypeRepo>();
builder.Services.AddTransient<IPlayerRepo, PlayerRepo>();
builder.Services.AddTransient<IPriceRepo, PriceRepo>();
builder.Services.AddTransient<IRankRepo, RankRepo>();
builder.Services.AddTransient<IScheduleGameRepo, ScheduleGameRepo>();
builder.Services.AddTransient<IShootRangeRepo, ShootRangeRepo>();
builder.Services.AddTransient<IUserExpChangeRepo, UserExpChangeRepo>();
builder.Services.AddTransient<IUserExpChangeModeRepo, UserExpChangeModeRepo>();
builder.Services.AddTransient<DataManager>();
#endregion

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "Identity/Account/Login";
        options.AccessDeniedPath = "Identity/Account/AccessDenied";
    });
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminAreaPolicy", policy => { policy.RequireRole("Admin"); });
    x.AddPolicy("PlayerAreaPolicy", policy => { policy.RequireRole("Client"); });
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.User.AllowedUserNameCharacters = "àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß -";
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<AppDbContext>()
   .AddDefaultTokenProviders()
   .AddDefaultUI();
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new ControllerModelConvention("Admin", "AdminAreaPolicy"));
    x.Conventions.Add(new ControllerModelConvention("Player", "PlayerAreaPolicy"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "client",
    pattern: "{area:exists}/{controller=Home}/{action=Profile}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
