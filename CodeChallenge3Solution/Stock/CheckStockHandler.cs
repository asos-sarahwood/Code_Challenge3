using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    using NServiceBus;
    using NServiceBus.Logging;

    class CheckStockHandler : IHandleMessages<CheckStock>
    {
        static ILog log = LogManager.GetLogger<CheckStockHandler>();

        public Task Handle(CheckStock message, IMessageHandlerContext context)
        {
            log.Info($"Handling: OrderCancelled for Order Id: {message.OrderId}");
            return Task.CompletedTask;
        }
    }

  
}
