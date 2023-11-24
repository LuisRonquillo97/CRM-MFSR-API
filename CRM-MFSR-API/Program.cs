using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Implementations;
using Services.Interfaces;
using SQLDB.Context;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Description = "test net core 8, with CRM Backend methods.",
        Title = "CRM-MFSR-API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Luis Ronquillo",
            Email = "lronquillo977@gmail.com",
            Url = new Uri("https://github.com/LuisRonquillo97"),
        }
    }
     );

    var filePath = Path.Combine(AppContext.BaseDirectory, "CRM-MFSR-API.xml");
    c.IncludeXmlComments(filePath);
});
//Add connection
string connection = new ConfigurationBuilder().AddJsonFile(path: Directory.GetCurrentDirectory() + @"\appsettings.json").Build().GetConnectionString("local") ?? "";
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
// Add services to the container.
builder.Services.AddTransient<IUserService<User>, UserService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}
        );
var app = builder.Build();
AppContext.SetSwitch("System.Globalization.Invariant", true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
