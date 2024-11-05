using MassTransit;
using MassTransitApp.Messages;
using Newtonsoft.Json;

namespace ConsumerConsoleAppDouble
{
    public class ConsoleAppDoubleEventConsumer : IConsumer<ConsoleAppEvent>
    {
        //Подписываемся на такое же сообщение что и оригинальный подписчик ConsoleAppEvent
        public Task Consume(ConsumeContext<ConsoleAppEvent> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"EVENT_C2:" + jsonMessage);

            Task.Delay(30000);

            return Task.CompletedTask;
        }
    }
}