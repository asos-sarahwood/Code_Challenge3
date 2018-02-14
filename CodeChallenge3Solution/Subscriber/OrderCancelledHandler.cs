using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    using NServiceBus;
    using NServiceBus.Logging;
    using Shared;
    class OrderCancelledHandler : 
        IHandleMessages<OrderCancelled>
    {
        static ILog log = LogManager.GetLogger<OrderCancelledHandler>();

        public Task Handle(OrderCancelled message, IMessageHandlerContext context)
        {
            log.Info($"Handling: OrderCancelled for Order Id: {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
