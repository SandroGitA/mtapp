using ConsumerConsoleAppCommand;
using MassTransit;

internal class Program
{
    private static void Main(string[] args)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.ReceiveEndpoint("car-endpoint-command", e =>
            {
                e.Consumer<ConsoleAppCommandConsumer>();
            });

            cfg.Host("localhost", "/", srv =>
            {
                srv.Username("guest");
                srv.Password("guest");
            });
        });

        bus.Start();

        Console.WriteLine("Start Console App Command...");
        Console.ReadLine();
    }
}