namespace MassTransitApp.Messages
{
    public record ConsoleAppEvent(
        Guid Id,
        string App,
        DateTime CreatedAt);
}
