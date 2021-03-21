using Ardalis.GuardClauses;
using Domain.WarehouseContext.Events;
using Domain.WarehouseContext.Rules;
using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Events;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class Warehouse : Entity, IAggregateRoot
    {
        public WarehouseId BussinessWarehouseId { get; private set; }

        public string WarehouseName { get; private set; }

        public WarehouseCodeName WarehouseCodeName { get; private set; }

        private Warehouse(
            string warehouseName,
            WarehouseCodeName warehouseCodeName)
        {
            BussinessWarehouseId = new WarehouseId(Guid.NewGuid());
            SetWarehouseName(warehouseName);
            SetWarehouseCodeName(warehouseCodeName);

            this.AddDomainEvent(new CreateWarehouseEvent(this));
        }

        protected void SetWarehouseName(
            string warehouseName)
        {
            const string regexPatternWareHouseName = @"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$";

            Guard.Against.NullOrEmpty(warehouseName, nameof(warehouseName));
            Guard.Against.NullOrWhiteSpace(warehouseName, nameof(warehouseName));
            Guard.Against.InvalidFormat(warehouseName, nameof(warehouseName), regexPatternWareHouseName);

            WarehouseName = warehouseName;
        }

        protected void SetWarehouseCodeName(
            WarehouseCodeName warehouseCodeName)
        {
            WarehouseCodeName = warehouseCodeName;
        }

        public override string ToString()
        {
            return $"{ WarehouseName } with id { BussinessWarehouseId } and Codenae of { WarehouseCodeName }  ";
        }

        //Factories 
        public static Warehouse Create(
         string warehouseName,
         WarehouseCodeName codeName,
         IWarehouseCodeNameUniqueChecker iCodeNameCheckerUniqueness)
        {
            Guard.Against.InvalidInput(codeName, nameof(codeName), iCodeNameCheckerUniqueness.IsUnique);

            return new Warehouse(warehouseName, codeName);
        }

    }
}
