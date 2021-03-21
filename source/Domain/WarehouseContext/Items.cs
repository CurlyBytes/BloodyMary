using Domain.WarehouseContext.ValueObjects;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseContext
{
    public class Items : Entity
    {

        public string ItemType { get; set; }


        public string ItemGroup { get; set; }

        public ItemCodeName ItemCodeName { get; set; }


        public string ItemName { get; set; }
    }
}
