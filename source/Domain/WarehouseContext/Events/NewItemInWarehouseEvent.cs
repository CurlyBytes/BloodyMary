using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Events
{
    public class NewItemInWarehouseEvent : DomainEvent
    {
        public ItemId ItemId { get; }

        public NewItemInWarehouseEvent(ItemId itemId)
        {
            ItemId = itemId;
        }
    }
}
