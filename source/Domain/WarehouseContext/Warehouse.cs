using Domain.WarehouseContext.Events;
using Domain.WarehouseContext.Rules;
using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Events;
using SharedKernel.Models;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.WarehouseContext
{
    public class Warehouse : Entity, IAggregateRoot
    {
        public WarehouseId BussinessWarehouseId { get; private set; }

        public string WarehouseName { get; private set; }

        public WarehouseCodeName WarehouseCodeName { get; private set; }

        private readonly List<Item> _item;
        private Warehouse(
            string warehouseName,
            WarehouseCodeName warehouseCodeName)
        {
            BussinessWarehouseId = new WarehouseId(Guid.NewGuid());
            SetWarehouseName(warehouseName);
            SetWarehouseCodeName(warehouseCodeName);
            _item = new List<Item>();
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

        public ItemId NewItem(
            ItemType ItemType,
            ItemCodeName ItemCodeName,
            string ItemName,
            IItemCodeNameUniqueChecker iItemCodeNameUniqueChecker)
        {
            Item item = Item.Create(ItemType, ItemCodeName, 
                ItemName, iItemCodeNameUniqueChecker);

            _item.Add(item);
            this.AddDomainEvent(new NewItemInWarehouseEvent(item.ItemId));

            return item.ItemId;
        }
        public void RemoveItem(ItemId itemId)
        {
            CheckRule(new WarehouseItemIsExist(_item, itemId));

            Item item = _item.FirstOrDefault(itemIndex => itemIndex.ItemId == itemId);
            _item.Remove(item);

            this.AddDomainEvent(new RemoveItemInWarehouseEvent(itemId));
        }

        public Item ModifyItem(ItemId itemId,Item itemModify)
        {
            CheckRule(new WarehouseItemIsExist(_item, itemId));

            Item item = _item.FirstOrDefault(itemIndex => itemIndex.ItemId == itemId);
            item.SetItemType(itemModify.ItemType);
            item.SetItemCodeName(itemModify.ItemCodeName);
            item.SetItemName(itemModify.ItemName);

            this.AddDomainEvent(new ModifyItemInWarehouseEvent(item.ItemType,
                item.ItemCodeName, item.ItemName));

            return item;
        }

    }
}
