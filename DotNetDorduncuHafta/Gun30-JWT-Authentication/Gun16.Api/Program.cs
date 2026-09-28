using Gun16.Application;
using Gun16.Infrastructure;
using Gun16.Api.ExceptionHandlers;
using System.Security.Claims;
using System.Text;
using Gun16.Api.Authentication;
using Gun16.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// API servisleri
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

// Application katmanındaki service kayıtları
builder.Services.AddApplicationServices();

// Infrastructure katmanındaki DbContext ve repository kayıtları
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(JwtOptions.SectionName)
);

builder.Services.AddScoped<ITokenService, JwtTokenService>();

JwtOptions jwtOptions =
    builder.Configuration
        .GetSection(JwtOptions.SectionName)
        .Get<JwtOptions>()
    ?? throw new InvalidOperationException("JWT ayarları bulunamadı.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Key)
            ),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,

            NameClaimType = ClaimTypes.Name
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Uygulamadaki yakalanmamış hataları ProblemDetails formatında döndürür.
app.UseExceptionHandler();

// OpenAPI endpoint'ini yalnızca Development ortamında açar.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();