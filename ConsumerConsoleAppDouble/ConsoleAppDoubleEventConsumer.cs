using MassTransit;
using MassTransitApp.Messages;
using Newtonsoft.Json;

namespace ConsumerConsoleAppDouble
{
    public class ConsoleAppDoubleEventConsumer : IConsumer<ConsoleAppEvent>
    {
        public Task Consume(ConsumeContext<ConsoleAppEvent> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"EVENT_C2:" + jsonMessage);

            Task.Delay(3000);

            return Task.CompletedTask;
        }
    }
}