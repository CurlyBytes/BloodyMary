using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Rules
{
    public class ItemCodeNameUniqueChecker : IBusinessRule
    {
        private readonly IItemCodeNameUniqueChecker _iItemCodeNameUniqueChecker;

        private readonly ItemCodeName _itemCodeName;
        public ItemCodeNameUniqueChecker(
            IItemCodeNameUniqueChecker iItemCodeNameUniqueChecker,
            ItemCodeName codeName)
        {
            _iItemCodeNameUniqueChecker = iItemCodeNameUniqueChecker;
            _itemCodeName = codeName;
        }
       
        public string Message => "ItemCodeName with this is already exist.";

        public bool IsBroken()
        {
            return !_iItemCodeNameUniqueChecker.IsUnique(_itemCodeName);
        }
    }
}
