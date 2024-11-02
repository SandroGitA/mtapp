using ConsumerConsoleAppDouble;
using MassTransit;

public class Program
{
    private static void Main(string[] args)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.ReceiveEndpoint("console-app-endpoint", e =>
            {
                e.Consumer<ConsoleAppDoubleEventConsumer>();
            });

            cfg.Host("localhost", "/", srv =>
            {
                srv.Username("guest");
                srv.Password("guest");
            });
        });

        bus.Start();

        Console.WriteLine("Start Console App Double...");
        Console.ReadLine();
    }
}