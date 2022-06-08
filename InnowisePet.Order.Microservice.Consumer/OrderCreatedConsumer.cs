using InnowisePet.Order.Microservice.SharedModels;
using MassTransit;
using Newtonsoft.Json;

namespace InnowisePet.Order.Microservice.Consumer;

class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        string jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"Order has been created {jsonMessage}");
    }
}