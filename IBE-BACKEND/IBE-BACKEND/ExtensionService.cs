
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Middlewares;
using IBE_BACKEND.Models;
using IBE_BACKEND.Repository;
using IBE_BACKEND.Services;
using IBE_BACKEND.Services.ClientServices;
using IBE_BACKEND.Services.DatabaseServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IBE_BACKEND
{
    public static class ExtensionService
    {
        public static IServiceCollection ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<team03Context>(options =>
            options.UseNpgsql("Server=kdujan23-postgres.clvoh3vxfheb.ap-south-1.rds.amazonaws.com;Port=5432;Database=team03;User Id=team03;Password=jw8s01reuiF4") );
            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIs", Version = "v1" });

                // Configure Swagger to include the JWT bearer token in the "Authorize" button
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter the JWT token to authorize access."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });
            });
            return services;
        }

        public static IServiceCollection GetConfigureLogger(this IServiceCollection services)
        {
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties |
                Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
            });
            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuring DynamoDB client with AWS SSO authentication
            services.AddAWSService<IAmazonDynamoDB>(new AWSOptions
            {
                Profile = configuration["AWS:Profile"],
                Region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"])
            })
            //cors configuration
            .AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            })
            .AddScoped<IConfigurationDataService, ConfigurationDataService>()
            .AddScoped<IPromotionsService, PromotionsService>()
            .AddScoped<ISearchResultsService, SearchResultsService>()
            .AddScoped<ICheckoutService, CheckoutService>()
            .AddScoped<MinimumRateService>()
            .AddScoped<ExceptionHandlingMiddleware>()
            .AddScoped<IBookingService, BookingService>()
            .AddScoped<IRoomTypeRoomIdRepository, RoomTypeRoomIdRepository>()
            .AddScoped<IRoomAvailabilityService, RoomAvailablityService>()
            .AddScoped<IBookingStatusService, BookingStatusService>()
            .AddScoped<GraphQLClientService>()
            .AddScoped<HttpClient>()
            .AddScoped<SQSClientService>()
            .AddHostedService<SqsBackGroundService>();


            return services;
        }


    }
}
