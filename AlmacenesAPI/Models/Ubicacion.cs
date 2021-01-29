using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryAPI.Models
{
    public partial class Ubicacion
    {

        public string UbicacionId { get; set; }
        public string AlmacenId { get; set; }
        public string Descripcion { get; set; }
        public virtual Almacen Almacen { get; set; }

    }
}
