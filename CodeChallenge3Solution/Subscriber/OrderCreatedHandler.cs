using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace Subscriber
{
    using Shared;

    public class OrderCreatedHandler :
        IHandleMessages<OrderPlaced>
    {
         static ILog log = LogManager.GetLogger<OrderCreatedHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            log.Info($"Handling: OrderPlaced for Order Id: {message.OrderId}");
            return Task.CompletedTask;
        }
    }

    
}
