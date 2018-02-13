using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Shared
{
    

    public class PlaceOrder : ICommand
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
    }

    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
