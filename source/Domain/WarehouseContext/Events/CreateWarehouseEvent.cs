using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Events
{
    public class CreateWarehouseEvent : DomainEvent
    {
        public Warehouse Warehouse { get; }

        public CreateWarehouseEvent(Warehouse warehouse)
        {
            Warehouse = warehouse;
        }
    }
}
