using Microsoft.EntityFrameworkCore;
using StudentManager.Backend.Contexts;
using Microsoft.AspNetCore.Identity;
using StudentManager.WebApp.Controllers;
using StudentManager.WebApp.Models;
using StudentManager.Backend.Indentity;
using StudentManager.WebApp.Areas.Identity.Data;
using StudentManager.WebApp.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ShortenUserController>();
builder.Services.AddDbContext<AppDbContext>(ctx => ctx.UseLazyLoadingProxies());
builder.Services.AddRazorPages();

AddDbLogger(builder.Logging, options =>
{
    builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
});

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<Mozgoeb, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


static ILoggingBuilder AddDbLogger(ILoggingBuilder builder, Action<DbLoggerOptions> configure)
{
    builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
    builder.Services.Configure(configure);
    return builder;
}