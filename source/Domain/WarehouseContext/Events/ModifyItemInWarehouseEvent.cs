using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Events
{
    public class ModifyItemInWarehouseEvent : DomainEvent
    {
        public ItemType ItemType { get; }
        public ItemCodeName ItemCodeName { get; }
        public String ItemName { get; }

        public ModifyItemInWarehouseEvent(ItemType itemType,
            ItemCodeName IitemCodeName,
            String itemName)
        {
            ItemType = itemType;
            ItemCodeName = IitemCodeName;
            ItemName = itemName;
        }
    }
}
