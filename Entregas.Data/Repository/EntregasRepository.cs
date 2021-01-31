using System;
using System.Collections.Generic;
using System.Text;
using Entregas.Data.Context;
using Entregas.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entregas.Data.Interface;

namespace Entregas.Data.Repository
{
    public class EntregasRepository : IEntregasRepository
    {
        private readonly EntregasDBContext _ctx;
        public EntregasRepository(EntregasDBContext ctx)
        {
            _ctx = ctx;
        }

        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }
        //
        /*public void CreateAlmacen(Almacen almacen)
        {
            _ctx.Almacenes.Add(almacen);
        }

        public void DeleteAlmacen(Almacen almacen)
        {
            _ctx.Almacenes.Remove(almacen);
        }


        public void UpdateAlmacen(Almacen almacen)
        {
            _ctx.Almacenes.Update(almacen);
        }

        Almacen IInventoryRepository.GetAlmacen(string almacenId)
        {//.Where(almacen => almacen.AlmacenId == almacenId).FirstOrDefault()
            return _ctx.Almacenes.Include(a => a.Ubicaciones).FirstOrDefault(a=>a.AlmacenId==almacenId);

        }

        IEnumerable<Almacen> IInventoryRepository.GetAlmacenes()
        {
            return _ctx.Almacenes;
        }
        //
        public IEnumerable<Item> GetItems()
        {
            return _ctx.Items;
        }

        public Item GetItem(string itemId)
        {
            return _ctx.Items.Find(itemId);
        }

        public void CreateItem(Item item)
        {
            _ctx.Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            _ctx.Items.Update(item);
        }

        public void DeleteItem(Item item)
        {
            _ctx.Items.Remove(item);
        }
        //
        public void CreateUbicacion(Ubicacion ubicacion)
        {
            _ctx.Ubicaciones.Add(ubicacion);
        }

        public void CreateStock(Stock stock)
        {
            _ctx.Stocks.Add(stock);
        }

        public void UpdateStock(Stock stock)
        {
            _ctx.Stocks.Update(stock);
        }

        public void DeleteStock(Stock stock)
        {
            _ctx.Stocks.Remove(stock);
        }

        public Stock GetStock(Stock stock)
        {
            return _ctx.Stocks.FirstOrDefault(s => s.ItemId == stock.ItemId && s.UbicacionId == stock.UbicacionId && s.AlmacenId == stock.AlmacenId );
        }*/
    }
}
