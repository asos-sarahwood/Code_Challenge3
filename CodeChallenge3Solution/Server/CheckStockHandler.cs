using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    using NServiceBus;
    using NServiceBus.Logging;
    using Shared;
    public class CheckStockHandler : IHandleMessages<CheckStock>
    {
        static ILog log = LogManager.GetLogger<CheckStockHandler>();

        public Task Handle(CheckStock message, IMessageHandlerContext context)
        {
            IEvent orderStatus;

            if (message.InStock)
            {
                log.Info($"Order for Product:{message.Product} placed with id: {message.OrderId}");
                log.Info($"Publishing: OrderPlaced for Order Id: {message.OrderId}");

                orderStatus = new OrderPlaced
                {
                    OrderId = message.OrderId
                };
                
            }
            else
            {
                orderStatus = new OrderCancelled
                {
                    OrderId = message.OrderId
                };
            }

            return context.Publish(orderStatus);
        }
    }
}
