namespace MassTransitApp.Messages
{
    public record CarCreatedEvent(
        Guid Id,
        string Model,
        DateTime CreatedAt);
}
