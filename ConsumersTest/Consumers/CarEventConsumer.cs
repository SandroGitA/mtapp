using MassTransit;
using MassTransitApp.Messages;
using Newtonsoft.Json;

namespace ConsumerWebApp.Consumers
{
    public class CarEventConsumer : IConsumer<CarCreatedEvent>
    {
        private readonly ILogger<CarEventConsumer> _logger;

        public CarEventConsumer(ILogger<CarEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CarCreatedEvent> context)
        {
            var ctx = context.Message;

            //var jsonMessage = JsonConvert.SerializeObject(ctx);

            _logger.LogInformation(
                $"EVENT: Создана машина {ctx.Model} c id {ctx.Id} в {ctx.CreatedAt} с хоста {context.Host.MachineName}");

            return Task.CompletedTask;
        }
    }
}
