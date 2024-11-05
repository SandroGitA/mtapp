using ConsumerConsoleApp;
using MassTransit;
using MassTransitApp.Messages;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitApp.Controllers
{
    [Controller]
    public class TransitController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public TransitController(
            IPublishEndpoint publishEndpoint,
            ISendEndpointProvider sendEndpointProvider)
        {
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost("create-console-app-event")]
        public IResult CreateConsoleAppEvent()
        {
            //Добавляем искуственную генерацию сообщений путем цикла в консоль
            for (int i = 0; i < 3600; i++)
            {
                _publishEndpoint.Publish(new ConsoleAppEvent(
                Guid.NewGuid(),
                $"EVENT #{i}",
                DateTime.UtcNow));
            }

            return Results.Ok();
        }

        [HttpPost("create-car-event")]
        public async Task<IResult> CreateCarEvent()
        {
            await _publishEndpoint.Publish(new CarCreatedEvent(
                Guid.NewGuid(),
                "Audi",
                DateTime.UtcNow));

            return Results.Ok();
        }

        [HttpPost("create-house-event")]
        public IResult CreateHouseEvent()
        {
            _publishEndpoint.Publish(new HouseCreatedEvent(
            Guid.NewGuid(),
            $"Новостройка",
            DateTime.UtcNow));

            return Results.Ok();
        }

        [HttpPost("create-car-command")]
        public async Task<IResult> CreateCarCommand()
        {
            string url = "exchange:RenameEndpointTest";
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(url));

            for (int i = 0; i < 100; i++)
            {
                await endpoint.Send(new CreateCarCommand(
                   Guid.NewGuid(),
                   $"Audi #{i}",                  
                   DateTime.UtcNow));
            }

            //await Task.Delay(30000);

            return Results.Ok();
        }
    }
}
