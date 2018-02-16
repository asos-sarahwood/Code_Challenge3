using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace Server
{
    public class CheckStockHandler : IHandleMessages<StockLevel>
    {
        static ILog log = LogManager.GetLogger<CheckStockHandler>();

        public Task Handle(StockLevel message, IMessageHandlerContext context)
        {
            IEvent orderStatus;

            if (message.InStock)
            {
                log.Info($"{message.Product} is in Stock. Order will now be placed");
                
                orderStatus = new OrderPlaced
                {
                    OrderId = message.OrderId
                };
                log.Info($"{orderStatus} event will now be published to Subscriber");


            }
            else
            {
                log.Info($"{message.Product} is not in Stock. Order will now be cancelled");
                
                orderStatus = new OrderCancelled
                {
                    OrderId = message.OrderId
                };
                log.Info($"{orderStatus} event will now be published to Subscriber");
            }

            return context.Publish(orderStatus);
        }
    }
}
