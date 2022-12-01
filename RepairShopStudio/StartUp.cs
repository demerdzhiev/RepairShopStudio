using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Extensions;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Models.User;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;

})
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
});

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RegistartionUserPolicy", policy =>
    {
        policy.RequireRole("Manager");
    });
});

var app = builder.Build();

app.SeedRolesInDatabase();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

});

app.MapRazorPages();

app.Run();
