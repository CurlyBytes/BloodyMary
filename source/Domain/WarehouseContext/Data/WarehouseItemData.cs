using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Data
{
    public class WarehouseItemData
    {
        public WarehouseItemData(ItemId itemId)
        {
            ItemId = itemId;
        }

        public ItemId ItemId { get; }

    }
}
