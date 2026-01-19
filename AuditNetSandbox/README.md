# Audit.NET Sandbox

This is a small console app meant for experimenting with Audit.NET and enriching events with custom fields.

## Run (requires .NET 8 SDK)

```bash
dotnet restore
dotnet run --project AuditNetSandbox/AuditNetSandbox.csproj
```

The app configures an in-memory console data provider and emits a single audit event.
