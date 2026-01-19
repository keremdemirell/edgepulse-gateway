# EdgePulse Gateway

**EdgePulse Gateway** is a minimal, async-first IoT simulation project built with **.NET** that demonstrates how high-frequency device telemetry can be ingested through a **non-blocking edge gateway**.

The project consists of:
- A **Device Simulator** that runs multiple virtual IoT devices in parallel and continuously sends telemetry
- An **Edge Gateway** that accepts incoming telemetry asynchronously and immediately responds with `202 Accepted`
- A shared contract layer for clean data transfer between components

### Key Concepts Demonstrated
- Async / concurrent device simulation
- Non-blocking HTTP ingestion (`async/await`)
- Edge-style telemetry gateway design
- Clean separation of simulator, gateway, and shared models

### Tech Stack
- C# / .NET
- ASP.NET Core Web API
- Task-based concurrency
- HTTP + JSON contracts

This project is intentionally kept small and focused to highlight **architecture and async thinking** rather than UI or infrastructure.

> Future extensions: batching, background workers, device health tracking, cloud forwarding.
