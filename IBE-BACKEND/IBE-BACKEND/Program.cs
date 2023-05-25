using IBE_BACKEND;
using IBE_BACKEND.Middlewares;
using IBE_BACKEND.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(loggingProvider =>
{
    loggingProvider.ClearProviders();
    loggingProvider.AddConsole();
    loggingProvider.AddDebug();
    loggingProvider.AddEventLog();
});


// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<GraphQLClientService>();
builder.Services.AddTransient<MinimumRateService>();

builder.Logging.AddConsole();


builder.Services.ConfigureDatabaseConnection(builder.Configuration)
    .GetConfigureLogger()
    .ConfigureSwagger()
    .ConfigureServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("AllowSpecificOrigins"); 

app.UseAuthorization();


app.MapControllers();

app.Run();
