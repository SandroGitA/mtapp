namespace MassTransitApp.Messages
{
    public record CreateCarCommand(
        Guid Id,
        string Model,
        string Color,
        int Year,
        DateTime CreatedAt);
}
