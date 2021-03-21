using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Events
{
    public class RemoveItemInWarehouseEvent : DomainEvent
    {
        public ItemId ItemId { get; }

        public RemoveItemInWarehouseEvent(ItemId itemId)
        {
            ItemId = itemId;
        }
    }
}
