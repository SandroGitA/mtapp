using MassTransit;
using MassTransitApp.Messages;

namespace ConsumerWebApp.Consumers
{
    public class HouseEventConsumer : IConsumer<HouseCreatedEvent>
    {
        private readonly ILogger<HouseEventConsumer> _logger;

        public HouseEventConsumer(ILogger<HouseEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<HouseCreatedEvent> context)
        {
            var ctx = context.Message;

            _logger.LogInformation(
                $"EVENT: Здание с id {ctx.Id} с типом {ctx.Type} построен в {ctx.CreatedAt} с хоста {context.Host.MachineName}");

            Task.Delay(TimeSpan.FromSeconds(7));

            return Task.CompletedTask;
        }
    }
}
