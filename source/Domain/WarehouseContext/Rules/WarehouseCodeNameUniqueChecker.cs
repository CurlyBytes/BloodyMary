using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.Rules
{
    public class WarehouseCodeNameUniqueChecker : IBusinessRule
    {
        private readonly IWarehouseCodeNameUniqueChecker _iWarehouseCodeNameUniqueChecker;

        private readonly WarehouseCodeName _codeName;
        public WarehouseCodeNameUniqueChecker(
            IWarehouseCodeNameUniqueChecker iWarehouseCodeNameUniqueChecker,
            WarehouseCodeName codeName)
        {
            _iWarehouseCodeNameUniqueChecker = iWarehouseCodeNameUniqueChecker;
            _codeName = codeName;
        }
       
        public string Message => "WarehouseCodename with this is already exist.";

        public bool IsBroken()
        {
            return !_iWarehouseCodeNameUniqueChecker.IsUnique(_codeName);
        }
    }
}
