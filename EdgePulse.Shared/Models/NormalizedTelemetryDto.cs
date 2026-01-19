using System;
using System.Collections.Generic;
using System.Text;

namespace EdgePulse.Shared.Models
{
    public record NormalizedTelemetryDto(
        string DeviceId,
        DateTimeOffset ReceivedAtUtc,
        DateTimeOffset DeviceTimestampUtc,
        double TemperatureC,
        double Humidity,
        int BatteryPercent,
        int SignalDbm,
        DeviceHealthStatus Health,
        double Lat,
        double Lon
    );
}
