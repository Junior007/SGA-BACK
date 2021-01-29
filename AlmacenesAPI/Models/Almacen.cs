using System;
using System.Collections.Generic;


namespace InventoryAPI.Models
{
    public partial class Almacen
    {

        public string AlmacenId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
    }
}
