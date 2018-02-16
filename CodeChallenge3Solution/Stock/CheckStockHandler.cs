using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace Stock
{ 
    class CheckStockHandler : IHandleMessages<CheckStock>
    {
        static ILog log = LogManager.GetLogger<CheckStockHandler>();

        public async Task Handle(CheckStock message, IMessageHandlerContext context)
        {
           // log.Info($"Handling: PlaceOrder for Order Id: {message.OrderId}");
            log.Info($"Checking stock levels for Order Id: {message.OrderId}: {message.Product}");
            //return Task.CompletedTask;
            await StockLevel(message, context);
        }

        static Task StockLevel(CheckStock message, IMessageHandlerContext context)
        {
           // Console.WriteLine("Press enter to check Stock");
            //Console.WriteLine("Press any key to exit");

            var stockLevel = new StockLevel
            {
                OrderId = message.OrderId,
                Product = message.Product,
                InStock = true
            };

            return context.Publish(stockLevel);
           // await context.Send("Samples.StepByStep.Server", stockLevel)
           //     .ConfigureAwait(false);
            Console.WriteLine($"Sent a StockLevel message with id: {message.OrderId:N}");
            
        }
    }

  
}
