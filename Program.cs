using IALClient.config;
using IALClient.Entity;
using IALClient.Infra.Data;
using IALClient.Service;
using IALClient.Service.CustomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using IALClient.Infra.ExternalApi;
using IALClient.Repository;

var builder = WebApplication.CreateBuilder(args);

// 202407041638 - Isak => Adding Env Vars for Docker Deployments, if you are using Docker to locally debug, set up a launch profile for yourself
//      with the correct connection string and tinydog urls settings.  Non docker debugging will use the appsettings.json file.
builder.Configuration.AddEnvironmentVariables(prefix: "ASPNETCORE_");
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("GmailSettings"));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(buider => buider.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});


// DB
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddHttpClient();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 3;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"]!))
    };
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Bearer Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
         {
             new OpenApiSecurityScheme
             {
                  Reference = new OpenApiReference
                  {
                      Id = "Bearer",
                       Type = ReferenceType.SecurityScheme
                  }
             }, new List<string>()
         }
     });

});

// UserVehicle Injects

builder.Services.AddScoped<UserVehicleService>();
builder.Services.AddScoped<UserVehicleRepository>();

// UserVehicleStatus Injects

builder.Services.AddScoped<UserVehicleStatusService>();
builder.Services.AddScoped<UserVehicleStatusRepository>();

// User Injects

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();

// Config Injects

builder.Services.AddScoped<ConfigService>();

// Authenticate Injects

builder.Services.AddScoped<AuthenticateService>();
builder.Services.AddScoped<TokenService>();

// PermissionLevel Injects

builder.Services.AddScoped<PermissionLevelService>();
builder.Services.AddScoped<PermissionLevelRepository>();

// Send-Email Inject

builder.Services.AddScoped<SendEmailService>();
builder.Services.AddScoped<UploadFileService>();

// Change-Password Inject

// External API

builder.Services.AddScoped<TinyDogService>();

builder.Services.AddScoped<ChangePasswordService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext http) => {

    var error = http.Features.Get<IExceptionHandlerFeature>()?.Error;

    if (error != null)
    {

        var message = error.Message;

        if (error is ResourceNotFoundException)
            return Results.Problem(title: message, statusCode: 404);
        else if (error is BadHttpRequestException)
            return Results.Problem(title: message, statusCode: 400);
        else if (error is InvalidChangePasswordCodeException)
            return Results.Problem(title: message, statusCode: 400);
        else if (error is InvalidTypeException)
            return Results.Problem(title: message, statusCode: 400);
        else if (error is PasswordIncorrectException)
            return Results.Problem(title: message, statusCode: 400);
        else if (error is CreateUserException)
            return Results.Problem(title: message, statusCode: 400);
        else if (error is SendEmailException)
            return Results.Problem(title: message, statusCode: 500);
        else if (error is UnauthorizedAccessException)
            return Results.Problem(title: message, statusCode: 403);
        else if (error is Exception)
            return Results.Problem(title: message, statusCode: 500);
    }

    return Results.Problem(title: "Error!", statusCode: 500);
});



app.Run();

