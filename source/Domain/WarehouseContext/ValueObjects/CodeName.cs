using Ardalis.GuardClauses;
using SharedKernel.Models;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.ValueObjects
{
    public class WarehouseCodeName : ValueObject
    {
        public string Name { get; private set; }

        public WarehouseCodeName(string warehouseCodeName)
        {
            const string regexPattern = @"\b\w*[-']\w*\b";
            const int minimumWarehouseCodeNameLength = 1;
            const int maximumWarehouseCodeNameLength = 25;

            CheckRule(new NullOrEmptyStringChecker(nameof(warehouseCodeName), warehouseCodeName));
            CheckRule(new NullOrEmptyWhitespaceChecker(nameof(warehouseCodeName), warehouseCodeName));
            CheckRule(new InvalidFormatChecker(nameof(warehouseCodeName), warehouseCodeName, regexPattern));
            CheckRule(new NullOrEmptyStringChecker(nameof(warehouseCodeName), warehouseCodeName));
            CheckRule(new OutOfRangeChecker(nameof(warehouseCodeName), warehouseCodeName.Length,
                minimumWarehouseCodeNameLength, maximumWarehouseCodeNameLength));

            Name = warehouseCodeName;
        }

        public override string ToString()
        {
            return Name;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name.ToUpper().Trim();
        }
    }
}
