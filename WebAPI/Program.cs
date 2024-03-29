using Application;
using Microsoft.OpenApi.Models;
using Persistence.Context;
using WebAPI.AppSetting;
using WebAPI.Extensions;
using WebAPI.Middlewares;
using WebAPI.Persistence.ContexInterfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    // Read from your appsettings.json.
    .AddJsonFile("appsettings.json")
    // Read from your secrets.
    //.AddUserSecrets<Program>(optional: true)
    //.AddEnvironmentVariables()
    .Build();

// Add controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    //the following is only needed for swagger to enable basic authenication
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

// added these for this project
builder.Services.AddApplication();

builder.Services.AddSingleton<ILiteDbContext>(provider =>
{
    // Adjust the path to your LiteDB database file.
    return new LiteDbContext("CartDB.db");
});

//this is need for basic authentication
builder.Services.Configure<BasicAuthentication>(configuration.GetSection("BasicAuthentication"));

//this is need for exception handling
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "API v1");
    });
}

//added to handle basic authentication
app.UseBasicAuthMiddleware();

//added to handle exceptions
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();