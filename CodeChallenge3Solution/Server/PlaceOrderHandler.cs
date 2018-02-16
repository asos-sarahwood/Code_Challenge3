using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using static ConfigureHandlerSettings;

namespace Server
{
    using System.Net.Http.Headers;
    using Shared;

    public class PlaceOrderHandler :
        IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)

        {

            log.Info($"Order for Product:{message.Product} placed with id: {message.OrderId}");
            //log.Info($"Publishing: OrderPlaced for Order Id: {message.OrderId}");
            await CheckStock(message, context);

        }

        static async Task CheckStock(PlaceOrder message, IMessageHandlerContext context)
        {
            //Console.WriteLine("Press enter to send a message");
            //Console.WriteLine("Press any key to exit");

            var checkStock = new CheckStock
            {
                OrderId = message.OrderId,
                Product = message.Product,
                //InStock = true
            };
            await context.Send("Stock", checkStock)
                .ConfigureAwait(false);
            Console.WriteLine($"Sent a CheckStock message with id: {message.OrderId:N}");
        }
    }
}
