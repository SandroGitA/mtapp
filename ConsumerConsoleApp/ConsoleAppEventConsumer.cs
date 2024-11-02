using MassTransit;
using MassTransitApp.Messages;
using Newtonsoft.Json;

namespace ConsumerConsoleApp
{
    public class ConsoleAppEventConsumer : IConsumer<ConsoleAppEvent>
    {
        public Task Consume(ConsumeContext<ConsoleAppEvent> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"EVENT_C1:" + jsonMessage);

            Task.Delay(1000);

            return Task.CompletedTask;
        }
    }
}