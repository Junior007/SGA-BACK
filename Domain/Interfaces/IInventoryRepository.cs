using System;
using System.Collections.Generic;
using System.Text;
using InventoryDomain.Model;

namespace InventoryDomain.Interfaces
{
    public interface IInventoryRepository
    {
        int SaveChanges();
        IEnumerable<Almacen> GetAlmacenes();
        Almacen GetAlmacen(string almacenId);
        void CreateAlmacen(Almacen almacen);
        void UpdateAlmacen(Almacen almacen);
        void DeleteAlmacen(Almacen almacen);
        //
        IEnumerable<Item> GetItems();
        Item GetItem(string itemId);
        void CreateItem(Item item);
        void UpdateItem(Item item); 
        void DeleteItem(Item item);
        //
        void CreateUbicacion(Ubicacion ubicacion);

        //
        void CreateStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(Stock stock);
        Stock GetStock(Stock stock);
    }
}
