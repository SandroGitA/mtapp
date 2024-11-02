using MassTransit;
using MassTransitApp.MassTransit.Messages;

namespace MassTransitApp.MassTransit
{
    public class CarConsumer : IConsumer<CarCreatedEvent>
    {
        private readonly ILogger<CarConsumer> _logger;

        public CarConsumer(ILogger<CarConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CarCreatedEvent> context)
        {
            _logger.LogInformation(
                $"Создана машина {context.Message.Model} c id {context.Message.Id} в {context.Message.CreatedAt}");
            return Task.CompletedTask;
        }
    }
}
