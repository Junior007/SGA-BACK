using Inventory.Application.Models;
using Inventory.Domain.Commands;
using Inventory.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
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
