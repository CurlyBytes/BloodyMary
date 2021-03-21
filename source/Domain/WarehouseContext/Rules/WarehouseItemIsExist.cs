using Domain.WarehouseContext.Data;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.WarehouseContext.Rules
{
    public class WarehouseItemIsExist : IBusinessRule
    {
        private readonly List<Item> _item;
        private readonly ItemId _itemId;

        public WarehouseItemIsExist(List<Item> item, ItemId itemId)
        {
            _item = item;
            _itemId = itemId;
        }

        public bool IsBroken() => _item.Any(itemIndex => itemIndex.ItemId == _itemId);

        public string Message => "Order must have at least one product";
    }
}
