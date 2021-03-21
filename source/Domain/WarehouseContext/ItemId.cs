using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class ItemId : TypedIdValueBase
    {
        public ItemId(Guid value) : base(value)
        {
        }
    }
}
