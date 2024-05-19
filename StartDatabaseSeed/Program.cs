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
builder.Services.AddScoped<StreamingAvailabilityApi>();
var app = builder.Build();
