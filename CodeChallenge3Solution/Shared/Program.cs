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
        public Guid OrderId { get; set; }
        public string Product { get; set; }
    }

    public class CheckStock : ICommand
    {
        public Guid OrderId { get; set; }
        public string Product { get; set; }
        public bool InStock { get; set; }
    }

    public class StockLevel : IEvent
    {
        public Guid OrderId { get; set; }
        public string Product { get; set; }
        public bool InStock { get; set; }
    }

    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }
        public string Product { get; set; }
    }

    public class OrderCancelled : IEvent
    {
        public Guid OrderId { get; set; }
        public string Product { get; set; }

    }
}