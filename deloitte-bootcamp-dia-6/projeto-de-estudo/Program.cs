using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Queue;
using StackExchange.Redis;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers / OpenAPI
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Service
builder.Services.AddSingleton<LoteService>();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSnakeCaseNamingConvention());


// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = builder.Configuration["Redis:ConnectionString"];
    return ConnectionMultiplexer.Connect(configuration);
});


// Queue Options
builder.Services.Configure<RedisQueueOptions>(
    builder.Configuration.GetSection("Redis"));


// Queue Producer
builder.Services.AddSingleton<ILoteQueueProducer, LoteQueueProducer>();


// Background Worker
builder.Services.AddHostedService<LoteQueueWorker>();


var app = builder.Build();


// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
