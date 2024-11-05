using MassTransit;
using MassTransitApp.Messages;

namespace ConsumerWebApp.Consumers
{
    public class CarCommandConsumer : IConsumer<CreateCarCommand>
    {
        private readonly ILogger<CreateCarCommand> _logger;

        public CarCommandConsumer(ILogger<CreateCarCommand> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CreateCarCommand> context)
        {
            var ctx = context.Message;

            _logger.LogInformation(
                $"COMMAND: команда на создание {ctx.Model} c id {ctx.Id} с хоста {context.Host.MachineName}");

            return Task.CompletedTask;
        }
    }
}
