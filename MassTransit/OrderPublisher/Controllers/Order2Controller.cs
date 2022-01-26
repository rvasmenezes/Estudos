using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System;
using System.Threading.Tasks;

namespace OrderPublisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Order2Controller : ControllerBase
    {

        private readonly IBus _bus;

        public Order2Controller(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {

            if (ticket != null)
            {
                ticket.Booked = DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/orderTicketQueue");

                var endPoint = await _bus.GetSendEndpoint(uri);

                await endPoint.Send(ticket);

                return Ok();
            }

            return BadRequest();

        }
    }

    public class Teste
    {
        public string Nome { get; set; }
    }
}
