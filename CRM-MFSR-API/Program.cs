using CRM_MFSR_API.MappingProfiles.EntitiesDto;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Implementations;
using Services.Interfaces;
using SQLDB.Context;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Description = "test net core 8, with CRM Backend methods.",
        Title = "CRM-MFSR-API",
        Contact = new OpenApiContact
        {
            Name = "Luis Ronquillo",
            Email = "lronquillo977@gmail.com",
            Url = new Uri("https://github.com/LuisRonquillo97"),
        }
    });
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = JwtBearerDefaults.AuthenticationScheme
       }
      },
      new string[] { }
    }
  });
    var filePath = Path.Combine(AppContext.BaseDirectory, "CRM-MFSR-API.xml");
    c.IncludeXmlComments(filePath);
});

//Add connection
string connection = new ConfigurationBuilder().AddJsonFile(path: Directory.GetCurrentDirectory() + @"\appsettings.json").Build().GetConnectionString("local") ?? "";
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddTransient<IUserService<User>, UserService>();
builder.Services.AddTransient<IRoleService<Role>, RoleService>();

//controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//mappings
builder.Services.AddAutoMapper(typeof(EntitiesDtoProfile));

//JWT Token security.
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization(x=> {
        //x.AddPolicy("UserSee", policy=> policy.RequireClaim("Permission","User.See"));
    })
    .AddAuthentication(x =>
    {
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

var app = builder.Build();
AppContext.SetSwitch("System.Globalization.Invariant", true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
