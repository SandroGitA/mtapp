namespace MassTransitApp.Messages
{
    public record HouseCreatedEvent(
        Guid Id,
        string Type,
        DateTime CreatedAt);
}
