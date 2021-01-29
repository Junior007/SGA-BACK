using InventoryApplication.Models;
using InventoryDomain.Commands;
using InventoryDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApplication.Interfaces
{
    public interface IAlmacenesService
    {
        Almacen GetAlmacen(string almacenId);
        IEnumerable<Almacen> GetAlmacenes();
        void Create(AlmacenDTO almacenForCreate);
        void Update(AlmacenDTO almacenForUpdate);
        void Delete(AlmacenDTO almacenForDelete);
        void CreateUbicacion(UbicacionDTO ubicacionForCreate);
    }
}
