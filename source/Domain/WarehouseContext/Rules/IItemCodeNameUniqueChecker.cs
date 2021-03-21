using Domain.WarehouseContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Rules
{
    public interface IItemCodeNameUniqueChecker
    {
        bool IsUnique(ItemCodeName itemCodeName);
    }
}
