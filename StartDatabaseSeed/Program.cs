using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StartDatabaseSeed.Data;
using StartDatabaseSeed.Services;

var builder = Host.CreateApplicationBuilder();
string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(mySqlConnection,
    ServerVersion.AutoDetect(mySqlConnection));
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<StreamingAvailabilityApi>();
builder.Services.AddScoped<SeedDbService>();
var app = builder.Build();
var seed = builder.Services.BuildServiceProvider().GetRequiredService<SeedDbService>();
await seed.SeedStreamings();
await seed.SeedGenres();
await seed.SeedItems();