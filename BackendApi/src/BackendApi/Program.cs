using BackendApi.Authorization;
using BackendApi.Helpers;
using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BackendApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<SpellLearningContext>(
                    options => options.UseNpgsql(
                        builder.Configuration["ConnectionString"]));
            builder.Services.AddControllers();
            // configure strongly typed settings object
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


            // configure DI for application services
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IGachaPullService, GachaPullService>();
            builder.Services.AddScoped<IGameSafeService, GameSafeService>();
            builder.Services.AddScoped<ISpellService, SpellService>();
            builder.Services.AddScoped<ITraceService, TraceService>();
            builder.Services.AddScoped<IUserClickerUpgradeService, UserClickerUpgradeService>();
            builder.Services.AddScoped<IUserDeckService, UserDeckService>();
            builder.Services.AddScoped<IUserInventoryService, UserInventoryService>();
            builder.Services.AddScoped<IUserUpgradeService, UserUpgradeService>();
            builder.Services.AddScoped<IDeckSlotService, DeckSlotService>();


            
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMapster();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Backend API",
                    Description = "Backend API ASP .NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Internet Shop",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Internet Shop",
                        Url = new Uri("https://example.com/license")
                    },
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SpellLearningContext>();
                await context.Database.MigrateAsync();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(policy => policy
                .WithOrigins(
                    "http://localhost:5080"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();
            app.Run();
        }
    }
}