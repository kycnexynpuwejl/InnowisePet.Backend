using InnowisePet.Identity.Data;
using InnowisePet.Identity.Extensions;
using InnowisePet.Identity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlite(connString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsPolicyBuilder =>
        corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();