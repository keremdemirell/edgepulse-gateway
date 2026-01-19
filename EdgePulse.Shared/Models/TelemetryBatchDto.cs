using System;
using System.Collections.Generic;
using System.Text;

namespace EdgePulse.Shared.Models
{
    public record TelemetryBatchDto(
        string GatewayId,
        DateTimeOffset SentAtUtc,
        IReadOnlyList<NormalizedTelemetryDto> TelemetryItems
    );
}
