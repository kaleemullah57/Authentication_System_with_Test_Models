using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Service_Folder;
using Authentication_System_with_Test_Models.Authentication_Folders.JWT_Helper_Folder;
using Authentication_System_with_Test_Models.Authentication_Folders.Repositories;
using Authentication_System_with_Test_Models.Database_Helper_Repository_Folder;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Services;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



// Add Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter the JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});



// Register DbConnection and repositories
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Auth Services 
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<DbHelperRepo>();
builder.Services.AddScoped<JWTHelper>();
builder.Services.AddScoped<AuthService>();





// Resume Services
builder.Services.AddScoped<IPersonalRecordInterface, PersonalRecordRepo>();
builder.Services.AddScoped<IEducationRecordInterface, EducationRecordRepo>();
builder.Services.AddScoped<IExtraEducationRecordInterface, ExtraEducationRecordRepo>();
builder.Services.AddScoped<IExperienceRecordInterface, ExperienceRecordRepo>();
builder.Services.AddScoped<ISkillsRecordInterface, SkillsRecordRepo>();
builder.Services.AddScoped<ILanguageRecordInterface, LanguageRecordRepo>();



// Get All Data Of Related Data To User.
builder.Services.AddScoped<IFinalResumeInterface, FinalResumeRepository>();
builder.Services.AddScoped<FinalResumeRepository>();


builder.Services.AddScoped<FinalResumeService>();














// Add JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"]; // Fetch the key from configuration
if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
{
    throw new Exception("JWT key must be at least 32 characters (256 bits) long.");
}

var key = Encoding.ASCII.GetBytes(jwtKey); // Convert it to bytes


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Matches Jwt:Issuer in appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"], // Matches Jwt:Audience in appsettings.json
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });








// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:4200") // Adjust based on your Angular application origin
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowSpecificOrigin"); // Ensure this matches the policy name

// Apply Authentication and Authorization middleware
app.UseAuthentication();  // Validate the JWT token
app.UseAuthorization();   // Handle role-based or claims-based access

app.MapControllers();

app.Run();
