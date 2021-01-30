using Inventory.Application.Models;
using Inventory.Domain.Commands;
using Inventory.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
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
