using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


// internal class Program
// {
//     private static void Main(string[] args)
//     {
        var builder = WebApplication.CreateBuilder(args);

        // Userdetail userRepository = new Userdetail();

        // // Example: Get user details by user ID
        // string name= "swe";
        // User user = userRepository.GetUserDetails(name);

        // if (user != null)
        // {
        //     Console.WriteLine($"User Name: {user.UserName}");
        //     Console.WriteLine($"Password: {user.Password}");
        //     Console.WriteLine($"Email: {user.Email}");
        //     // Display other user details as needed
        // }
        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });
        builder.Services.AddAuthorization();
        // Add configuration from appsettings.json
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseAuthentication();
        app.UseAuthorization();
        IConfiguration configuration = app.Configuration;
        IWebHostEnvironment environment = app.Environment;
        app.MapControllers();
        app.Run();
//     }
// }