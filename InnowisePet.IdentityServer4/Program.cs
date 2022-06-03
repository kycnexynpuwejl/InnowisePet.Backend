using InnowisePet.IdentityServer4.Data;
using InnowisePet.IdentityServer4.Extensions;
using InnowisePet.IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlite(connString));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.AddControllers();


var app = builder.Build();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();

