using InnowisePet.Services.Storage.API.Extensions;
using InnowisePet.Services.Storage.BLL.Services;
using InnowisePet.Services.Storage.DAL.Data;
using InnowisePet.Services.Storage.DAL.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureMassTransit();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddScoped<IStorageService, StorageService>();

builder.Services.AddDbContext<StorageDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("StorageDBConnection"),
        b => b.MigrationsAssembly("InnowisePet.Services.Storage.API")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();