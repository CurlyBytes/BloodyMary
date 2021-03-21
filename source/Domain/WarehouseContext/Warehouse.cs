using Ardalis.GuardClauses;
using Domain.WarehouseContext.Events;
using Domain.WarehouseContext.Rules;
using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Events;
using SharedKernel.Models;
using SharedKernel.Rules;
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
            const string regexPatternWarehouseName = @"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$";
            const int minimumWarehouseNameLength = 1;
            const int maximumWarehouseNameLength = 120;

            CheckRule(new NullOrEmptyStringChecker(nameof(warehouseName), warehouseName));
            CheckRule(new NullOrEmptyWhitespaceChecker(nameof(warehouseName), warehouseName));
            CheckRule(new InvalidFormatChecker(nameof(warehouseName), warehouseName, regexPatternWarehouseName));
            CheckRule(new NullOrEmptyStringChecker(nameof(warehouseName), warehouseName));
            CheckRule(new OutOfRangeChecker(nameof(warehouseName), warehouseName.Length,
                minimumWarehouseNameLength, maximumWarehouseNameLength));
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
       
            CheckRule(new WarehouseCodeNameUniqueChecker(iCodeNameCheckerUniqueness, codeName));
            return new Warehouse(warehouseName, codeName);
        }

    }
}
