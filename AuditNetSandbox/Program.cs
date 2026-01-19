using Audit.Core;

Console.WriteLine("Audit.NET sandbox starting...");

Configuration.DataProvider = new ConsoleDataProvider();
Configuration.CreationPolicy = EventCreationPolicy.InsertOnEnd;

var correlationId = Guid.NewGuid().ToString("N");

using (var scope = AuditScope.Create(new AuditScopeOptions
{
    EventType = "sandbox/event",
    ExtraFields = new Dictionary<string, object>
    {
        ["correlationId"] = correlationId,
        ["stage"] = "ingest",
        ["action"] = "accept",
        ["outcome"] = "success"
    }
}))
{
    scope.SetCustomField("messageId", "MSG-12345");
    scope.SetCustomField("bizMsgIdr", "BIZ-ABC-0001");

    Console.WriteLine("Simulating audited operation...");
    await Task.Delay(200);
}

Console.WriteLine("Audit.NET sandbox completed.");

internal sealed class ConsoleDataProvider : AuditDataProvider
{
    public override object InsertEvent(AuditEvent auditEvent)
    {
        var json = Configuration.JsonAdapter.Serialize(auditEvent);
        Console.WriteLine("--- Audit Event ---");
        Console.WriteLine(json);
        return Guid.NewGuid();
    }
}
