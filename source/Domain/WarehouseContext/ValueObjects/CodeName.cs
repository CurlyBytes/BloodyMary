using Ardalis.GuardClauses;
using SharedKernel.Models;
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
            string regexPattern = @"\b\w*[-']\w*\b";
            Guard.Against.NullOrEmpty(warehouseCodeName, nameof(warehouseCodeName));
            Guard.Against.NullOrWhiteSpace(warehouseCodeName, nameof(warehouseCodeName));
            Guard.Against.InvalidFormat(warehouseCodeName, nameof(warehouseCodeName), regexPattern);
            Guard.Against.InvalidInput(warehouseCodeName, nameof(warehouseCodeName), CannotMoreThanTenCharacter);

            Name = warehouseCodeName ?? throw new ArgumentNullException(nameof(warehouseCodeName));
        }

        public bool CannotMoreThanTenCharacter(string codename) => codename.Length <= 10;

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
