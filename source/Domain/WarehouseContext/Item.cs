using Domain.WarehouseContext.Events;
using Domain.WarehouseContext.Rules;
using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Models;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class Item : Entity
    {
        public ItemId ItemId { get; private set; }

        public ItemType ItemType { get; private set; }

        public ItemCodeName ItemCodeName { get; private set; }

        public string ItemName { get; private set; }

        public Item(
            ItemType ItemType,
            ItemCodeName ItemCodeName,
            string ItemName)
        {
            ItemId = new ItemId(Guid.NewGuid());
            SetItemType(ItemType);
            SetItemCodeName(ItemCodeName);
            SetItemName(ItemName);

            this.AddDomainEvent(new CreateItemEvent(this));
        }

        public Item(
            ItemId itemId,
            ItemType itemType,
            ItemCodeName itemCodeName,
            string ItemName)
        {
            SetItemType(itemType);
            SetItemCodeName(itemCodeName);
            SetItemName(ItemName);
        }

        public void SetItemType(
            ItemType itemType)
        {
            ItemType = itemType;
        }

        public void SetItemCodeName(
            ItemCodeName itemCodeName)
        {
            ItemCodeName = itemCodeName;
        }

        public void SetItemName(
            string itemName)
        {
            const string regexPatternItemName = @"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$";
            const int minimumItemNameLength = 1;
            const int maximumItemNameLength = 150;

            CheckRule(new NullOrEmptyStringChecker(nameof(itemName), itemName));
            CheckRule(new NullOrEmptyWhitespaceChecker(nameof(itemName), itemName));
            CheckRule(new InvalidFormatChecker(nameof(itemName), itemName, regexPatternItemName));
            CheckRule(new NullOrEmptyStringChecker(nameof(itemName), itemName));
            CheckRule(new OutOfRangeChecker(nameof(itemName), itemName.Length,
                minimumItemNameLength, maximumItemNameLength));
            ItemName = itemName;
        }

        public static Item Create(
            ItemType ItemType,
            ItemCodeName ItemCodeName,
            string ItemName,
            IItemCodeNameUniqueChecker iItemCodeNameUniqueChecker)
        {

            CheckRule(new ItemCodeNameUniqueChecker(iItemCodeNameUniqueChecker, ItemCodeName));
            return new Item(ItemType, ItemCodeName, ItemName);
        }
    }
}
