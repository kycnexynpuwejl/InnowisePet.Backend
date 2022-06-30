using System.Data;
using System.Reflection;
using InnowisePet.Common.API.Extensions;
using MassTransit;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var s = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.ManifestModule.Name.Contains("Innowise"));

builder.Services.ConfigureServices();
builder.Services.AddAutoMapper(Assembly.Load("InnowisePet.Profiles"));
builder.Services.AddControllers();

builder.Services.AddMassTransit(x => x.UsingRabbitMq());

builder.Services.AddHttpClient<OrderClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["OrderServiceUri"]);
});

/*builder.Services.AddHttpClient<ProductClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ProductServiceUri"]);
});*/

builder.Services.AddTransient<IDbConnection>(_ =>
    new SqlConnection(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7000";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "APIScope");
    });
});

WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    //.RequireAuthorization("ApiScope");
});


app.Run();