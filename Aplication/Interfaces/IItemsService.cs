using InventoryApplication.Models;
using InventoryDomain.Commands;
using InventoryDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApplication.Interfaces
{
    public interface IItemsService
    {
        Item GetItem(string itemId);
        IEnumerable<Item> GetItems();
        void Create(ItemDTO itemForCreate);
        void Update(ItemDTO itemForUpdate);
        void Delete(ItemDTO itemForDelete);
        void SetStock(StockDTO stockDTO);
    }
}
