using MassTransit;
using MassTransitApp.Messages;
using Newtonsoft.Json;

namespace ConsumerConsoleAppCommand
{
    public class ConsoleAppCommandConsumer : IConsumer<CreateCarCommand>
    {
        public Task Consume(ConsumeContext<CreateCarCommand> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"COMMAND_C1:" + jsonMessage);

            Task.Delay(10000);

            return Task.CompletedTask;
        }
    }
}
