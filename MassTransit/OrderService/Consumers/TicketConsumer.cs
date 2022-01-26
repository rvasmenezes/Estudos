using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Model;
using System;
using System.Threading.Tasks;

namespace OrderConsumer.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {

        private readonly ILogger<TicketConsumer> _looger;

        public TicketConsumer(ILogger<TicketConsumer> looger)
        {
            _looger = looger;
        }

        public async Task Consume(ConsumeContext<Ticket> context)
        {
            await Console.Out.WriteLineAsync(context.Message.UserName);

            _looger.LogInformation($"Nova mensagem recebida: " + $"{context.Message.UserName} {context.Message.Location}");
        }
    }
}
