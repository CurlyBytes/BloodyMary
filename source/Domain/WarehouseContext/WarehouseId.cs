using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class WarehouseId : TypedIdValueBase
    {
        public WarehouseId(Guid value) : base(value)
        {
        }
    }
}
