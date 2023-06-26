using ›dentityServer.Models;
using Microsoft.EntityFrameworkCore;
using ›dentityServer.extenition;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<›dentityServerDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookebuilder = new CookieBuilder();
    cookebuilder.Name = "›dentity‹yelikCookie";
    opt.LoginPath = new PathString("/Home/Sign›n");
    opt.LogoutPath = new PathString("/Member/SignOut");
    opt.Cookie = cookebuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(30);
    opt.SlidingExpiration = true;
});
builder.Services.Add›dentityWithEx();
var app = builder.Build();
//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();


app.Run();
