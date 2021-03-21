using SharedKernel.Models;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.ValueObjects
{
    public class ItemType : ValueObject
    {
        public string Name { get; private set; }

        public ItemType(string itemType)
        {
            const string regexPattern = @"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$";
            const int minimumWarehouseCodeNameLength = 1;
            const int maximumWarehouseCodeNameLength = 40;

            CheckRule(new NullOrEmptyStringChecker(nameof(itemType), itemType));
            CheckRule(new NullOrEmptyWhitespaceChecker(nameof(itemType), itemType));
            CheckRule(new InvalidFormatChecker(nameof(itemType), itemType, regexPattern));
            CheckRule(new NullOrEmptyStringChecker(nameof(itemType), itemType));
            CheckRule(new OutOfRangeChecker(nameof(itemType), itemType.Length,
                minimumWarehouseCodeNameLength, maximumWarehouseCodeNameLength));

            Name = itemType;
        }

        public override string ToString()
        {
            return Name.ToUpperInvariant();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name.ToLower().Trim();
        }
    }
}
