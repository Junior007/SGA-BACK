using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryDomain.Model
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Stocks = new HashSet<Stock>();
        }

        public string UbicacionId { get; set; }
        public string AlmacenId { get; set; }
        public string Descripcion { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
