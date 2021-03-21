using SharedKernel.Models;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext.ValueObjects
{
    public class ItemCodeName : ValueObject
    {
        public string Name { get; private set; }

        public ItemCodeName(string itemCodeName)
        {
            const string regexPattern = @"\b\w*[-']\w*\b";
            const int minimumItemCodeNameLength = 1;
            const int maximumItemCodeNameLength = 25;

            CheckRule(new NullOrEmptyStringChecker(nameof(itemCodeName), itemCodeName));
            CheckRule(new NullOrEmptyWhitespaceChecker(nameof(itemCodeName), itemCodeName));
            CheckRule(new InvalidFormatChecker(nameof(itemCodeName), itemCodeName, regexPattern));
            CheckRule(new NullOrEmptyStringChecker(nameof(itemCodeName), itemCodeName));
            CheckRule(new OutOfRangeChecker(nameof(itemCodeName), itemCodeName.Length,
                minimumItemCodeNameLength, maximumItemCodeNameLength));

            Name = itemCodeName;
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
