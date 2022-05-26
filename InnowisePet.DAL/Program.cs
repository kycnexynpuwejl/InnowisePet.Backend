using System.Data;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();