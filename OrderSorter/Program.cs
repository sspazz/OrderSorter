using Core.Abstractions.Repository;
using Core.Abstractions.Services;
using Core.DTOs;
using Core.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Repository;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Generic
builder.Services.AddCors();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


// Repositories
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IDeliveryPersonRepository, DeliveryPersonRepository>();
builder.Services.AddTransient<IHistoricalDataRepository, HistoricalDataRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IDailyRouteRepository, DailyRouteRepository>();

// Business
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IHistoricalDataService, HistoricalDataService>();
builder.Services.AddTransient<IDeliveryPersonService, DeliveryPersonService>();
builder.Services.AddTransient<IDailyRouteService, DailyRouteService>();
builder.Services.AddTransient<IRouteCalculatorService, RouteCalculatorService>();

// EF
string connectionString = builder.Configuration.GetConnectionString("SQLServer");
builder.Services.AddDbContext<IOrderSorterContext, OrderSorterContext>(options => options.UseSqlServer(connectionString));

// Configure Logger
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.MinimumLevel.Warning()/*.WriteTo.MSSqlServer(
                connectionString: connectionString,
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = "ordersortlog",
                    SchemaName = "dbo",
                    AutoCreateSqlTable = true
                },
                sinkOptionsSection: ctx.Configuration.GetSection("Serilog:SinkOptions"),
                appConfiguration: ctx.Configuration,
                columnOptionsSection: ctx.Configuration.GetSection("Serilog:ColumnOptions"))*/
    .WriteTo.EventLog("Order Sorter", manageEventSource: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<IOrderSorterContext>();
    var migrations = context.Database.GetPendingMigrations();
    if (migrations.Any())
    {
        context.Database.Migrate();
    }
}

app.UseCors(options =>
{
    options.WithOrigins("*");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
