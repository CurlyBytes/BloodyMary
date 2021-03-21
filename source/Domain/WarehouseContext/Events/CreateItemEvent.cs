using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Events
{
    public class CreateItemEvent : DomainEvent
    {
        public Item Item { get; }

        public CreateItemEvent(Item item)
        {
            Item = item;
        }
    }
}
