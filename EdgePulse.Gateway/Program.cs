using EdgePulse.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapPost("/ingest", (DeviceTelemetryDto telemetry) =>
{
    Console.WriteLine($"Received telemetry from device {telemetry.DeviceId} at {telemetry.TimestampUtc}");
    return Results.Accepted(value: new {queued = true});
});
app.MapControllers();

app.Run();
