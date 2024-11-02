using ConsumerWebApp.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    //Для закрепления возможности именовать очередь таким способом
    //x.AddConsumer<CarEventConsumer>().Endpoint(e =>
    //{
    //    e.Name = "car-renamed-endpoint";
    //});

    x.AddConsumer<CarEventConsumer>();
    x.AddConsumer<HouseEventConsumer>();    

    x.AddConsumer<CarCommandConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("car-endpoint", e =>
        {
            e.ConfigureConsumer<CarEventConsumer>(context);
        });

        cfg.ReceiveEndpoint("house-endpoint", e =>
        {
            e.ConfigureConsumer<HouseEventConsumer>(context);            
        });

        cfg.ReceiveEndpoint("car-endpoint-command", e =>
        {
            e.ConfigureConsumer<CarCommandConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
        cfg.UseRawJsonSerializer();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
//app.MapControllers();

app.Run();
