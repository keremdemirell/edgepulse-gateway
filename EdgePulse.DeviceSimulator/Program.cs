// See https://aka.ms/new-console-template for more information
using EdgePulse.Shared.Models;
using System.Net.Http.Json;

const int deviceCount = 10;
const int mintIntervalMs = 2000;
const int maxIntervalMs = 5000;
const string gatewayUrl = "http://localhost:5041";

var http = new HttpClient();
var tasks = new List<Task>(capacity: deviceCount);

for (int i = 0; i < deviceCount; i++)
{
    int deviceIndex = i + 1;
    var random = new Random();
    tasks.Add(Task.Run(async () =>
    {
        while (true)
        {
            DeviceTelemetryDto telemetryDto = new DeviceTelemetryDto(
                DeviceId: $"TRK-{deviceIndex}",
                TimestampUtc: DateTimeOffset.UtcNow,
                TemperatureC: Math.Round(15 + random.NextDouble() * 20, 2),
                Humidity: Math.Round(30 + random.NextDouble() * 50, 2),
                BatteryPercent: Math.Max(0, random.Next(60, 101) - random.Next(0, 4)),
                SignalDbm: random.Next(-120, -80),
                Lat: 36.8219 + (random.NextDouble() - 0.5) * 0.01,
                Lon: -1.2921 + (random.NextDouble() - 0.5) * 0.01
                );

            try 
            {
                var resp = await http.PostAsJsonAsync($"{gatewayUrl}/ingest", telemetryDto);
                Console.WriteLine(resp);
                Console.WriteLine($"Sent telemetry from device {telemetryDto.DeviceId} at {telemetryDto.TimestampUtc}");
                Console.WriteLine($"\n{telemetryDto.DeviceId} -> {(int) resp.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending telemetry from device {telemetryDto.DeviceId}: {ex.Message}");
            }

            await Task.Delay(random.Next(mintIntervalMs, maxIntervalMs));
        }
    }));
}

await Task.WhenAll(tasks);