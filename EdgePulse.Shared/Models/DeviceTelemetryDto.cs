using System;
using System.Collections.Generic;
using System.Text;

namespace EdgePulse.Shared.Models
{
    public record DeviceTelemetryDto(
        string DeviceId,
        DateTimeOffset TimestampUtc,
        double TemperatureC,
        double Humidity,
        int BatteryPercent,
        int SignalDbm,
        double Lat,
        double Lon
    );
}
