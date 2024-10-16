using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Controller support
builder.Services.AddControllers();

// Add HttpClient support for making external API calls
builder.Services.AddHttpClient();

// JWT Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidateIssuer = false, // You can set this to true and define an issuer if needed
            ValidateAudience = false, // You can set this to true and define an audience if needed
            ValidateLifetime = true, // Token expiration validation
            ClockSkew = TimeSpan.Zero // Disable clock skew for token expiration
        };
    });

// Register your custom services
builder.Services.AddScoped<IFrontEndService, FrontEndService>();
builder.Services.AddScoped<IAPI2Service, API2Service>();
builder.Services.AddScoped<IAPI3Service, API3Service>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Enable in-memory cache (if you're using in-memory storage)
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline (middleware)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Detailed error pages for development environment
}

// Enable Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// Enable routing and map controllers
app.MapControllers();

app.Run();
