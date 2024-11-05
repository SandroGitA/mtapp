namespace MassTransitApp.Messages
{
    public record CreateCarCommand(
        Guid Id,
        string Model,
        DateTime CreatedAt);
}
