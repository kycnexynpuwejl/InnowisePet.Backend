using InnowisePet.HttpClients;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>  
{  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });  
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme  
    {  
        Name = "Authorization",  
        Type = SecuritySchemeType.Http,  
        Scheme = "basic",  
        In = ParameterLocation.Header,  
        Description = "Basic Authorization header using the Bearer scheme."  
    });  
    c.AddSecurityRequirement(new OpenApiSecurityRequirement  
    {  
        {  
            new OpenApiSecurityScheme  
            {  
                Reference = new OpenApiReference  
                {  
                    Type = ReferenceType.SecurityScheme,  
                    Id = "basic"  
                }  
            },  
            new string[] {}  
        }  
    });  
});  


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddMassTransit(x => x.UsingRabbitMq());

builder.Services.AddHttpClient<OrderClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["OrderServiceUri"]);
});

builder.Services.AddHttpClient<ProductClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ProductServiceUri"]);
});

builder.Services.AddHttpClient<StorageClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["StorageServiceUri"]);
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7000/";
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
    endpoints.MapControllers().RequireAuthorization("ApiScope");
});


app.Run();